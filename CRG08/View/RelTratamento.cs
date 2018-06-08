using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CRG08.Dao;
using CRG08.VO;
using Microsoft.Reporting.WinForms;
using CRG08.BO;

namespace CRG08.View
{
    public partial class RelTratamento : Form
    {
        private VO.Ciclos ciclo;
        private int opcao;
        private string comentario = "", empresa;
        private ConfiguracaoRelatorio configRelatorio;

        public RelTratamento()
        {
            InitializeComponent();
        }

        public RelTratamento(VO.Ciclos ciclo, int opcao, string empresa, string comentario, ConfiguracaoRelatorio configRelatorio)
        {
            InitializeComponent();
            this.ciclo = ciclo;
            this.opcao = opcao;
            this.empresa = empresa;
            this.comentario = comentario;
            this.configRelatorio = configRelatorio;
        }

        /*public static List<ListaCiclosTratGrafico> populaTratamentoNovo(VO.Ciclos ciclo,
            List<LeiturasCiclo> leiturasCiclo, List<LeiturasTrat> leiturasTrat)
        {
            var listaRetorno = new List<ListaCiclosTratGrafico>();
            if (leiturasTrat == null || leiturasTrat.Count == 0) return listaRetorno;

            var cntAntesTrat = ciclo.NLIniTrat-1;
            int nl = 1, nlt = 1;
            var jmp_AntesTrat = cntAntesTrat/9;
        }*/

        public static List<int> PegarIndicesPorDivisao(int indiceInicial, int indiceFinal, int qtdMaxima)
        {
            var listaRetorno = new List<int>();
            var total = indiceFinal - indiceInicial + 1;
            if (qtdMaxima >= total-1)
            {
                for (var i = 0; i < total; i++)
                {
                    listaRetorno.Add(indiceInicial + i);
                }
                return listaRetorno;
            }
            var totalDentro = total - 2;

            //var jmp = ((double)totalDentro) / qtdMaxima;
            var jmp = (double)total / qtdMaxima;

            listaRetorno.Add(indiceInicial);

            double totaljmp = indiceInicial + jmp;
            for (var i = 1; i < qtdMaxima - 1; i++)
            {
                var ind = Convert.ToInt32(Math.Round(totaljmp));
                listaRetorno.Add(ind);
                totaljmp += jmp;
            }

            listaRetorno.Add(indiceFinal);

            return listaRetorno;
        }

        public static List<ListaCiclosTratGrafico> GerarListaTratamento(VO.Ciclos ciclo,
            List<LeiturasCiclo> leiturasCiclo,
            List<LeiturasTrat> leiturasTrat, ConfiguracaoRelatorio configRelatorio)
        {
            var listaRetorno = new List<ListaCiclosTratGrafico>();
            var linhasAntesTrat = configRelatorio.LeiturasAntes;
            var linhasTrat = configRelatorio.LeiturasTrat;
            var linhasDepoisTrat = configRelatorio.LeiturasDepois;
            if (leiturasTrat == null || leiturasTrat.Count == 0) return listaRetorno;

            var totalCiclo = leiturasCiclo.Count;
            var totalAntesTrat = ciclo.NLIniTrat-1;
            var inicioTrat = ciclo.NLIniTrat;
            var totalTrat = leiturasTrat.Count;
            var fimTrat = inicioTrat + totalTrat - 1;
            var totalDepoisTrat = totalCiclo - fimTrat;
            var nlt = 0;


            /// POPULA DADOS DO AQUECIMENTO

            //if (totalAntesTrat <= linhasAntesTrat)
            //{
            //    for (var i = 0; i < totalAntesTrat; i++)
            //    {
            //        nlt++;
            //        listaRetorno.Add(new ListaCiclosTratGrafico()
            //        {
            //            NLT = nlt,
            //            NL = i + 1,
            //            horario = leiturasCiclo[i].horario,
            //            T1 = leiturasCiclo[i].T1,
            //            T2 = leiturasCiclo[i].T2,
            //            T3 = leiturasCiclo[i].T3,
            //            T4 = leiturasCiclo[i].T4
            //        });
            //    }
            //}
            //else
            //{
                var indicesAntesTrat = PegarIndicesPorDivisao(0, totalAntesTrat - 1, linhasAntesTrat);
                foreach (var indice in indicesAntesTrat.ToList())
                {
                    nlt++;
                    listaRetorno.Add(new ListaCiclosTratGrafico()
                    {
                        NLT = nlt,
                        NL = indice+1,
                        horario = leiturasCiclo[indice].horario,
                        T1 = leiturasCiclo[indice].T1,
                        T2 = leiturasCiclo[indice].T2,
                        T3 = leiturasCiclo[indice].T3,
                        T4 = leiturasCiclo[indice].T4
                    });
                }
            //}

            /// POPULA DADOS DO TRATAMENTO

            //if (totalTrat < linhasTrat)
            //{
            //    for (var i = 0; i < totalTrat; i++)
            //    {
            //        nlt++;
            //        listaRetorno.Add(new ListaCiclosTratGrafico()
            //        {
            //            NLT = nlt,
            //            NL = inicioTrat + i,
            //            horario = leiturasCiclo[i].horario,
            //            T1 = leiturasCiclo[i].T1,
            //            T2 = leiturasCiclo[i].T2,
            //            T3 = leiturasCiclo[i].T3,
            //            T4 = leiturasCiclo[i].T4
            //        });
            //    }
            //}
            //else
            //{
                var indicesTrat = PegarIndicesPorDivisao(0, totalTrat-1, linhasTrat);
                foreach (var indice in indicesTrat.ToList())
                {
                    nlt++;
                    listaRetorno.Add(new ListaCiclosTratGrafico()
                    {
                        NLT = nlt,
                        NL = inicioTrat+indice,
                        horario = leiturasTrat[indice].horario,
                        T1 = leiturasTrat[indice].T1,
                        T2 = leiturasTrat[indice].T2,
                        T3 = leiturasTrat[indice].T3,
                        T4 = leiturasTrat[indice].T4,
                        demarca_tratamento = indice==0||indice==(totalTrat-1)
                    });
                }
            //}
            

            /// POPULA DADOS DO RESFRIAMENTO

            //if (totalDepoisTrat <= linhasDepoisTrat)
            //{
            //    for (var i = fimTrat; i < totalCiclo; i++)
            //    {
            //        nlt++;
            //        listaRetorno.Add(new ListaCiclosTratGrafico()
            //        {
            //            NLT = nlt,
            //            NL = i + 1,
            //            horario = leiturasCiclo[i].horario,
            //            T1 = leiturasCiclo[i].T1,
            //            T2 = leiturasCiclo[i].T2,
            //            T3 = leiturasCiclo[i].T3,
            //            T4 = leiturasCiclo[i].T4
            //        });
            //    }
            //}
            //else
            //{
                var indicesDepoisTrat = PegarIndicesPorDivisao(fimTrat, totalCiclo - 1, linhasDepoisTrat);
                foreach (var indice in indicesDepoisTrat.ToList())
                {
                    nlt++;
                    listaRetorno.Add(new ListaCiclosTratGrafico()
                    {
                        NLT = nlt,
                        NL = indice + 1,
                        horario = leiturasCiclo[indice].horario,
                        T1 = leiturasCiclo[indice].T1,
                        T2 = leiturasCiclo[indice].T2,
                        T3 = leiturasCiclo[indice].T3,
                        T4 = leiturasCiclo[indice].T4
                    });
                }
            //}

            return listaRetorno;
        }

        public static List<ListaCiclosTratGrafico> populaTratamento(VO.Ciclos ciclo, List<LeiturasCiclo> leiturasCiclo,
            List<LeiturasTrat> leiturasTrat, ConfiguracaoRelatorio configRelatorio)
        {

            return GerarListaTratamento(ciclo, leiturasCiclo, leiturasTrat, configRelatorio);
            /*if (leiturasTrat == null || leiturasTrat.Count == 0)
            {
                return listaRetorno;
            }
            var nl = 1;
            var nlt = 1;
            var leiturainicial = ciclo.NLIniTrat;
            var jmp = (leiturainicial - 1) / 9;
            var i = 0;

            for (i = 0; i < ciclo.NLIniTrat - 1; i += jmp, nl += jmp)
            {
                listaRetorno.Add(new ListaCiclosTratGrafico()
                {
                    NLT = nlt,
                    NL = nl,
                    horario = leiturasCiclo[i].horario,
                    T1 = leiturasCiclo[i].T1,
                    T2 = leiturasCiclo[i].T2,
                    T3 = leiturasCiclo[i].T3,
                    T4 = leiturasCiclo[i].T4
                });
                nlt++;
            }
            if (i <= ciclo.NLIniTrat - 1)
            {
                nl = leiturainicial - 1;
                nlt = 10;
                listaRetorno.Add(new ListaCiclosTratGrafico()
                {
                    NLT = nlt,
                    NL = nl,
                    horario = leiturasCiclo[ciclo.NLIniTrat-2].horario,
                    T1 = leiturasCiclo[ciclo.NLIniTrat - 2].T1,
                    T2 = leiturasCiclo[ciclo.NLIniTrat - 2].T2,
                    T3 = leiturasCiclo[ciclo.NLIniTrat - 2].T3,
                    T4 = leiturasCiclo[ciclo.NLIniTrat - 2].T4
                });
                nlt = 11;
            }


            nl = ciclo.NLIniTrat;

            for (i = 0; i <= leiturasTrat.Count - 1; i += 2, nl += 2)
            {
                listaRetorno.Add(new ListaCiclosTratGrafico()
                {
                    NLT = nlt,
                    NL = nl,
                    horario = leiturasTrat[i].horario,
                    T1 = leiturasTrat[i].T1,
                    T2 = leiturasTrat[i].T2,
                    T3 = leiturasTrat[i].T3,
                    T4 = leiturasTrat[i].T4
                });
                if (i == 0)
                {
                    listaRetorno[listaRetorno.Count - 1].demarca_tratamento = true;
                }
                nlt++;
            }
            if (i == leiturasTrat.Count)
            {
                nl = ciclo.NLIniTrat + leiturasTrat.Count - 1;
                listaRetorno.Add(new ListaCiclosTratGrafico()
                {
                    NLT = nlt,
                    NL = nl,
                    horario = leiturasTrat[leiturasTrat.Count - 1].horario,
                    T1 = leiturasTrat[leiturasTrat.Count - 1].T1,
                    T2 = leiturasTrat[leiturasTrat.Count - 1].T2,
                    T3 = leiturasTrat[leiturasTrat.Count - 1].T3,
                    T4 = leiturasTrat[leiturasTrat.Count - 1].T4
                });
                nlt++;
            }

            listaRetorno[listaRetorno.Count - 1].demarca_tratamento = true;

            nl = ciclo.NLIniTrat + ciclo.nlt;

            var countFim = ciclo.nlPostTrat;
            jmp = countFim / 9;

            for (i = 0; i < countFim; i += 2, nl += 2)
            {
                listaRetorno.Add(new ListaCiclosTratGrafico()
                {
                    NLT = nlt,
                    NL = nl,
                    horario = leiturasCiclo[nl - 1].horario,
                    T1 = leiturasCiclo[nl - 1].T1,
                    T2 = leiturasCiclo[nl - 1].T2,
                    T3 = leiturasCiclo[nl - 1].T3,
                    T4 = leiturasCiclo[nl - 1].T4
                });
                nlt++;
            }
            if (i < leiturasCiclo.Count - 1)
            {
                nl = leiturasCiclo.Count;
                listaRetorno.Add(new ListaCiclosTratGrafico()
                {
                    NLT = nlt,
                    NL = nl,
                    horario = leiturasCiclo[leiturasCiclo.Count - 1].horario,
                    T1 = leiturasCiclo[leiturasCiclo.Count - 1].T1,
                    T2 = leiturasCiclo[leiturasCiclo.Count - 1].T2,
                    T3 = leiturasCiclo[leiturasCiclo.Count - 1].T3,
                    T4 = leiturasCiclo[leiturasCiclo.Count - 1].T4
                });
            }
            return listaRetorno;*/

        }

        private VO.Ciclos TransformaEmListaCorreta(VO.Ciclos c)
        {
            var listaLeiturasCiclo = new List<LeiturasCiclo>();
            var listaLeiturasTrat = new List<LeiturasTrat>();

            listaLeiturasCiclo = LeiturasCicloDAO.ListaLeiturasCiclos(c);
            listaLeiturasTrat = LeiturasTratDAO.ListaLeiturasTratamento(c);

            return new VO.Ciclos();

        }

        private void RelTratamento_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.EnableExternalImages = true;
            
            var fieldInfo = typeof(Microsoft.Reporting.WinForms.RenderingExtension).GetField("m_isVisible", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            foreach (var extension in this.reportViewer1.LocalReport.ListRenderingExtensions())
            {

                if (string.Compare("Excel", extension.Name) == 0)
                    fieldInfo.SetValue(extension, false);
                else if (string.Compare("WORD", extension.Name) == 0)
                    fieldInfo.SetValue(extension, false);
                else if (string.Compare("EXCELOPENXML", extension.Name) == 0) fieldInfo.SetValue(extension, false);
                else if (string.Compare("WORDOPENXML", extension.Name) == 0) fieldInfo.SetValue(extension, false);
            }

            List<ProdutoCiclo> listaProdutos;
            if (empresa != "")
            {
                int idEmpresa = EmpresaCicloDAO.retornaID(empresa);
                listaProdutos = ProdutoCicloDAO.listaProdutosCicloPorEmpresa(ciclo,idEmpresa);
            }
            else listaProdutos = ProdutoCicloDAO.listaProdutosCiclo(ciclo);
            var listaLeiturasTrat = LeiturasTratDAO.ListaLeiturasTratamento(ciclo);
            var listaLeiturasCiclo = LeiturasCicloDAO.ListaLeiturasCiclos(ciclo);

            var strProdutos = string.Empty;
            foreach (var p in listaProdutos)
            {
                strProdutos += p.produto.descricao + " com " + p.volume + " " + p.unidade.unidade + " - " +
                           p.empresa.nome + Environment.NewLine;
            }

            RelatorioUtils.GerarQrCode($"Relatório do Controlador Nº {ciclo.crg} {Environment.NewLine}Nº Série: {ciclo.numSerie}{Environment.NewLine}" +
                $"Tratamento Nº {ciclo.nTrat}{Environment.NewLine}" +
                $"Nº de leituras: {ciclo.nl}{Environment.NewLine}{Environment.NewLine}" +
                $"Período do ciclo: {Environment.NewLine}Início: {ciclo.dataInicio}{Environment.NewLine}Fim: {ciclo.dataFim}{Environment.NewLine}{Environment.NewLine}" +
                $"Temperatura de Controle {Environment.NewLine}Tc: {ciclo.temperaturaControle} ºC{Environment.NewLine}{Environment.NewLine}" +
                $"Temperatura do Tratamento {Environment.NewLine}Tt: {ciclo.temperaturaTrat} ºC{Environment.NewLine}{Environment.NewLine}" +
                $"Tempo do Tratamento {Environment.NewLine}tt: {ciclo.tempoTrat} minuto(s){Environment.NewLine}{Environment.NewLine}" +
                (!string.IsNullOrWhiteSpace(ciclo.VolumeFixo) ? $"Volume total: {Environment.NewLine}" + ciclo.VolumeFixo + (ciclo.IsMetrosCubicos ? "m³" : " peças") + Environment.NewLine + Environment.NewLine : "") + 
                (listaLeiturasTrat?.Count > 0 
                    ? $"Início do Tratamento{Environment.NewLine}Leitura: {ciclo.NLIniTrat}{Environment.NewLine}Data: {ciclo.dataIniTrat}{Environment.NewLine}(concluído)"
                    : "Não realizou tratamento") + Environment.NewLine + Environment.NewLine +
                $"Responsável Técnico: {Environment.NewLine}{ciclo.responsavel}{Environment.NewLine}{Environment.NewLine}" +
                $"Operador: {Environment.NewLine}{ciclo.operador}{Environment.NewLine}{Environment.NewLine}" +
                $"PRODUTOS: {Environment.NewLine}" +
                strProdutos
            );

            ReportParameter Titulo = new ReportParameter("Titulo");
            Titulo.Values.Add("Relatório do Controlador Nº " + ciclo.crg + " (Nº Série: " + ciclo.numSerie + ")");
            ReportParameter Periodo = new ReportParameter("Periodo");
            Periodo.Values.Add("Período do ciclo: " + ciclo.dataInicio + " - " + ciclo.dataFim);
            ReportParameter Tc = new ReportParameter("Tc");
            Tc.Values.Add("   - Temperatura de Controle (Tc): " + ciclo.temperaturaControle + " ºC");
            ReportParameter Tt = new ReportParameter("Tt");
            Tt.Values.Add("   - Temperatura do Tratamento (Tt): " + ciclo.temperaturaTrat + " ºC");
            ReportParameter tempoT = new ReportParameter("tempoT");
            tempoT.Values.Add("   - Tempo do Tratamento (tt): " + ciclo.tempoTrat + " minuto(s)");
            ReportParameter Controlador = new ReportParameter("Controlador");
            Controlador.Values.Add("Controlador nº " + ciclo.crg + " com " + ciclo.nl + " leituras(NTrat: " +
                                   ciclo.nTrat + ")");
            ReportParameter Descricao = new ReportParameter("Descricao");
            Descricao.Values.Add("Descrição: " + ciclo.descricao);
            ReportParameter VolumeFixo = new ReportParameter("VolumeFixo");
            if (!string.IsNullOrWhiteSpace(ciclo.VolumeFixo))
            {
                VolumeFixo.Values.Add("Volume total: " + ciclo.VolumeFixo + (ciclo.IsMetrosCubicos ? "m³" : " peças"));
            }
            else
            {
                VolumeFixo.Values.Add("");
            }
            ReportParameter Tratamento = new ReportParameter("Tratamento");
            if (listaLeiturasCiclo != null && listaLeiturasTrat.Count > 0)
                Tratamento.Values.Add("Início do Tratamento na leitura " + ciclo.NLIniTrat + " - " + ciclo.dataIniTrat +
                                      "(concluído)");
            else
                Tratamento.Values.Add("Não realizou o tratamento");
            ReportParameter Responsavel = new ReportParameter("Responsavel");
            Responsavel.Values.Add("Responsável Técnico: " + ciclo.responsavel);
            ReportParameter Operador = new ReportParameter("Operador");
            Operador.Values.Add("Operador: " + ciclo.operador);
            ReportParameter Produtos = new ReportParameter("Produtos");
            string produtos = "";
            foreach (var p in listaProdutos)
                produtos = produtos + p.produto.descricao + " com " + p.volume + " " + p.unidade.unidade + " - " +
                           p.empresa.nome + " \n";
            Produtos.Values.Add(produtos);
            ReportParameter path = new ReportParameter("path");
            path.Values.Add(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath) ?? string.Empty, "Image.png"));
            ReportParameter qrCode = new ReportParameter("QrCodePath");

            qrCode.Values.Add(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath) ?? string.Empty, "qrcode.png"));
            ReportParameter coment = new ReportParameter("Comentario");
            coment.Values.Add("Comentário: " + comentario);

            VO.Empresa empresaCiclo = EmpresaDAO.retornaEmpresa();
            if (empresaCiclo != null)
                dataSetGeral.Empresa.AddEmpresaRow(empresaCiclo.Nome, empresaCiclo.Endereco, empresaCiclo.Cep, empresaCiclo.Cidade,
                    empresaCiclo.UF,
                    empresaCiclo.Fone, empresaCiclo.Fax, empresaCiclo.CNPJ, empresaCiclo.IE, empresaCiclo.NCredenciamento, empresaCiclo.Logo);
            else dataSetGeral.Empresa.AddEmpresaRow("", "", "", "", -1, "", "", "", "", "", null);

            var maskSensores = ciclo.tipoCRG == 150 ? "" : "#0.0";

            int aux = 1, nl = 1, nlt = 1;
            if (listaLeiturasTrat != null && listaLeiturasTrat.Count > 0)
            {
                var puloleitura = (ciclo.NLIniTrat - 1)/10;
                var lista = populaTratamento(ciclo, listaLeiturasCiclo, listaLeiturasTrat, configRelatorio);

                foreach (var item in lista.ToList())
                {
                    dataSetGeral.Tratamento.AddTratamentoRow(item.NLT.ToString("000"), item.NL.ToString("000"),
                        item.horario, item.T1.ToString(maskSensores),
                        item.T2.ToString(maskSensores),
                        item.T3.ToString(maskSensores),
                        item.T4.ToString(maskSensores));
                }
                
                var primeiro = true;
                ReportParameter p1 = null, p2 = null;
                foreach (var item in lista.ToList())
                {
                    if (item.demarca_tratamento == true)
                    {
                        if (primeiro)
                        {
                            p1 = new ReportParameter("nlt_inicio", item.NLT.ToString("000"));
                            primeiro = false;
                        }
                        else
                        {
                            p2 = new ReportParameter("nlt_fim", item.NLT.ToString("000"));
                            break;
                        }
                    }
                }
                if (p1 != null)
                {
                    reportViewer1.LocalReport.SetParameters(p1);
                }
                if (p2 != null)
                {
                    reportViewer1.LocalReport.SetParameters(p2);
                }

                Grafico grafico = new Grafico(ciclo, 2, lista);
                grafico.ShowDialog(this);

                //Leituras antes do Tratamento
                /*for (int i = 0; i < ciclo.nlAntesTrat; i += 2)
                {
                    dataSetGeral.Tratamento.AddTratamentoRow("--", nl.ToString("000"),
                        listaLeiturasCiclo[i].horario, listaLeiturasCiclo[i].T1.ToString("00.0"),
                        listaLeiturasCiclo[i].T2.ToString("00.0"),
                        listaLeiturasCiclo[i].T3.ToString("00.0"), listaLeiturasCiclo[i].T4.ToString("00.0"));
                    nl += 2;
                }*/
                /*for (int i = 0; i < ciclo.NLIniTrat; i += puloleitura)
                {
                    dataSetGeral.Tratamento.AddTratamentoRow(nlt.ToString("000"), nl.ToString("000"),
                        listaLeiturasCiclo[i].horario, listaLeiturasCiclo[i].T1.ToString("00.0"),
                        listaLeiturasCiclo[i].T2.ToString("00.0"),
                        listaLeiturasCiclo[i].T3.ToString("00.0"), listaLeiturasCiclo[i].T4.ToString("00.0"));
                    nl += puloleitura;
                    nlt++;
                }
                nl = ciclo.NLIniTrat;
                //Leituras do Tratamento
                puloleitura = listaLeiturasTrat.Count/20;

                for (int i = 0; i < listaLeiturasTrat.Count; i += 2)
                {
                    dataSetGeral.Tratamento.AddTratamentoRow(aux.ToString("000"), nl.ToString("000"),
                        listaLeiturasTrat[i].horario, listaLeiturasTrat[i].T1.ToString("00.0"),
                        listaLeiturasTrat[i].T2.ToString("00.0"),
                        listaLeiturasTrat[i].T3.ToString("00.0"), listaLeiturasTrat[i].T4.ToString("00.0"));
                    aux += 2;
                    nl += 2;
                }
                nl = listaLeiturasCiclo.Count - 20;
                //Leituras após o tratamento
                for (int i = 0; i < ciclo.nlPostTrat; i += 2)
                {
                    dataSetGeral.Tratamento.AddTratamentoRow("--", nl.ToString("000"),
                        listaLeiturasCiclo[nl - 1].horario, listaLeiturasCiclo[nl - 1].T1.ToString("00.0"),
                        listaLeiturasCiclo[nl - 1].T2.ToString("00.0"),
                        listaLeiturasCiclo[nl - 1].T3.ToString("00.0"), listaLeiturasCiclo[nl - 1].T4.ToString("00.0"));
                    nl += 2;
                }*/

                int tamanho = dataSetGeral.Tratamento.Count/2;
                int resto = dataSetGeral.Tratamento.Count%2;
                if (resto == 1)
                {
                    for (int i = 0; i < tamanho + 1; i++)
                    {
                        dataSetGeral.Tratamento1.AddTratamento1Row(dataSetGeral.Tratamento[i].NLT,
                            dataSetGeral.Tratamento[i].NL, dataSetGeral.Tratamento[i].Hora,
                            dataSetGeral.Tratamento[i].T1, dataSetGeral.Tratamento[i].T2, dataSetGeral.Tratamento[i].T3,
                            dataSetGeral.Tratamento[i].T4);
                    }
                    for (int i = tamanho + 1; i < dataSetGeral.Tratamento.Count; i++)
                    {
                        dataSetGeral.Tratamento2.AddTratamento2Row(dataSetGeral.Tratamento[i].NLT,
                            dataSetGeral.Tratamento[i].NL, dataSetGeral.Tratamento[i].Hora,
                            dataSetGeral.Tratamento[i].T1, dataSetGeral.Tratamento[i].T2, dataSetGeral.Tratamento[i].T3,
                            dataSetGeral.Tratamento[i].T4);
                    }
                }
                if (resto == 0)
                {
                    for (int i = 0; i < tamanho; i++)
                    {
                        dataSetGeral.Tratamento1.AddTratamento1Row(dataSetGeral.Tratamento[i].NLT,
                            dataSetGeral.Tratamento[i].NL, dataSetGeral.Tratamento[i].Hora,
                            dataSetGeral.Tratamento[i].T1, dataSetGeral.Tratamento[i].T2, dataSetGeral.Tratamento[i].T3,
                            dataSetGeral.Tratamento[i].T4);
                    }
                    for (int i = tamanho; i < dataSetGeral.Tratamento.Count; i++)
                    {
                        dataSetGeral.Tratamento2.AddTratamento2Row(dataSetGeral.Tratamento[i].NLT,
                            dataSetGeral.Tratamento[i].NL, dataSetGeral.Tratamento[i].Hora,
                            dataSetGeral.Tratamento[i].T1, dataSetGeral.Tratamento[i].T2, dataSetGeral.Tratamento[i].T3,
                            dataSetGeral.Tratamento[i].T4);
                    }
                }
            }

            

            reportViewer1.LocalReport.SetParameters(Titulo);
            reportViewer1.LocalReport.SetParameters(Periodo);
            reportViewer1.LocalReport.SetParameters(Tc);
            reportViewer1.LocalReport.SetParameters(Tt);
            reportViewer1.LocalReport.SetParameters(tempoT);
            reportViewer1.LocalReport.SetParameters(Controlador);
            reportViewer1.LocalReport.SetParameters(Descricao);
            reportViewer1.LocalReport.SetParameters(Tratamento);
            reportViewer1.LocalReport.SetParameters(Responsavel);
            reportViewer1.LocalReport.SetParameters(Operador);
            reportViewer1.LocalReport.SetParameters(Produtos);
            reportViewer1.LocalReport.SetParameters(path);
            reportViewer1.LocalReport.SetParameters(qrCode);
            reportViewer1.LocalReport.SetParameters(new ReportParameter("ExibirQrCode", "false"));
            reportViewer1.LocalReport.SetParameters(coment);
            reportViewer1.LocalReport.SetParameters(VolumeFixo);

            empresaBindingSource.DataSource = dataSetGeral.Empresa;
            tratamento1BindingSource.DataSource = dataSetGeral.Tratamento1;
            comentarioBindingSource.DataSource = dataSetGeral.Comentario;
            tratamento2BindingSource.DataSource = dataSetGeral.Tratamento2;

            this.reportViewer1.RefreshReport();
            reportViewer1.LocalReport.EnableExternalImages = true;
        }
    }
}
