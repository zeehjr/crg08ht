using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using CRG08.Dao;
using CRG08.Util;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;

namespace CRG08.View
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        Principal principal = new Principal();
        public Backup(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCopiaDeSeguranca_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdBackup = new SaveFileDialog();

            this.Cursor = Cursors.WaitCursor;
            FbBackup backupSvc = new FbBackup();
            string NomeArquivo = string.Empty;

            backupSvc.ConnectionString = Util.DAO.Conn;
            backupSvc.Verbose = true;

            try
            {
                sfdBackup.Filter = "Arquivo de BackUp CRG 08|*.crg";
                sfdBackup.Title = "Salvar Como";
                sfdBackup.FileName = "BackUp CRG 08 - Dia " + DateTime.Today.Day.ToString("0,0") + "_" +
                        DateTime.Today.Month.ToString("0,0");

                if (sfdBackup.ShowDialog(this) == DialogResult.OK)
                {
                    if (sfdBackup.FileName != string.Empty)
                    {
                        NomeArquivo = sfdBackup.FileName;
                        if (File.Exists(NomeArquivo)) File.Delete(NomeArquivo);
                    }
                    else
                    {
                        MessageBox.Show("Digite um nome para o backup","Atenção",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                backupSvc.BackupFiles.Add(new FbBackupFile(NomeArquivo, -1));
                backupSvc.Execute();
                MessageBox.Show("Backup do banco de Dados efetuado com Sucesso! \nArquivo Criado em: " + NomeArquivo, "Backup", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                backupSvc = null;
            }
        }

        private void btnRestaurarCopiaDeSeguranca_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdBackup = new OpenFileDialog();

            this.Cursor = Cursors.WaitCursor;

            string NomeArquivo = string.Empty;

            FbConnection.ClearAllPools();

            try
            {
                {
                    ofdBackup.Title = "Abrir arquivo de BackUp";
                    ofdBackup.Filter = "Arquivo de Backup CRG 08|*.crg";
                    if (ofdBackup.ShowDialog(this) == DialogResult.OK)
                    {
                        if (ofdBackup.FileName != string.Empty)
                        {
                            NomeArquivo = ofdBackup.FileName;
                        }
                        else
                        {
                            MessageBox.Show("Selecione o backup para restaurar os dados","Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                this.Cursor = Cursors.WaitCursor;


                string RestoreBanco = Environment.CurrentDirectory + "\\db.fdb";
                //string conexao = @"User=SYSDBA;Password=masterkey;database = " + RestoreBanco + ";DataSource=localhost;Port=3050;Dialect=3;";

                string conexao = Util.DAO.Conn;
                FbRestore RestoreSvc = new FbRestore();
                RestoreSvc.ConnectionString = conexao;

                RestoreSvc.BackupFiles.Add(new FbBackupFile(NomeArquivo, 2048));
                RestoreSvc.Verbose = true;
                RestoreSvc.PageSize = 4096;
                RestoreSvc.Options = FbRestoreFlags.Create | FbRestoreFlags.Replace;

                RestoreSvc.Execute();

                MessageBox.Show("Backup restaurado com sucesso!", "Sucesso!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Application.Restart();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            chkAtivarBackup.Visible = true;
            VO.Backup backup = BackupDAO.RetornaBackup();
            if (backup == null)
            {
                chkAtivarBackup.Checked = false;
                label1.Enabled = false;
                label2.Enabled = false;
                CaminhoBackup.Enabled = false;
                LocalizarCaminho.Enabled = false;
                label3.Enabled = false;
                label4.Enabled = false;
                SalvarConfiguracaoBackup.Enabled = false;
                cmbPeriodo.Enabled = false;
                cmbPeriodo.Text = "Diariamente";
                CaminhoBackup.Text = "";
            }
            else
            {
                chkAtivarBackup.Checked = true;
                switch (backup.Periodo)
                {
                    case 0:
                        cmbPeriodo.Text = "Diariamente";
                        break;
                    case 1:
                        cmbPeriodo.Text = "Semanalmente";
                        break;
                    case 2:
                        cmbPeriodo.Text = "Mensalmente";
                        break;
                }
                CaminhoBackup.Text = backup.CaminhoBackup;
            }
        }

        private void LocalizarCaminho_Click(object sender, EventArgs e)
        {
            var dialogResult = folderBrowserDialog1.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                CaminhoBackup.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void SalvarConfiguracaoBackup_Click(object sender, EventArgs e)
        {
            VO.Backup backup = BackupDAO.RetornaBackup();
            if (backup == null && chkAtivarBackup.Checked)
            {
                backup = new VO.Backup();
                backup.Periodo = cmbPeriodo.SelectedIndex;
                backup.CaminhoBackup = CaminhoBackup.Text;
                bool retorno = BackupDAO.InserirBackup(backup);
                if (retorno)
                {
                    MessageBox.Show("Backup Salvo com Sucesso.","Sucesso",MessageBoxButtons.OK, MessageBoxIcon.None);
                    VO.LogMudanca log = new VO.LogMudanca();
                    log.descricao = "Backup automático inserido";
                    log.crg = 0;
                    log.data = DateTime.Now;
                    string[] dados = ObterDadosUltimo();
                    log.responsavel = dados[1];
                    LogMudancaDAO.insereLogMudanca(log);
                }
                else MessageBox.Show("Erro ao tentar salvar o backup.Verifique o log de erro para obter mais informações.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (chkAtivarBackup.Checked)
            {
                backup.Periodo = cmbPeriodo.SelectedIndex;
                backup.CaminhoBackup = CaminhoBackup.Text;
                string data = DateTime.Now.ToString();
                backup.DataUltimoBackup = data.Substring(0, 10);
                bool retorno = BackupDAO.AlteraBackup(backup);
                if (retorno)
                {
                    MessageBox.Show("Alterado as configurações do Backup");
                    VO.LogMudanca log = new VO.LogMudanca();
                    log.descricao = "Backup automático alterado";
                    log.crg = 0;
                    log.data = DateTime.Now;
                    string[] dados = ObterDadosUltimo();
                    log.responsavel = dados[1];
                    LogMudancaDAO.insereLogMudanca(log);
                }
                else MessageBox.Show("Erro ao tentar alterar o backup!");
            }
            else if (backup != null && chkAtivarBackup.Checked == false)
            {
                if (MessageBox.Show("Você desativou o backup automático.Deseja confirmar?", "Confirmar", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    VO.LogMudanca log = new VO.LogMudanca();
                    log.descricao = "Backup automático desativado";
                    log.crg = 0;
                    DateTime d = DateTime.Now;
                    log.data = DateTime.Now;
                    string[] dados = ObterDadosUltimo();
                    log.responsavel = dados[1];
                    LogMudancaDAO.insereLogMudanca(log);
                    BackupDAO.DeletaBackup();
                }
            }
            principal.CarregaInformacoes();
        }

        public bool AtualizaUltimo(string operador, string responsavel)
        {
            try
            {
                return UltimosDAO.SetarUltimoOperador(operador) &&
                       UltimosDAO.SetarUltimoResponsavel(responsavel);
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
                string[] retorno = new string[2];
                retorno[0] = ult.Element("Operador").Value;
                retorno[1] = ult.Element("Responsavel").Value;
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

        private void chkAtivarBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtivarBackup.Checked)
            {
                label1.Enabled = true;
                label2.Enabled = true;
                CaminhoBackup.Enabled = true;
                LocalizarCaminho.Enabled = true;
                label3.Enabled = true;
                label4.Enabled = true;
                SalvarConfiguracaoBackup.Enabled = true;
                cmbPeriodo.Enabled = true;
            }
            else
            {
                label1.Enabled = false;
                label2.Enabled = false;
                CaminhoBackup.Enabled = false;
                LocalizarCaminho.Enabled = false;
                label3.Enabled = false;
                label4.Enabled = false;
                cmbPeriodo.Enabled = false;
            }
        }
    }
}
