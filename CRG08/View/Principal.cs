using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
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
    public partial class Principal : Form
    {
        private Stopwatch timerAtualizacao = new Stopwatch();
        private static Thread VerificaAtualizacao;
        private int intervaloAtualizacao = -1;
        private Configuracao config;
        private Thread t;
        private int numTrat1 = -1, numTrat2 = -1;
        public Principal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void informaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Informacoes informacoes = new Informacoes();
            informacoes.ShowDialog(this);
        }

        private void ciclosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void monitorarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Monitorar monitorar = new Monitorar(this);
            monitorar.ShowDialog(this);
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup backup = new Backup(this);
            backup.ShowDialog(this);
        }

        private void configuraçõesGeraisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracoesGerais configuracoes = new ConfiguracoesGerais(this);
            configuracoes.ShowDialog(this);
        }

        private void dadosEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empresa empresa = new Empresa();
            empresa.ShowDialog(this);
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            CarregaInformacoes();
            int[] atualizacao = ConfiguracaoDAO.RetornaAtualizacao();
            config = new Configuracao();
            config.atualizacao = atualizacao[0];
            config.intervalo = atualizacao[1];
            if (config.atualizacao == 3)
            {
                string dataUltimaAtualizacao = ObterUltimaAtualizacao();
                if (dataUltimaAtualizacao != "")
                {
                    DateTime data = new DateTime(int.Parse(dataUltimaAtualizacao.Substring(6, 4)),
                        int.Parse(dataUltimaAtualizacao.Substring(3, 2)),
                        int.Parse(dataUltimaAtualizacao.Substring(0, 2)),
                        int.Parse(dataUltimaAtualizacao.Substring(11, 2)),
                        int.Parse(dataUltimaAtualizacao.Substring(14, 2)), 0);
                    if (DateTime.Now > data.AddMinutes(config.intervalo))
                    {
                        AtualizaCiclo();
                    }
                }
                intervaloAtualizacao = int.Parse(TimeSpan.FromMinutes(config.intervalo).TotalMilliseconds.ToString());
                VerificaAtualizacao = new Thread(VerificaTempoTimerAtualizacao);
                VerificaAtualizacao.Start();
                timerAtualizacao.Start();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            btn.FlatAppearance.BorderColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.FlatAppearance.BorderColor = Color.Silver;
        }

        public void CarregaInformacoes()
        {
            string opcao = ObterDadosUltimo();
            if (opcao == "Empresa")
            {
                VO.Empresa empresa = EmpresaDAO.retornaEmpresa();
                if (empresa.Logo != null)
                {
                    MemoryStream mStream = new MemoryStream();
                    byte[] pData = empresa.Logo;
                    mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                    Bitmap bm = new Bitmap(mStream, false);
                    mStream.Dispose();

                    pictureBox1.Image = bm;
                }
            }
            else
            {
                pictureBox1.Image = CRG08.Properties.Resources.LogoDigiComNome;
            }

            lblPorta.Text = "A porta de comunicação é a " + ConfiguracaoDAO.retornaPorta();
            
            Configuracao config = ConfiguracaoDAO.retornaConfiguracao();
            if (config != null)
            {
                switch (config.atualizacao)
                {
                    case 1:
                        lblAtualizacao.Text = "A atualização está como individual";
                        break;
                    case 2:
                        lblAtualizacao.Text = "A atualização está ativada para todas";
                        break;
                    case 3:
                        lblAtualizacao.Text = "A atualização está como automática a cada " + config.intervalo.ToString()+ " minutos";
                        break;
                    case 4:
                        lblAtualizacao.Text = "A atualização está desativada";
                        break;
                }
            }

            VO.Backup backup = BackupDAO.RetornaBackup();
            if (backup == null)
            {
                lblBackup.Text = "Não há backup configurado";
            }
            else
            {
                switch (backup.Periodo)
                {
                    case 0:
                        lblBackup.Text = "O Backup está configurado para diariamente";
                        break;
                    case 1:
                        lblBackup.Text = "O Backup está configurado para semanalmente";
                        break;
                    case 2:
                        lblBackup.Text = "O Backup está configurado para mensalmente";
                        break;
                }
            }
        }

        private void logErrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogErro log = new LogErro();
            log.ShowDialog(this);
        }

        private void logMudançasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogMudanca log = new LogMudanca();
            log.ShowDialog(this);
        }

        private string ObterDadosUltimo()
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
                string retorno = ult.Element("Logo").Value;
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
                return "";
            }
        }

        private void exportarImportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportarExportar importarExportar = new ImportarExportar();
            importarExportar.ShowDialog(this);
        }

        private void ciclosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ciclos ciclos = new Ciclos(this);
            ciclos.ShowDialog(this);
        }

        private void VerificaTempoTimerAtualizacao()
        {
            while (timerAtualizacao.ElapsedMilliseconds <= intervaloAtualizacao) { }

            this.Enabled = false;

            AtualizaCiclo();

            this.Enabled = true;
            
            timerAtualizacao.Reset();
            VerificaAtualizacao = new Thread(VerificaTempoTimerAtualizacao);
            VerificaAtualizacao.Start();
            timerAtualizacao.Start();
        }

        public bool AtualizaCiclo()
        {
            List<string> mensagens = new List<string>();
            //Lista ciclos em Andamento
            List<VO.Ciclos> ciclos = CicloDAO.listaCiclosPorSituacaoAll(0);
            t = new Thread(new ThreadStart(carregarAguarde));
            //this.Enabled = false;

            try
            {

                for (int i = 0; i < ciclos.Count; i++)
                {

                    VO.Ciclos cic = ciclos[i];
                    List<ProdutoCiclo> listaProdutos = ProdutoCicloDAO.listaProdutosCiclo(cic);
                    VO.Ciclos ciclo = new VO.Ciclos();

                    string porta = ConfiguracaoDAO.retornaPorta();
                    bool continua = false;
                    if (!t.IsAlive) t.Start();

                    var srpComm = new SerialPort(porta, 19200, Parity.None, 8, StopBits.One);
                    srpComm.DtrEnable = true;
                    srpComm.RtsEnable = false;
                    srpComm.ReadBufferSize = 100000;
                    srpComm.WriteBufferSize = 100000;

                    Conexao.srpComm = srpComm;
                    Conexao.srpComm.Open();
                    Thread.Sleep(100);

                    int numBytes = 0;
                    int aux = cic.crg + 63;
                    Conexao.srpComm.Write(((char) 19).ToString());
                    Thread.Sleep(100);
                    Conexao.srpComm.Write(((char) 17).ToString());
                    Thread.Sleep(100);
                    Conexao.srpComm.Write(((char) aux).ToString());
                    Thread.Sleep(100);

                    if (Conexao.srpComm.BytesToRead != 0)
                    {
                        numBytes = byte.Parse(Conexao.srpComm.BytesToRead.ToString());
                        Conexao.buffer = new byte[numBytes];
                        Conexao.srpComm.Read(Conexao.buffer, 0, numBytes);
                    }
                    continua = true;
                    if (continua)

                        // int cont = 0;
                        //Verifica se é aparelho novo ou antigo
                        switch (Conexao.buffer[0])
                        {
                                //Versão nova até 150ºC
                            case 167:
                                string binario = decimalParaBinario(cic.nTrat);
                                numTrat1 = binarioParaDecimal(binario.Substring(0, 8));
                                numTrat2 = binarioParaDecimal(binario.Substring(8, 8));

                                Conexao.srpComm.Write(((char)5).ToString());
                                Thread.Sleep(100);
                                Conexao.srpComm.Write(((char)numTrat1).ToString());
                                Thread.Sleep(100);
                                Conexao.srpComm.Write(((char)numTrat2).ToString());
                                Thread.Sleep(8000);

                                int contador = 0;
                                do
                                {
                                    if (Conexao.srpComm.BytesToRead != 0)
                                    {
                                        numBytes = int.Parse(Conexao.srpComm.BytesToRead.ToString());
                                        Conexao.buffer = new byte[numBytes];
                                        Conexao.srpComm.Read(Conexao.buffer, 0, numBytes);
                                    }
                                    contador++;
                                } while (Conexao.srpComm.BytesToRead != 0);

                                int checksum = 0;
                                //Verifica se o ciclo ainda está na memória do equipamento
                                if (Conexao.buffer.Length > 2)
                                {
                                    for (int j = 0; j < Conexao.buffer.Length - 2; j++) checksum ^= Conexao.buffer[j];
                                    if (checksum == Conexao.buffer[Conexao.buffer.Length - 2])
                                    {
                                        int aux2 = Conexao.buffer.Length - 10;
                                        cic.numSerie = ((char)Conexao.buffer[aux2]).ToString() +
                                                         ((char)Conexao.buffer[aux2 + 1]).ToString() +
                                                         ((char)Conexao.buffer[aux2 + 2]).ToString() +
                                                         ((char)Conexao.buffer[aux2 + 3]).ToString() +
                                                         ((char)Conexao.buffer[aux2 + 4]).ToString() +
                                                         ((char)Conexao.buffer[aux2 + 5]).ToString() +
                                                         ((char)Conexao.buffer[aux2 + 6]).ToString() +
                                                         ((char)Conexao.buffer[aux2 + 7]).ToString();
                                        cic.nTrat = (Conexao.buffer[0] * 256) + Conexao.buffer[1];
                                        string dataInicio =
                                            string.Concat((Conexao.buffer[7] / 16), (Conexao.buffer[7] % 16)) +
                                            "/" +
                                            string.Concat((Conexao.buffer[8] / 16), (Conexao.buffer[8] % 16)) +
                                            "/20" +
                                            string.Concat((Conexao.buffer[9] / 16), (Conexao.buffer[9] % 16)) +
                                            " " +
                                            string.Concat((Conexao.buffer[5] / 16), (Conexao.buffer[5] % 16)) +
                                            ":" +
                                            string.Concat((Conexao.buffer[4] / 16), (Conexao.buffer[4] % 16));
                                        cic.dataInicio = Convert.ToDateTime(dataInicio);
                                        cic.dataColeta = DateTime.Now;

                                        bool retorno = false;


                                        int indiceLeitCiclo = LeiturasCicloDAO.retornaQtdeLeituras(cic.id,
                                            cic.crg);
                                        int indiceLeitTrat = LeiturasTratDAO.retornaQtdeLeituras(cic.id, cic.crg);
                                        retorno = ConexaoBO.EnviaBancodeDados(cic, Conexao.buffer, true,
                                                listaProdutos, indiceLeitCiclo, indiceLeitTrat, true);
                                        if (retorno)
                                        {
                                            AtualizaUltimo(cic.operador, cic.responsavel);
                                            mensagens.Add("O ciclo nº " + cic.nTrat + " do aparelho nº " + cic.crg +
                                                          " foi atualizado com sucesso.");
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Erro no checksum.", "Erro", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                                    }

                                }
                                else
                                {
                                    mensagens.Add("O ciclo nº " + cic.nTrat + " do aparelho nº " + cic.crg +
                                                  " nao está mais na memória do equipamento.");
                                }
                                break;
                                //Versão nova até 102ºC
                            case 166:
                                string binario1 = decimalParaBinario(cic.nTrat);
                                numTrat1 = binarioParaDecimal(binario1.Substring(0, 8));
                                numTrat2 = binarioParaDecimal(binario1.Substring(8, 8));

                                Conexao.srpComm.Write(((char) 5).ToString());
                                Thread.Sleep(100);
                                Conexao.srpComm.Write(((char) numTrat1).ToString());
                                Thread.Sleep(100);
                                Conexao.srpComm.Write(((char) numTrat2).ToString());
                                Thread.Sleep(8000);

                                int contador1 = 0;
                                do
                                {
                                    if (Conexao.srpComm.BytesToRead != 0)
                                    {
                                        numBytes = int.Parse(Conexao.srpComm.BytesToRead.ToString());
                                        Conexao.buffer = new byte[numBytes];
                                        Conexao.srpComm.Read(Conexao.buffer, 0, numBytes);
                                    }
                                    contador1++;
                                } while (Conexao.srpComm.BytesToRead != 0);

                                int checksum1 = 0;
                                //Verifica se o ciclo ainda está na memória do equipamento
                                if (Conexao.buffer.Length > 2)
                                {
                                    for (int j = 0; j < Conexao.buffer.Length - 2; j++) checksum1 ^= Conexao.buffer[j];
                                    if (checksum1 == Conexao.buffer[Conexao.buffer.Length - 2])
                                    {
                                        int aux2 = Conexao.buffer.Length - 10;
                                        ciclo.numSerie = ((char) Conexao.buffer[aux2]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 1]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 2]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 3]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 4]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 5]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 6]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 7]).ToString();
                                        ciclo.nTrat = (Conexao.buffer[0]*256) + Conexao.buffer[1];
                                        string dataInicio =
                                            string.Concat((Conexao.buffer[7]/16), (Conexao.buffer[7]%16)) +
                                            "/" +
                                            string.Concat((Conexao.buffer[8]/16), (Conexao.buffer[8]%16)) +
                                            "/20" +
                                            string.Concat((Conexao.buffer[9]/16), (Conexao.buffer[9]%16)) +
                                            " " +
                                            string.Concat((Conexao.buffer[5]/16), (Conexao.buffer[5]%16)) +
                                            ":" +
                                            string.Concat((Conexao.buffer[4]/16), (Conexao.buffer[4]%16));
                                        ciclo.dataInicio = Convert.ToDateTime(dataInicio);
                                        ciclo.dataColeta = DateTime.Now;

                                        bool retorno = false;


                                        int indiceLeitCiclo = LeiturasCicloDAO.retornaQtdeLeituras(ciclo.id,
                                            ciclo.crg);
                                        int indiceLeitTrat = LeiturasTratDAO.retornaQtdeLeituras(ciclo.id, ciclo.crg);
                                        retorno = ConexaoBO.EnviaBancodeDados(ciclo, Conexao.buffer, true,
                                                listaProdutos, indiceLeitCiclo, indiceLeitTrat, false);
                                        if (retorno)
                                        {
                                            AtualizaUltimo(cic.operador, cic.responsavel);
                                            mensagens.Add("O ciclo nº " + cic.nTrat + " do aparelho nº " + cic.crg +
                                                          " foi atualizado com sucesso.");
                                        }

                                    }
                                    else
                                    {
                                        mensagens.Add("Não foi possível atualizar o ciclo nº " + cic.nTrat +
                                                      " do aparelho nº " + cic.crg + ". Erro de Checksum.");
                                    }

                                }
                                else
                                {
                                    mensagens.Add("O ciclo nº " + cic.nTrat + " do aparelho nº " + cic.crg +
                                                  " nao está mais na memória do equipamento.");
                                }
                                break;
                                //Versão antiga até 102ºC apenas
                            case 165:
                                Conexao.srpComm.Write(((char) 6).ToString());
                                Thread.Sleep(8000);

                                int cont = 0;
                                do
                                {
                                    if (Conexao.srpComm.BytesToRead != 0)
                                    {
                                        numBytes = int.Parse(Conexao.srpComm.BytesToRead.ToString());
                                        Conexao.buffer = new byte[numBytes];
                                        Conexao.srpComm.Read(Conexao.buffer, 0, numBytes);
                                    }
                                    cont++;
                                } while (Conexao.srpComm.BytesToRead != 0);

                                int chk = 0;
                                for (int j = 0; j < Conexao.buffer.Length - 2; j++) chk ^= Conexao.buffer[j];

                                if (((Conexao.buffer[5]*256) + Conexao.buffer[2]) == cic.nTrat)
                                {
                                    if (chk == Conexao.buffer[Conexao.buffer.Length - 2])
                                    {
                                        int aux2 = Conexao.buffer.Length - 10;
                                        cic.numSerie = ((char) Conexao.buffer[aux2]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 1]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 2]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 3]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 4]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 5]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 6]).ToString() +
                                                         ((char) Conexao.buffer[aux2 + 7]).ToString();
                                        cic.nTrat = (Conexao.buffer[5] * 256) + Conexao.buffer[2];
                                        string dataInicio =
                                            string.Concat((Conexao.buffer[6]/16), (Conexao.buffer[6]%16)) + "/" +
                                            string.Concat((Conexao.buffer[7]/16), (Conexao.buffer[7]%16)) + "/20" +
                                            string.Concat((Conexao.buffer[8]/16), (Conexao.buffer[8]%16)) + " " +
                                            string.Concat((Conexao.buffer[4]/16), (Conexao.buffer[4]%16)) + ":" +
                                            string.Concat((Conexao.buffer[3]/16), (Conexao.buffer[3]%16));
                                        cic.dataInicio = Convert.ToDateTime(dataInicio);
                                        cic.dataColeta = DateTime.Now;

                                        bool retorno = false;

                                        int indiceLeitCiclo = LeiturasCicloDAO.retornaQtdeLeituras(cic.id,
                                            cic.crg);
                                        int indiceLeitTrat = LeiturasTratDAO.retornaQtdeLeituras(cic.id,
                                            cic.crg);
                                        retorno = ConexaoBO.EnviaBancodeDadosAntigo(cic, Conexao.buffer, true,
                                                listaProdutos, indiceLeitCiclo, indiceLeitTrat);
                                        if (retorno)
                                        {
                                            AtualizaUltimo(cic.operador, cic.responsavel);
                                            mensagens.Add("O ciclo nº " + cic.nTrat + " do aparelho nº " + cic.crg +
                                                          " foi atualizado com sucesso.");
                                        }
                                    }
                                    else
                                    {
                                        mensagens.Add("Não foi possível atualizar o ciclo nº " + cic.nTrat +
                                                      " do aparelho nº " + cic.crg + ". Erro de Checksum.");
                                    }
                                }
                                else
                                {
                                    mensagens.Add("O ciclo nº " + cic.nTrat + " do aparelho nº " + cic.crg +
                                                  " não está mais no histórico.");
                                }


                                break;
                        }
                    Conexao.srpComm.Close();
                    Thread.Sleep(100);

                }
                t.Abort();

                if (mensagens.Count > 0)
                {
                    StatusAtualizacao frm = new StatusAtualizacao(mensagens);
                    frm.ShowDialog(this);
                }
                return true;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao tentar receber o ciclo";
                logErro.maisDetalhes = error.Message + " " + error.StackTrace;
                logErro.data = DateTime.Now;
                LogErroDAO.inserirLogErro(logErro, logErro.crg);
                t.Abort();
                return false;
            }
        }

        public void carregarAguarde()
        {
            // Carrega uma thread paralela com o Carregar
            Carregar carregar = new Carregar();
            carregar.ShowDialog(this);
        }

        public static string decimalParaBinario(int numero)
        {
            string valor = "";
            int cont = 8;
            int dividendo = Convert.ToInt32(numero);

            while (valor.Length < 16)
            {
                valor += Convert.ToString(dividendo % 2);

                dividendo = dividendo / 2;
            }

            return inverterString(valor);
        }

        public static string inverterString(string str)
        {
            int tamanho = str.Length;

            char[] caracteres = new char[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                if (!(tamanho - i > str.Length))
                {
                    caracteres[i] = str[tamanho - 1 - i];
                }
                else
                {
                    caracteres[i] = '0';
                }
            }
            return new string(caracteres);
        }

        public static int binarioParaDecimal(string valorBinario)
        {
            int expoente = 0;
            int numero;
            int soma = 0;
            string numeroInvertido = inverterString(valorBinario);

            for (int i = 0; i < numeroInvertido.Length; i++)
            {
                numero = Convert.ToInt32(numeroInvertido.Substring(i, 1));
                soma += numero * (int)Math.Pow(2, expoente);
                expoente++;
            }
            return soma;
        }

        public bool AtualizaUltimo(string operador, string responsavel)
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
                    ut.Element("Operador").Value = operador;
                    ut.Element("Responsavel").Value = responsavel;
                    doc.Save(path);
                }
                return true;
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

        private string ObterUltimaAtualizacao()
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
                return ult.Element("Atualizacao").Value;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao obter a ultima data de atualizacao do Software";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);
                
                return "";
            }
        }

        public bool AtualizaDataAtualizacao(string data)
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
                    ut.Element("Atualizacao").Value = data;
                    doc.Save(path);
                }
                return true;
            }
            catch (Exception error)
            {
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = 0;
                logErro.descricao = "Erro ao atualizar a data da ultima atualização";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, 0);

                MessageBox.Show("Erro ao atualizar a data da ultima atualização", "Erro", MessageBoxButtons.OK,
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

        public void ParaAtualizacao()
        {
            if(VerificaAtualizacao != null && VerificaAtualizacao.IsAlive)VerificaAtualizacao.Abort();
            timerAtualizacao.Stop();
        }

        public void RetomaAtualizacao()
        {
            int[] atualizacao = ConfiguracaoDAO.RetornaAtualizacao();
            config = new Configuracao();
            config.atualizacao = atualizacao[0];
            config.intervalo = atualizacao[1];
            if (config.atualizacao == 3)
            {
                timerAtualizacao.Reset();
                VerificaAtualizacao = new Thread(VerificaTempoTimerAtualizacao);
                VerificaAtualizacao.Start();
                timerAtualizacao.Start();
            }
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParaAtualizacao();
            CRG08.Properties.Settings.Default.FecharPrograma = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ciclo = new VO.Ciclos();
            ciclo.id = 1;
            List<LeiturasTrat> listaLeiturasTrat = LeiturasTratDAO.ListaLeiturasTratamento(ciclo);
            MessageBox.Show(listaLeiturasTrat.Count.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frmImportarExportar = new ImportarExportar(true);
            frmImportarExportar.ShowDialog(this);
        }

        private void configuraçõesRelatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var configRelatorio = new frmConfiguracoesRelatorio();
            configRelatorio.ShowDialog(this);
        }
    }
}
