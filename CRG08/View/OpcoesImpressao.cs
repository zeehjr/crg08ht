using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CRG08.Dao;
using CRG08.VO;

namespace CRG08.View
{
    public partial class OpcoesImpressao : Form
    {
        public OpcoesImpressao()
        {
            InitializeComponent();
        }

        private VO.Ciclos ciclo;
        public OpcoesImpressao(VO.Ciclos ciclo)
        {
            InitializeComponent();
            this.ciclo = ciclo;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpcoesImpressao_Load(object sender, EventArgs e)
        {
            List<string> empresas = ProdutoCicloDAO.retornaEmpresasdoCiclo(ciclo);
            foreach (var em in empresas)
            {
                if(!cmbEmpresas.Items.Contains(em))cmbEmpresas.Items.Add(em);
            }
            var configRelatorio = ConfiguracaoDAO.PegarConfigRelatorio();
            txtLinhasAntes.Value = configRelatorio.LeiturasAntes;
            txtLinhasTratamento.Value = configRelatorio.LeiturasTrat;
            txtLinhasDepois.Value = configRelatorio.LeiturasDepois;
        }

        private void Individual_CheckedChanged(object sender, EventArgs e)
        {
            if (Individual.Checked) cmbEmpresas.Enabled = true;
            else cmbEmpresas.Enabled = false;
        }

        private void Geral_CheckedChanged(object sender, EventArgs e)
        {
            if (Geral.Checked) txtFiltro.Enabled = true;
            else txtFiltro.Enabled = false;
        }

        private void Continuar_Click(object sender, EventArgs e)
        {
            var linhasAntes = Convert.ToInt32(txtLinhasAntes.Value);
            var linhasTratamento = Convert.ToInt32(txtLinhasTratamento.Value);
            var linhasDepois = Convert.ToInt32(txtLinhasDepois.Value);
            var config = new ConfiguracaoRelatorio(linhasAntes, linhasTratamento, linhasDepois);
            ConfiguracaoDAO.GravarConfigRelatorio(config.LeiturasAntes, config.LeiturasTrat, config.LeiturasDepois);
            if (Tratamento.Checked)
            {
                if (Todos.Checked)
                {
                    RelTratamento relatorio = new RelTratamento(ciclo, 1, "", txtComentario.Text, config);
                    relatorio.ShowDialog(this);
                    this.Close();
                }
                else if (Individual.Checked)
                {
                    RelTratamento relatorio = new RelTratamento(ciclo, 2, cmbEmpresas.SelectedItem.ToString(), txtComentario.Text, config);
                    relatorio.ShowDialog(this);
                    this.Close();
                }
            }
            else if (Geral.Checked)
            {
                bool continua = false;
                if (Todos.Checked)
                {
                    if (txtFiltro.Text != "")
                    {
                        string aux = txtFiltro.Text;
                        aux = aux.Replace('-', 'X');
                        aux = aux.Replace(';', 'X');
                        string[] compara = aux.Split('X');
                        int maior = 0;
                        for (int i = 0; i < compara.Length; i ++)
                        {
                            if (compara[i] != "" && Convert.ToInt32(compara[i]) > maior)
                            {
                                maior = Convert.ToInt32(compara[i]);
                                continua = true;
                            }
                            else if (compara[i] != "")
                            {
                                continua = false;
                                i = compara.Length;
                            }
                        }
                        int n;
                        if (txtFiltro.Text.Substring(txtFiltro.Text.Length - 1, 1) != ";")
                        {
                            if (Int32.TryParse(txtFiltro.Text.Substring(txtFiltro.Text.Length - 1, 1), out n))
                                txtFiltro.Text = txtFiltro.Text + ";";
                            else if (txtFiltro.Text.Substring(txtFiltro.Text.Length - 1, 1) == "-")
                                txtFiltro.Text = txtFiltro.Text.Substring(0, txtFiltro.Text.Length - 1) + ";";
                        }
                    }
                    else continua = true;
                    if (continua)
                    {
                        RelGeral relatorio = new RelGeral(ciclo, 1, "", txtComentario.Text, txtFiltro.Text, config);
                        relatorio.ShowDialog(this);
                        this.Close();
                    }
                    else
                        MessageBox.Show("O filtro só pode ser ordenado em ordem crescente.", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (Individual.Checked)
                {
                    if (txtFiltro.Text != "")
                    {
                        string aux = txtFiltro.Text;
                        aux = aux.Replace('-', 'X');
                        aux = aux.Replace(';', 'X');
                        string[] compara = aux.Split('X');
                        int maior = 0;
                        for (int i = 0; i < compara.Length; i++)
                        {
                            if (compara[i] != "" && Convert.ToInt32(compara[i]) > maior)
                            {
                                maior = Convert.ToInt32(compara[i]);
                                continua = true;
                            }
                            else if (compara[i] != "")
                            {
                                continua = false;
                                i = compara.Length;
                            }
                        }
                        int n;
                        if (txtFiltro.Text.Substring(txtFiltro.Text.Length - 1, 1) != ";")
                        {
                            if (Int32.TryParse(txtFiltro.Text.Substring(txtFiltro.Text.Length - 1, 1), out n))
                                txtFiltro.Text = txtFiltro.Text + ";";
                            else if (txtFiltro.Text.Substring(txtFiltro.Text.Length - 1, 1) == "-")
                                txtFiltro.Text = txtFiltro.Text.Substring(0, txtFiltro.Text.Length - 1)+";";
                        }
                    }
                    else continua = true;
                    if (continua)
                    {
                        RelGeral relatorio = new RelGeral(ciclo, 2, cmbEmpresas.SelectedItem.ToString(),
                            txtComentario.Text, txtFiltro.Text, config);
                        relatorio.ShowDialog(this);
                        this.Close();
                    }
                    else
                        MessageBox.Show("O filtro só pode ser ordenado em ordem crescente.", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && txtFiltro.Text.Length >= 2 && txtFiltro.SelectionStart != 0)
            {
                int n;
                if (Int32.TryParse(txtFiltro.Text.Substring(txtFiltro.SelectionStart -1, 1), out n) == false)
                    e.KeyChar = (char)0;
            }
            else if (e.KeyChar == 59 && txtFiltro.Text.Length >= 2 && txtFiltro.SelectionStart != 0)
            {
                int n;
                if (Int32.TryParse(txtFiltro.Text.Substring(txtFiltro.SelectionStart -1, 1), out n) == false)
                    e.KeyChar = (char)0;
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tratamento_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void lblPadraoAntesTrat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtLinhasAntes.Value = ConfiguracaoDAO.PadraoConfigRelatorio().LeiturasAntes;
        }

        private void lblPadraoTrat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtLinhasTratamento.Value = ConfiguracaoDAO.PadraoConfigRelatorio().LeiturasTrat;
        }

        private void lblPadraoDepoisTrat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtLinhasDepois.Value = ConfiguracaoDAO.PadraoConfigRelatorio().LeiturasDepois;
        }

        private void txtLinhasAntes_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblQtdLinhasAntes_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
