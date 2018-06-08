using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using CRG08.Dao;
using CRG08.Util;
using CRG08.VO;

namespace CRG08.View
{
    public partial class ConfigGrafico : Form
    {
        public ConfigGrafico()
        {
            InitializeComponent();
        }

        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cores_Load(object sender, EventArgs e)
        {
            var ultimasLegendas = UltimosDAO.RetornaUltimasLegendas();
            txtT1.Text = ultimasLegendas.T1;
            txtT2.Text = ultimasLegendas.T2;
            txtT3.Text = ultimasLegendas.T3;
            txtT4.Text = ultimasLegendas.T4;
            txtCA.Text = ultimasLegendas.CA;

            var ultimasCores = UltimosDAO.RetornaUltimasCores();

            var corT1R = Convert.ToInt32(ultimasCores.T1RGB.Split(',')[0]);
            var corT1G = Convert.ToInt32(ultimasCores.T1RGB.Split(',')[1]);
            var corT1B = Convert.ToInt32(ultimasCores.T1RGB.Split(',')[2]);
            btnCorT1.BackColor = Color.FromArgb(corT1R, corT1G, corT1B);

            var corT2R = Convert.ToInt32(ultimasCores.T2RGB.Split(',')[0]);
            var corT2G = Convert.ToInt32(ultimasCores.T2RGB.Split(',')[1]);
            var corT2B = Convert.ToInt32(ultimasCores.T2RGB.Split(',')[2]);
            btnCorT2.BackColor = Color.FromArgb(corT2R, corT2G, corT2B);

            var corT3R = Convert.ToInt32(ultimasCores.T3RGB.Split(',')[0]);
            var corT3G = Convert.ToInt32(ultimasCores.T3RGB.Split(',')[1]);
            var corT3B = Convert.ToInt32(ultimasCores.T3RGB.Split(',')[2]);
            btnCorT3.BackColor = Color.FromArgb(corT3R, corT3G, corT3B);

            var corT4R = Convert.ToInt32(ultimasCores.T4RGB.Split(',')[0]);
            var corT4G = Convert.ToInt32(ultimasCores.T4RGB.Split(',')[1]);
            var corT4B = Convert.ToInt32(ultimasCores.T4RGB.Split(',')[2]);
            btnCorT4.BackColor = Color.FromArgb(corT4R, corT4G, corT4B);

            var corCAR = Convert.ToInt32(ultimasCores.CARGB.Split(',')[0]);
            var corCAG = Convert.ToInt32(ultimasCores.CARGB.Split(',')[1]);
            var corCAB = Convert.ToInt32(ultimasCores.CARGB.Split(',')[2]);
            btnCorCA.BackColor = Color.FromArgb(corCAR, corCAG, corCAB);
        }

        public bool AtualizaUltimo(string T1, string T2, string T3, string T4, string CA)
        {
            var novasLegendas = new LegendasGrafico
            {
                T1 = T1,
                T2 = T2,
                T3 = T3,
                T4 = T4,
                CA = CA
            };
            return UltimosDAO.SetarUltimasLegendas(novasLegendas);
        }

        private void Aplicar_Click(object sender, EventArgs e)
        {
            var corT1Str = btnCorT1.BackColor.R.ToString() + "," + btnCorT1.BackColor.G.ToString() + "," +
                           btnCorT1.BackColor.B.ToString();
            var corT2Str = btnCorT2.BackColor.R.ToString() + "," + btnCorT2.BackColor.G.ToString() + "," +
                           btnCorT2.BackColor.B.ToString();
            var corT3Str = btnCorT3.BackColor.R.ToString() + "," + btnCorT3.BackColor.G.ToString() + "," +
                           btnCorT3.BackColor.B.ToString();
            var corT4Str = btnCorT4.BackColor.R.ToString() + "," + btnCorT4.BackColor.G.ToString() + "," +
                           btnCorT4.BackColor.B.ToString();
            var corCAStr = btnCorCA.BackColor.R.ToString() + "," + btnCorCA.BackColor.G.ToString() + "," +
                           btnCorCA.BackColor.B.ToString();

            var novasCores = new CoresGrafico()
            {
                T1RGB = corT1Str,
                T2RGB = corT2Str,
                T3RGB = corT3Str,
                T4RGB = corT4Str,
                CARGB = corCAStr
            };

            var novasLegendas = new LegendasGrafico()
            {
                T1 = txtT1.Text,
                T2 = txtT2.Text,
                T3 = txtT3.Text,
                T4 = txtT4.Text,
                CA = txtCA.Text
            };

            if (UltimosDAO.SetarUltimasLegendas(novasLegendas))
            {
                MessageBox.Show("Legendas alteradas com sucesso!", "Sucesso!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao alterar as legendas.", "Erro!", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            if (UltimosDAO.SetarUltimasCores(novasCores))
            {
                MessageBox.Show("Cores alteradas com sucesso!", "Sucesso!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao alterar as cores.", "Erro!", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            //bool retorno = AtualizaUltimo(txtT1.Text, txtT2.Text, txtT3.Text, txtT4.Text, txtCA.Text);
            //if (retorno) MessageBox.Show("As Cores foram atualizadas com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);
            //else MessageBox.Show("Erro ao tentar alterar as Cores.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCor_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            color.Color = btn.BackColor;
            if (color.ShowDialog(this) == DialogResult.OK)
                btn.BackColor = color.Color;
        }

        private void txtCores_Leave(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            if (txt == null) return;
            if (String.IsNullOrEmpty(txt.Text))
            {
                MessageBox.Show("Nenhum sensor pode ficar com nome em branco!" + Environment.NewLine + "Por favor, insira um nome.",
                    "Nome em branco!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt.Text = txt.Name.Replace("txt", String.Empty);
                txt.Focus();
                return;
            }
            foreach (var t in Controls.OfType<TextBox>())
            {
                if (t != txt)
                {
                    if (t.Text == txt.Text)
                    {
                        MessageBox.Show(
                            "Já existe um sensor com o nome de \"" + t.Text + "\"!" + Environment.NewLine + "Por favor, insira outro nome.",
                            "Nome duplicado!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt.Text = txt.Name.Replace("txt", String.Empty);
                        txt.Focus();
                        break;
                    }
                }
            }
        }
    }
}
