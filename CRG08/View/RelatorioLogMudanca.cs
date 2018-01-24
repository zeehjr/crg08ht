using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CRG08.Dao;
using Microsoft.Reporting.WinForms;

namespace CRG08.View
{
    public partial class RelatorioLogMudanca : Form
    {
        public RelatorioLogMudanca()
        {
            InitializeComponent();
        }

        private string dataInicio, dataFim;
        public RelatorioLogMudanca(string dataInicio, string dataFim)
        {
            InitializeComponent();
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
        }

        private void RelatorioLogMudanca_Load(object sender, EventArgs e)
        {
            var fieldInfo = typeof(Microsoft.Reporting.WinForms.RenderingExtension).GetField("m_isVisible", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            foreach (var extension in this.reportViewer1.LocalReport.ListRenderingExtensions())
            {
                if (string.Compare("Excel", extension.Name) == 0)
                    fieldInfo.SetValue(extension, false);
                else if (string.Compare("WORD", extension.Name) == 0)
                    fieldInfo.SetValue(extension, false);
            }

            ReportParameter periodo = new ReportParameter("intervaloRelatorio");
            periodo.Values.Add("Relatório de Mudanças do dia " + dataInicio + " a " + dataFim);
            List<VO.LogMudanca> listaMudancas = LogMudancaDAO.buscaListaPorPeriodo(dataInicio.ToString().Substring(0, 10), dataFim.ToString().Substring(0, 10));
            DataSetGeral data = new DataSetGeral();
            foreach (var listaMudanca in listaMudancas)
            {
                data.LogMudanca.AddLogMudancaRow(listaMudanca.descricao, listaMudanca.crg.ToString(),
                    listaMudanca.data.ToString().Substring(0, 10), listaMudanca.data.ToString().Substring(11, 8),
                    listaMudanca.responsavel);
            }
            VO.Empresa empresa = EmpresaDAO.buscaEmpresa();
            if (empresa != null) data.Empresa.AddEmpresaRow(empresa.Nome,empresa.Endereco,empresa.Cep,empresa.Cidade, empresa.UF, empresa.Fone, empresa.Fax,
                empresa.CNPJ, empresa.IE, empresa.NCredenciamento, empresa.Logo);
            else data.Empresa.AddEmpresaRow("", "", "", "", -1, "", "", "", "", "", null);

            ReportDataSource Empresa = new ReportDataSource("DataSetEmpresa", data.Tables[1]);
            ReportDataSource logErro = new ReportDataSource("DataSetLogMudanca", data.Tables[10]);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(logErro);
            reportViewer1.LocalReport.DataSources.Add(Empresa);
            reportViewer1.LocalReport.SetParameters(periodo);
            this.reportViewer1.RefreshReport();
        }
    }
}
