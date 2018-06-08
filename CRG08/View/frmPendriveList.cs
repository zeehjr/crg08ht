using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CRG08.BO;
using CRG08.Dao;

namespace CRG08.View
{
    public partial class frmPendriveList : Form
    {
        private List<ItemPendrive> listaPendrives = new List<ItemPendrive>();

        public string Arquivo = string.Empty;
        public int NTrat = -1;
        public int Crg = -1;

        public frmPendriveList()
        {
            InitializeComponent();
        }

        public frmPendriveList(int crg, int nTrat)
        {
            InitializeComponent();
            Crg = crg;
            NTrat = nTrat;
        }

        private void frmPendriveList_Load(object sender, EventArgs e)
        {
            if (Crg > -1 && NTrat > -1)
            {
                cbCRG.SelectedIndex = Crg - 1;
                var listaPendrives = PendriveBO.RetornaPendrivePorCrgETrat(Crg, NTrat);
                if (listaPendrives != null && listaPendrives.Count >= 1)
                {
                    foreach (var pendrive in listaPendrives)
                    {
                        cbUnidade.Items.Add(pendrive.Unidade);
                    }
                    cbUnidade.SelectedIndex = 0;
                }
                return;
            } else if (Crg > -1)
            {
                cbCRG.SelectedIndex = Crg - 1;
                cbCRG.Enabled = false;
                var listaPendrives = PendriveBO.RetornaPendrivesPorCRG(Crg);
                if (listaPendrives != null && listaPendrives.Count >= 1)
                {
                    cbUnidade.Items.Clear();
                    foreach (var pendrive in listaPendrives)
                    {
                        cbUnidade.Items.Add(pendrive.Unidade);
                        cbUnidade.SelectedIndex = 0;
                    }
                    return;
                }
                MessageBox.Show("Nenhum pendrive foi encontrado com tratamentos para este aparelho!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }


            var ultimoEquip = UltimosDAO.RetornaUltimoEquipamento();
            cbCRG.SelectedIndex = ultimoEquip >= 1 ? ultimoEquip-1 : 0;
            listaPendrives = PendriveBO.RetornaPendrivesPorCRG(ultimoEquip);
            cbUnidade.Items.Clear();
            if (listaPendrives != null && listaPendrives.Count >= 1)
            {
                foreach (var pendrive in listaPendrives)
                {
                    cbUnidade.Items.Add(pendrive.Unidade);
                }
                cbUnidade.SelectedIndex = 0;
                return;
            }
        }

        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbArquivos.Items.Clear();
            if (cbUnidade.SelectedIndex == -1) return;

            var item = listaPendrives.FirstOrDefault(x => x.Unidade == cbUnidade.Items[cbUnidade.SelectedIndex].ToString());
            if (item == null) return;
            var orderedArquivos = item.Arquivos.OrderByDescending(x => x).ToList();
            foreach (var arquivo in orderedArquivos)
            {
                if (NTrat > -1 && !arquivo.Contains("SEC" + NTrat.ToString("000"))) continue;
                if (!Regex.IsMatch(arquivo, @"SEC\d{3}.TRT", RegexOptions.IgnoreCase)) continue;
                lbArquivos.Items.Add(Regex.Replace(arquivo, @"[^\\]+[^S]+[^E]+[^C]+\\(SEC\d{3}\.TRT)", "$1", RegexOptions.IgnoreCase));
            }
        }

        private void cbCRG_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaPendrives = PendriveBO.RetornaPendrivesPorCRG(cbCRG.SelectedIndex+1);
            cbUnidade.Items.Clear();
            lbArquivos.Items.Clear();
            if (listaPendrives != null && listaPendrives.Count >= 1)
            {
                listaPendrives = listaPendrives.OrderBy(x => x.Unidade).ToList();
                foreach (var pendrive in listaPendrives)
                {
                    cbUnidade.Items.Add(pendrive.Unidade);
                }
                cbUnidade.SelectedIndex = 0;
                return;
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (lbArquivos.SelectedIndex == -1 || cbUnidade.SelectedIndex == -1 || cbCRG.SelectedIndex == -1)
            {
                MessageBox.Show("Não há nenhum tratamento selecionado! Tente novamente.", "Atenção!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var item = listaPendrives.FirstOrDefault(x => x.Unidade == cbUnidade.Items[cbUnidade.SelectedIndex].ToString());
            if (item == null)
            {
                MessageBox.Show("Algum erro ocorreu ao buscar o nome do arquivo.", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            var nomeItem = lbArquivos.Items[lbArquivos.SelectedIndex].ToString();
            var arquivo =
                item.Arquivos.FirstOrDefault(x => x.IndexOf(nomeItem) >= 0);
            if (arquivo == null)
            {
                MessageBox.Show("Algum erro ocorreu ao buscar o nome do arquivo.", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Arquivo = arquivo;
            var strNTrat = Regex.Replace(nomeItem, @"SEC(\d{3})\.TRT", "$1", RegexOptions.IgnoreCase);
            NTrat = Convert.ToInt32(strNTrat);
            Crg = cbCRG.SelectedIndex + 1;
            Close();
        }
    }
}
