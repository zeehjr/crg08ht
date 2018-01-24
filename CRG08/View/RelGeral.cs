using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CRG08.Dao;
using CRG08.View;
using CRG08.VO;
using Microsoft.Reporting.WinForms;

namespace CRG08
{
    public partial class RelGeral : Form
    {
        private VO.Ciclos ciclo;
        private int opcao;
        private string comentario, empresa, filtro;
        List<string> ordemFiltro = new List<string>();
        private ConfiguracaoRelatorio configRelatorio;

        public RelGeral()
        {
            InitializeComponent();
        }

        public RelGeral(VO.Ciclos ciclo, int opcao, string empresa, string comentario, string filtro, ConfiguracaoRelatorio configRelatorio)
        {
            InitializeComponent();
            this.ciclo = ciclo;
            this.opcao = opcao;
            this.empresa = empresa;
            this.comentario = comentario;
            this.filtro = filtro;
            this.configRelatorio = configRelatorio;
        }

        private void RelGeral_Load(object sender, EventArgs e)
        {
            var fieldInfo = typeof(Microsoft.Reporting.WinForms.RenderingExtension).GetField("m_isVisible", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            foreach (var extension in this.reportViewer1.LocalReport.ListRenderingExtensions())
            {
                if (string.Compare("Excel", extension.Name) == 0)
                    fieldInfo.SetValue(extension, false);
                else if (string.Compare("WORD", extension.Name) == 0)
                    fieldInfo.SetValue(extension, false);
            }

            List<ProdutoCiclo> listaProdutos;
            if (empresa != "")
            {
                int idEmpresa = EmpresaCicloDAO.retornaID(empresa);
                listaProdutos = ProdutoCicloDAO.listaProdutosCicloPorEmpresa(ciclo, idEmpresa);
            }
            else listaProdutos = ProdutoCicloDAO.listaProdutosCiclo(ciclo);
            var listaLeiturasTrat = LeiturasTratDAO.ListaLeiturasTratamento(ciclo);
            var listaLeiturasCiclo = LeiturasCicloDAO.ListaLeiturasCiclos(ciclo);

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
            Controlador.Values.Add("Controlador nº " + ciclo.crg + " com " + ciclo.nl + " leituras(NTrat: " + ciclo.nTrat + ")");
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
            if(listaLeiturasCiclo != null && listaLeiturasTrat.Count > 0)
                Tratamento.Values.Add("Início do Tratamento na leitura " + ciclo.NLIniTrat + " - " + ciclo.dataIniTrat + "(concluído)");
            else 
                Tratamento.Values.Add("Não realizou o tratamento");
            ReportParameter Responsavel = new ReportParameter("Responsavel");
            Responsavel.Values.Add("Responsável Técnico: " + ciclo.responsavel);
            ReportParameter Operador = new ReportParameter("Operador");
            Operador.Values.Add("Operador: " + ciclo.operador);
            ReportParameter Produtos = new ReportParameter("Produtos");
            string produtos = "";
            for (int i = 0; i < listaProdutos.Count; i++) 
            {
                produtos = produtos + listaProdutos[i].produto.descricao + " com " + listaProdutos[i].volume + " "
                + listaProdutos[i].unidade.unidade + " - " + listaProdutos[i].empresa.nome;
                if ((i+1) < listaProdutos.Count) produtos = produtos + " \n";
            }
            Produtos.Values.Add(produtos);
            ReportParameter NLIniTrat = new ReportParameter("NLIniTrat");
            NLIniTrat.Values.Add(ciclo.NLIniTrat.ToString("000"));
            ReportParameter Comentario = new ReportParameter("Comentario");
            Comentario.Values.Add("Comentário: "+ comentario);

            VO.Empresa dadosEmpresa = EmpresaDAO.retornaEmpresa();
            if (dadosEmpresa != null)
                DataSetGeral.Empresa.AddEmpresaRow(dadosEmpresa.Nome, dadosEmpresa.Endereco, dadosEmpresa.Cep, dadosEmpresa.Cidade,
                    dadosEmpresa.UF,
                    dadosEmpresa.Fone, dadosEmpresa.Fax, dadosEmpresa.CNPJ, dadosEmpresa.IE, dadosEmpresa.NCredenciamento, dadosEmpresa.Logo);
            else DataSetGeral.Empresa.AddEmpresaRow("", "", "", "", -1, "", "", "", "", "", null);

            var maskSensores = ciclo.tipoCRG == 150 ? "" : "#0.0";

            //Forma lista com dados dos Ciclo
            if (filtro == "")
            {
                for (int i = 0; i < listaLeiturasCiclo.Count; i++)
                    DataSetGeral.Ciclo.AddCicloRow((i + 1).ToString("000"), listaLeiturasCiclo[i].horario,
                        listaLeiturasCiclo[i].T1.ToString(maskSensores),
                        listaLeiturasCiclo[i].T2.ToString(maskSensores), listaLeiturasCiclo[i].T3.ToString(maskSensores),
                        listaLeiturasCiclo[i].T4.ToString(maskSensores));
            }
            else
            {
                int contLista = 0;
                for (int i = 0; i < filtro.Length; i++)
                {
                    int n;
                    //Se é numérico
                    if (Int32.TryParse(filtro.Substring(i, 1), out n))
                    {
                        ordemFiltro.Add(filtro.Substring(i,1));
                        int j = i + 1;
                        bool passou = false;
                        //Enquanto não encontra ";" e "-"
                        while (Int32.TryParse(filtro.Substring(j, 1), out n))
                        {
                            ordemFiltro[contLista] = ordemFiltro[contLista] + filtro.Substring(j, 1);
                            j++;
                            passou = true;
                        }
                        if (passou) i = j - 1;
                        contLista++;
                    }
                     //Se e traçinho
                    else if (filtro.Substring(i, 1) == "-")
                    {
                        ordemFiltro[contLista - 1] = ordemFiltro[contLista - 1] + filtro.Substring(i, 2);
                        int j = i + 2;
                        bool passou = false;
                        //Enquanto não encontra ";" e "-"
                        while (Int32.TryParse(filtro.Substring(j, 1), out n))
                        {
                            ordemFiltro[contLista-1] = ordemFiltro[contLista-1] + filtro.Substring(j, 1);
                            j++;
                            passou = true;
                        }
                        if (passou) i = j - 1;
                        else i = i + 1;
                    }
                        //Se é ;
                    else if (filtro.Substring(i, 1) == ";")
                    {}
                }

                for (int i = 0; i < ordemFiltro.Count; i++)
                {
                    if (ordemFiltro[i].Contains("-"))
                    {
                        string[] numeros = ordemFiltro[i].Split('-');
                        for (int j = Convert.ToInt32(numeros[0]) - 1; j < Convert.ToInt32(numeros[1]); j++)
                        {
                            DataSetGeral.Ciclo.AddCicloRow((j + 1).ToString("000"), listaLeiturasCiclo[j].horario,
                                listaLeiturasCiclo[j].T1.ToString(maskSensores),
                                listaLeiturasCiclo[j].T2.ToString(maskSensores), listaLeiturasCiclo[i].T3.ToString(maskSensores),
                                listaLeiturasCiclo[j].T4.ToString(maskSensores));
                        }
                    }
                    else
                    {
                        int j = Convert.ToInt32(ordemFiltro[i]) - 1;
                        DataSetGeral.Ciclo.AddCicloRow((j + 1).ToString("000"), listaLeiturasCiclo[j].horario,
                                listaLeiturasCiclo[j].T1.ToString(maskSensores),
                                listaLeiturasCiclo[j].T2.ToString(maskSensores), listaLeiturasCiclo[i].T3.ToString(maskSensores),
                                listaLeiturasCiclo[j].T4.ToString(maskSensores));
                    }
                }
            }

            int tamanho = DataSetGeral.Ciclo.Count/2;
            if (DataSetGeral.Ciclo.Count%2 == 0)
            {
                for (int i = 0; i < tamanho; i++)
                {
                    DataSetGeral.Ciclo1.AddCiclo1Row(DataSetGeral.Ciclo[i].NL,
                        DataSetGeral.Ciclo[i].Hora, DataSetGeral.Ciclo[i].T1,
                        DataSetGeral.Ciclo[i].T2, DataSetGeral.Ciclo[i].T3, DataSetGeral.Ciclo[i].T4);
                }
                for (int i = tamanho; i < DataSetGeral.Ciclo.Count; i++)
                {
                    DataSetGeral.Ciclo2.AddCiclo2Row(DataSetGeral.Ciclo[i].NL,
                        DataSetGeral.Ciclo[i].Hora, DataSetGeral.Ciclo[i].T1,
                        DataSetGeral.Ciclo[i].T2, DataSetGeral.Ciclo[i].T3, DataSetGeral.Ciclo[i].T4);
                }
            }
            else
            {
                for (int i = 0; i < tamanho + 1; i++)
                {
                    DataSetGeral.Ciclo1.AddCiclo1Row(DataSetGeral.Ciclo[i].NL,
                        DataSetGeral.Ciclo[i].Hora, DataSetGeral.Ciclo[i].T1,
                        DataSetGeral.Ciclo[i].T2, DataSetGeral.Ciclo[i].T3, DataSetGeral.Ciclo[i].T4);
                }
                for (int i = tamanho + 1; i < DataSetGeral.Ciclo.Count; i++)
                {
                    DataSetGeral.Ciclo2.AddCiclo2Row(DataSetGeral.Ciclo[i].NL,
                        DataSetGeral.Ciclo[i].Hora, DataSetGeral.Ciclo[i].T1,
                        DataSetGeral.Ciclo[i].T2, DataSetGeral.Ciclo[i].T3, DataSetGeral.Ciclo[i].T4);
                }
            }

            
            int aux = 1, nl = 1;

            //Forma a tabela com os dados do tratamento
            //Leituras antes do Tratamento
            ReportParameter p1 = null, p2 = null;
            var listaTratamento = RelTratamento.populaTratamento(ciclo, listaLeiturasCiclo, listaLeiturasTrat, configRelatorio);
            foreach (var item in listaTratamento)
            {
                if (item.demarca_tratamento)
                {
                    if (p1 == null)
                    {
                        p1 = new ReportParameter("nlt_inicio", item.NLT.ToString("000"));
                    }
                    else
                    {
                        p2 = new ReportParameter("nlt_fim", item.NLT.ToString("000"));
                    }
                }
                DataSetGeral.Tratamento.AddTratamentoRow(item.NLT.ToString("000"), item.NL.ToString("000"),
                    item.horario, item.T1.ToString(maskSensores), item.T2.ToString(maskSensores),
                    item.T3.ToString(maskSensores), item.T4.ToString(maskSensores));
            }

            /*for (int i = 0; i < ciclo.nlAntesTrat; i += 2)
            {
                DataSetGeral.Tratamento.AddTratamentoRow("--", nl.ToString("000"),
                    listaLeiturasCiclo[i].horario, listaLeiturasCiclo[i].T1.ToString("00.0"),
                    listaLeiturasCiclo[i].T2.ToString("00.0"),
                    listaLeiturasCiclo[i].T3.ToString("00.0"), listaLeiturasCiclo[i].T4.ToString("00.0"));
                nl += 2;
            }
            nl -= 1;
            //Leituras do Tratamento
            for (int i = 0; i < listaLeiturasTrat.Count; i += 2)
            {
                DataSetGeral.Tratamento.AddTratamentoRow(aux.ToString("000"), nl.ToString("000"),
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
                DataSetGeral.Tratamento.AddTratamentoRow("--", nl.ToString("000"),
                    listaLeiturasCiclo[nl - 1].horario, listaLeiturasCiclo[nl - 1].T1.ToString("00.0"),
                    listaLeiturasCiclo[nl - 1].T2.ToString("00.0"),
                    listaLeiturasCiclo[nl - 1].T3.ToString("00.0"),
                    listaLeiturasCiclo[nl - 1].T4.ToString("00.0"));
                nl += 2;
            }*/

            if (p1 != null && p2 != null)
            {
                reportViewer1.LocalReport.SetParameters(p1);
                reportViewer1.LocalReport.SetParameters(p2);
            }

            tamanho = DataSetGeral.Tratamento.Count / 2;
            if (DataSetGeral.Tratamento.Count % 2 == 0)
            {
                for (int i = 0; i < tamanho; i++)
                {
                    DataSetGeral.Tratamento1.AddTratamento1Row(DataSetGeral.Tratamento[i].NLT,
                        DataSetGeral.Tratamento[i].NL, DataSetGeral.Tratamento[i].Hora,
                        DataSetGeral.Tratamento[i].T1, DataSetGeral.Tratamento[i].T2,
                        DataSetGeral.Tratamento[i].T3,
                        DataSetGeral.Tratamento[i].T4);
                }
                for (int i = tamanho; i < DataSetGeral.Tratamento.Count; i++)
                {
                    DataSetGeral.Tratamento2.AddTratamento2Row(DataSetGeral.Tratamento[i].NLT,
                        DataSetGeral.Tratamento[i].NL, DataSetGeral.Tratamento[i].Hora,
                        DataSetGeral.Tratamento[i].T1, DataSetGeral.Tratamento[i].T2,
                        DataSetGeral.Tratamento[i].T3,
                        DataSetGeral.Tratamento[i].T4);
                }
            }
            else
            {
                for (int i = 0; i < tamanho + 1; i++)
                {
                    DataSetGeral.Tratamento1.AddTratamento1Row(DataSetGeral.Tratamento[i].NLT,
                        DataSetGeral.Tratamento[i].NL, DataSetGeral.Tratamento[i].Hora,
                        DataSetGeral.Tratamento[i].T1, DataSetGeral.Tratamento[i].T2,
                        DataSetGeral.Tratamento[i].T3,
                        DataSetGeral.Tratamento[i].T4);
                }
                for (int i = tamanho + 1; i < DataSetGeral.Tratamento.Count; i++)
                {
                    DataSetGeral.Tratamento2.AddTratamento2Row(DataSetGeral.Tratamento[i].NLT,
                        DataSetGeral.Tratamento[i].NL, DataSetGeral.Tratamento[i].Hora,
                        DataSetGeral.Tratamento[i].T1, DataSetGeral.Tratamento[i].T2,
                        DataSetGeral.Tratamento[i].T3,
                        DataSetGeral.Tratamento[i].T4);
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
            reportViewer1.LocalReport.SetParameters(NLIniTrat);
            reportViewer1.LocalReport.SetParameters(Comentario);
            reportViewer1.LocalReport.SetParameters(VolumeFixo);

            EmpresaBindingSource.DataSource = DataSetGeral.Empresa;
            Tratamento1BindingSource.DataSource = DataSetGeral.Tratamento1;
            ComentarioBindingSource.DataSource = DataSetGeral.Comentario;
            Tratamento2BindingSource.DataSource = DataSetGeral.Tratamento2;
            Ciclo1BindingSource.DataSource = DataSetGeral.Ciclo1;
            Ciclo2BindingSource.DataSource = DataSetGeral.Ciclo2;

            this.reportViewer1.RefreshReport();
        }

        public static int ObterCasasDecimais(decimal numero)
        {
            decimal resultado = numero - Math.Floor(numero);
            int qtdCasas = QuantidadeCasasDecimais(resultado);
            string[] split = numero.ToString().Split(',');
            int parteDecimal = Convert.ToInt32(split[0]);
            return parteDecimal;
        }

        static int QuantidadeCasasDecimais(decimal num)
        {
            return BitConverter.GetBytes(decimal.GetBits(num)[3])[2];
        }
    }
}
