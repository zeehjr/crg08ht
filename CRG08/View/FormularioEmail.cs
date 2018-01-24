using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using CRG08.Dao;
using CRG08.Util;
using CRG08.VO;

namespace CRG08.View
{
    public partial class FormularioEmail : Form
    {
        private ImportarExportar exportar;
        public FormularioEmail(ImportarExportar exportar)
        {
            InitializeComponent();
            this.exportar = exportar;
        }
        public FormularioEmail()
        {
            InitializeComponent();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Continuar_Click(object sender, EventArgs e)
        {
            if (txtServidorSMTP.Text != "" && txtDe.Text != "" && txtNomeUsuario.Text != "" && txtSenha.Text != "" &&
                txtPorta.Text != "" && dtgDestinatarios.Rows.Count > 0 && dtgDestinatarios.Rows[0].Cells[1].Value != "+")
            {
                string[] dados = new string[6];
                dados[0] = txtServidorSMTP.Text;
                dados[1] = txtDe.Text;
                dados[2] = txtNomeUsuario.Text;
                dados[3] = txtSenha.Text;
                dados[4] = txtPorta.Text;
                if (chkSSL.Checked) dados[5] = "1";
                else dados[5] = "0";
                AtualizaDadosEmail(dados);
                exportar.ContinuaEnviandoPorEmail();
                this.Close();
            }
            else if(txtServidorSMTP.Text != "" && txtDe.Text != "" && txtNomeUsuario.Text != "" && txtSenha.Text != "" &&
                txtPorta.Text != "" && dtgDestinatarios.Rows.Count == 1 && dtgDestinatarios.Rows[0].Cells[1].Value == "+")
                    MessageBox.Show("É preciso adicionar um destinatário pelo menos.", "Atenção", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            else 
                MessageBox.Show("É preciso preencher todos os dados para o envio e adicionar um destinatário pelo menos.", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void AdicionarDestinatario_Click(object sender, EventArgs e)
        {   
            List<Destinatarios> destinatarios = ListaDestinatarios();
            if (destinatarios.All(
                    d => d.email != dtgDestinatarios.Rows[dtgDestinatarios.Rows.Count - 1].Cells[1].Value.ToString()))
            {
                bool retorno = AddDestinatario(dtgDestinatarios.Rows[dtgDestinatarios.Rows.Count - 1].Cells[1].Value.ToString(),
                    int.Parse(dtgDestinatarios.Rows[dtgDestinatarios.Rows.Count - 1].Cells[0].Value.ToString()));
                if (retorno)
                {
                    destinatarios = ListaDestinatarios();

                    int proximoId;
                    if (destinatarios.Count > 0) proximoId = destinatarios[destinatarios.Count - 1].id + 1;
                    else proximoId = 1;
                    dtgDestinatarios.Rows.Clear();
                    foreach (var d in destinatarios)
                    {
                        dtgDestinatarios.Rows.Add(d.id, d.email);
                    }
                    dtgDestinatarios.Rows.Add(proximoId, "+");
                    MessageBox.Show("Destinatário adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK,MessageBoxIcon.None);
                }
                else
                    MessageBox.Show("Ocorreu um erro ao tentar adicionado destinatário.",
                        "Erro", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else MessageBox.Show("Destinatário já existente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AlterarDestinatario_Click(object sender, EventArgs e)
        {
            List<Destinatarios> destinatarios = ListaDestinatarios();
            if (destinatarios.All(
                d => d.email != dtgDestinatarios.Rows[dtgDestinatarios.SelectedRows[0].Index].Cells[1].Value.ToString()))
            {
                Destinatarios d = new Destinatarios();
                d.id = int.Parse(dtgDestinatarios.Rows[dtgDestinatarios.SelectedRows[0].Index].Cells[0].Value.ToString());
                d.email = dtgDestinatarios.Rows[dtgDestinatarios.SelectedRows[0].Index].Cells[1].Value.ToString();
                bool retorno = EditarDestinatario(d);
                if (retorno) MessageBox.Show("Destinatário alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);
                else
                    MessageBox.Show("Ocorreu um erro ao tentar alterar destinatário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Destinatário já existente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirDestinatario_Click(object sender, EventArgs e)
        {
            bool retorno  = ExcluiDestinatario(int.Parse(dtgDestinatarios.Rows[dtgDestinatarios.SelectedRows[0].Index].Cells[0].Value.ToString()));
            if (retorno)
            {
                List<Destinatarios> destinatarios = ListaDestinatarios();

                int proximoId;
                if (destinatarios.Count > 0) proximoId = destinatarios[destinatarios.Count - 1].id + 1;
                else proximoId = 1;
                dtgDestinatarios.Rows.Clear();
                foreach (var d in destinatarios)
                {
                    dtgDestinatarios.Rows.Add(d.id, d.email);
                }
                dtgDestinatarios.Rows.Add(proximoId, "+");
                MessageBox.Show("Destinatário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
                MessageBox.Show("Ocorreu um erro ao tentar excluir destinatário.","Erro", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private string[] ObterDadosEmail()
        {
            try
            {
                var path = Environment.CurrentDirectory + "\\ConfiguracaoEmail.xml";
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                var cspParams = new CspParameters();

                cspParams.KeyContainerName = "Configuracao";
                var rsaKey = new RSACryptoServiceProvider(cspParams);

                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument doc = XDocument.Load(stream);
                var config = doc.Element("ConfiguracaoEmail").Element("Configuracao");
                string[] retorno = new string[6];
                retorno[0] = config.Element("SMTP").Value;
                retorno[1] = config.Element("De").Value;
                retorno[2] = config.Element("NomeUsuario").Value;
                retorno[3] = config.Element("Senha").Value;
                retorno[4] = config.Element("Porta").Value;
                retorno[5] = config.Element("SSL").Value;
                return retorno;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter dados da Configuração de Email";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao obter dados da Configuração de Email", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return new string[6];
            }
        }

        public bool AtualizaDadosEmail(string[] dados)
        {
            try
            {
                string path = Environment.CurrentDirectory + "\\ConfiguracaoEmail.xml";
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                var cspParams = new CspParameters();

                cspParams.KeyContainerName = "Configuracao";
                var rsaKey = new RSACryptoServiceProvider(cspParams);

                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument doc = XDocument.Load(stream);
                var config = from ultimo in doc.Element("ConfiguracaoEmail").Elements("Configuracao") select ultimo;
                
                foreach (var conf in config.Where(x => x.Element("Id").Value.Equals((1).ToString())))
                {
                    conf.Element("SMTP").Value = dados[0];
                    conf.Element("De").Value = dados[1];
                    conf.Element("NomeUsuario").Value = dados[2];
                    conf.Element("Senha").Value = dados[3];
                    conf.Element("Porta").Value = dados[4];
                    conf.Element("SSL").Value = dados[5];
                    
                    doc.Save(path);
                }
                return true;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao atualizar dados da Configuração de Email";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao atualizar dados da Configuração de Email", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            finally
            {
                var xmlDoc = new XmlDocument();
                string path = Environment.CurrentDirectory + "\\ConfiguracaoEmail.xml";
                try
                {
                    xmlDoc.PreserveWhitespace = true;
                    xmlDoc.Load(path);
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message);
                }

                var cspParams = new CspParameters();
                cspParams.KeyContainerName = "Configuracao";

                var rsaKey = new RSACryptoServiceProvider(cspParams);

                try
                {
                    Crypto.Encrypt(xmlDoc, "ConfiguracaoEmail", "Configuracao", rsaKey, "rsaKey");
                    xmlDoc.Save(path);
                }
                catch (Exception er)
                {
                    VO.LogErro logErro = new VO.LogErro();
                    logErro.crg = 0;
                    logErro.descricao = "Erro ao tentar encriptografar Configuração de Email";
                    logErro.data = DateTime.Now;
                    logErro.maisDetalhes = er.Message;
                    LogErroDAO.inserirLogErro(logErro, 0);
                }
            }
        }

        public static bool AddDestinatario(string email, int id)
        {
            try
            {
                string path = Environment.CurrentDirectory + "\\Destinatarios.xml";
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                var cspParams = new CspParameters();

                cspParams.KeyContainerName = "Destinatarios";
                var rsaKey = new RSACryptoServiceProvider(cspParams);

                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument xml = XDocument.Load(stream);

                XElement x = new XElement("Destinatarios");
                x.Add(new XAttribute("Id", id.ToString()));
                x.Add(new XAttribute("Email", email));
                //XElement xml = XElement.Load("Destinatarios.xml");
                xml.Element("Destinatarios").Add(x);
                xml.Save(path);

                return true;
            }
            catch (Exception er)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao tentar adicionar destinatário";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = er.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                return false;
            }
            finally
            {
                var xmlDoc = new XmlDocument();
                string path = Environment.CurrentDirectory + "\\Destinatarios.xml";
                try
                {
                    xmlDoc.PreserveWhitespace = true;
                    xmlDoc.Load(path);
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message);
                }

                var cspParams = new CspParameters();
                cspParams.KeyContainerName = "Destinatarios";

                var rsaKey = new RSACryptoServiceProvider(cspParams);

                try
                {
                    Crypto.Encrypt(xmlDoc, "Destinatarios", "Destinatario", rsaKey, "rsaKey");
                    xmlDoc.Save(path);
                }
                catch (Exception er)
                {
                    VO.LogErro logErro = new VO.LogErro();
                    logErro.crg = 0;
                    logErro.descricao = "Erro ao tentar encriptografar Destinatarios";
                    logErro.data = DateTime.Now;
                    logErro.maisDetalhes = er.Message;
                    LogErroDAO.inserirLogErro(logErro, 0);
                }
            }
        }

        public static List<Destinatarios> ListaDestinatarios()
        {
            try
            {
                List<Destinatarios> destinatarios = new List<Destinatarios>();
                var path = Environment.CurrentDirectory + "\\Destinatarios.xml";
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                var cspParams = new CspParameters();

                cspParams.KeyContainerName = "Destinatarios";
                var rsaKey = new RSACryptoServiceProvider(cspParams);

                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument xml = XDocument.Load(stream);
                
                foreach (XElement x in xml.Element("Destinatarios").Elements())
                {
                    Destinatarios d = new Destinatarios()
                    {
                        id = int.Parse(x.Attribute("Id").Value),
                        email = x.Attribute("Email").Value
                    };
                    destinatarios.Add(d);
                }
                return destinatarios;
            }
            catch (Exception er)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao tentar listar destinatários";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = er.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                return new List<Destinatarios>();
            }
        }

        public static bool ExcluiDestinatario(int id)
        {
            string path = Environment.CurrentDirectory + "\\Destinatarios.xml";
            var cspParams = new CspParameters();
            cspParams.KeyContainerName = "Destinatarios";
            var rsaKey = new RSACryptoServiceProvider(cspParams);
            try
            {
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                
                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument xml = XDocument.Load(stream);

                var elements = xml.XPathSelectElements("Destinatarios/Destinatarios");
                foreach (var xElement in elements)
                {
                    if (xElement.FirstAttribute.Value == id.ToString())
                    {
                        xElement.Remove();
                    }
                }
                xml.Save(path);
                return true;

                return true;
            }
            catch (Exception er)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao tentar excluir destinatário";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = er.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                return false;
            }

            finally
            {
                var xmlDoc = new XmlDocument();
                
                try
                {
                    xmlDoc.PreserveWhitespace = true;
                    xmlDoc.Load(path);
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message);
                }

                try
                {
                    Crypto.Encrypt(xmlDoc, "Destinatarios", "Destinatario", rsaKey, "rsaKey");
                    xmlDoc.Save(path);
                }
                catch (Exception er)
                {
                    VO.LogErro logErro = new VO.LogErro();
                    logErro.crg = 0;
                    logErro.descricao = "Erro ao tentar encriptografar Destinatarios";
                    logErro.data = DateTime.Now;
                    logErro.maisDetalhes = er.Message;
                    LogErroDAO.inserirLogErro(logErro, 0);
                }
            }
        }

        public static bool EditarDestinatario(Destinatarios destinatario)
        {
            string path = Environment.CurrentDirectory + "\\Destinatarios.xml";
            var cspParams = new CspParameters();
            cspParams.KeyContainerName = "Destinatarios";
            var rsaKey = new RSACryptoServiceProvider(cspParams);
            try
            {
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                
                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument xml = XDocument.Load(stream);
                var elements = xml.XPathSelectElements("Destinatarios/Destinatarios");
                foreach (var xElement in elements)
                {
                    if (xElement.FirstAttribute.Value == destinatario.id.ToString())
                    {
                        xElement.LastAttribute.Value = destinatario.email;
                    }
                }
                xml.Save(path);
                return true;
            }
            catch (Exception er)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao tentar editar destinatário";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = er.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                return false;
            }
            finally
            {
                var xmlDoc = new XmlDocument();
                
                try
                {
                    xmlDoc.PreserveWhitespace = true;
                    xmlDoc.Load(path);
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message);
                }

                try
                {
                    Crypto.Encrypt(xmlDoc, "Destinatarios", "Destinatario", rsaKey, "rsaKey");
                    xmlDoc.Save(path);
                }
                catch (Exception er)
                {
                    VO.LogErro logErro = new VO.LogErro();
                    logErro.crg = 0;
                    logErro.descricao = "Erro ao tentar encriptografar Destinatarios";
                    logErro.data = DateTime.Now;
                    logErro.maisDetalhes = er.Message;
                    LogErroDAO.inserirLogErro(logErro, 0);
                }
            }
        }

        private void FormularioEmail_Load(object sender, EventArgs e)
        {
            string[] dadosConfiguracao = ObterDadosEmail();
            
            txtServidorSMTP.Text = dadosConfiguracao[0];
            txtDe.Text = dadosConfiguracao[1];
            txtNomeUsuario.Text = dadosConfiguracao[2];
            txtSenha.Text = dadosConfiguracao[3];
            txtPorta.Text = dadosConfiguracao[4];
            if (int.Parse(dadosConfiguracao[5]) == 1) chkSSL.Checked = true;
            else chkSSL.Checked = false;
            
            List<Destinatarios> destinatarios = ListaDestinatarios();
            foreach (var d in destinatarios)
            {
                dtgDestinatarios.Rows.Add(d.id, d.email);
            }

            int proximoId;
            if (destinatarios.Count > 0) proximoId = destinatarios[destinatarios.Count - 1].id + 1;
            else proximoId = 1;
            dtgDestinatarios.Rows.Add(proximoId, "+");
        }
    }
}
