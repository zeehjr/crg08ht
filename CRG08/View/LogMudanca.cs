using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CRG08.Dao;

namespace CRG08.View
{
    public partial class LogMudanca : Form
    {

        private bool pesquisou = false;
        public LogMudanca()
        {
            InitializeComponent();
        }

        private void LogMudanca_Load(object sender, EventArgs e)
        {
            DateTime diaI = DateTime.Now.AddDays(-30);
                DateTime diaF = DateTime.Now;
                diaInicio.MinDate = diaI;
                diaInicio.MaxDate = diaF;
                diaFim.MinDate = diaI;
                diaFim.MaxDate = diaF;

                LogMudancaDAO.deletaLogMudanca(diaI, diaF);
                List<VO.LogMudanca> listaMudanca = LogMudancaDAO.listaLogMudancas();
                if (listaMudanca == null || listaMudanca.Count > 0)
                    foreach (var m in listaMudanca)
                    {
                        if (m.crg == 0)
                            dtgErros.Rows.Add(m.codMudanca, Convert.ToDateTime(m.data), "", m.descricao,
                                m.responsavel);
                        else
                            dtgErros.Rows.Add(m.codMudanca, Convert.ToDateTime(m.data), m.crg, m.descricao,
                                m.responsavel);
                    }
            }

        private void Search_Click(object sender, EventArgs e)
        {
            pesquisou = true;
            string diaIni = diaInicio.Text.ToString();
            string diaF = diaFim.Text.ToString();
            if (Convert.ToDateTime(diaF) >= Convert.ToDateTime(diaIni))
            {
                List<VO.LogMudanca> listaMudanca = LogMudancaDAO.buscaListaPorPeriodo(
                    diaIni.ToString().Substring(0, 10), diaF.ToString().Substring(0, 10));
                dtgErros.Rows.Clear();
                if (listaMudanca == null || listaMudanca.Count == 0)
                    MessageBox.Show("Não houve mudanças nesse período", "Atenção", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                    foreach (var m in listaMudanca)
                    {
                        if (m.crg == 0)
                            dtgErros.Rows.Add(m.codMudanca, Convert.ToDateTime(m.data), "", m.descricao,
                                m.responsavel);
                        else
                            dtgErros.Rows.Add(m.codMudanca, Convert.ToDateTime(m.data), m.crg, m.descricao,
                                m.responsavel);
                    }
            }
            else
            {
                MessageBox.Show("Data Inicial maior que data final.", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            if (pesquisou)
            {
                string diaIni = diaInicio.Text.ToString();
                string diaF = diaFim.Text.ToString();
                RelatorioLogMudanca relatorio = new RelatorioLogMudanca(diaIni, diaF);
                relatorio.ShowDialog(this);
            }
            else
            {
                string diaIni = DateTime.Now.AddDays(-30).ToString();
                string diaF = DateTime.Now.ToString();
                RelatorioLogMudanca relatorio = new RelatorioLogMudanca(diaIni, diaF);
                relatorio.ShowDialog(this);
            }
        }
    }
}
