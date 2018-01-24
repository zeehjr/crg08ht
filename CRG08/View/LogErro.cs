using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CRG08.Dao;

namespace CRG08.View
{
    public partial class LogErro : Form
    {
        private bool pesquisou = false;
        private bool pesquisouM = false;
        public LogErro()
        {
            InitializeComponent();
        }

        private void Logs_Load(object sender, EventArgs e)
        {
            DateTime diaI = DateTime.Now.AddDays(-30);
            DateTime diaF = DateTime.Now;
            diaInicio.MinDate = diaI;
            diaInicio.MaxDate = diaF;
            diaFim.MinDate = diaI;
            diaFim.MaxDate = diaF;

            LogErroDAO.deletaLogErro(diaI, diaF);
            List<VO.LogErro> listaErros = LogErroDAO.ListaErros();
            foreach (var erro in listaErros)
            {
                if (erro.crg == 0) dtgErros.Rows.Add(erro.codErro, erro.data, "", erro.descricao, "+ Detalhes");
                else dtgErros.Rows.Add(erro.codErro, erro.data, erro.crg, erro.descricao, "+ Detalhes");
            }
        }

        private void dtgErros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int codigo = Convert.ToInt32(dtgErros.Rows[e.RowIndex].Cells[0].Value);
                string maisDetalhes = LogErroDAO.RetornaMaisDetalhes(codigo);
                if (maisDetalhes != null) MessageBox.Show(maisDetalhes, "Mais Detalhes", MessageBoxButtons.OK);
                else MessageBox.Show("Não há mais detalhes", "Atenção", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {

            pesquisou = true;
            string diaIni = diaInicio.Text.ToString();
            string diaF = diaFim.Text.ToString();
            if (Convert.ToDateTime(diaF) >= Convert.ToDateTime(diaIni))
            {
                List<VO.LogErro> listaErros = LogErroDAO.listaErrosPorPeriodo(diaIni, diaF);
                dtgErros.Rows.Clear();
                if (listaErros == null || listaErros.Count == 0)
                    MessageBox.Show("Não houve erro nesse período", "Atenção", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                {
                    foreach (var erro in listaErros)
                    {
                        dtgErros.Rows.Add(erro.codErro, erro.data, erro.crg, erro.descricao,
                            "+ Detalhes");
                    }
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
                RelatorioLogErro relatorio = new RelatorioLogErro(diaIni, diaF);
                relatorio.ShowDialog(this);
            }
            else
            {
                string diaIni = DateTime.Now.AddDays(-30).ToString();
                string diaF = DateTime.Now.ToString();
                RelatorioLogErro relatorio = new RelatorioLogErro(diaIni, diaF);
                relatorio.ShowDialog(this);
            }
        }
    }
}
