using System;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using CRG08.Dao;
using CRG08.Util;
using CRG08.VO;

namespace CRG08.View
{
    public partial class Historico : Form
    {
        Ciclos ciclos;
        private Thread t;
        public Historico(Ciclos ciclos)
        {
            InitializeComponent();
            this.ciclos = ciclos;
        }

        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Receber_Click(object sender, EventArgs e)
        {
            dtgHistorico.Rows.Clear();
            int numEquipamento = cmbCRG.SelectedIndex + 1;
            string porta = ConfiguracaoDAO.retornaPorta();
            bool continua = false;
            byte numBytes = 0;

            try
            {
                t = new Thread(new ThreadStart(carregarAguarde));
                t.Start();
                var srpComm = new SerialPort(porta, 19200, Parity.None, 8, StopBits.One);
                srpComm.DtrEnable = true;
                srpComm.RtsEnable = false;
                srpComm.ReadBufferSize = 50000;
                srpComm.WriteBufferSize = 50000;

                Conexao.srpComm = srpComm;

                if (Conexao.srpComm.IsOpen == false)
                {
                    Conexao.srpComm.Open();
                    Thread.Sleep(100);
                }

                int aux = numEquipamento + 63;
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
                {
                    int contador = 0;

                    switch (Conexao.buffer[0])
                    {
                        case 167:
                            Conexao.srpComm.Write(((char) 15).ToString());
                            Thread.Sleep(500);
                            do
                            {
                                if (Conexao.srpComm.BytesToRead != 0)
                                {
                                    numBytes = byte.Parse(Conexao.srpComm.BytesToRead.ToString());
                                    Conexao.buffer = new byte[numBytes];
                                    Conexao.srpComm.Read(Conexao.buffer, 0, numBytes);
                                }
                            } while (contador < 3 && Conexao.srpComm.BytesToRead != 0);

                            int checksum = 0;
                            for (int i = 0; i < Conexao.buffer.Length - 2; i++) checksum ^= Conexao.buffer[i];

                            if (checksum == Conexao.buffer[Conexao.buffer.Length - 2])
                            {
                                for (int i = 0; i < Conexao.buffer.Length - 2; i++)
                                {
                                    VO.Ciclos ciclo = new VO.Ciclos();
                                    ciclo.nTrat = (Conexao.buffer[i]*256) + Conexao.buffer[i + 1];
                                    ciclo.nl = (Conexao.buffer[i + 2]*256) + Conexao.buffer[i + 3];
                                    ciclo.dataInicio =
                                        Convert.ToDateTime(
                                            string.Concat((Conexao.buffer[i + 7]/16), (Conexao.buffer[i + 7]%16)) + "/" +
                                            string.Concat((Conexao.buffer[i + 8]/16), (Conexao.buffer[i + 8]%16)) +
                                            "/20" +
                                            string.Concat((Conexao.buffer[i + 9]/16), (Conexao.buffer[i + 9]%16)) + " " +
                                            string.Concat((Conexao.buffer[i + 5]/16), (Conexao.buffer[i + 5]%16)) + ":" +
                                            string.Concat((Conexao.buffer[i + 4]/16), (Conexao.buffer[i + 4]%16)));
                                    ciclo.crg = numEquipamento;
                                    bool noBanco = CicloDAO.testanoBanco(ciclo);
                                    if (!noBanco)
                                    {
                                        dtgHistorico.Rows.Add(ciclo.nTrat, ciclo.nl,
                                            ciclo.dataInicio.ToString("dd/MM/yyyy HH:mm"));
                                    }
                                    i = i + 9;
                                }
                                t.Abort();
                                Thread.Sleep(100);
                                if (dtgHistorico.Rows.Count == 0) MessageBox.Show("Não há nenhum histórico novo");
                                Conexao.srpComm.Close();
                            }
                            else
                            {
                                MessageBox.Show("Erro de checksum.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Conexao.srpComm.Close();
                            }

                            break;
                        case 166:
                            Conexao.srpComm.Write(((char) 15).ToString());
                            Thread.Sleep(500);
                            do
                            {
                                if (Conexao.srpComm.BytesToRead != 0)
                                {
                                    numBytes = byte.Parse(Conexao.srpComm.BytesToRead.ToString());
                                    Conexao.buffer = new byte[numBytes];
                                    Conexao.srpComm.Read(Conexao.buffer, 0, numBytes);
                                }
                            } while (contador < 3 && Conexao.srpComm.BytesToRead != 0);

                            int checksum1 = 0;
                            for (int i = 0; i < Conexao.buffer.Length - 2; i++) checksum1 ^= Conexao.buffer[i];

                            if (checksum1 == Conexao.buffer[Conexao.buffer.Length - 2])
                            {
                                for (int i = 0; i < Conexao.buffer.Length - 2; i++)
                                {
                                    VO.Ciclos ciclo = new VO.Ciclos();
                                    ciclo.nTrat = (Conexao.buffer[i]*256) + Conexao.buffer[i + 1];
                                    ciclo.nl = (Conexao.buffer[i + 2]*256) + Conexao.buffer[i + 3];
                                    ciclo.dataInicio =
                                        Convert.ToDateTime(
                                            string.Concat((Conexao.buffer[i + 7]/16), (Conexao.buffer[i + 7]%16)) + "/" +
                                            string.Concat((Conexao.buffer[i + 8]/16), (Conexao.buffer[i + 8]%16)) +
                                            "/20" +
                                            string.Concat((Conexao.buffer[i + 9]/16), (Conexao.buffer[i + 9]%16)) + " " +
                                            string.Concat((Conexao.buffer[i + 5]/16), (Conexao.buffer[i + 5]%16)) + ":" +
                                            string.Concat((Conexao.buffer[i + 4]/16), (Conexao.buffer[i + 4]%16)));
                                    ciclo.crg = numEquipamento;
                                    bool noBanco = CicloDAO.testanoBanco(ciclo);
                                    if (!noBanco)
                                    {
                                        dtgHistorico.Rows.Add(ciclo.nTrat, ciclo.nl,
                                            ciclo.dataInicio.ToString("dd/MM/yyyy HH:mm"));
                                    }
                                    i = i + 9;
                                }
                                t.Abort();
                                Thread.Sleep(100);
                                if (dtgHistorico.Rows.Count == 0) MessageBox.Show("Não há nenhum histórico novo","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                Conexao.srpComm.Close();
                            }
                            else
                            {
                                MessageBox.Show("Erro de checksum.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Conexao.srpComm.Close();
                            }
                            break;
                        case 165:
                            t.Abort();
                            Thread.Sleep(100);
                            if (dtgHistorico.Rows.Count > 0) dtgHistorico.Rows.Clear();
                            MessageBox.Show("Essa função não está disponivel para esse equipamento.", "Atenção",MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Conexao.srpComm.Close();
                            break;
                    }
                    inserir.Enabled = true;
                }
            }
            catch (Exception error)
            {
                if (t.IsAlive)
                {
                    t.Abort();
                    Thread.Sleep(100);
                }
                VO.LogErro logErro = new VO.LogErro();
                logErro.crg = numEquipamento;
                logErro.data = DateTime.Now;
                logErro.descricao = "Erro ao decodificar os dados do histórico, aparelho nº " + numEquipamento;
                logErro.maisDetalhes = error.Message + " " + error.StackTrace;
                LogErroDAO.inserirLogErro(logErro, logErro.crg);
                MessageBox.Show("Erro durante a comunicação com o equipamento","Erro",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void inserir_Click(object sender, EventArgs e)
        {
            string binario = decimalParaBinario(Convert.ToInt32(dtgHistorico.SelectedRows[0].Cells[0].Value));
            int numTrat1 = binarioParaDecimal(binario.Substring(0, 8));
            int numTrat2 = binarioParaDecimal(binario.Substring(8, 8));
            NovoCiclo novo = new NovoCiclo(numTrat1, numTrat2, this, cmbCRG.SelectedIndex);
            novo.ShowDialog(this);
            AtualizaUltimoEquipamento(cmbCRG.SelectedIndex+1);
            ciclos.CarregaCiclos();
        }

        private void dtgHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
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

        public static string decimalParaBinario(int numero, int numero2)
        {
            string valor = "";
            int cont = 8;
            int dividendo = Convert.ToInt32(numero2);
            int dividendo2 = Convert.ToInt32(numero);
            while (valor.Length < 16)
            {
                if (valor.Length < 8)
                {
                    valor += Convert.ToString(dividendo%2);

                    dividendo = dividendo/2;
                }
                else
                {
                    valor += Convert.ToString(dividendo2 % 2);

                    dividendo2 = dividendo2 / 2;
                }
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

        private void frmHistorico_Load(object sender, EventArgs e)
        {
            int equipamento = ObterUltimoEquipamento();
            cmbCRG.SelectedIndex = equipamento - 1;
        }

        public void removeTratamentoSalvo(int nTrat1, int nTrat2)
        {
            string binario = decimalParaBinario(nTrat1, nTrat2);
            int nTrat = binarioParaDecimal(binario);
            DataGridViewRow row = dtgHistorico.Rows.Cast<DataGridViewRow>()
                    .Where(r => r.Cells["NTrat"].Value.ToString().Equals(nTrat.ToString()))
                    .First();
            dtgHistorico.Rows.RemoveAt(row.Index);
        }

        public void carregarAguarde()
        {
            // Carrega uma thread paralela com o Carregar
            Carregar carregar = new Carregar();
            carregar.ShowDialog();
        }

        private int ObterUltimoEquipamento()
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
    }
}
