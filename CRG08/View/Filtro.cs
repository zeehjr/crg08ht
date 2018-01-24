using System;
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
    public partial class Filtro : Form
    {
        public int selecao, qtdeMeses, crg, aparelho;
        public string dataInicio, dataFim;
        private Ciclos ciclo;
        private UltimoFiltro filtro = new UltimoFiltro();
        public Filtro(Ciclos ciclo)
        {
            InitializeComponent();
            this.ciclo = ciclo;
        }

        private void TodosEquipamentos_CheckedChanged(object sender, EventArgs e)
        {
            if (TodosEquipamentos.Checked)
            {
                IntervaloData.Enabled = false;
                IntervaloMeses.Enabled = false;
                comboBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
                ListaEquipamentos.Enabled = false;
                TodosRegistros.Enabled = false;
            }
        }

        private void Equipamento_CheckedChanged(object sender, EventArgs e)
        {
            if (Equipamento.Checked)
            {
                IntervaloData.Enabled = true;
                IntervaloMeses.Enabled = true;
                comboBox1.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                label1.Enabled = true;
                label2.Enabled = true;
                ListaEquipamentos.Enabled = true;
                TodosRegistros.Enabled = true;
                comboBox1.Text = "1";
            }
            else
            {
                IntervaloData.Enabled = false;
                IntervaloMeses.Enabled = false;
                comboBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
                ListaEquipamentos.Enabled = false;
                TodosRegistros.Enabled = false;
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void Filtrar_Click(object sender, EventArgs e)
        {
            if (TodosEquipamentos.Checked == true)
            {
                selecao = 1;
                filtro.ValorFiltro = selecao;

            }
            else if (Equipamento.Checked == true)
            {
                aparelho = Convert.ToInt32(ListaEquipamentos.Text);
                filtro.Equipamento = aparelho;
                if (IntervaloData.Checked == true)
                {
                    if (dateTimePicker1.Value < dateTimePicker2.Value)
                    {
                        selecao = 2;
                        filtro.ValorFiltro = selecao;
                        filtro.DataInicio = dateTimePicker1.Value;
                        filtro.DataFim = dateTimePicker2.Value;
                    }
                    else
                    {
                        MessageBox.Show("Data Inicial não pode ser maior que a final.", "Atenção", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        selecao = 1;
                        filtro.ValorFiltro = selecao;
                    }
                }
                else if (IntervaloMeses.Checked == true)
                {
                    qtdeMeses = int.Parse(comboBox1.Text);
                    selecao = 3;
                    filtro.ValorFiltro = selecao;
                    filtro.QtdMeses = qtdeMeses;
                }
                else if (TodosRegistros.Checked == true)
                {
                    selecao = 4;
                    filtro.ValorFiltro = selecao;
                }
            }
            UltimosDAO.SetarUltimoFiltro(filtro);
            ciclo.CarregaCiclos();
            Close();
        }

        private void Filtro_Load(object sender, EventArgs e)
        {
            filtro = UltimosDAO.RetornaUltimoFiltro();
            switch (filtro.ValorFiltro)
            {
                case 0:
                    ListaEquipamentos.Text = ListaEquipamentos.Items[0].ToString();
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                    dateTimePicker2.Format = DateTimePickerFormat.Custom;
                    dateTimePicker2.CustomFormat = "dd/MM/yyyy";
                    crg = int.Parse(ListaEquipamentos.Text);
                    break;
                case 1:
                    ListaEquipamentos.Text = ListaEquipamentos.Items[0].ToString();
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                    dateTimePicker2.Format = DateTimePickerFormat.Custom;
                    dateTimePicker2.CustomFormat = "dd/MM/yyyy";
                    crg = int.Parse(ListaEquipamentos.Text);
                    TodosEquipamentos.Checked = true;
                    Equipamento.Checked = false;
                    break;
                case 2:
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                    dateTimePicker2.Format = DateTimePickerFormat.Custom;
                    dateTimePicker2.CustomFormat = "dd/MM/yyyy";
                    crg = filtro.Equipamento;
                    TodosEquipamentos.Checked = false;
                    Equipamento.Checked = true;
                    ListaEquipamentos.Text = filtro.Equipamento.ToString();
                    IntervaloData.Checked = true;
                    IntervaloMeses.Checked = false;
                    TodosRegistros.Checked = false;
                    dateTimePicker1.Value = filtro.DataInicio;
                    dateTimePicker2.Value = filtro.DataFim;
                    break;
                case 3:
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                    dateTimePicker2.Format = DateTimePickerFormat.Custom;
                    dateTimePicker2.CustomFormat = "dd/MM/yyyy";
                    crg = filtro.Equipamento;
                    TodosEquipamentos.Checked = false;
                    Equipamento.Checked = true;
                    ListaEquipamentos.Text = filtro.Equipamento.ToString();
                    IntervaloData.Checked = false;
                    IntervaloMeses.Checked = true;
                    TodosRegistros.Checked = false;
                    comboBox1.Text = filtro.QtdMeses.ToString();
                    break;
                case 4:
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                    dateTimePicker2.Format = DateTimePickerFormat.Custom;
                    dateTimePicker2.CustomFormat = "dd/MM/yyyy";
                    crg = filtro.Equipamento;
                    TodosEquipamentos.Checked = false;
                    Equipamento.Checked = true;
                    ListaEquipamentos.Text = filtro.Equipamento.ToString();
                    IntervaloData.Checked = false;
                    IntervaloMeses.Checked = false;
                    TodosRegistros.Checked = true;
                    break;
            }
        }

    }
}
