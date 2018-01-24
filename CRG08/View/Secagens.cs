using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CRG08.BO;
using CRG08.Dao;
using CRG08.DataMigration;
using CRG08.Util;
using CRG08.VO;

namespace CRG08.View
{
    public partial class Secagens : Form
    {
        private List<ItemListaSecagem> listaSecagens;
        private Ciclos ciclos;

        private delegate List<byte> funcaoAssincrona();

        public Secagens()
        {
            InitializeComponent();
        }

        public Secagens(Ciclos ciclos)
        {
            InitializeComponent();
            this.ciclos = ciclos;
        }

        private void btnReceber_Click(object sender, EventArgs e)
        {
            lvSecagens.Items.Clear();
            var porta = ConfiguracaoDAO.retornaPorta();
            
            var listaRetorno = SecagensBO.ListarSecagens(Convert.ToInt32(cmbCRG.SelectedItem), porta);
            if (listaRetorno == null)
            {
                var erro = ErrorHandler.GetLastError;
                if (erro != null)
                {
                    MessageBox.Show(erro.ErrorMessage, "Erro (" + erro.Identifier + ")", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    ErrorHandler.RemoveLastError();
                }
                else
                {
                    MessageBox.Show("Não foi possível listar as secagens! Tente novamente.", "Erro desconhecido",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            UltimosDAO.SetarUltimoCRG(Convert.ToInt32(cmbCRG.SelectedItem));
            listaSecagens = listaRetorno;
            lvSecagens.Items.Clear();
            foreach (var item in listaRetorno)
            {
                var listItem = new ListViewItem(item.Id.ToString());
                listItem.SubItems.Add(item.NumeroLeituras.ToString());
                listItem.SubItems.Add(item.Data.ToString("dd/MM/yyyy HH:mm"));
                
                lvSecagens.Items.Add(listItem);
            }
        }

        private void Secagens_Load(object sender, EventArgs e)
        {
            var ultimoCRG = UltimosDAO.RetornaUltimoCRG();
            if (ultimoCRG == -1)
            {
                cmbCRG.SelectedIndex = 0;
            }
            else
            {
                cmbCRG.SelectedIndex = cmbCRG.Items.IndexOf(ultimoCRG.ToString());
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listaSecagens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSecagens.Items.Count == 0 || lvSecagens.SelectedItems.Count == 0)
            {
                btnInserir.Enabled = false;
            }
            else
            {
                btnInserir.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(lvSecagens.SelectedItems[0].Text);
            var item = listaSecagens.FirstOrDefault(x => x.Id == id);
            var crg = Convert.ToInt32(cmbCRG.Text);

            var func = new funcaoAssincrona(() => SecagensBO.ReceberSecagem(id, crg, ConfiguracaoDAO.retornaPorta()));

            this.Enabled = false;
            var frmCarregar = new Carregar();
            frmCarregar.Show(this);
            var asyncResult = func.BeginInvoke((ar) =>
            {

            }, null);

            while (asyncResult.IsCompleted == false)
            {
                Application.DoEvents();
                Thread.Sleep(50);
            }

            frmCarregar.Invoke(new MethodInvoker(() => frmCarregar.Close()));

            var listaRetorno = func.EndInvoke(asyncResult);

            if (listaRetorno == null)
            {
                MessageBox.Show("");
                return;
            }

            var secagem = SecagensBO.DescriptografarSecagem(listaRetorno);
            
            if (secagem == null)
            {
                var msg = "Não foi possível carregar este ciclo!";
                if (ErrorHandler.GetLastError != null)
                {
                    msg += Environment.NewLine + Environment.NewLine + "Detalhes:" + Environment.NewLine +
                           ErrorHandler.GetLastError.ErrorMessage;
                    ErrorHandler.ClearErrors();
                }
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto Fim;
            }

            secagem.ciclo.crg = crg;


            var status = SecagensBO.SalvarSecagem(false, secagem, null, this);

            Enabled = true;

            if (status.Cancelado) return;

            if (status.Sucesso)
            {
                MessageBox.Show("Ciclo " + secagem.ciclo.nTrat + " " + (status.Salvo ? "salvo" : "atualizado") +
                                " com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                goto Fim;
            }

            var ultimoErro = ErrorHandler.GetLastError;
            if (ultimoErro != null)
            {
                MessageBox.Show(ultimoErro.ErrorMessage, ultimoErro.Identifier == 0 ? "Erro" : "Informação",
                    MessageBoxButtons.OK,
                    ultimoErro.Identifier == 0 ? MessageBoxIcon.Error : MessageBoxIcon.Information);
                goto Fim;
            }

            MessageBox.Show(
                "Ciclo " + id + " atualizado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Fim:
            //ciclos.Activate();
            ciclos?.CarregaCiclos();
        }
    }
}
