using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CRG08.VO;

namespace CRG08.View
{
    public partial class DetalhesProdutosCiclo : Form
    {
        public DetalhesProdutosCiclo()
        {
            InitializeComponent();
        }

        List<ProdutoCiclo> listaProdutos;
        public DetalhesProdutosCiclo(List<ProdutoCiclo> listaProdutos)
        {
            InitializeComponent();
            this.listaProdutos = listaProdutos;
        }
        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetalhesProdutosCiclo_Load(object sender, EventArgs e)
        {
            string ultimo = "";
            foreach (var listaProduto in listaProdutos)
            {
                if (ultimo != "")
                {
                    if (ultimo == listaProduto.empresa.nome)
                    {
                        dtgprodutos.Rows.Add("  - "+listaProduto.produto.descricao + " com " + listaProduto.volume + " " +
                            listaProduto.unidade.unidade, listaProduto.empresa.idEmpresa, listaProduto.produto.idProduto);
                        this.dtgprodutos.Rows[dtgprodutos.RowCount -1].Visible = false;
                        ultimo = listaProduto.empresa.nome;
                    }
                    else
                    {
                        dtgprodutos.Rows.Add(listaProduto.empresa.nome, listaProduto.empresa.idEmpresa, 0);
                        dtgprodutos.Rows[dtgprodutos.RowCount - 1].DefaultCellStyle.BackColor = SystemColors.Control;
                        dtgprodutos.Rows.Add("  - " + listaProduto.produto.descricao + " com " + listaProduto.volume + " " +
                            listaProduto.unidade.unidade, listaProduto.empresa.idEmpresa, listaProduto.produto.idProduto);
                        this.dtgprodutos.Rows[dtgprodutos.RowCount - 1].Visible = false;
                        ultimo = listaProduto.empresa.nome;
                    }
                }
                else
                {
                    dtgprodutos.Rows.Add(listaProduto.empresa.nome, listaProduto.empresa.idEmpresa, 0);
                    dtgprodutos.Rows[dtgprodutos.RowCount - 1].DefaultCellStyle.BackColor = SystemColors.Control;
                    dtgprodutos.Rows.Add("  - " + listaProduto.produto.descricao + " com " + listaProduto.volume + " " +
                            listaProduto.unidade.unidade, listaProduto.empresa.idEmpresa, listaProduto.produto.idProduto);
                    this.dtgprodutos.Rows[dtgprodutos.RowCount - 1].Visible = false;
                    ultimo = listaProduto.empresa.nome;
                }
            }
        }

        private void dtgprodutos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dtgprodutos.RowCount; i++) dtgprodutos.Rows[i].DefaultCellStyle.BackColor = SystemColors.Control;
            dtgprodutos.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
        }

        private void dtgprodutos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int empresa = Convert.ToInt32(dtgprodutos.Rows[e.RowIndex].Cells[1].Value);
            for (int i = 0; i < dtgprodutos.RowCount; i++)
            {
                if (Convert.ToInt32(dtgprodutos.Rows[i].Cells[1].Value) == empresa && Convert.ToInt32(dtgprodutos.Rows[i].Cells[2].Value)!= 0)
                    if (this.dtgprodutos.Rows[i].Visible) this.dtgprodutos.Rows[i].Visible = false;
                    else this.dtgprodutos.Rows[i].Visible = true;
            }
        }
    }
}
