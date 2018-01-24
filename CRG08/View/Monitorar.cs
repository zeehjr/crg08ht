using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using CRG08.BO;
using CRG08.Dao;
using CRG08.Util;
using CRG08.VO;

namespace CRG08.View
{
    public partial class Monitorar : Form
    {
        private Envios envios;
        public SerialPort SrpComm;
        public string porta { get; set; }

        public Thread threadLoopingEnvios;

        public int posinicial;
        public int poslabel;

        public Stopwatch tempo_decorrido;
        public int ultimo_cursor;
        public Label lblAnterior;
        public int cont_conexao_erro = 0;

        public bool aguardando_conexao = false,
            conexao_sucesso = false,
            configurar_leds = false,
            esperandoF = false,
            em_uso = false,
            processando = false,
            para_looping_envios = false;

        private Principal principal;
        public Monitorar(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
        }

        public Monitorar()
        {
            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            return false;
        }

        public Label buscarLabelPorNome(string nome)
        {
            return (Label)this.Controls.Find(nome, true).FirstOrDefault();
        }

        public void limpaTela()
        {
            if (lbl128.InvokeRequired)
            {
                lbl128.Invoke(new MethodInvoker(() =>
                {
                    for (var i = 128; i <= 159; i++)
                    {
                        var lbl = buscarLabelPorNome("lbl" + i);
                        lbl.BackColor = Color.FromArgb(45, 155, 253);
                        lbl.ForeColor = Color.White;
                        lbl.Text = " ";

                    }
                    for (var i = 192; i <= 223; i++)
                    {
                        var lbl = buscarLabelPorNome("lbl" + i);
                        lbl.BackColor = Color.FromArgb(45, 155, 253);
                        lbl.ForeColor = Color.White;
                        lbl.Text = " ";
                    }
                }));
            }
            else
            {
                for (var i = 128; i <= 159; i++)
                {
                    var lbl = buscarLabelPorNome("lbl" + i);
                    lbl.BackColor = Color.FromArgb(45, 155, 253);
                    lbl.ForeColor = Color.White;
                    lbl.Text = "";

                }
                for (var i = 192; i <= 223; i++)
                {
                    var lbl = buscarLabelPorNome("lbl" + i);
                    lbl.BackColor = Color.FromArgb(45, 155, 253);
                    lbl.ForeColor = Color.White;
                    lbl.Text = "";
                }
            }
            posinicial = 128;
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            if (!para_looping_envios)
            {
                Sair.Enabled = false;
                Ligar.PerformClick();
                Thread.Sleep(1000);
                Close();
            }
            else
            {
                Sair.Enabled = false;
                Thread.Sleep(1000);
                Close();
            }
        }

        private void Ligar_Click(object sender, EventArgs e)
        {
            if (Ligar.Text == "Ligar")
            {
                principal.ParaAtualizacao();
                int equipamento = ObterUltimoEquipamento();
                SelectEquip selecionaEquip = new SelectEquip(this, equipamento);
                selecionaEquip.ShowDialog(this);
            }
            else if (Ligar.Text == "Desligar")
            {
                toggleBotaoLigar(false);
                toggleBotoesNavegacao(false);
                para_looping_envios = true;
                Thread.Sleep(2000);
                Ligar.Text = "Ligar";
                Ligar.Enabled = true;
                CRGCursor.Enabled = false;
                InfoCRG.Text = "CRG Nº -- (offline)";
                infoPorta.Text = "Porta: -- (offline)";
                limpaTela();
                Configura_LEDs(0xFF);
                principal.RetomaAtualizacao();
            }
        }

        public void ligarCRG(int numEquipamento)
        {
            limpaTela();
            Ligar.Enabled = false;
            int ultEquip = ObterUltimoEquipamento();
            if (numEquipamento != ultEquip) AtualizaUltimoEquipamento(numEquipamento);
            string porta = ConfiguracaoDAO.retornaPorta();
            SrpComm.PortName = porta;
            var aux = numEquipamento + 63;
            
            infoPorta.Text = "Porta: " + porta;
            InfoCRG.Text = "CRG Nº " + numEquipamento.ToString();
            try
            {
                SrpComm.Open();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Erro ao abrir a COM.");
                toggleBotaoLigar(false);
                toggleBotoesNavegacao(false);
                para_looping_envios = true;
                Thread.Sleep(2000);
                Ligar.Text = "Ligar";
                Ligar.Enabled = true;
                CRGCursor.Enabled = false;
                InfoCRG.Text = "CRG Nº -- (offline)";
                infoPorta.Text = "Porta: -- (offline)";
                limpaTela();
                Configura_LEDs(0xFF);
                principal.RetomaAtualizacao();
                return;
            }
            para_looping_envios = false;
            threadLoopingEnvios = new Thread(loop_enviaExistentes);
            threadLoopingEnvios.Start();
            envios.Fila.Add(19);
            envios.Fila.Add(17);
            envios.Fila.Add(Convert.ToByte(aux));
            aguardando_conexao = true;
            conexao_sucesso = false;
            Ligar.Text = "Desligar";
            posinicial = 128;
            ultimo_cursor = 128;
            CRGCursor.Enabled = true;
        }

        public void toggleBotoesNavegacao(bool ativo)
        {
            if (btnFuncao.InvokeRequired)
            {
                btnFuncao.Invoke(new MethodInvoker(() =>
                {
                    btnFuncao.Enabled = ativo;
                    btnFuncao.Visible = ativo;
                }));
                btnEntrar.Invoke(new MethodInvoker(() =>
                {
                    btnEntrar.Enabled = ativo;
                    btnEntrar.Visible = ativo;
                }));
                btnEsquerda.Invoke(new MethodInvoker(() =>
                {
                    btnEsquerda.Enabled = ativo;
                    btnEsquerda.Visible = ativo;
                }));
                btnCima.Invoke(new MethodInvoker(() =>
                {
                    btnCima.Enabled = ativo;
                    btnCima.Visible = ativo;
                }));
                btnDireita.Invoke(new MethodInvoker(() =>
                {
                    btnDireita.Enabled = ativo;
                    btnDireita.Visible = ativo;
                }));
                btnBaixo.Invoke(new MethodInvoker(() =>
                {
                    btnBaixo.Enabled = ativo;
                    btnBaixo.Visible = ativo;
                }));
            }
            else
            {
                btnFuncao.Enabled = ativo;
                btnFuncao.Visible = ativo;
                btnEntrar.Enabled = ativo;
                btnEntrar.Visible = ativo;
                btnEsquerda.Enabled = ativo;
                btnEsquerda.Visible = ativo;
                btnCima.Enabled = ativo;
                btnCima.Visible = ativo;
                btnDireita.Enabled = ativo;
                btnDireita.Visible = ativo;
                btnBaixo.Enabled = ativo;
                btnBaixo.Visible = ativo;
            }
        }

        public void toggleBotaoLigar(bool ativo)
        {
            if (Ligar.InvokeRequired)
            {
                Ligar.Invoke(new MethodInvoker(() =>
                {
                    Ligar.Enabled = ativo;
                }));
            }
            else
            {
                Ligar.Enabled = ativo;
            }
        }

        public void Configura_LEDs(byte b)
        {
            var s1 = b & 0x01;
            var s2 = b & 0x04;
            var s3 = b & 0x08;
            //var s4 = b & 0x04;
            pctSaida12.Invoke(new MethodInvoker(() =>
            {
                pctSaida12.Visible = s1 != 0;
                pctSaida12Vermelho.Visible = s1 == 0;
                pctSaida6.Visible = s2 != 0;
                pctSaida6Vermelho.Visible = s2 == 0;
                pctSaida7.Visible = s3 != 0;
                pctSaida7Vermelho.Visible = s3 == 0;
                //pctSaida6.Visible = s4 != 0;
                //pctSaida6Vermelho.Visible = s4 == 0;
            }));
        }

        public void loop_enviaExistentes()
        {
            tempo_decorrido.Restart();
            while (!para_looping_envios)
            {
                if (tempo_decorrido.ElapsedMilliseconds >= 2000)
                {
                    if (esperandoF)
                    {
                        cont_conexao_erro++;
                        if (cont_conexao_erro >= 3)
                        {
                            MessageBox.Show("Conexão perdida.", "Erro!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            esperandoF = false;
                            cont_conexao_erro = 0;
                            Ligar.Invoke(new MethodInvoker(() =>
                            {
                                Ligar.Enabled = true;
                                Ligar.PerformClick();
                            }));
                        }
                    }
                    envios.Fila.Add(15);
                    tempo_decorrido.Restart();
                    esperandoF = true;
                }
                if (envios.Fila.Count > 0 && em_uso == false)
                {
                    em_uso = true;
                    var tmpDados = new List<byte>();
                    foreach (var dadoItem in envios.Fila.ToList())
                    {
                        if (dadoItem == -5)
                        {
                            ConexaoBO.enviaDados(tmpDados, SrpComm);
                            tmpDados.Clear();
                        }
                        else
                        {
                            tmpDados.Add(dadoItem);
                        }
                    }
                    if (tmpDados.Count > 0)
                    {
                        ConexaoBO.enviaDados(tmpDados, SrpComm);
                    }
                    envios.Fila.Clear();
                    em_uso = false;
                }
                //Thread.Sleep(50);
                ProcessaDados();
            }
            Thread.Sleep(1000);
            SrpComm.Close();
        }

        public void ProcessaDados()
        {
            em_uso = true;
            if (aguardando_conexao)
            {
                Thread.Sleep(250);
            }
            var bytesToRead = SrpComm.BytesToRead;
            if (bytesToRead > 0)
            {
                cont_conexao_erro = 0;
                tempo_decorrido.Restart();
                var buffer = new byte[bytesToRead];
                SrpComm.Read(buffer, 0, bytesToRead);
                processando = true;
                try
                {
                    for (var i = 0; i < buffer.Length; i++)
                    {
                        var b = buffer[i];
                        if (configurar_leds)
                        {
                            Configura_LEDs(b);
                            configurar_leds = false;
                            continue;
                        }
                        if (b == 1)
                        {
                            limpaTela();
                        }
                        else if (b >= 165 && b <= 169)
                        {
                            conexao_sucesso = true;
                            envios.Fila.Add(3);
                        }
                        else if (b >= 32 && b <= 127)
                        {
                            var lbl = buscarLabelPorNome("lbl" + posinicial);

                            var txt = ((char)b).ToString();

                            if (lbl.InvokeRequired)
                            {
                                lbl.Invoke(new MethodInvoker(() =>
                                {
                                    lbl.Text = txt;
                                }));
                            }
                            else
                            {
                                lbl.Text = txt;
                            }
                            posinicial++;
                            if (posinicial == 160)
                            {
                                posinicial = 192;
                            } else if (posinicial == 224) posinicial = 223;
                        }
                        else if (b == 162 || b == 163)
                        {
                            var lbl = buscarLabelPorNome("lbl" + posinicial);
                            var txt = " ";
                            txt = b == 162 ? "\u2193" : "\u2191";
                            if (lbl.InvokeRequired)
                            {
                                lbl.Invoke(new MethodInvoker(() =>
                                {
                                    lbl.Text = txt;
                                }));
                            }
                            else
                            {
                                lbl.Text = txt;
                            }
                        }
                        else if ((b >= 128 && b <= 159) || (b >= 192 && b <= 223))
                        {
                            posinicial = b;
                        }
                        else if (b == 3)
                        {
                            configurar_leds = true;
                        }
                        else if (b == 15)
                        {
                            esperandoF = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    MessageBox.Show(posinicial.ToString());
                }
            }
            if (aguardando_conexao)
            {
                if (!conexao_sucesso)
                {
                    MessageBox.Show("Não foi possível fazer conexão com o equipamento.", "Erro!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Ligar.Invoke(new MethodInvoker(() =>
                    {
                        Ligar.Enabled = true;
                        Ligar.PerformClick();
                    }));
                }
                else
                {
                    toggleBotoesNavegacao(true);
                    toggleBotaoLigar(true);

                }
                aguardando_conexao = false;
                conexao_sucesso = true;
            }
            em_uso = false;
            processando = false;
        }

        private void btnFuncao_Click(object sender, EventArgs e)
        {
            envios.Fila.Add(55);
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            envios.Fila.Add(47);
        }

        private void btnDireita_Click(object sender, EventArgs e)
        {
            envios.Fila.Add(62);
        }

        private void btnEsquerda_Click(object sender, EventArgs e)
        {
            envios.Fila.Add(31);
        }

        private void btnBaixo_Click(object sender, EventArgs e)
        {
            envios.Fila.Add(59);
        }

        private void btnCima_Click(object sender, EventArgs e)
        {
            envios.Fila.Add(61);
        }

        private void CRGCursor_Tick(object sender, EventArgs e)
        {
            if (processando) return;
            var lblPos = buscarLabelPorNome("lbl" + posinicial);
            if (lblPos == null) return;
            if (lblPos.BackColor == Color.White)
            {
                lblPos.BackColor = Color.FromArgb(45, 155, 253);
                lblPos.ForeColor = Color.White;
            }
            else
            {
                if (lblPos != lblAnterior)
                {
                    lblAnterior.BackColor = Color.FromArgb(45, 155, 253);
                    lblAnterior.ForeColor = Color.White;
                    lblAnterior = lblPos;
                }
                lblPos.BackColor = Color.White;
                lblPos.ForeColor = Color.FromArgb(45, 155, 253);
            }
        }

        private void Monitorar_Load(object sender, EventArgs e)
        {
            aguardando_conexao = false;
            conexao_sucesso = false;
            SrpComm = new SerialPort("COM0", 19200, Parity.None, 8, StopBits.One)
            {
                DtrEnable = true,
                RtsEnable = false,
                ReadBufferSize = 50000,
                WriteBufferSize = 50000
            };
            //SrpComm.StopBits = StopBits.One;
            //SrpComm.DataReceived += RecebidosHandler;
            envios = new Envios();
            em_uso = false;
            para_looping_envios = true;
            tempo_decorrido = new Stopwatch();
            posinicial = 128;
            ultimo_cursor = 128;
            processando = true;
            lblAnterior = lbl128;
        }

        private void Monitorar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Sair.Enabled)
            {
                Sair.PerformClick();
            }
        }

        private static int ObterUltimoEquipamento()
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
                return int.Parse(ult.Element("Equipamento").Value);
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter ultimo equipamento";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao obter ultimo equipamento", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return 0;
            }
        }

        public bool AtualizaUltimoEquipamento(int equipmento)
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
                    ut.Element("Equipamento").Value = equipmento.ToString();
                    doc.Save(path);
                }
                return true;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao atualizar dados do equipamento";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao atualizar dados do equipamento", "Erro", MessageBoxButtons.OK,
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

        private void Monitorar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        btnEsquerda.PerformClick();
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        btnCima.PerformClick();
                        e.Handled = true;
                        break;
                    }
                case Keys.Right:
                    {
                        btnDireita.PerformClick();
                        e.Handled = true;
                        break;
                    }
                case Keys.Down:
                    {
                        btnBaixo.PerformClick();
                        e.Handled = true;
                        break;
                    }
                case Keys.Escape:
                    {
                        btnFuncao.PerformClick();
                        e.Handled = true;
                        break;
                    }
                case Keys.Back:
                    {
                        btnFuncao.PerformClick();
                        e.Handled = true;
                        break;
                    }
                case Keys.F:
                    {
                        btnFuncao.PerformClick();
                        e.Handled = true;
                        break;
                    }
                case Keys.Enter:
                    {
                        btnEntrar.PerformClick();
                        e.Handled = true;
                        break;
                    }
                case Keys.Space:
                    {
                        btnEntrar.PerformClick();
                        e.Handled = true;
                        break;
                    }
                case Keys.E:
                    {
                        btnEntrar.PerformClick();
                        e.Handled = true;
                        break;
                    }
            }
        }
    }
}
