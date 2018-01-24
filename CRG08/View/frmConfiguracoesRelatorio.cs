using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CRG08.Dao;

namespace CRG08.View
{
    public partial class frmConfiguracoesRelatorio : Form
    {
        public frmConfiguracoesRelatorio()
        {
            InitializeComponent();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblPadraoAntesTrat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            udLinhasAntes.Value = ConfiguracaoDAO.PadraoConfigRelatorio().LeiturasAntes;
        }

        private void lblPadraoTrat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            udLinhasTrat.Value = ConfiguracaoDAO.PadraoConfigRelatorio().LeiturasTrat;
        }

        private void lblPadraoDepoisTrat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            udLinhasDepois.Value = ConfiguracaoDAO.PadraoConfigRelatorio().LeiturasDepois;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var lAntes = Convert.ToInt32(udLinhasAntes.Value);
            var lTrat = Convert.ToInt32(udLinhasTrat.Value);
            var lDepois = Convert.ToInt32(udLinhasDepois.Value);
            ConfiguracaoDAO.GravarConfigRelatorio(lAntes, lTrat, lDepois);
            Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmConfiguracoesRelatorio_Load(object sender, EventArgs e)
        {
            var config = ConfiguracaoDAO.PegarConfigRelatorio();
            udLinhasAntes.Value = config.LeiturasAntes;
            udLinhasTrat.Value = config.LeiturasTrat;
            udLinhasDepois.Value = config.LeiturasDepois;
        }
    }
}
