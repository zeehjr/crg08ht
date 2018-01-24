using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace CRG08.View
{
    public partial class frmPenDrive : Form
    {
        public frmPenDrive()
        {
            InitializeComponent();
        }

        FileInfo[] listaTratamentos;
        NovoCiclo novoCiclo;
        string unidade = "", equip= "";
        List<string> unidades;
        bool terminou = false, selecionou = false, Atualizar = false;
        private int nTrat = -1;
        
        public frmPenDrive(bool Atualizar, FileInfo[] listaTratamentos, NovoCiclo novoCiclo, string unidade, string equip, int nTrat)
        {
            InitializeComponent();
            this.Atualizar = Atualizar;
            this.listaTratamentos = listaTratamentos;
            this.novoCiclo = novoCiclo;
            this.unidade = unidade;
            this.equip = equip;
            this.nTrat = nTrat;
        }

        public frmPenDrive(bool Atualizar, NovoCiclo novoCiclo, List<string> unidades, string equip, int nTrat)
        {
            InitializeComponent();
            this.Atualizar = Atualizar;
            this.novoCiclo = novoCiclo;
            this.unidades = unidades;
            this.equip = equip;
            this.nTrat = nTrat;
        }

        private void frmPenDrive_Load(object sender, EventArgs e)
        {
            if (unidade != "")
            {
                cmbUnidades.Items.Add(unidade);
                cmbUnidades.SelectedIndex = 0;
                string equipa = String.Format("{0:00}", equip);
                string caminho = cmbUnidades.SelectedItem + "CRG" + equipa;
                DirectoryInfo Dir = new DirectoryInfo(@"" + caminho);
                if (Atualizar)
                {
                    FileInfo[] Files = Dir.GetFiles("SEC" + nTrat.ToString("000") + ".TRT", SearchOption.AllDirectories);
                    dtgTratamentos.Rows.Clear();
                    foreach (FileInfo f in Files)
                    {
                        dtgTratamentos.Rows.Add(f);
                    }
                    dtgTratamentos.Sort(dtgTratamentos.Columns[0],ListSortDirection.Descending);
                }
                else
                {
                    FileInfo[] Files = Dir.GetFiles("*.TRT", SearchOption.AllDirectories);
                    dtgTratamentos.Rows.Clear();
                    foreach (FileInfo f in Files)
                    {
                        dtgTratamentos.Rows.Add(f);
                    }
                    dtgTratamentos.Sort(dtgTratamentos.Columns[0], ListSortDirection.Descending);
                }
            }
            else if (unidades.Count > 0)
            {
                foreach (var s in unidades)
                {
                    cmbUnidades.Items.Add(s);
                }
                string equipa = String.Format("{0:00}", equip);
                bool encontrou = false;
                int i = 0;
                if (!Atualizar)
                {
                    do
                    {
                        string caminho = cmbUnidades.Items[i] + "CRG" + equipa;
                        DirectoryInfo Dir = new DirectoryInfo(@"" + caminho);
                        if (Dir.Exists)
                        {
                            FileInfo[] Files = Dir.GetFiles("*.TRT", SearchOption.AllDirectories);
                            dtgTratamentos.Rows.Clear();
                            foreach (FileInfo f in Files)
                            {
                                dtgTratamentos.Rows.Add(f);
                            }
                            cmbUnidades.SelectedIndex = i;
                            encontrou = true;
                        }
                        i++;
                    } while (!encontrou);
                    dtgTratamentos.Sort(dtgTratamentos.Columns[0], ListSortDirection.Descending);
                }
                else
                {
                    do
                    {
                        string caminho = cmbUnidades.Items[i] + "CRG" + equipa;
                        DirectoryInfo Dir = new DirectoryInfo(@"" + caminho);
                        if (Dir.Exists)
                        {
                            FileInfo[] Files = Dir.GetFiles("SEC"+nTrat.ToString("000")+".TRT", SearchOption.AllDirectories);
                            dtgTratamentos.Rows.Clear();
                            foreach (FileInfo f in Files)
                            {
                                dtgTratamentos.Rows.Add(f);
                            }
                            cmbUnidades.SelectedIndex = i;
                            encontrou = true;
                        }
                        i++;
                    } while (!encontrou);
                    dtgTratamentos.Sort(dtgTratamentos.Columns[0], ListSortDirection.Descending);
                }
            }
            /*if (listaTratamentos != null && listaTratamentos.Length > 0)
            {
                foreach (var listaTratamento in listaTratamentos)
                {
                    dtgTratamentos.Rows.Add(listaTratamento);
                }
                dtgTratamentos.CurrentCell = dtgTratamentos.Rows[0].Cells[0];
                dtgTratamentos.Sort(dtgTratamentos.Columns[0], ListSortDirection.Descending);
            }*/
            terminou = true;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            string equipa = String.Format("{0:00}", equip);
            novoCiclo.recebeArquivoSelecionadoPenDrive(cmbUnidades.SelectedItem + "CRG" + string.Concat(equip,@"\") +  dtgTratamentos.SelectedRows[0].Cells[0].Value);
            selecionou = true;
            this.Close();
        }

        private void cmbUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (terminou)
            {
                string equipa = String.Format("{0:00}", equip);
                string caminho = cmbUnidades.SelectedItem + "CRG" + equipa;
                DirectoryInfo Dir = new DirectoryInfo(@"" + caminho);
                if (Dir.Exists)
                {
                    FileInfo[] Files = Dir.GetFiles("*.TRT", SearchOption.AllDirectories);
                    dtgTratamentos.Rows.Clear();
                    foreach (FileInfo f in Files)
                    {
                        dtgTratamentos.Rows.Add(f);
                    }
                    dtgTratamentos.Sort(dtgTratamentos.Columns[0], ListSortDirection.Descending);
                }
                else
                {
                    MessageBox.Show("Não foi possivel localizar a pasta do CRG nº " + equip +
                                    ". Verifique a existência da pasta CRG" + equip + " no pen drive inserido.",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmPenDrive_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!selecionou)novoCiclo.AlterarReceberPendrive();
        }
    }
}
