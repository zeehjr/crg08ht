using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CRG08.Dao;
using CRG08.VO;

namespace CRG08.View
{
    public partial class frmSelecionarMeioComunicacao : Form
    {
        public string TipoComunicacao = string.Empty;
        public int NumCRG = -1;
        public bool Sucesso = false;

        public frmSelecionarMeioComunicacao()
        {
            InitializeComponent();
        }

        public frmSelecionarMeioComunicacao(int crg)
        {
            InitializeComponent();
            NumCRG = crg;
        }

        private void frmSelecionarMeioComunicacao_Load(object sender, EventArgs e)
        {
            if (NumCRG > -1)
            {
                ckApenasAparelho.Checked = NumCRG > 0;
                cmbNumCRG.Enabled = false;
                cmbNumCRG.SelectedIndex = NumCRG - 1;
                return;
            }

            var ultimaComunicacao = UltimosDAO.RetornaUltimaComunicacao();
            if (ultimaComunicacao.Online)
            {
                rdBtnOnline.Checked = true;
            }
            else
            {
                rdBtnPendrive.Checked = true;
            }

            ckApenasAparelho.Checked = rdBtnOnline.Checked || ultimaComunicacao.ApenasAparelho;

            var ultimoCRG = ultimaComunicacao.NumCRG;
            cmbNumCRG.SelectedItem = ultimoCRG > 0 ? ultimoCRG.ToString("00") : "01";
        }

        private void ckApenasAparelho_CheckedChanged(object sender, EventArgs e)
        {
            if (ckApenasAparelho.Checked)
            {
                lblNumCRG.Enabled = true;
                cmbNumCRG.Enabled = true;
            }
            else
            {
                lblNumCRG.Enabled = false;
                cmbNumCRG.Enabled = false;
            }
        }

        private void rdBtnOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (NumCRG > -1) return;
            if (rdBtnOnline.Checked)
            {
                ckApenasAparelho.Enabled = false;
                ckApenasAparelho.Checked = true;
            }
            else
            {
                ckApenasAparelho.Enabled = true;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            TipoComunicacao = rdBtnOnline.Checked ? "ONLINE" : "PENDRIVE";
            if (ckApenasAparelho.Checked)
            {
                NumCRG = cmbNumCRG.SelectedIndex + 1;
            }
            Sucesso = true;

            UltimosDAO.SetarUltimaComunicacao(new ComunicacaoSelecionada
            {
                ApenasAparelho = ckApenasAparelho.Checked,
                NumCRG = NumCRG > 0 ? NumCRG : -1,
                Online = rdBtnOnline.Checked
            });

            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbNumCRG_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
