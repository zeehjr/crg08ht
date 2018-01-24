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

namespace CRG08.View
{
    public partial class Empresa : Form
    {
        private bool mudouImagem = false, carregou = false;
        byte[] imagem;
        public Empresa()
        {
            InitializeComponent();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimparEmpresa_Click(object sender, EventArgs e)
        {
            txtEmpresa.Text = "";
            txtEndereco.Text = "";
            txtCEP.Text = "";
            txtCidade.Text = "";
            cmbUF.SelectedIndex = 0;
            txtFone.Text = "";
            txtFax.Text = "";
            txtCnpj.Text = "";
            txtIE.Text = "";
            txtNumCredenciamento.Text = "";

            lblQtdEmpresa.Text = "";
            lblQtdEndereco.Text = "";
            lblQtdCEP.Text = "";
            lblQtdCidade.Text = "";
            lblQtdUF.Text = "";
            lblQtdFone.Text = "";
            lblQtdFax.Text = "";
            lblQtdCnpj.Text = "";
            lblQtdIE.Text = "";
            lblQtdNumCredenciamento.Text = "";
            pictureBox1.Image = null;
            mudouImagem = true;
        }

        private void btnSalvarEmpresa_Click(object sender, EventArgs e)
        {
            VO.Empresa empresa = EmpresaDAO.retornaEmpresa();
            if (empresa == null)
            {
                if (txtEmpresa.Text != "" ||
                    txtEndereco.Text != "" ||
                    txtCEP.Text != "" ||
                    txtCidade.Text != "" ||
                    cmbUF.SelectedIndex != 0 ||
                    txtFone.Text != "" ||
                    txtFax.Text != "" ||
                    txtCnpj.Text != "" ||
                    txtIE.Text != "" ||
                    txtNumCredenciamento.Text != "" ||
                    pictureBox1.Image != null)
                {
                    empresa = new VO.Empresa();

                    empresa.Nome = txtEmpresa.Text;
                    empresa.Endereco = txtEndereco.Text;
                    empresa.Cep = txtCEP.Text;
                    empresa.Cidade = txtCidade.Text;
                    empresa.UF = cmbUF.SelectedIndex;
                    empresa.Fone = txtFone.Text;
                    empresa.Fax = txtFax.Text;
                    empresa.CNPJ = txtCnpj.Text;
                    empresa.IE = txtIE.Text;
                    empresa.NCredenciamento = txtNumCredenciamento.Text;
                    empresa.Logo = imagem;

                    bool retornoInsert = EmpresaDAO.insereEmpresa(empresa);

                    if (retornoInsert)
                    {
                        MessageBox.Show("Incluído com Sucesso !", "Incluir", MessageBoxButtons.OK,
                            MessageBoxIcon.None);
                        if (chkLogoEmpresa.Checked) AtualizaUltimo("Empresa");
                        else AtualizaUltimo("Digisystem");
                        VO.LogMudanca log = new VO.LogMudanca();
                        log.descricao = "Empresa foi inserido com sucesso";
                        log.crg = 0;
                        log.data = DateTime.Now;
                        string[] dados = ObterDadosUltimoMudanca();
                        log.responsavel = dados[1];
                        LogMudancaDAO.insereLogMudanca(log);
                    }
                }
            }
            else
            {
                if (
                    empresa.Nome != txtEmpresa.Text ||
                    empresa.Endereco != txtEndereco.Text ||
                    empresa.Cep != txtCEP.Text ||
                    empresa.Cidade != txtCidade.Text ||
                    empresa.UF != cmbUF.SelectedIndex ||
                    empresa.Fone != txtFone.Text ||
                    empresa.Fax != txtFax.Text ||
                    empresa.CNPJ != txtCnpj.Text ||
                    empresa.IE != txtIE.Text ||
                    empresa.NCredenciamento != txtNumCredenciamento.Text ||
                    pictureBox1.Image != null
                    )
                {
                    var file = new FileInfo(abrirArquivo.FileName);

                    empresa.Nome = txtEmpresa.Text;
                    empresa.Endereco = txtEndereco.Text;
                    empresa.Cep = txtCEP.Text.Replace("_", "");
                    empresa.Cidade = txtCidade.Text;
                    empresa.UF = cmbUF.SelectedIndex;
                    empresa.Fone = txtFone.Text.Replace("_", "");
                    empresa.Fax = txtFax.Text.Replace("_", "");
                    empresa.CNPJ = txtCnpj.Text.Replace("_", "");
                    empresa.IE = txtIE.Text;
                    empresa.NCredenciamento = txtNumCredenciamento.Text;

                    bool retornoUpdate;
                    if (mudouImagem)
                    {
                        empresa.Logo = imagem;
                        retornoUpdate = EmpresaDAO.alteraEmpresaComLogo(empresa);
                    }
                    else retornoUpdate = EmpresaDAO.alteraEmpresa(empresa);

                    if (retornoUpdate)
                    {
                        MessageBox.Show("Alterado com Sucesso !", "Alterar", MessageBoxButtons.OK,MessageBoxIcon.None);
                        if (chkLogoEmpresa.Checked) AtualizaUltimo("Empresa");
                        else AtualizaUltimo("Digisystem");
                        VO.LogMudanca log = new VO.LogMudanca();
                        log.descricao = "Empresa foi alterada com sucesso";
                        log.crg = 0;
                        log.data = DateTime.Now;
                        string[] dados = ObterDadosUltimoMudanca();
                        log.responsavel = dados[1];
                        LogMudancaDAO.insereLogMudanca(log);
                    }
                }
                else if (pictureBox1.Image == null && empresa.Logo != null)
                {
                    var file = new FileInfo(abrirArquivo.FileName);

                    empresa.Nome = txtEmpresa.Text;
                    empresa.Endereco = txtEndereco.Text;
                    empresa.Cep = txtCEP.Text;
                    empresa.Cidade = txtCidade.Text;
                    empresa.UF = cmbUF.SelectedIndex;
                    empresa.Fone = txtFone.Text.Replace("_", "");
                    empresa.Fax = txtFax.Text;
                    empresa.CNPJ = txtCnpj.Text;
                    empresa.IE = txtIE.Text;
                    empresa.NCredenciamento = txtNumCredenciamento.Text;

                    bool retornoUpdate;
                    if (mudouImagem)
                    {
                        empresa.Logo = imagem;
                        retornoUpdate = EmpresaDAO.alteraEmpresaComLogo(empresa);
                    }
                    else retornoUpdate = EmpresaDAO.alteraEmpresa(empresa);

                    if (retornoUpdate)
                    {
                        MessageBox.Show("Alterado com Sucesso !", "Alterar", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        if (chkLogoEmpresa.Checked) AtualizaUltimo("Empresa");
                        else AtualizaUltimo("Digisystem");
                        VO.LogMudanca log = new VO.LogMudanca();
                        log.descricao = "Empresa foi alterada com sucesso";
                        log.crg = 0;
                        log.data = DateTime.Now;
                        string[] dados = ObterDadosUltimoMudanca();
                        log.responsavel = dados[1];
                        LogMudancaDAO.insereLogMudanca(log);
                    }
                }
                else MessageBox.Show("Nada para alterar !", "Atenção", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            abrirArquivo.RestoreDirectory = true;
            abrirArquivo.Title = "Importar Imagem";
            abrirArquivo.Filter = "JPEG Images(*.jpg)|*.jpg";
            abrirArquivo.DefaultExt = "jpg";
            abrirArquivo.CheckPathExists = true;

            var dialogResult = abrirArquivo.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    var file = new FileInfo(abrirArquivo.FileName);

                    using (var stream = abrirArquivo.OpenFile())
                    using (var reader = new BinaryReader(stream))
                        imagem = reader.ReadBytes((int)stream.Length);

                    MemoryStream memoryStream = new MemoryStream(imagem);
                    Bitmap image = new Bitmap(memoryStream);

                    pictureBox1.Image = image;
                    mudouImagem = true;
                }
                catch (Exception error)
                {
                    VO.LogErro logErro = new VO.LogErro();
                    logErro.crg = 0;
                    logErro.descricao = "Erro ao importar imagem";
                    logErro.data = DateTime.Now;
                    logErro.maisDetalhes = error.Message;
                    LogErroDAO.inserirLogErro(logErro, 0);

                    MessageBox.Show("Erro ao importar imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public bool AtualizaUltimo(string opcao)
        {
            try
            {
                return UltimosDAO.SetarUltimaLogo(opcao);
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao atualizar dados de Operador e Responsavel";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao atualizar dados de Operador e Responsavel", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
        }

        private string ObterDadosUltimo()
        {
            try
            {
                return UltimosDAO.RetornaUltimaLogo();
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter dados de Operador e Responsavel";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao obter dados de Operador e Responsavel", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return "";
            }
        }

        private void Empresa_Load(object sender, EventArgs e)
        {

            VO.Empresa empresa = EmpresaDAO.retornaEmpresa();

            if (empresa != null)
            {
                txtEmpresa.Text = empresa.Nome;
                txtEndereco.Text = empresa.Endereco;
                txtCEP.Text = empresa.Cep;
                txtCidade.Text = empresa.Cidade;
                cmbUF.SelectedIndex = empresa.UF;
                txtFone.Text = empresa.Fone;
                txtFax.Text = empresa.Fax;
                txtCnpj.Text = empresa.CNPJ;
                txtIE.Text = empresa.IE;
                txtNumCredenciamento.Text = empresa.NCredenciamento;
                
                if (empresa.Logo != null)
                {
                    MemoryStream mStream = new MemoryStream();
                    byte[] pData = empresa.Logo;
                    mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                    Bitmap bm = new Bitmap(mStream, false);
                    mStream.Dispose();

                    pictureBox1.Image = bm;
                }

                string opcao = ObterDadosUltimo();
                if (opcao == "Empresa") chkLogoEmpresa.Checked = true;
                else chkLogoEmpresa.Checked = false;
            }
            carregou = true;
        }

        private string[] ObterDadosUltimoMudanca()
        {
            try
            {
                string[] retorno = new string[2];
                retorno[0] = UltimosDAO.RetornaUltimoOperador();
                retorno[1] = UltimosDAO.RetornaUltimoResponsavel();
                return retorno;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter dados de Operador e Responsavel";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao obter dados de Operador e Responsavel", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return new string[2] { "", "" };
            }
        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFone_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkLogoEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if(chkLogoEmpresa.Checked && carregou)
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Essa opção só é possivel caso haja uma imagem de Logo ao lado.", "Atenção",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);
                    chkLogoEmpresa.Checked = false;
                }
        }
    }
}
