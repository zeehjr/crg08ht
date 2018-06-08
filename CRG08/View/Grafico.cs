using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Xml.Linq;
using CRG08.Dao;
using CRG08.Util;
using CRG08.VO;
using Cursor = System.Windows.Forms.Cursor;

namespace CRG08.View
{
    public partial class Grafico : Form
    {
        public Grafico()
        {
            InitializeComponent();
        }

        private VO.Ciclos ciclo;
        private CoresGrafico _cores = new CoresGrafico();
        string[] Legendas = new string[5];
        private List<VO.LeiturasTrat> listaLeiturasT;
        private List<VO.LeiturasCiclo> listaLeituraC;
        private int opcao = 0;
        private List<ListaCiclosTratGrafico> lista;
        private Font backupFont;


        public Grafico(VO.Ciclos ciclo)
        {
            InitializeComponent();
            this.ciclo = ciclo;
            var listaLeiturasCiclo = LeiturasCicloDAO.ListaLeiturasCiclos(ciclo);
            var listaLeiturasTrat = LeiturasTratDAO.ListaLeiturasTratamento(ciclo);
            var config = ConfiguracaoDAO.PegarConfigRelatorio();
            lista = RelTratamento.populaTratamento(ciclo, listaLeiturasCiclo, listaLeiturasTrat, config);
        }


        public Grafico(VO.Ciclos ciclo, int opcao, List<ListaCiclosTratGrafico> listaCiclosTrat)
        {
            InitializeComponent();
            this.ciclo = ciclo;
            this.opcao = opcao;
            CheckForIllegalCrossThreadCalls = false;
            lista = listaCiclosTrat;
            //CriaImagem();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Produtos_Click(object sender, EventArgs e)
        {
            List<ProdutoCiclo> listaProdutos = ProdutoCicloDAO.listaProdutosCiclo(ciclo);
            DetalhesProdutosCiclo produtos = new DetalhesProdutosCiclo(listaProdutos);
            produtos.ShowDialog(this);
        }

        private void Cores_Click(object sender, EventArgs e)
        {
            var configGrafico = new ConfigGrafico();
            configGrafico.ShowDialog();
        }

        private string ProdutosToString(VO.Ciclos ciclo)
        {
            var listaProdutos = ProdutoCicloDAO.listaProdutosCiclo(ciclo);
            var strProdutos = string.Empty;

            if (listaProdutos.Count > 1)
            {
                strProdutos = "Produtos: ";
                foreach (var item in listaProdutos)
                {
                    if (strProdutos != "Produtos:")
                    {
                        strProdutos += ", ";
                    }
                    strProdutos += item.produto.descricao + " com " + item.volume + " " + item.unidade.unidade;
                }
            }
            else if (listaProdutos.Count == 1)
            {
                var item = listaProdutos.First();
                strProdutos = "Produto: " + item.produto.descricao + " com " + item.volume + " " +
                              item.unidade.unidade;
            }
            return strProdutos;
        }

        private void Grafico_Load(object sender, EventArgs e)
        {
            if (opcao != 0)
            {
                string[] cores = ObterCores();
                Legendas = ObterLegendas();
                _cores.T1RGB = cores[0];
                _cores.T2RGB = cores[1];
                _cores.T3RGB = cores[2];
                _cores.T4RGB = cores[3];
                _cores.CARGB = cores[4];

                PreencherCores();
                if (opcao == 1) PreencherChartCiclo();
                else PreencherChartTratamento();
                Controlador.Text = "Controlador nº " + ciclo.crg + " com " + ciclo.nl + " leituras(NTrat: " +
                                   ciclo.nTrat + ")";
                Datas.Text = ciclo.dataInicio + " - " + ciclo.dataFim;
                if (ciclo.NLIniTrat > 0)
                {
                    DadosTrat.Text = "Inicio do tratamento na leitura " + ciclo.NLIniTrat + " - " + ciclo.dataIniTrat;
                    tempoTrat.Text = "Tempo do Tratamento (tt): " + ciclo.tempoTrat + " minuto(s)";
                }
                else
                {
                    DadosTrat.Text = "Não realizou o tratamento";
                    tempoTrat.Text = "";
                }
                Descricao.Text = "Descrição: " + ciclo.descricao;
                Responsavel.Text = "Responsável Técnico: " + ciclo.responsavel;
                Operador.Text = "Operador: " + ciclo.operador;
                lblProdutos.Text = ProdutosToString(ciclo);
                chkT1.Focus();
                DoMouseClick();
                SalvaGrafico2();
                this.Close();
            }
            else
            {
                string[] cores = ObterCores();
                Legendas = ObterLegendas();
                _cores.T1RGB = cores[0];
                _cores.T2RGB = cores[1];
                _cores.T3RGB = cores[2];
                _cores.T4RGB = cores[3];
                _cores.CARGB = cores[4];

                PreencherCores();
                PreencherChartCiclo();
                Controlador.Text = "Controlador nº " + ciclo.crg + " com " + ciclo.nl + " leituras(NTrat: " +
                                   ciclo.nTrat + ")";
                Datas.Text = ciclo.dataInicio + " - " + ciclo.dataFim;
                if (ciclo.nlt == ciclo.tempoTrat)
                {
                    DadosTrat.Text = "Inicio do tratamento na leitura " + ciclo.NLIniTrat + " - " + ciclo.dataIniTrat;
                    tempoTrat.Text = "Tempo do Tratamento (tt): " + ciclo.tempoTrat + " minuto(s)";
                }
                else
                {
                    DadosTrat.Text = "Não realizou o tratamento";
                    tempoTrat.Text = "";
                }
                Descricao.Text = "Descrição: " + ciclo.descricao;
                Responsavel.Text = "Responsável Técnico: " + ciclo.responsavel;
                Operador.Text = "Operador: " + ciclo.operador;



                lblProdutos.Text = ProdutosToString(ciclo);

                chkT1.Focus();
            }

        }

        private void PreencherChartCiclo()
        {
            try
            {
                listaLeituraC = LeiturasCicloDAO.ListaLeiturasCiclos(ciclo);
                listaLeiturasT = LeiturasTratDAO.ListaLeiturasTratamento(ciclo);

                chart1.Series.Clear();
                chart1.ChartAreas[0].AxisX.Interval = 0;
                chart1.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
                chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                

                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                if (this.ciclo.tipoCRG == 100)
                {
                    chart1.ChartAreas[0].AxisY.Maximum = 100;
                }
                else if (this.ciclo.tipoCRG == 150)
                {
                    chart1.ChartAreas[0].AxisY.Maximum = 150;
                }
                chart1.ChartAreas[0].AxisX.Maximum = listaLeituraC.Count;

                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas[0].AxisX.LineColor = Color.Black;
                chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
                chart1.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.Red;

                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas[0].AxisY.LineColor = Color.Black;
                chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
                chart1.ChartAreas[0].AxisY.MinorTickMark.Size = (float)0.5;
                chart1.ChartAreas[0].AxisY.MajorTickMark.Size = 1;
                chart1.ChartAreas[0].AxisX.MinorTickMark.Size = (float)0.5;
                chart1.ChartAreas[0].AxisX.MajorTickMark.Size = 1;
                chart1.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.Red;

                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

                chart1.ChartAreas[0].CursorX.AutoScroll = true;
                chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

                chart1.ChartAreas[0].CursorY.AutoScroll = true;
                chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                chart1.ChartAreas[0].CursorX.LineColor = Color.Red;
                chart1.ChartAreas[0].CursorY.LineColor = Color.Red;

                chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8);
                chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 8);
                chart1.ChartAreas[0].AxisX.Title = "NL";
                chart1.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Far;
                chart1.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 8, FontStyle.Bold);
                chart1.ChartAreas[0].AxisY.Title = "ºC";
                chart1.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Far;
                chart1.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 8, FontStyle.Bold);

                Series serieT1 = new Series(Legendas[0], listaLeituraC.Count);
                serieT1.ChartType = SeriesChartType.Spline;
                for (int i = 0; i < listaLeituraC.Count; i++)
                {
                    serieT1.Points.AddXY(i + 1, listaLeituraC[i].T1);
                }
                string[] split = _cores.T1RGB.Split(',');
                serieT1.Color = Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
                chart1.Series.Add(serieT1);
                chart1.Series[Legendas[0]].Enabled = true;
                chart1.Series[Legendas[0]].IsVisibleInLegend = true;

                Series serieT2 = new Series(Legendas[1], listaLeituraC.Count);
                serieT2.ChartType = SeriesChartType.Spline;
                for (int i = 0; i < listaLeituraC.Count; i++)
                {
                    serieT2.Points.AddXY(i + 1, listaLeituraC[i].T2);
                }
                split = _cores.T2RGB.Split(',');
                serieT2.Color = Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
                chart1.Series.Add(serieT2);
                chart1.Series[Legendas[1]].Enabled = true;
                chart1.Series[Legendas[1]].IsVisibleInLegend = true;

                Series serieT3 = new Series(Legendas[2], listaLeituraC.Count);
                serieT3.ChartType = SeriesChartType.Spline;
                for (int i = 0; i < listaLeituraC.Count; i++)
                {
                    serieT3.Points.AddXY(i + 1, listaLeituraC[i].T3);
                }
                split = _cores.T3RGB.Split(',');
                serieT3.Color = Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
                chart1.Series.Add(serieT3);
                chart1.Series[Legendas[2]].Enabled = true;
                chart1.Series[Legendas[2]].IsVisibleInLegend = true;

                Series serieT4 = new Series(Legendas[3], listaLeituraC.Count);
                serieT4.ChartType = SeriesChartType.Spline;
                for (int i = 0; i < listaLeituraC.Count; i++)
                {
                    serieT4.Points.AddXY(i + 1, listaLeituraC[i].T4);
                }
                split = _cores.T4RGB.Split(',');
                serieT4.Color = Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
                chart1.Series.Add(serieT4);
                chart1.Series[Legendas[3]].Enabled = true;
                chart1.Series[Legendas[3]].IsVisibleInLegend = true;

                if (ciclo.nlt == ciclo.tempoTrat)
                {

                    Series inicioFito = new Series("Inicio Tratamento",
                        Convert.ToInt32(chart1.ChartAreas[0].AxisY.Maximum));
                    inicioFito.ChartType = SeriesChartType.Line;
                    for (int i = 0; i < chart1.ChartAreas[0].AxisY.Maximum; i++)
                    {
                        inicioFito.Points.AddXY(ciclo.NLIniTrat, i);
                    }
                    inicioFito.Color = Color.DarkGreen;
                    inicioFito.BorderWidth = 2;
                    chart1.Series.Add(inicioFito);
                    chart1.Series["Inicio Tratamento"].IsVisibleInLegend = true;
                }
                else
                {
                    TipoGrafico.Enabled = false;
                }

                int pontos = listaLeituraC.Count / 5;

                Series serieCA = new Series(Legendas[4], 1);
                serieCA.ChartType = SeriesChartType.Spline;
                switch (ciclo.sensor)
                {
                    case 0:
                        for (int i = 0; i < listaLeituraC.Count; i++)
                        {
                            serieCA.Points.AddXY(i + 1, listaLeituraC[i].T2);
                        }
                        break;
                    case 16:
                        for (int i = 0; i < listaLeituraC.Count; i++)
                        {
                            serieCA.Points.AddXY(i + 1, listaLeituraC[i].T3);
                        }
                        break;
                    case 32:
                        for (int i = 0; i < listaLeituraC.Count; i++)
                        {
                            serieCA.Points.AddXY(i + 1, listaLeituraC[i].T4);
                        }
                        break;
                    case 48:
                        for (int i = 0; i < listaLeituraC.Count; i++)
                        {
                            serieCA.Points.AddXY(i + 1, ((listaLeituraC[i].T2 + listaLeituraC[i].T3 + listaLeituraC[i].T4) / 3));
                        }
                        break;
                    case 64:
                        for (int i = 0; i < listaLeituraC.Count; i++)
                        {
                            serieCA.Points.AddXY(i + 1, listaLeituraC[i].T4);
                        }
                        break;
                    case 80:
                        for (int i = 0; i < listaLeituraC.Count; i++)
                        {
                            serieCA.Points.AddXY(i + 1, listaLeituraC[i].T4);
                        }
                        break;
                }

                split = _cores.CARGB.Split(',');
                serieCA.Color = Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
                chart1.Series.Add(serieCA);
                chart1.Series[Legendas[4]].Enabled = true;
                chart1.Series[Legendas[4]].IsVisibleInLegend = true;

                Series serieTempTrat = new Series("" + ciclo.temperaturaTrat + "ºC(Tratamento)", 1);
                serieTempTrat.ChartType = SeriesChartType.Spline;
                for (int i = 0; i <= listaLeituraC.Count; i++)
                {
                    serieTempTrat.Points.AddXY(i, ciclo.temperaturaTrat);
                }
                serieTempTrat.Color = Color.DarkOrange;
                chart1.Series.Add(serieTempTrat);
                chart1.Series["" + ciclo.temperaturaTrat + "ºC(Tratamento)"].Enabled = true;

                Series serieTControl = new Series("" + ciclo.temperaturaControle + "ºC(Controle)", 1);
                serieTControl.ChartType = SeriesChartType.Spline;
                for (int i = 0; i <= listaLeituraC.Count; i++)
                {
                    serieTControl.Points.AddXY(i, ciclo.temperaturaControle);
                }
                serieTControl.Color = Color.Purple;
                chart1.Series.Add(serieTControl);
                chart1.Series["" + ciclo.temperaturaControle + "ºC(Controle)"].Enabled = true;

                serieT1.Points[1].Label = "T1";
                serieT2.Points[pontos].Label = "T2";
                serieT3.Points[2 * pontos].Label = "T3";
                serieT4.Points[3 * pontos].Label = "T4";
                serieCA.Points[4 * pontos].Label = "CA";

                if (backupFont != null)
                {
                    chart1.Legends[0].Font = backupFont;
                }
                else
                {
                    backupFont = chart1.Legends[0].Font;
                }
            }
            catch (Exception ex)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = ciclo.crg;
                logErro.descricao = "Erro ao tentar preencher gráfico do ciclo";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = ex.Message;
                LogErroDAO.inserirLogErro(logErro, ciclo.crg);
            }
        }

        private void PreencherCores()
        {
            try
            {
                foreach (Control b in pnlBotoes.Controls)
                {
                    var botao = b as Button;

                    if (botao != null)
                    {
                        string[] split = null;
                        switch (b.Name)
                        {
                            case "btnT1":
                                split = _cores.T1RGB.Split(',');
                                b.BackColor = Color.FromArgb((int.Parse(split[0])), (int.Parse(split[1])), (int.Parse(split[2])));
                                break;
                            case "btnT2":
                                split = _cores.T2RGB.Split(',');
                                b.BackColor = Color.FromArgb((int.Parse(split[0])), (int.Parse(split[1])), (int.Parse(split[2])));
                                break;
                            case "btnT3":
                                split = _cores.T3RGB.Split(',');
                                b.BackColor = Color.FromArgb((int.Parse(split[0])), (int.Parse(split[1])), (int.Parse(split[2])));
                                break;
                            case "btnT4":
                                split = _cores.T4RGB.Split(',');
                                b.BackColor = Color.FromArgb((int.Parse(split[0])), (int.Parse(split[1])), (int.Parse(split[2])));
                                break;
                            case "btnCA":
                                split = _cores.CARGB.Split(',');
                                b.BackColor = Color.FromArgb((int.Parse(split[0])), (int.Parse(split[1])), (int.Parse(split[2])));
                                break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao preencher as cores!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BotoesPaletaDeCor(object sender, EventArgs e)
        {
            chart1.ApplyPaletteColors();

            Button button = (Button)sender;

            var cdgCores = new ColorDialog();
            if (cdgCores.ShowDialog(this) == DialogResult.OK)
            {
                Color color;
                Series series;

                button.BackColor = cdgCores.Color;
                switch (button.Name)
                {
                    case "btnT1":
                        series = VerificarLinha(Legendas[0]);
                        color = button.BackColor;
                        series.Color = color;
                        _cores.T1RGB = "" + color.R + "," + color.G + "," + color.B.ToString();
                        AtualizaUltimo(_cores.T1RGB, _cores.T2RGB, _cores.T3RGB, _cores.T4RGB, _cores.CARGB);
                        break;
                    case "btnT2":
                        series = VerificarLinha(Legendas[1]);
                        color = button.BackColor;
                        series.Color = color;
                        _cores.T2RGB = "" + color.R + "," + color.G + "," + color.B.ToString();
                        AtualizaUltimo(_cores.T1RGB, _cores.T2RGB, _cores.T3RGB, _cores.T4RGB, _cores.CARGB);
                        break;
                    case "btnT3":
                        series = VerificarLinha(Legendas[2]);
                        color = button.BackColor;
                        series.Color = color;
                        _cores.T3RGB = "" + color.R + "," + color.G + "," + color.B.ToString();
                        AtualizaUltimo(_cores.T1RGB, _cores.T2RGB, _cores.T3RGB, _cores.T4RGB, _cores.CARGB);
                        break;
                    case "btnT4":
                        series = VerificarLinha(Legendas[3]);
                        color = button.BackColor;
                        series.Color = color;
                        _cores.T4RGB = "" + color.R + "," + color.G + "," + color.B.ToString();
                        AtualizaUltimo(_cores.T1RGB, _cores.T2RGB, _cores.T3RGB, _cores.T4RGB, _cores.CARGB);
                        break;
                    case "btnCA":
                        series = VerificarLinha(Legendas[4]);
                        color = button.BackColor;
                        series.Color = color;
                        _cores.CARGB = "" + color.R + "," + color.G + "," + color.B.ToString();
                        AtualizaUltimo(_cores.T1RGB, _cores.T2RGB, _cores.T3RGB, _cores.T4RGB, _cores.CARGB);
                        break;
                }
            }
        }

        private void btnGR_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = !chart1.ChartAreas[0].AxisX.MajorGrid.Enabled;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = !chart1.ChartAreas[0].AxisX.MinorGrid.Enabled;

            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = !chart1.ChartAreas[0].AxisY.MajorGrid.Enabled;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = !chart1.ChartAreas[0].AxisY.MinorGrid.Enabled;
        }

        private void VisualizarLinhasDoGrafico(object sender, EventArgs e)
        {
            var nomeSeries = "";
            string nome = ((CheckBox)sender).Name;
            bool state = ((CheckBox)sender).Checked;

            switch (nome)
            {
                case "chkT1":
                    nomeSeries = Legendas[0];
                    _cores.T1 = state ? 1 : 0;

                    break;
                case "chkT2":
                    nomeSeries = Legendas[1];
                    _cores.T2 = state ? 1 : 0;

                    break;
                case "chkT3":
                    nomeSeries = Legendas[2];
                    _cores.T3 = state ? 1 : 0;

                    break;
                case "chkT4":
                    nomeSeries = Legendas[3];
                    _cores.T4 = state ? 1 : 0;

                    break;
                case "chkCA":
                    nomeSeries = Legendas[4];
                    _cores.CA = state ? 1 : 0;

                    break;
            }

            CheckBox chk = (CheckBox)sender;
            chart1.Series[nomeSeries].Enabled = chk.Checked;
        }

        private Series VerificarLinha(string nome)
        {
            return chart1.Series.FirstOrDefault(serie => serie.Name == nome);
        }

        private string[] ObterCores()
        {
            try
            {
                var cores = UltimosDAO.RetornaUltimasCores();
                string[] retorno = new string[5];
                retorno[0] = cores.T1RGB;
                retorno[1] = cores.T2RGB;
                retorno[2] = cores.T3RGB;
                retorno[3] = cores.T4RGB;
                retorno[4] = cores.CARGB;
                return retorno;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter as cores do gráfico";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao obter as cores do gráfico", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return new string[5] { "", "", "", "", "" };
            }
        }

        public bool AtualizaUltimo(string T1, string T2, string T3, string T4, string CA)
        {
            try
            {
                return UltimosDAO.SetarUltimasCores(new CoresGrafico
                {
                    T1RGB = T1,
                    T2RGB = T2,
                    T3RGB = T3,
                    T4RGB = T4,
                    CARGB = CA
                });
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter as cores do gráfico";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao obter as cores do gráfico", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
        }

        private string[] ObterLegendas()
        {
            try
            {
                var legendas = UltimosDAO.RetornaUltimasLegendas();
                string[] retorno = new string[5];
                retorno[0] = legendas.T1;
                retorno[1] = legendas.T2;
                retorno[2] = legendas.T3;
                retorno[3] = legendas.T4;
                retorno[4] = legendas.CA;
                return retorno;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter dados das Cores";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao obter dados das Cores", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return new string[5] { "", "", "", "", "" };
            }
        }

        private void TipoGrafico_Click(object sender, EventArgs e)
        {
            if (TipoGrafico.Text == "Tratamento")
            {
                PreencherChartTratamento(false);
                TipoGrafico.Text = "Ciclo";
            }
            else
            {
                PreencherChartCiclo();
                TipoGrafico.Text = "Tratamento";
            }
        }

        private void PreencherChartTratamento(bool fonteGrandeCores = true)
        {
            try
            {
                List<VO.LeiturasCiclo> listaLeiturasCiclo = LeiturasCicloDAO.ListaLeiturasCiclos(ciclo);
                List<VO.LeiturasTrat> listaLeiturasTrat = LeiturasTratDAO.ListaLeiturasTratamento(ciclo);
                listaLeiturasT = new List<LeiturasTrat>();
                if (listaLeituraC == null) listaLeituraC = listaLeiturasCiclo;
                
                int contGeral = 0;
                //Leituras Anteriores ao Tratamento
                for (int i = 0; i < ciclo.nlAntesTrat; i++)
                {
                    LeiturasTrat leitura = new LeiturasTrat();
                    leitura.horario = listaLeiturasCiclo[i].horario;
                    leitura.T1 = listaLeiturasCiclo[i].T1;
                    leitura.T2 = listaLeiturasCiclo[i].T2;
                    leitura.T3 = listaLeiturasCiclo[i].T3;
                    leitura.T4 = listaLeiturasCiclo[i].T4;
                    listaLeiturasT.Add(leitura);
                    contGeral++;
                }

                int contTrat = 1;
                //Leituras do Tratamento
                for (int i = 0; i < listaLeiturasTrat.Count; i++)
                {
                    listaLeiturasT.Add(listaLeiturasTrat[i]);
                    contTrat++;
                    contGeral++;
                }

                //Leituras Posteriores ao Tratamento
                for (int i = contGeral; i < listaLeiturasCiclo.Count; i++)
                {
                    LeiturasTrat leitura = new LeiturasTrat();
                    leitura.horario = listaLeiturasCiclo[i].horario;
                    leitura.T1 = listaLeiturasCiclo[i].T1;
                    leitura.T2 = listaLeiturasCiclo[i].T2;
                    leitura.T3 = listaLeiturasCiclo[i].T3;
                    leitura.T4 = listaLeiturasCiclo[i].T4;
                    listaLeiturasT.Add(leitura);
                    contGeral++;
                }

                chart1.Series.Clear();
                
                chart1.ChartAreas[0].AxisY.Interval = 5;

                if (lista.Count > 40)
                {
                    chart1.ChartAreas[0].AxisX.Interval = 0;
                    chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                }
                else
                {
                    chart1.ChartAreas[0].AxisX.Interval = 1;
                }

                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                int maximoY = 0;
                if (ciclo.tipoCRG == 100)
                {
                    maximoY = 100;
                    chart1.ChartAreas[0].AxisY.LabelStyle.Interval = 5;
                }
                else if (ciclo.tipoCRG == 150)
                {
                    maximoY = 150;
                    chart1.ChartAreas[0].AxisY.LabelStyle.Interval = 10;
                }
                chart1.ChartAreas[0].AxisY.Maximum = maximoY;

                chart1.ChartAreas[0].AxisX.Maximum = lista.Count;
                chart1.ChartAreas[0].AxisY.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;
                chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("", 7);

                

                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas[0].AxisX.LineColor = Color.Black;
                chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
                chart1.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.Red;

                //chart1.ChartAreas[0].AxisY.LineWidth = 2;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas[0].AxisY.LineColor = Color.Black;
                chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
                chart1.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.Red;

                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisX.Title = "NLT";

                chart1.ChartAreas[0].CursorX.AutoScroll = true;
                chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
                chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

                chart1.ChartAreas[0].CursorY.AutoScroll = true;
                chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
                chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
                chart1.ChartAreas[0].CursorX.LineColor = Color.Red;
                chart1.ChartAreas[0].CursorY.LineColor = Color.Red;

                Series serieT1 = new Series(Legendas[0], listaLeiturasT.Count);
                serieT1.ChartType = SeriesChartType.Spline;
                for (int i = 0; i < lista.Count; i++)
                {
                    serieT1.Points.AddXY(lista[i].NLT, lista[i].T1);
                }
                string[] split = _cores.T1RGB.Split(',');
                serieT1.Color = Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
                chart1.Series.Add(serieT1);
                chart1.Series[Legendas[0]].Enabled = true;
                chart1.Series[Legendas[0]].IsVisibleInLegend = true;

                Series serieT2 = new Series(Legendas[1], listaLeiturasT.Count);
                serieT2.ChartType = SeriesChartType.Spline;
                for (int i = 0; i < lista.Count; i++)
                {
                    serieT2.Points.AddXY(lista[i].NLT, lista[i].T2);
                }
                split = _cores.T2RGB.Split(',');
                serieT2.Color = Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
                chart1.Series.Add(serieT2);
                chart1.Series[Legendas[1]].Enabled = true;
                chart1.Series[Legendas[1]].IsVisibleInLegend = true;

                Series serieT3 = new Series(Legendas[2], listaLeiturasT.Count);
                serieT3.ChartType = SeriesChartType.Spline;
                for (int i = 0; i < lista.Count; i++)
                {
                    serieT3.Points.AddXY(lista[i].NLT, lista[i].T3);
                }
                split = _cores.T3RGB.Split(',');
                serieT3.Color = Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
                chart1.Series.Add(serieT3);
                chart1.Series[Legendas[2]].Enabled = true;
                chart1.Series[Legendas[2]].IsVisibleInLegend = true;

                Series serieT4 = new Series(Legendas[3], listaLeiturasT.Count);
                serieT4.ChartType = SeriesChartType.Spline;
                for (int i = 0; i < lista.Count; i++)
                {
                    serieT4.Points.AddXY(lista[i].NLT, lista[i].T4);
                }
                split = _cores.T4RGB.Split(',');
                serieT4.Color = Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
                chart1.Series.Add(serieT4);
                chart1.Series[Legendas[3]].Enabled = true;
                chart1.Series[Legendas[3]].IsVisibleInLegend = true;

                // Inicio do Tratamento
                Series inicioFito = new Series("Inicio/Fim Tratamento", maximoY);
                inicioFito.ChartType = SeriesChartType.Line;

                for (var i = 0; i < lista.Count - 1; i++)
                {
                    if (lista[i].demarca_tratamento == true)
                    {
                        for (var j = 0; j <= maximoY; j++)
                        {
                            inicioFito.Points.AddXY(lista[i].NLT, j);
                        }
                        break;
                    }
                }

                inicioFito.Color = Color.DarkGreen;
                inicioFito.BorderWidth = 2;
                chart1.Series.Add(inicioFito);
                chart1.Series["Inicio/Fim Tratamento"].IsVisibleInLegend = true;

                // Só deve exibir essa linha, caso o tratamento tenha
                // concluído
                var encontrou = false;
                var indiceFim = -1;
                for (var i = 0; i < lista.Count - 1; i++)
                {
                    if (lista[i].demarca_tratamento == true)
                    {
                        if (!encontrou)
                        {
                            encontrou = true;
                        }
                        else
                        {
                            indiceFim = i;
                        }
                    }
                }
                if (indiceFim > -1)
                {
                    // Fim do Tratamento
                    Series fimFito = new Series("Fim Tratamento", maximoY);
                    fimFito.ChartType = SeriesChartType.Line;
                    fimFito.IsVisibleInLegend = false;
                        for (var j = 0; j <= maximoY; j++)
                        {
                            fimFito.Points.AddXY(lista[indiceFim].NLT, j);
                        }
                    fimFito.Color = Color.DarkGreen;
                    fimFito.BorderWidth = 2;
                    chart1.Series.Add(fimFito);
                    chart1.Series["Fim Tratamento"].IsVisibleInLegend = false;
                }
                
                int pontos = lista.Count / 5;

                Series serieCA = new Series(Legendas[4], 1);
                serieCA.ChartType = SeriesChartType.Spline;
                switch (ciclo.sensor)
                {
                    case 0:
                        for (int i = 0; i < lista.Count; i++)
                        {
                            serieCA.Points.AddXY(lista[i].NLT, lista[i].T2);
                        }
                        break;
                    case 16:
                        for (int i = 0; i < lista.Count; i++)
                        {
                            serieCA.Points.AddXY(lista[i].NLT, lista[i].T3);
                        }
                        break;
                    case 32:
                        for (int i = 0; i < lista.Count; i++)
                        {
                            serieCA.Points.AddXY(lista[i].NLT, lista[i].T4);
                        }
                        break;
                    case 48:
                        for (int i = 0; i < lista.Count; i++)
                        {
                            serieCA.Points.AddXY(lista[i].NLT, ((lista[i].T2 + lista[i].T3 + lista[i].T4) / 3));
                        }
                        break;
                    case 64:
                        for (int i = 0; i < lista.Count; i++)
                        {
                            serieCA.Points.AddXY(lista[i].NLT, lista[i].T4);
                        }
                        break;
                    case 80:
                        for (int i = 0; i < lista.Count; i++)
                        {
                            serieCA.Points.AddXY(lista[i].NLT, lista[i].T4);
                        }
                        break;
                }

                split = _cores.CARGB.Split(',');
                serieCA.Color = Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
                chart1.Series.Add(serieCA);
                chart1.Series[Legendas[4]].Enabled = true;
                chart1.Series[Legendas[4]].IsVisibleInLegend = true;

                Series serieTempTrat = new Series("" + ciclo.temperaturaTrat + "ºC(Tratamento)", 1);
                serieTempTrat.ChartType = SeriesChartType.Spline;
                for (int i = 0; i <= lista.Count; i++)
                {
                    serieTempTrat.Points.AddXY(i, ciclo.temperaturaTrat);
                }
                serieTempTrat.Color = Color.DarkOrange;
                chart1.Series.Add(serieTempTrat);
                chart1.Series["" + ciclo.temperaturaTrat + "ºC(Tratamento)"].Enabled = true;

                Series serieTControl = new Series("" + ciclo.temperaturaControle + "ºC(Controle)", 1);
                serieTControl.ChartType = SeriesChartType.Spline;
                for (int i = 0; i <= lista.Count; i++)
                {
                    serieTControl.Points.AddXY(i, ciclo.temperaturaControle);
                }
                serieTControl.Color = Color.Purple;
                chart1.Series.Add(serieTControl);
                chart1.Series["" + ciclo.temperaturaControle + "ºC(Controle)"].Enabled = true;

                serieT1.Points[1].Label = "[T1]";
                serieT2.Points[pontos].Label = "[T2]";
                serieT3.Points[2 * pontos].Label = "[T3]";
                serieT4.Points[3 * pontos].Label = "[T4]";
                serieCA.Points[4 * pontos].Label = "[CA]";
                if (fonteGrandeCores)
                {
                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
                    chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
                    //chart1.ChartAreas[0].AxisX.Interval
                    //chart1.Height += 500;
                    chart1.Width -= 75;
                    chart1.ChartAreas[0].Position = new ElementPosition(0, 0, 100, 85);
                    //chart1.Legends[0].Position = new ElementPosition(0,0,100,100);
                    chart1.Legends[0].Docking = Docking.Bottom;
                    chart1.Legends[0].Font = new Font("", 8);
                    //chart1.ChartAreas[0].AxisY.Title = "Cº";
                    //chart1.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Far;
                    chart1.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Far;
                    chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0}º";
                }

            }
            catch (Exception ex)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = ciclo.crg;
                logErro.descricao = "Erro ao tentar preencher gráfico do ciclo";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = ex.Message;
                LogErroDAO.inserirLogErro(logErro, ciclo.crg);
            }
        }

        private void Desmarca_Click(object sender, EventArgs e)
        {
            if (Desmarca.Text == "Desmarcar")
            {
                chkT1.Checked = false;
                chkT2.Checked = false;
                chkT3.Checked = false;
                chkT4.Checked = false;
                chkCA.Checked = false;
                Desmarca.Text = "Marcar";
            }
            else if (Desmarca.Text == "Marcar")
            {
                chkT1.Checked = true;
                chkT2.Checked = true;
                chkT3.Checked = true;
                chkT4.Checked = true;
                chkCA.Checked = true;
                Desmarca.Text = "Desmarcar";
            }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (TipoGrafico.Text == "Tratamento")
                {
                    var pX = (int) chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                    var pY = (int) chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

                    if (pX >= 1 && pY >= 0 && pX <= listaLeituraC.Count)
                    {
                        if (listaLeituraC.Count > 0)
                        {
                            txtHorario.Text = listaLeituraC[pX - 1].horario;
                            txtNL.Text = "NL = " + (pX - 1).ToString();
                            txtValor.Text = (pY - 1).ToString() + " ºC";
                        }
                    }
                }
                else if (TipoGrafico.Text == "Ciclo")
                {
                    var pX = (int)chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                    var pY = (int)chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

                    if (pX >= 1 && pY >= 0 && pX <= lista.Count)
                    {
                        if (lista.Count > 0)
                        {
                            txtHorario.Text = lista[pX].horario;
                            txtNL.Text = "NLT = " + (pX).ToString();
                            txtValor.Text = (pY - 1).ToString() + " ºC";
                        }
                    }
                }
            }
            catch
            {
                // Há um erro ao tentar carregar o form se ficar mexendo o mouse em cima
                // do gráfico, por isso foi colocado esse try/catch
                // mas não interfere em nada o processo
            }
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            if (TipoGrafico.Text == "Ciclo")
            {
                var pageSettings = new PageSettings { Landscape = true };
                chart1.Printing.PrintDocument.DocumentName = "GraficoTratamento";
                chart1.Printing.PrintDocument.DefaultPageSettings = pageSettings;

                var printDlg = new PrintDialog
                {
                    Document = chart1.Printing.PrintDocument,
                    AllowSelection = false,
                    AllowSomePages = false,
                    AllowCurrentPage = false,
                    AllowPrintToFile = false
                };

                if (printDlg.ShowDialog(this) == DialogResult.OK)
                {
                    var pd = printDlg.Document;
                    pd.PrintPage += PrintPage;
                    pd.Print();
                }
            }
            else if (TipoGrafico.Text == "Tratamento")
            {
                var pageSettings = new PageSettings { Landscape = true };
                chart1.Printing.PrintDocument.DocumentName = "GraficoCiclo";
                chart1.Printing.PrintDocument.DefaultPageSettings = pageSettings;

                var printDlg = new PrintDialog
                {
                    Document = chart1.Printing.PrintDocument,
                    AllowSelection = false,
                    AllowSomePages = false,
                    AllowCurrentPage = false,
                    AllowPrintToFile = false
                };

                if (printDlg.ShowDialog(this) == DialogResult.OK)
                {
                    var pd = printDlg.Document;
                    pd.PrintPage += PrintPage;
                    pd.Print();
                }
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            var stream = new MemoryStream();
            chart1.SaveImage(stream, ChartImageFormat.Png);

            var bitmap = new Bitmap(stream);

            e.Graphics.Clear(Color.White);
            Image img = Image.FromHbitmap(bitmap.GetHbitmap()); // FromFile("D:\\Foto.jpg");
            Point loc = new Point(20, 40);
            e.Graphics.DrawImage(img, loc);
            var bitmap1 = new Bitmap(panel1.Width, panel1.Height);
            this.panel1.DrawToBitmap(bitmap1, new Rectangle(0, 0, this.panel1.Width, this.panel1.Height));
            foreach (Control control in panel1.Controls)
            {
                DrawControl(control, bitmap1);
            }

            // Dados lado esquerdo
            e.Graphics.DrawString(Controlador.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 55, 455);
            e.Graphics.DrawString(Datas.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 55, 475);
            e.Graphics.DrawString(DadosTrat.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 55, 495);
            e.Graphics.DrawString(lblProdutos.Text, new Font("Arial", 8), new SolidBrush(Color.Black), 55, 515);
            // Dados lado direito
            e.Graphics.DrawString(tempoTrat.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 395, 455);
            e.Graphics.DrawString(Descricao.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 395, 475);
            e.Graphics.DrawString(Responsavel.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 395, 495);
            e.Graphics.DrawString(Operador.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 395, 515);


            string[] split = _cores.T1RGB.Split(',');
            Pen T1Pen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])),3);
            e.Graphics.DrawLine(T1Pen, new Point(880,75),new Point(900,75));
            e.Graphics.DrawString(Legendas[0], new System.Drawing.Font("Arial", 8),
                new System.Drawing.SolidBrush(System.Drawing.Color.Black), 905, 67);

            split = _cores.T2RGB.Split(',');
            Pen T2Pen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
            e.Graphics.DrawLine(T2Pen, new Point(880, 95), new Point(900, 95));
            e.Graphics.DrawString(Legendas[1], new System.Drawing.Font("Arial", 8),
                new System.Drawing.SolidBrush(System.Drawing.Color.Black), 905, 87);

            split = _cores.T3RGB.Split(',');
            Pen T3Pen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
            e.Graphics.DrawLine(T3Pen, new Point(880, 115), new Point(900, 115));
            e.Graphics.DrawString(Legendas[2], new System.Drawing.Font("Arial", 8),
                new System.Drawing.SolidBrush(System.Drawing.Color.Black), 905, 107);

            split = _cores.T4RGB.Split(',');
            Pen T4Pen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
            e.Graphics.DrawLine(T4Pen, new Point(880, 135), new Point(900, 135));
            e.Graphics.DrawString(Legendas[3], new System.Drawing.Font("Arial", 8),
                new System.Drawing.SolidBrush(System.Drawing.Color.Black), 905, 127);

            split = _cores.CARGB.Split(',');
            Pen CAPen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
            e.Graphics.DrawLine(CAPen, new Point(880, 155), new Point(900, 155));
            e.Graphics.DrawString(Legendas[4], new System.Drawing.Font("Arial", 8),
                new System.Drawing.SolidBrush(System.Drawing.Color.Black), 905, 147);

            Pen blackPen = new Pen(Color.Black, 1);
            Rectangle rect = new Rectangle(50, 50, 1000, 485);
            e.Graphics.DrawRectangle(blackPen, rect);

            VO.Empresa empresa = EmpresaDAO.retornaEmpresa();
            if (empresa != null)
            {
                MemoryStream mStream = new MemoryStream();
                if (empresa.Logo != null)
                {
                    mStream.Write(empresa.Logo, 0, Convert.ToInt32(empresa.Logo.Length));
                    Image logo = Image.FromStream(mStream);
                    e.Graphics.DrawImage(logo, 55, 545, 400, 86);
                }
                e.Graphics.DrawString(empresa.Nome, new System.Drawing.Font("Arial", 8, FontStyle.Bold),
                new System.Drawing.SolidBrush(System.Drawing.Color.Black), 470, 560);
                e.Graphics.DrawString(empresa.Endereco + " " + empresa.Cep + " " + empresa.Cidade + " " + empresa.UF, new System.Drawing.Font("Arial", 8),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Black), 470, 575);
                e.Graphics.DrawString("Tel: " + empresa.Fone + "  Fax: " + empresa.Fax, new System.Drawing.Font("Arial", 8),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Black), 470, 590);
                e.Graphics.DrawString("CNPJ: " + empresa.CNPJ + "  IE: " + empresa.IE + "  Nº Credenciamento: " + empresa.NCredenciamento, new System.Drawing.Font("Arial", 8),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Black), 470, 605);
            }
        }

        public void ExportarImagem()
        {
            var stream = new MemoryStream();
            chart1.SaveImage(stream, ChartImageFormat.Png);

            var b = new Bitmap(chart1.Width + 250, chart1.Height + 500);

            var bitmap = new Bitmap(stream);

            var g = Graphics.FromImage(b);

            g.Clear(Color.White);
            Image img = Image.FromHbitmap(bitmap.GetHbitmap()); // FromFile("D:\\Foto.jpg");
            Point loc = new Point(20, 50);
            g.DrawImage(img, loc);
            var bitmap1 = new Bitmap(panel1.Width, panel1.Height);
            this.panel1.DrawToBitmap(bitmap1, new Rectangle(0, 0, this.panel1.Width, this.panel1.Height));
            foreach (Control control in panel1.Controls)
            {
                DrawControl(control, bitmap1);
            }

            // Dados lado esquerdo
            g.DrawString(Controlador.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 55, 455);
            g.DrawString(Datas.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 55, 475);
            g.DrawString(DadosTrat.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 55, 495);
            g.DrawString(lblProdutos.Text, new Font("Arial", 8), new SolidBrush(Color.Black), 55, 515);
            // Dados lado direito
            g.DrawString(tempoTrat.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 395, 455);
            g.DrawString(Descricao.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 395, 475);
            g.DrawString(Responsavel.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 395, 495);
            g.DrawString(Operador.Text, new Font("Arial", 8),
                new SolidBrush(Color.Black), 395, 515);

            string[] split = _cores.T1RGB.Split(',');
            Pen T1Pen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
            g.DrawLine(T1Pen, new Point(880, 75), new Point(900, 75));
            g.DrawString(Legendas[0], new System.Drawing.Font("Arial", 8),
                new System.Drawing.SolidBrush(System.Drawing.Color.Black), 905, 67);

            split = _cores.T2RGB.Split(',');
            Pen T2Pen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
            g.DrawLine(T2Pen, new Point(880, 95), new Point(900, 95));
            g.DrawString(Legendas[1], new System.Drawing.Font("Arial", 8),
                new System.Drawing.SolidBrush(System.Drawing.Color.Black), 905, 87);

            split = _cores.T3RGB.Split(',');
            Pen T3Pen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
            g.DrawLine(T3Pen, new Point(880, 115), new Point(900, 115));
            g.DrawString(Legendas[2], new System.Drawing.Font("Arial", 8),
                new System.Drawing.SolidBrush(System.Drawing.Color.Black), 905, 107);

            split = _cores.T4RGB.Split(',');
            Pen T4Pen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
            g.DrawLine(T4Pen, new Point(880, 135), new Point(900, 135));
            g.DrawString(Legendas[3], new System.Drawing.Font("Arial", 8),
                new System.Drawing.SolidBrush(System.Drawing.Color.Black), 905, 127);

            split = _cores.CARGB.Split(',');
            Pen CAPen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
            g.DrawLine(CAPen, new Point(880, 155), new Point(900, 155));
            g.DrawString(Legendas[4], new System.Drawing.Font("Arial", 8),
                new System.Drawing.SolidBrush(System.Drawing.Color.Black), 905, 147);

            Pen blackPen = new Pen(Color.Black, 1);
            Rectangle rect = new Rectangle(50, 50, 1000, 485);
            g.DrawRectangle(blackPen, rect);

            VO.Empresa empresa = EmpresaDAO.retornaEmpresa();
            if (empresa != null)
            {
                MemoryStream mStream = new MemoryStream();
                if (empresa.Logo != null)
                {
                    mStream.Write(empresa.Logo, 0, Convert.ToInt32(empresa.Logo.Length));
                    Image logo = Image.FromStream(mStream);
                    g.DrawImage(logo, 55, 545, 400, 86);
                }
                g.DrawString(empresa.Nome, new System.Drawing.Font("Arial", 8, FontStyle.Bold),
                new System.Drawing.SolidBrush(System.Drawing.Color.Black), 470, 560);
                g.DrawString(empresa.Endereco + " " + empresa.Cep + " " + empresa.Cidade + " " + empresa.UF, new System.Drawing.Font("Arial", 8),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Black), 470, 575);
                g.DrawString("Tel: " + empresa.Fone + "  Fax: " + empresa.Fax, new System.Drawing.Font("Arial", 8),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Black), 470, 590);
                g.DrawString("CNPJ: " + empresa.CNPJ + "  IE: " + empresa.IE + "  Nº Credenciamento: " + empresa.NCredenciamento, new System.Drawing.Font("Arial", 8),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Black), 470, 605);
            }

            var savedlg = new SaveFileDialog();
            savedlg.Filter = "Arquivo PNG (*.png)|*.png";
            savedlg.ShowDialog(this);
            if (!string.IsNullOrWhiteSpace(savedlg.FileName))
            {
                b.Save(savedlg.FileName, ImageFormat.Png);
            }
        }

        public void DrawControl(Control control, Bitmap bitmap)
        {
            control.DrawToBitmap(bitmap, control.Bounds);
            foreach (Control childControl in control.Controls)
            {
                DrawControl(childControl, bitmap);
            }
        }

        private void CriaImagem()
        {
            this.SalvaGrafico.PerformClick();
        }

        public void SalvaGrafico_Click(object sender, EventArgs e)
        {
            //Point coordenadas = Cursor.Position;
            string[] cores = ObterCores();
            Legendas = ObterLegendas();
            _cores.T1RGB = cores[0];
            _cores.T2RGB = cores[1];
            _cores.T3RGB = cores[2];
            _cores.T4RGB = cores[3];
            _cores.CARGB = cores[4];
            PreencherCores();
            if (opcao == 1) PreencherChartCiclo();
            else PreencherChartTratamento();

            try
            {
                chart1.SaveImage(Environment.CurrentDirectory + "\\Image.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = ciclo.crg;
                logErro.descricao = "Erro ao tentar criar gráfico para o relatório";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = ex.Message;
                LogErroDAO.inserirLogErro(logErro, ciclo.crg);
            }
        }

        public static void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            //uint X = (uint) Cursor.Position.X;
            //uint Y = (uint) Cursor.Position.Y;
            Cursor.Position = new Point(876,539);

            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public void SalvaGrafico2()
        {
            string[] cores = ObterCores();
            Legendas = ObterLegendas();
            _cores.T1RGB = cores[0];
            _cores.T2RGB = cores[1];
            _cores.T3RGB = cores[2];
            _cores.T4RGB = cores[3];
            _cores.CARGB = cores[4];
            PreencherCores();
            if (opcao == 1) PreencherChartCiclo();
            else PreencherChartTratamento();

            try
            {
                /*var imagenzinea = new Bitmap(chart1.Width+125, chart1.Height);
                chart1.Legends[0].Enabled = false;
                var g = Graphics.FromImage(imagenzinea);
                g.Clear(Color.White);
                chart1.DrawToBitmap(imagenzinea, new Rectangle(0, 0, chart1.Width, chart1.Height));
                //imagenzinea.
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                var comecoLinha = 820;
                var topInicio = 30;

                string[] split = _cores.T1RGB.Split(',');
                Pen T1Pen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
                g.DrawLine(T1Pen, new Point(comecoLinha, topInicio + 25), new Point(comecoLinha + 20, topInicio+25));
                g.DrawString(Cores[0], new System.Drawing.Font("Arial", 8),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Black), comecoLinha + 25, topInicio+17);

                split = _cores.T2RGB.Split(',');
                Pen T2Pen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
                g.DrawLine(T2Pen, new Point(comecoLinha, topInicio+45), new Point(comecoLinha + 20, topInicio + 45));
                g.DrawString(Cores[1], new System.Drawing.Font("Arial", 8),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Black), comecoLinha + 25, topInicio+37);

                split = _cores.T3RGB.Split(',');
                Pen T3Pen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
                g.DrawLine(T3Pen, new Point(comecoLinha, topInicio + 65), new Point(comecoLinha + 20, topInicio+65));
                g.DrawString(Cores[2], new System.Drawing.Font("Arial", 8),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Black), comecoLinha + 25, topInicio+57);

                split = _cores.T4RGB.Split(',');
                Pen T4Pen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
                g.DrawLine(T4Pen, new Point(comecoLinha, topInicio + 85), new Point(comecoLinha + 20, topInicio+85));
                g.DrawString(Cores[3], new System.Drawing.Font("Arial", 8),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Black), comecoLinha + 25, topInicio+77);

                split = _cores.CARGB.Split(',');
                Pen CAPen = new Pen(Color.FromArgb(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2])), 3);
                g.DrawLine(CAPen, new Point(comecoLinha, topInicio + 105), new Point(comecoLinha + 20, topInicio+105));
                g.DrawString(Cores[4], new System.Drawing.Font("Arial", 8),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Black), comecoLinha + 25, topInicio+97);

                split = _cores.CARGB.Split(',');
                Pen TratPen = new Pen(Color.DarkGreen, 3);
                g.DrawLine(TratPen, new Point(comecoLinha, topInicio + 125), new Point(comecoLinha + 20, topInicio + 125));
                g.DrawString("Início/Fim Trat.", new System.Drawing.Font("Arial", 8),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Black), comecoLinha + 25, topInicio + 117);
                g.Flush();
                imagenzinea.Save(Environment.CurrentDirectory + "\\Image.png", ImageFormat.Png);

                chart1.Legends[0].Enabled = true;*/
                
                chart1.SaveImage(Environment.CurrentDirectory + "\\Image.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = ciclo.crg;
                logErro.descricao = "Erro ao tentar criar gráfico para o relatório";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = ex.Message;
                LogErroDAO.inserirLogErro(logErro, ciclo.crg);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportarImagem();
        }
    }
}
