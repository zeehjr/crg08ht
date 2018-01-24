using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CRG08.Dao;
using CRG08.VO;

namespace CRG08.View
{
    public partial class DetalhesCiclo : Form
    {
        public DetalhesCiclo()
        {
            InitializeComponent();
        }

        int idCiclo = -1, crg = -1;
        public DetalhesCiclo(int idCiclo, int crg)
        {
            InitializeComponent();
            this.idCiclo = idCiclo;
            this.crg = crg;
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetalhesCiclo_Load(object sender, EventArgs e)
        {
            var config = ConfiguracaoDAO.PegarConfigRelatorio();
            VO.Ciclos ciclo = CicloDAO.buscaCiclo(crg, idCiclo);
            List<LeiturasCiclo> listaLeiturasCiclo = LeiturasCicloDAO.ListaLeiturasCiclos(ciclo);
            List<LeiturasTrat> listaLeiturasTrat = LeiturasTratDAO.ListaLeiturasTratamento(ciclo);
            
            var dados = new List<string>();
            if(string.IsNullOrEmpty(ciclo.versaoEquip))
                dados.Add("Controlador nº" + crg.ToString("##") + " com " + ciclo.nl + " leituras(NTRAT: " + ciclo.nTrat.ToString("000") +
                       ") - Nº Série " + ciclo.numSerie);
            else
                dados.Add("Controlador nº" + crg.ToString("##") + " com " + ciclo.nl + " leituras(NTRAT: " + ciclo.nTrat.ToString("000") +
                       ") "+ ciclo.versaoEquip + " - Nº Série " + ciclo.numSerie);

            
            
            dados.Add("Valores programados no SET POINT do equipamento");
            dados.Add("    - Temperatura de Controle(Tc): " + ciclo.temperaturaControle.ToString("##.0") + "ºC");
            dados.Add("    - Temperatura do Tratamento(Tt): " + ciclo.temperaturaTrat.ToString("##.0") + "ºC");
            dados.Add("    - Tempo do Tratamento(tt): " + ciclo.tempoTrat+" minuto(s)");
            dados.Add("Período do ciclo: " + ciclo.dataInicio + " - " + ciclo.dataFim);
            dados.Add("Descrição: " + ciclo.descricao);
            if (listaLeiturasTrat.Count > 0 && ciclo.nlt == ciclo.tempoTrat)
                dados.Add("Início do tratamento na leitura " + ciclo.NLIniTrat + " - " + ciclo.dataIniTrat +
                           " (concluído)");
            else dados.Add("Não realizou o tratamento");
            dados.Add("Responsável Técnico: " + ciclo.responsavel);
            dados.Add("Operador: " + ciclo.operador);

            if (!string.IsNullOrWhiteSpace(ciclo.VolumeFixo))
            {
                dados.Add("Volume total: " + ciclo.VolumeFixo + (ciclo.IsMetrosCubicos ? "m³" : " peça(s)"));
            }
            else
            {
                dados.Add("");
            }

            switch (ciclo.sensor)
            {
                case 0:
                    dtgTratamento.Columns["T1T"].HeaderText = "T1 Mad";
                    dtgTratamento.Columns["T2T"].HeaderText = "T2 Amb";
                    dtgTratamento.Columns["T3T"].HeaderText = "T3 Amb";
                    dtgTratamento.Columns["T4T"].HeaderText = "T4 Amb";
                    dtgCiclo.Columns["T1"].HeaderText = "T1 Mad";
                    dtgCiclo.Columns["T2"].HeaderText = "T2 Amb";
                    dtgCiclo.Columns["T3"].HeaderText = "T3 Amb";
                    dtgCiclo.Columns["T4"].HeaderText = "T4 Amb";
                    break;
                case 16:
                    dtgTratamento.Columns["T1T"].HeaderText = "T1 Mad";
                    dtgTratamento.Columns["T2T"].HeaderText = "T2 Amb";
                    dtgTratamento.Columns["T3T"].HeaderText = "T3 Amb";
                    dtgTratamento.Columns["T4T"].HeaderText = "T4 Amb";
                    dtgCiclo.Columns["T1"].HeaderText = "T1 Mad";
                    dtgCiclo.Columns["T2"].HeaderText = "T2 Amb";
                    dtgCiclo.Columns["T3"].HeaderText = "T3 Amb";
                    dtgCiclo.Columns["T4"].HeaderText = "T4 Amb";
                    break;
                case 32:
                    dtgTratamento.Columns["T1T"].HeaderText = "T1 Mad";
                    dtgTratamento.Columns["T2T"].HeaderText = "T2 Amb";
                    dtgTratamento.Columns["T3T"].HeaderText = "T3 Amb";
                    dtgTratamento.Columns["T4T"].HeaderText = "T4 Amb";
                    dtgCiclo.Columns["T1"].HeaderText = "T1 Mad";
                    dtgCiclo.Columns["T2"].HeaderText = "T2 Amb";
                    dtgCiclo.Columns["T3"].HeaderText = "T3 Amb";
                    dtgCiclo.Columns["T4"].HeaderText = "T4 Amb";
                    break;
                case 48:
                    dtgTratamento.Columns["T1T"].HeaderText = "T1 Mad";
                    dtgTratamento.Columns["T2T"].HeaderText = "T2 Amb";
                    dtgTratamento.Columns["T3T"].HeaderText = "T3 Amb";
                    dtgTratamento.Columns["T4T"].HeaderText = "T4 Amb";
                    dtgCiclo.Columns["T1"].HeaderText = "T1 Mad";
                    dtgCiclo.Columns["T2"].HeaderText = "T2 Amb";
                    dtgCiclo.Columns["T3"].HeaderText = "T3 Amb";
                    dtgCiclo.Columns["T4"].HeaderText = "T4 Amb";
                    break;
                case 64:
                    dtgTratamento.Columns["T1T"].HeaderText = "T1 Mad";
                    dtgTratamento.Columns["T2T"].HeaderText = "T2 Mad";
                    dtgTratamento.Columns["T3T"].HeaderText = "T3 Amb";
                    dtgTratamento.Columns["T4T"].HeaderText = "T4 Amb";
                    dtgCiclo.Columns["T1"].HeaderText = "T1 Mad";
                    dtgCiclo.Columns["T2"].HeaderText = "T2 Mad";
                    dtgCiclo.Columns["T3"].HeaderText = "T3 Amb";
                    dtgCiclo.Columns["T4"].HeaderText = "T4 Amb";
                    break;
                case 80:
                    dtgTratamento.Columns["T1T"].HeaderText = "T1 Mad";
                    dtgTratamento.Columns["T2T"].HeaderText = "T2 Mad";
                    dtgTratamento.Columns["T3T"].HeaderText = "T3 Mad";
                    dtgTratamento.Columns["T4T"].HeaderText = "T4 Amb";
                    dtgCiclo.Columns["T1"].HeaderText = "T1 Mad";
                    dtgCiclo.Columns["T2"].HeaderText = "T2 Mad";
                    dtgCiclo.Columns["T3"].HeaderText = "T3 Mad";
                    dtgCiclo.Columns["T4"].HeaderText = "T4 Amb";
                    break;
            }

            foreach (var dado in dados)
            {
                dtgResumo.Rows.Add(dado);
            }
            dtgResumo.Rows[1].DefaultCellStyle.Font = new Font("Microsoft Sans Seriff",8,FontStyle.Bold);

            if (ciclo.tipoCRG == 100)
            {
                foreach (var leiturasCiclo in listaLeiturasCiclo)
                {
                    dtgCiclo.Rows.Add((dtgCiclo.Rows.Count + 1).ToString("000"), leiturasCiclo.horario,
                        leiturasCiclo.T1.ToString("#0.0"),
                        leiturasCiclo.T2.ToString("#0.0"), leiturasCiclo.T3.ToString("#0.0"),
                        leiturasCiclo.T4.ToString("#0.0"));
                    if (ciclo.NLIniTrat == dtgCiclo.Rows.Count)
                        dtgCiclo.Rows[dtgCiclo.Rows.Count - 1].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                int contGeral = 1;
                var listaTratamento = new List<ListaCiclosTratGrafico>();
                if (listaLeiturasTrat.Count > 0 && ciclo.nlt == ciclo.tempoTrat)
                {
                    listaTratamento = RelTratamento.populaTratamento(ciclo, listaLeiturasCiclo, listaLeiturasTrat,
                        config);
                }

                if (listaTratamento.Count > 0)
                {
                    var nlt_inicio_tratamento = 0;
                    var nlt_fim_tratamento = 0;
                    foreach (var item in listaTratamento.ToList())
                    {
                        if (item.demarca_tratamento)
                        {
                            if (nlt_inicio_tratamento == 0)
                            {
                                nlt_inicio_tratamento = item.NLT;
                            }
                            else
                            {
                                nlt_fim_tratamento = item.NLT;
                            }
                        }
                        dtgTratamento.Rows.Add(item.NLT.ToString("000"), item.NL.ToString("000"), item.horario,
                            item.T1.ToString("#0.0"), item.T2.ToString("#0.0"), item.T3.ToString("#0.0"),
                            item.T4.ToString("#0.0"));
                    }
                    foreach (DataGridViewRow row in dtgTratamento.Rows)
                    {
                        var nlt_value = Convert.ToInt32(row.Cells[0].Value);
                        if (nlt_value >= nlt_inicio_tratamento && nlt_value <= nlt_fim_tratamento)
                        {
                            row.DefaultCellStyle.BackColor = Color.PaleGreen;
                        }
                    }
                    //Leituras Anteriores ao Tratamento
                    /*for (int i = 0; i < ciclo.nlAntesTrat; i += 2)
                    {
                        dtgTratamento.Rows.Add("--", contGeral.ToString("000"), listaLeiturasCiclo[i].horario,
                            listaLeiturasCiclo[i].T1.ToString("##.0"),
                            listaLeiturasCiclo[i].T2.ToString("##.0"), listaLeiturasCiclo[i].T3.ToString("##.0"),
                            listaLeiturasCiclo[i].T4.ToString("##.0"));
                        contGeral += 2;
                    }

                    int contTrat = 1;
                    //Leituras do Tratamento
                    for (int i = 0; i < listaLeiturasTrat.Count; i += 2)
                    {
                        dtgTratamento.Rows.Add(contTrat.ToString("000"), contGeral.ToString("000"),
                            listaLeiturasTrat[i].horario, listaLeiturasTrat[i].T1.ToString("##.0"),
                            listaLeiturasTrat[i].T2.ToString("##.0"), listaLeiturasTrat[i].T3.ToString("##.0"),
                            listaLeiturasTrat[i].T4.ToString("##.0"));
                        contTrat += 2;
                        contGeral += 2;
                        dtgTratamento.Rows[dtgTratamento.RowCount - 1].DefaultCellStyle.BackColor = Color.PaleGreen;
                    }

                    //Leituras Posteriores ao Tratamento
                    for (int i = contGeral; i < listaLeiturasCiclo.Count; i += 2)
                    {
                        dtgTratamento.Rows.Add("--", contGeral.ToString("000"), listaLeiturasCiclo[i - 1].horario,
                            listaLeiturasCiclo[i - 1].T1.ToString("##.0"),
                            listaLeiturasCiclo[i - 1].T2.ToString("##.0"), listaLeiturasCiclo[i - 1].T3.ToString("##.0"),
                            listaLeiturasCiclo[i - 1].T4.ToString("##.0"));
                        contGeral += 2;
                    }*/
                }
            }
            else if(ciclo.tipoCRG == 150)
            {
                foreach (var leiturasCiclo in listaLeiturasCiclo)
                {
                    dtgCiclo.Rows.Add((dtgCiclo.Rows.Count + 1).ToString("000"), leiturasCiclo.horario,
                        leiturasCiclo.T1.ToString(),
                        leiturasCiclo.T2.ToString(), leiturasCiclo.T3.ToString(),
                        leiturasCiclo.T4.ToString());
                    if (ciclo.NLIniTrat == dtgCiclo.Rows.Count)
                        dtgCiclo.Rows[dtgCiclo.Rows.Count - 1].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                int contGeral = 1;
                var listaTratamento = new List<ListaCiclosTratGrafico>();
                if (listaLeiturasTrat.Count > 0 && ciclo.nlt == ciclo.tempoTrat)
                {
                    listaTratamento = RelTratamento.populaTratamento(ciclo, listaLeiturasCiclo, listaLeiturasTrat,
                        config);
                }
                if (listaTratamento.Count > 0)
                {
                    var nlt_inicio_tratamento = 0;
                    var nlt_fim_tratamento = 0;
                    foreach (var item in listaTratamento.ToList())
                    {
                        if (item.demarca_tratamento)
                        {
                            if (nlt_inicio_tratamento == 0)
                            {
                                nlt_inicio_tratamento = item.NLT;
                            }
                            else
                            {
                                nlt_fim_tratamento = item.NLT;
                            }
                        }
                        dtgTratamento.Rows.Add(item.NLT.ToString("000"), item.NL.ToString("000"), item.horario,
                            item.T1.ToString(), item.T2.ToString(), item.T3.ToString(),
                            item.T4.ToString());
                    }
                    foreach (DataGridViewRow row in dtgTratamento.Rows)
                    {
                        var nlt_value = Convert.ToInt32(row.Cells[0].Value);
                        if (nlt_value >= nlt_inicio_tratamento && nlt_value <= nlt_fim_tratamento)
                        {
                            row.DefaultCellStyle.BackColor = Color.PaleGreen;
                        }
                    }
                    //Leituras Anteriores ao Tratamento
                    /*for (int i = 0; i < ciclo.nlAntesTrat; i += 2)
                    {
                        dtgTratamento.Rows.Add("--", contGeral.ToString("000"), listaLeiturasCiclo[i].horario,
                            listaLeiturasCiclo[i].T1.ToString(),
                            listaLeiturasCiclo[i].T2.ToString(), listaLeiturasCiclo[i].T3.ToString(),
                            listaLeiturasCiclo[i].T4.ToString());
                        contGeral += 2;
                    }

                    int contTrat = 1;
                    //Leituras do Tratamento
                    for (int i = 0; i < listaLeiturasTrat.Count; i += 2)
                    {
                        dtgTratamento.Rows.Add(contTrat.ToString("000"), contGeral.ToString("000"),
                            listaLeiturasTrat[i].horario, listaLeiturasTrat[i].T1.ToString(),
                            listaLeiturasTrat[i].T2.ToString(), listaLeiturasTrat[i].T3.ToString(),
                            listaLeiturasTrat[i].T4.ToString());
                        contTrat += 2;
                        contGeral += 2;
                        dtgTratamento.Rows[dtgTratamento.RowCount - 1].DefaultCellStyle.BackColor = Color.PaleGreen;
                    }

                    //Leituras Posteriores ao Tratamento
                    for (int i = contGeral; i < listaLeiturasCiclo.Count; i += 2)
                    {
                        dtgTratamento.Rows.Add("--", contGeral.ToString("000"), listaLeiturasCiclo[i - 1].horario,
                            listaLeiturasCiclo[i - 1].T1.ToString(),
                            listaLeiturasCiclo[i - 1].T2.ToString(), listaLeiturasCiclo[i - 1].T3.ToString(),
                            listaLeiturasCiclo[i - 1].T4.ToString());
                        contGeral += 2;
                    }*/
                }
            }
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            VO.Ciclos ciclo = CicloDAO.buscaCiclo(crg, idCiclo);
            OpcoesImpressao impressao = new OpcoesImpressao(ciclo);
            impressao.ShowDialog(this);
        }

        private void Produtos_Click(object sender, EventArgs e)
        {
            VO.Ciclos ciclo = CicloDAO.buscaCiclo(crg, idCiclo);
            List<ProdutoCiclo> listaProdutos = ProdutoCicloDAO.listaProdutosCiclo(ciclo);
            DetalhesProdutosCiclo produtos = new DetalhesProdutosCiclo(listaProdutos);
            produtos.ShowDialog(this);
        }

        private void Grafico_Click(object sender, EventArgs e)
        {
            VO.Ciclos ciclo = CicloDAO.buscaCiclo(crg, idCiclo);
            Grafico grafico = new Grafico(ciclo);
            grafico.ShowDialog(this);
        }
    }
}
