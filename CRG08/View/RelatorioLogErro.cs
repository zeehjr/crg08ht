using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CRG08.Dao;
using Microsoft.Reporting.WinForms;

namespace CRG08.View
{
    public partial class RelatorioLogErro : Form
    {
        public RelatorioLogErro()
        {
            InitializeComponent();
        }

        private string dataInicio, dataFim;
        public RelatorioLogErro(string dataInicio, string dataFim)
        {
            InitializeComponent();
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
        }

        private void RelatorioLogErro_Load(object sender, EventArgs e)
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
            periodo.Values.Add("Relatório de Erros do dia " + dataInicio + " a " + dataFim);
            List<VO.LogErro> listaErros = LogErroDAO.listaErrosPorPeriodo(dataInicio.Substring(0, 10), dataFim.Substring(0, 10));
            DataSetGeral data = new DataSetGeral();
            foreach (var listaErro in listaErros)
            {
                data.LogErro.AddLogErroRow(listaErro.descricao, listaErro.crg.ToString(), listaErro.maisDetalhes, listaErro.data.ToString().Substring(0,10),
                    listaErro.data.ToString().Substring(11,8));
            }
            VO.Empresa empresa = EmpresaDAO.buscaEmpresa();
            if (empresa != null) data.Empresa.AddEmpresaRow(empresa.Nome,empresa.Endereco,empresa.Cep, empresa.Cidade, empresa.UF, empresa.Fone, empresa.Fax, empresa.CNPJ,
                empresa.IE, empresa.NCredenciamento, empresa.Logo);
            else data.Empresa.AddEmpresaRow("", "", "", "", -1, "", "", "", "", "", null);

            ReportDataSource Empresa = new ReportDataSource("DataSetEmpresa", data.Tables[1]);
            ReportDataSource logErro = new ReportDataSource("DataSetLogErro", data.Tables[11]);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(logErro);
            reportViewer1.LocalReport.DataSources.Add(Empresa);
            reportViewer1.LocalReport.SetParameters(periodo);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
