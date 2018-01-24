using System;
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
    public partial class Cores : Form
    {
        public Cores()
        {
            InitializeComponent();
        }

        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cores_Load(object sender, EventArgs e)
        {
            string[] Cores = ObterDadosUltimo();
            txtT1.Text = Cores[0];
            txtT2.Text = Cores[1];
            txtT3.Text = Cores[2];
            txtT4.Text = Cores[3];
            txtCA.Text = Cores[4];
        }

        private string[] ObterDadosUltimo()
        {
            try
            {
                var path = Environment.CurrentDirectory + "\\Ultimos.xml";
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                var cspParams = new CspParameters();

                cspParams.KeyContainerName = "Ultimo";
                var rsaKey = new RSACryptoServiceProvider(cspParams);

                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument doc = XDocument.Load(stream);
                var ult = doc.Element("Ultimos").Element("ultimo");
                string[] retorno = new string[5];
                retorno[0] = ult.Element("CoresT1").Value;
                retorno[1] = ult.Element("CoresT2").Value;
                retorno[2] = ult.Element("CoresT3").Value;
                retorno[3] = ult.Element("CoresT4").Value;
                retorno[4] = ult.Element("CoresCA").Value;
                return retorno;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter dados das Cores";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao obter dados das Cores", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return new string[5] { "", "", "", "", "" };
            }
        }

        public bool AtualizaUltimo(string T1, string T2, string T3, string T4, string CA)
        {
            try
            {
                string path = Environment.CurrentDirectory + "\\Ultimos.xml";
                var stream = new MemoryStream();
                var xmlDocument = new XmlDocument();
                var cspParams = new CspParameters();

                cspParams.KeyContainerName = "Ultimo";
                var rsaKey = new RSACryptoServiceProvider(cspParams);

                xmlDocument.PreserveWhitespace = true;
                xmlDocument.Load(path);

                Crypto.Decrypt(xmlDocument, rsaKey, "rsaKey");

                xmlDocument.Save(stream);
                stream.Flush();
                stream.Position = 0;

                XDocument doc = XDocument.Load(stream);
                var ult = from ultimo in doc.Element("Ultimos").Elements("ultimo") select ultimo;
                foreach (var ut in ult.Where(x => x.Element("Id").Value.Equals((1).ToString())))
                {
                    ut.Element("CoresT1").Value = T1;
                    ut.Element("CoresT2").Value = T2;
                    ut.Element("CoresT3").Value = T3;
                    ut.Element("CoresT4").Value = T4;
                    ut.Element("CoresCA").Value = CA;
                    doc.Save(path);
                }
                return true;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao atualizar as Cores";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao atualizar as Cores", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            finally
            {
                var xmlDoc = new XmlDocument();
                string path = Environment.CurrentDirectory + "\\Ultimos.xml";
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
                cspParams.KeyContainerName = "Ultimo";

                var rsaKey = new RSACryptoServiceProvider(cspParams);

                try
                {
                    Crypto.Encrypt(xmlDoc, "Ultimos", "ultimo", rsaKey, "rsaKey");
                    xmlDoc.Save(path);
                }
                catch (Exception er)
                {
                    VO.LogErro logErro = new VO.LogErro();
                    logErro.crg = 0;
                    logErro.descricao = "Erro ao tentar encriptografar Ultimo";
                    logErro.data = DateTime.Now;
                    logErro.maisDetalhes = er.Message;
                    LogErroDAO.inserirLogErro(logErro, 0);
                }
            }
        }

        private void Aplicar_Click(object sender, EventArgs e)
        {
            bool retorno = AtualizaUltimo(txtT1.Text, txtT2.Text, txtT3.Text, txtT4.Text, txtCA.Text);
            if (retorno) MessageBox.Show("As Cores foram atualizadas com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);
            else MessageBox.Show("Erro ao tentar alterar as Cores.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
