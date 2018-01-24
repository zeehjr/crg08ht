using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CRG08.Dao;
using CRG08.VO;

namespace CRG08.View
{
    public partial class CadastroGenerico : Form
    {
        string tipo = "";
        public CadastroGenerico()
        {
            InitializeComponent();
        }

        public CadastroGenerico(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Inserir_Click(object sender, EventArgs e)
        {
            if (Inserir.Text == "Inserir")
            {
                dtgInsercao.Rows.Add("",-1);
                Inserir.Text = "Salvar";
            }
            else
            {
                switch (tipo)
                {
                    case "Produto":
                        Produto produto = new Produto();
                        if (dtgInsercao.CurrentRow.Cells[0].Value != null)
                        {
                            produto.descricao = dtgInsercao.CurrentRow.Cells[0].Value.ToString();
                            bool podeInserir = ProdutoDAO.testaDescricao(produto.descricao);
                            if (podeInserir && produto.descricao != "")
                            {
                                bool retornoP = ProdutoDAO.InsereProduto(produto);
                                if (!retornoP)
                                    MessageBox.Show("Erro ao tentar salvar o produto.", "Erro", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                else
                                {
                                    int codP = ProdutoDAO.retornarIDProduto(produto.descricao);
                                    dtgInsercao.CurrentRow.Cells[1].Value = codP.ToString();
                                    Inserir.Text = "Inserir";
                                }
                            }
                            else if (produto.descricao == "")
                                MessageBox.Show("Insira uma descrição válida para salvar o produto.", "Atenção",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Descrição de produto já utilizada.", "Atenção", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                        }
                        else MessageBox.Show("Erro ao salvar produto.Insira uma descrição válida para salvar o produto.", "Atenção",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "Empresa":
                        VO.EmpresaCiclo empresa = new VO.EmpresaCiclo();
                        if (dtgInsercao.CurrentRow.Cells[0].Value != null)
                        {
                            empresa.nome = dtgInsercao.CurrentRow.Cells[0].Value.ToString();
                            bool podeInserirE = EmpresaCicloDAO.testaNome(empresa.nome);
                            if (podeInserirE && empresa.nome != "")
                            {
                                bool retornoE = EmpresaCicloDAO.InsereEmpresa(empresa);
                                if (!retornoE)
                                    MessageBox.Show("Erro ao tentar salvar a empresa.", "Erro", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                else
                                {
                                    int codE = EmpresaCicloDAO.retornaID(empresa.nome);
                                    dtgInsercao.CurrentRow.Cells[1].Value = codE.ToString();
                                    Inserir.Text = "Inserir";
                                }
                            }
                            else if (empresa.nome == "") MessageBox.Show("Insira um nome válido para salvar a empresa.", "Atenção", MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Empresa já utilizada.", "Atenção", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                        }
                        else MessageBox.Show("Erro ao salvar empresa.Insira um nome válido para salvar a empresa.", "Atenção",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "Unidade":
                        VO.Unidade unidade = new VO.Unidade();
                        if (dtgInsercao.CurrentRow.Cells[0].Value != null)
                        {
                            unidade.unidade = dtgInsercao.CurrentRow.Cells[0].Value.ToString();
                            bool podeInserirU = UnidadeDAO.testaUnidade(unidade.unidade);
                            if (podeInserirU && unidade.unidade != "")
                            {
                                bool retorno = UnidadeDAO.InsereUnidade(unidade);
                                if (!retorno)
                                    MessageBox.Show("Erro ao tentar salvar a unidade.", "Erro", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                else
                                {
                                    int codU = UnidadeDAO.retornaID(unidade.unidade);
                                    dtgInsercao.CurrentRow.Cells[1].Value = codU.ToString();
                                    Inserir.Text = "Inserir";
                                }
                            }
                            else if (unidade.unidade == "") MessageBox.Show("Insira uma unidade válida para salvar-la.", "Atenção", MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Unidade já utilizada.", "Atenção", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                        }
                        else MessageBox.Show("Erro ao salvar a unidade.Insira uma unidade válida para salvar-la.", "Atenção",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private void CadastroGenerico_Load(object sender, EventArgs e)
        {
            switch (tipo)
            {
                case "Produto":
                    Descricao.Text = "Produtos";
                    this.Text = "Gerenciar Produtos";
                    List<Produto> listaProdutos = ProdutoDAO.retornaProdutos();
                    if(listaProdutos.Count != null && listaProdutos.Count > 0)
                        foreach (var listaProduto in listaProdutos)
                        {
                            dtgInsercao.Rows.Add(listaProduto.descricao, listaProduto.idProduto);
                        }
                    break;
                case "Empresa":
                    Descricao.Text = "Empresas";
                    this.Text = "Gerenciar Empresas";
                    List<VO.EmpresaCiclo> listaEmpresas = EmpresaCicloDAO.retornaEmpresas();
                    if(listaEmpresas != null && listaEmpresas.Count > 0)
                        foreach (var listaEmpresa in listaEmpresas)
                        {
                            dtgInsercao.Rows.Add(listaEmpresa.nome, listaEmpresa.idEmpresa);
                        }
                    break;
                case "Unidade":
                    Descricao.Text = "Unidades";
                    this.Text = "Gerenciar Unidades";
                    List<VO.Unidade> listaUnidades = UnidadeDAO.retornaUnidades();
                    if(listaUnidades != null && listaUnidades.Count > 0)
                        foreach (var listaUnidade in listaUnidades)
                        {
                            dtgInsercao.Rows.Add(listaUnidade.unidade, listaUnidade.idUnidade);
                        }
                    break;
            }
            if(dtgInsercao.Rows.Count > 0 )dtgInsercao.CurrentCell = dtgInsercao.Rows[0].Cells[0];
        }

        private void Excluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dtgInsercao.CurrentRow.Cells[1].Value);
            if (MessageBox.Show("Deseja continuar com a exclusão?", "Excluir", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (tipo)
                {
                    case "Produto":
                        bool testaProduto = ProdutoDAO.testaUsoProd(id);
                        if (!testaProduto)
                        {
                            bool retornoP = ProdutoDAO.deletaProduto(id);
                            if (!retornoP)
                                MessageBox.Show("Erro ao tentar excluir o produto.", "Erro", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            else
                            {
                                dtgInsercao.Rows.Clear();
                                List<Produto> listaProdutos = ProdutoDAO.retornaProdutos();
                                if (listaProdutos.Count != null && listaProdutos.Count > 0)
                                    foreach (var listaProduto in listaProdutos)
                                    {
                                        dtgInsercao.Rows.Add(listaProduto.descricao, listaProduto.idProduto);
                                    }
                            }
                        }
                        else
                            MessageBox.Show("O produto não pode ser excluído pois está sendo usado em algum ciclo.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "Empresa":
                        bool testaEmpresa = EmpresaCicloDAO.testaUsoEmpresa(id);
                        if (!testaEmpresa)
                        {
                            bool retornoE = EmpresaCicloDAO.deletaEmpresa(id);
                            if (!retornoE)
                                MessageBox.Show("Erro ao tentar excluir a empresa.", "Erro", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            else
                            {
                                dtgInsercao.Rows.Clear();
                                List<VO.EmpresaCiclo> empresas = EmpresaCicloDAO.retornaEmpresas();
                                if (empresas.Count != null && empresas.Count > 0)
                                    foreach (var empresa in empresas)
                                    {
                                        dtgInsercao.Rows.Add(empresa.nome, empresa.idEmpresa);
                                    }
                            }
                        }
                        else
                            MessageBox.Show("A empresa não pode ser excluída pois está sendo usada em algum ciclo.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "Unidade":
                        bool testaUnidade = UnidadeDAO.testaUsoUnid(id);
                        if (!testaUnidade)
                        {
                            bool retorno = UnidadeDAO.deletaUnidade(id);
                            if (!retorno)
                                MessageBox.Show("Erro ao tentar excluir a unidade.", "Erro", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            else
                            {
                                dtgInsercao.Rows.Clear();
                                List<VO.Unidade> unidades = UnidadeDAO.retornaUnidades();
                                if (unidades.Count != null && unidades.Count > 0)
                                    foreach (var unidade in unidades)
                                    {
                                        dtgInsercao.Rows.Add(unidade.unidade, unidade.idUnidade);
                                    }
                            }
                        }
                        else
                            MessageBox.Show("A unidade não pode ser excluída pois está sendo usada em algum ciclo.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private void Alterar_Click(object sender, EventArgs e)
        {
            switch (tipo)
            {
                case "Produto":
                    Produto prod = new Produto();
                    if (dtgInsercao.CurrentRow.Cells[0].Value != null)
                    {
                        prod.descricao = dtgInsercao.CurrentRow.Cells[0].Value.ToString();
                        prod.idProduto = Convert.ToInt32(dtgInsercao.CurrentRow.Cells[1].Value);
                        if (prod.idProduto != -1)
                        {
                            bool retornoP = ProdutoDAO.alterarProduto(prod);
                            if (!retornoP)
                                MessageBox.Show("Erro ao tentar alterar o produto.", "Erro", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Empresa alterada com sucesso", "Sucesso", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                        }
                        else
                            MessageBox.Show("Produto não cadastrado.", "Erro", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Erro ao tentar alterar o produto. Insira uma descrição válida.", "Atenção", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
                case "Empresa":
                    VO.EmpresaCiclo emp = new VO.EmpresaCiclo();
                    emp.idEmpresa = Convert.ToInt32(dtgInsercao.CurrentRow.Cells[1].Value);
                    if (dtgInsercao.CurrentRow.Cells[0].Value != null)
                    {
                        emp.nome = dtgInsercao.CurrentRow.Cells[0].Value.ToString();
                        if (emp.idEmpresa != -1)
                        {
                            bool retornoE = EmpresaCicloDAO.alterarEmpresa(emp);
                            if (!retornoE)
                                MessageBox.Show("Erro ao tentar alterar a empresa.", "Erro", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Empresa alterada com sucesso", "Sucesso", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                        }
                        else
                            MessageBox.Show("Empresa não cadastrada.", "Erro", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Erro ao tentar alterar a empresa. Insira um nome válido.", "Atenção", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
                case "Unidade":
                    VO.Unidade unid = new VO.Unidade();
                    unid.idUnidade = Convert.ToInt32(dtgInsercao.CurrentRow.Cells[1].Value);
                    if (dtgInsercao.CurrentRow.Cells[0].Value != null)
                    {
                        unid.unidade = dtgInsercao.CurrentRow.Cells[0].Value.ToString();
                        if (unid.idUnidade != -1)
                        {
                            bool retorno = UnidadeDAO.alterarUnidade(unid);
                            if (!retorno)
                                MessageBox.Show("Erro ao tentar alterar a unidade.", "Erro", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Empresa alterada com sucesso", "Sucesso", MessageBoxButtons.OK,
                                    MessageBoxIcon.None);
                        }
                        else
                            MessageBox.Show("Unidade não cadastrada.", "Erro", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Erro ao tentar alterar a unidade. Insira uma unidade válida.", "Atenção", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    break;
            }
        }
    }
}
