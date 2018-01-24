using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Schema;
using CRG08.Dao;
using CRG08.VO;
using Ciclos = CRG08.VO.Ciclos;

namespace CRG08.BO
{
    public sealed class SerialConnection
    {
        private static volatile SerialPort sp;
        private static bool InUse = false;

        public static bool InitializeService(string port)
        {
            if (sp == null) sp = new SerialPort(port, 19200, Parity.None, 8, StopBits.One);
            if (InUse) return false;
            InUse = true;
            try
            {
                sp.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static void TerminateService()
        {
            InUse = false;
            sp.Close();
        }

        public static List<byte> SendAndWaitForResponse(List<byte> data, int msDelayBetweenDataSend = 100, int msMaxWaitForResponse = 500)
        {
            var retorno = new List<byte>();
            try
            {
                if (sp == null) return null;
                if (msDelayBetweenDataSend == 0) msDelayBetweenDataSend = 1;
                if (msMaxWaitForResponse == 0) msMaxWaitForResponse = 500;
                foreach (var b in data)
                {
                    var by = new byte[1];
                    by[0] = b;
                    sp.Write(by, 0, by.Length);
                    Thread.Sleep(msDelayBetweenDataSend);
                }
                Thread.Sleep(msMaxWaitForResponse);
                while (sp.BytesToRead > 0)
                {
                    var numBytes = int.Parse(sp.BytesToRead.ToString());
                    byte[] buffer = new byte[numBytes];
                    sp.Read(buffer, 0, numBytes);
                    retorno.AddRange(buffer.ToList());
                    Thread.Sleep(msMaxWaitForResponse);
                }
            }
            catch
            {
                ErrorHandler.ThrowNew(0, "Porta fechada!");
            }
            return retorno;
        }
    }

    public class ConexaoBO
    {
        private static volatile SerialPort sp;
        private static readonly object padlock = new object();

        public static SerialPort PegarInstancia(string port = "COM1")
        {
            return sp ?? (sp = new SerialPort(port, 19200, Parity.None, 8, StopBits.One));
        }

        public static bool enviaDados(List<byte> dados, SerialPort sp)
        {
            if (sp == null)
            {
                return false;
            }
            if (sp.IsOpen == false)
            {
                try
                {
                    sp.Open();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Não foi possível abrir a conexão.");
                }
            }
            sp.Write(dados.ToArray(), 0, dados.Count);
            Thread.Sleep(100);
            return true;
        }

        public static bool EnviaBancodeDados(Ciclos ciclo, byte[] buffer, bool atualiza,
            List<ProdutoCiclo> listaProdutos, int indiceLeitCiclo, int indiceLeitTrat, bool crg150)
        {
            try
            {
                //Novo histórico

                List<LeiturasTrat> leiturasTrat = new List<LeiturasTrat>();
                List<LeiturasCiclo> leiturasCiclo = new List<LeiturasCiclo>();


                ciclo.nl = (Conexao.buffer[2]*256) + Conexao.buffer[3];
                string dataFim = string.Concat((Conexao.buffer[13]/16), (Conexao.buffer[13]%16)) + "/" +
                                 string.Concat((Conexao.buffer[14]/16), (Conexao.buffer[14]%16)) + "/20" +
                                 string.Concat((Conexao.buffer[15]/16), (Conexao.buffer[15]%16)) + " " +
                                 string.Concat((Conexao.buffer[11]/16), (Conexao.buffer[11]%16)) + ":" +
                                 string.Concat((Conexao.buffer[10]/16), (Conexao.buffer[10]%16));
                ciclo.dataFim = Convert.ToDateTime(dataFim);
                string dataIniTrat = string.Concat((Conexao.buffer[19]/16), (Conexao.buffer[19]%16)) +
                                     "/" +
                                     string.Concat((Conexao.buffer[20]/16), (Conexao.buffer[20]%16)) +
                                     "/20" +
                                     string.Concat((Conexao.buffer[21]/16), (Conexao.buffer[21]%16)) +
                                     " " +
                                     string.Concat((Conexao.buffer[17]/16), (Conexao.buffer[17]%16)) +
                                     ":" +
                                     string.Concat((Conexao.buffer[16]/16), (Conexao.buffer[16]%16));
                ciclo.dataIniTrat = Convert.ToDateTime(dataIniTrat);
                //Leitura inicio do Tratamento
                ciclo.NLIniTrat = ((Conexao.buffer[22] & 127)*256) + Conexao.buffer[23];
                //Qtde leituras do Tratamento
                ciclo.nlt = Conexao.buffer[24];
                //Flags
                string flags = decimalParaBinario(Conexao.buffer[25]);

                ciclo.baseTempo = Convert.ToInt32(flags.Substring(6, 1));
                //TControl e Histerese
                string aux = decimalParaBinario(Conexao.buffer[26]);
                ciclo.tControl = binarioParaDecimal(aux.Substring(0, 4));
                ciclo.histerese = binarioParaDecimal(aux.Substring(4, 4));

                ciclo.nlAntesTrat = Conexao.buffer[27];
                ciclo.nlPostTrat = Conexao.buffer[28];

                //Tempo Tratamento
                ciclo.tempoTrat = Conexao.buffer[33];

                //Sensor
                ciclo.sensor = Conexao.buffer[26] & 240;
                if (crg150)
                {
                    //Tipo 1 é normal e 2 é 150
                    ciclo.tipoCRG = 150;
                    //Temperatura de Controle e do Tratamento
                    int auxT = (Conexao.buffer[29]*256) + Conexao.buffer[30];
                    if (auxT < 150) ciclo.temperaturaControle = auxT;
                    else ciclo.temperaturaControle = 150;
                    auxT = (Conexao.buffer[31]*256) + Conexao.buffer[32];
                    if (auxT < 150) ciclo.temperaturaTrat = auxT;
                    else ciclo.temperaturaTrat = 150;

                    //leituras do Ciclo
                    int cont = 34;
                    if (ciclo.nl > 0)
                    {
                        for (int i = 0; i < ciclo.nl; i++)
                        {
                            LeiturasCiclo leitura = new LeiturasCiclo();

                            int auxL = (Conexao.buffer[cont + 2]*16) + (Conexao.buffer[cont + 3]/16);
                            if (auxL < 150) leitura.T1 = auxL;
                            else leitura.T1 = 150;

                            auxL = ((Conexao.buffer[cont + 3]%16)*256) + Conexao.buffer[cont + 4];
                            if (auxL < 150) leitura.T2 = auxL;
                            else leitura.T2 = 150;

                            auxL = (Conexao.buffer[cont + 5]*16) + (Conexao.buffer[cont + 6]/16);
                            if (auxL < 150) leitura.T3 = auxL;
                            else leitura.T3 = 150;

                            auxL = ((Conexao.buffer[cont + 6]%16)*256) + Conexao.buffer[cont + 7];
                            if (auxL < 150) leitura.T4 = auxL;
                            else leitura.T4 = 150;

                            leitura.horario =
                                string.Concat((Conexao.buffer[cont]/16), (Conexao.buffer[cont]%16)) + ":" +
                                string.Concat((Conexao.buffer[cont + 1]/16), (Conexao.buffer[cont + 1]%16));
                            leiturasCiclo.Add(leitura);
                            cont = cont + 8;
                        }
                    }

                    //leituras do Tratamento
                    if (ciclo.nlt > 0)
                    {
                        for (int i = 0; i < ciclo.nlt; i++)
                        {
                            LeiturasTrat leitura = new LeiturasTrat();

                            int auxL = (Conexao.buffer[cont + 2]*16) + (Conexao.buffer[cont + 3]/16);
                            if (auxL < 150) leitura.T1 = auxL;
                            else leitura.T1 = 150;

                            auxL = ((Conexao.buffer[cont + 3]%16)*256) + Conexao.buffer[cont + 4];
                            if (auxL < 150) leitura.T2 = auxL;
                            else leitura.T2 = 150;

                            auxL = (Conexao.buffer[cont + 5]*16) + (Conexao.buffer[cont + 6]/16);
                            if (auxL < 150) leitura.T3 = auxL;
                            else leitura.T3 = 150;

                            auxL = ((Conexao.buffer[cont + 6]%16)*256) + Conexao.buffer[cont + 7];
                            if (auxL < 150) leitura.T4 = auxL;
                            else leitura.T4 = 150;

                            string binario = decimalParaBinario(Conexao.buffer[cont]);
                            auxL = binarioParaDecimal(binario.Substring(1, 7));
                            leitura.horario = string.Concat((auxL/16), (auxL%16)) + ":" +
                                              string.Concat((Conexao.buffer[cont + 1]/16),
                                                  (Conexao.buffer[cont + 1]%16));
                            leiturasTrat.Add(leitura);
                            cont = cont + 8;
                        }
                    }
                }
                else
                {
                    //1 é normal e 2 é 150
                    ciclo.tipoCRG = 100;
                    //Temperatura de Controle e do Tratamento
                    int auxT = (Conexao.buffer[29]*256) + Conexao.buffer[30];
                    if (auxT < 1000) ciclo.temperaturaControle = auxT/10;
                    else ciclo.temperaturaControle = 999/10;
                    auxT = (Conexao.buffer[31]*256) + Conexao.buffer[32];
                    if (auxT < 1000) ciclo.temperaturaTrat = auxT/10;
                    else ciclo.temperaturaTrat = 999/10;

                    //leituras do Ciclo
                    int cont = 34;
                    if (ciclo.nl > 0)
                    {
                        for (int i = 0; i < ciclo.nl; i++)
                        {
                            LeiturasCiclo leitura = new LeiturasCiclo();

                            int auxL = (Conexao.buffer[cont + 2]*16) + (Conexao.buffer[cont + 3]/16);
                            if (auxL < 1000) leitura.T1 = auxL/10.0;
                            else leitura.T1 = 999/10.0;

                            auxL = ((Conexao.buffer[cont + 3]%16)*256) + Conexao.buffer[cont + 4];
                            if (auxL < 1000) leitura.T2 = auxL/10.0;
                            else leitura.T2 = 999/10.0;

                            auxL = (Conexao.buffer[cont + 5]*16) + (Conexao.buffer[cont + 6]/16);
                            if (auxL < 1000) leitura.T3 = auxL/10.0;
                            else leitura.T3 = 999/10.0;

                            auxL = ((Conexao.buffer[cont + 6]%16)*256) + Conexao.buffer[cont + 7];
                            if (auxL < 1000) leitura.T4 = auxL/10.0;
                            else leitura.T4 = 999/10.0;

                            leitura.horario =
                                string.Concat((Conexao.buffer[cont]/16), (Conexao.buffer[cont]%16)) + ":" +
                                string.Concat((Conexao.buffer[cont + 1]/16), (Conexao.buffer[cont + 1]%16));
                            leiturasCiclo.Add(leitura);
                            cont = cont + 8;
                        }
                    }

                    //leituras do Tratamento
                    if (ciclo.nlt > 0)
                    {
                        for (int i = 0; i < ciclo.nlt; i++)
                        {
                            LeiturasTrat leitura = new LeiturasTrat();

                            int auxL = (Conexao.buffer[cont + 2]*16) + (Conexao.buffer[cont + 3]/16);
                            if (auxL < 1000) leitura.T1 = auxL/10.0;
                            else leitura.T1 = 999/10.0;

                            auxL = ((Conexao.buffer[cont + 3]%16)*256) + Conexao.buffer[cont + 4];
                            if (auxL < 1000) leitura.T2 = auxL/10.0;
                            else leitura.T2 = 999/10.0;

                            auxL = (Conexao.buffer[cont + 5]*16) + (Conexao.buffer[cont + 6]/16);
                            if (auxL < 1000) leitura.T3 = auxL/10.0;
                            else leitura.T3 = 999/10.0;

                            auxL = ((Conexao.buffer[cont + 6]%16)*256) + Conexao.buffer[cont + 7];
                            if (auxL < 1000) leitura.T4 = auxL/10.0;
                            else leitura.T4 = 999/10.0;

                            string binario = decimalParaBinario(Conexao.buffer[cont]);
                            auxL = binarioParaDecimal(binario.Substring(1, 7));
                            leitura.horario = string.Concat((auxL/16), (auxL%16)) + ":" +
                                              string.Concat((Conexao.buffer[cont + 1]/16),
                                                  (Conexao.buffer[cont + 1]%16));
                            leiturasTrat.Add(leitura);
                            cont = cont + 8;
                        }
                    }
                }
                ciclo.situacao = 0;
                if (!atualiza)
                {
                    bool retorno = CicloDAO.inserirCiclo(ciclo);
                    if (retorno)
                    {
                        ciclo.id = CicloDAO.retornaId(ciclo);
                        foreach (var l in listaProdutos)
                        {
                            l.ciclo = ciclo;
                            ProdutoCicloDAO.inserirProdutoCiclo(l);
                        }
                        if (leiturasCiclo.Count > 0)
                        {
                            LeiturasCicloDAO.inserirLeiturasCiclo(leiturasCiclo, 0, ciclo);
                        }
                        if (leiturasTrat.Count > 0)
                        {
                            LeiturasTratDAO.inserirLeiturasTratamento(leiturasTrat, 0, ciclo);
                        }
                        
                    }
                }
                else
                {
                    bool retorno = CicloDAO.alteraCiclo(ciclo);
                    if (retorno)
                    {
                        ProdutoCicloDAO.DeletaProdutosCiclo(ciclo.id, ciclo.crg);
                        for (int i = 0; i < listaProdutos.Count; i++)
                        {
                            listaProdutos[i].ciclo = ciclo;
                            ProdutoCicloDAO.inserirProdutoCiclo(listaProdutos[i]);
                        }
                        if (leiturasCiclo.Count > 0)
                        {
                            LeiturasCicloDAO.inserirLeiturasCiclo(leiturasCiclo, indiceLeitCiclo, ciclo);
                        }
                        if (leiturasTrat.Count > 0)
                        {
                            LeiturasTratDAO.inserirLeiturasTratamento(leiturasTrat, indiceLeitTrat, ciclo);
                        }
                    }
                }


                return true;
            }
            catch (Exception error)
            {
                LogErro logErro = new LogErro();
                logErro.crg = ciclo.crg;
                logErro.data = DateTime.Now;
                logErro.descricao = "Erro ao tentar processar os dados do Tratamento e salvá-lo";
                logErro.maisDetalhes = error.Message + " " + error.StackTrace;
                return false;
            }
        }

        public static bool EnviaBancodeDadosAntigo(Ciclos ciclo, byte[] buffer, bool atualiza,
            List<ProdutoCiclo> listaProdutos, int indiceLeitCiclo, int indiceLeitTrat)
        {
            try
            {
                //Novo histórico

                List<LeiturasTrat> leiturasTrat = new List<LeiturasTrat>();
                List<LeiturasCiclo> leiturasCiclo = new List<LeiturasCiclo>();


                if ((Conexao.buffer[0] & 128) == 0) ciclo.baseTempo = 0;
                else ciclo.baseTempo = 1;

                ciclo.nl = ((Conexao.buffer[0] & 127)*256) + Conexao.buffer[1];

                string dataFim = string.Concat((Conexao.buffer[12]/16), (Conexao.buffer[12]%16)) + "/" +
                                 string.Concat((Conexao.buffer[13]/16), (Conexao.buffer[13]%16)) + "/20" +
                                 string.Concat((Conexao.buffer[14]/16), (Conexao.buffer[14]%16)) + " " +
                                 string.Concat((Conexao.buffer[10]/16), (Conexao.buffer[10]%16)) + ":" +
                                 string.Concat((Conexao.buffer[9]/16), (Conexao.buffer[9]%16));
                ciclo.dataFim = Convert.ToDateTime(dataFim);

                //Sensor
                ciclo.sensor = Conexao.buffer[16] & 240;

                int cont = 20;


                ciclo.tipoCRG = 100;
                //Qtde leituras do Tratamento
                ciclo.nlt = ((Conexao.buffer.Length - ((ciclo.nl*8) + 42))/8);

                //leituras do Ciclo
                if (ciclo.nl > 0)
                {
                    for (int i = 0; i < ciclo.nl; i++)
                    {
                        LeiturasCiclo leitura = new LeiturasCiclo();

                        int auxL = (Conexao.buffer[cont]*16) + (Conexao.buffer[cont + 1]/16);
                        if (auxL < 1000) leitura.T1 = auxL/10.0;
                        else leitura.T1 = 999/10.0;

                        auxL = ((Conexao.buffer[cont + 1]%16)*256) + Conexao.buffer[cont + 2];
                        if (auxL < 1000) leitura.T2 = auxL/10.0;
                        else leitura.T2 = 999/10.0;

                        auxL = (Conexao.buffer[cont + 3]*16) + (Conexao.buffer[cont + 4]/16);
                        if (auxL < 1000) leitura.T3 = auxL/10.0;
                        else leitura.T3 = 999/10.0;

                        auxL = ((Conexao.buffer[cont + 4]%16)*256) + Conexao.buffer[cont + 5];
                        if (auxL < 1000) leitura.T4 = auxL/10.0;
                        else leitura.T4 = 999/10.0;

                        leitura.horario =
                            string.Concat((Conexao.buffer[cont + 7]/16), (Conexao.buffer[cont + 7]%16)) + ":" +
                            string.Concat((Conexao.buffer[cont + 6]/16), (Conexao.buffer[cont + 6]%16));
                        leiturasCiclo.Add(leitura);
                        cont = cont + 8;
                    }
                }

                //Temperatura de Controle e do Tratamento
                int auxT = (Conexao.buffer[cont]*256) + Conexao.buffer[cont + 1];
                if (auxT < 1000) ciclo.temperaturaControle = auxT/10;
                else ciclo.temperaturaControle = 999/10;

                auxT = (Conexao.buffer[cont + 2]*256) + Conexao.buffer[cont + 3];
                if (auxT < 1000) ciclo.temperaturaTrat = auxT/10;
                else ciclo.temperaturaTrat = 999/10;

                //Tempo Tratamento
                ciclo.tempoTrat = Conexao.buffer[cont + 4];
                if (ciclo.tempoTrat > 100) ciclo.tempoTrat = 99;

                //Data e hora inicio do tratamento
                String dataInicioTrat = string.Concat((Conexao.buffer[cont + 8]/16), (Conexao.buffer[cont + 8]%16)) +
                                        "/" +
                                        string.Concat((Conexao.buffer[cont + 9]/16), (Conexao.buffer[cont + 9]%16)) +
                                        "/20" +
                                        string.Concat((Conexao.buffer[cont + 10]/16), (Conexao.buffer[cont + 10]%16)) +
                                        " " +
                                        string.Concat((Conexao.buffer[cont + 6]/16), (Conexao.buffer[cont + 6]%16)) +
                                        ":" +
                                        string.Concat((Conexao.buffer[cont + 5]/16), (Conexao.buffer[cont + 5]%16));
                ciclo.dataIniTrat = Convert.ToDateTime(dataInicioTrat);

                //Leitura inicio do Tratamento
                ciclo.NLIniTrat = ((Conexao.buffer[cont + 11] & 127)*256) + Conexao.buffer[cont + 12];

                //leituras do Tratamento
                if (ciclo.nlt > 0)
                {
                    cont = cont + 13;
                    for (int i = 0; i < ciclo.nlt; i++)
                    {
                        LeiturasTrat leitura = new LeiturasTrat();
                        int auxL = (Conexao.buffer[cont]*16) + (Conexao.buffer[cont + 1]/16);
                        if (auxL < 1000) leitura.T1 = auxL/10.0;
                        else leitura.T1 = 999/10.0;

                        auxL = ((Conexao.buffer[cont + 1]%16)*256) + Conexao.buffer[cont + 2];
                        if (auxL < 1000) leitura.T2 = auxL/10.0;
                        else leitura.T2 = 999/10.0;

                        auxL = (Conexao.buffer[cont + 3]*16) + (Conexao.buffer[cont + 4]/16);
                        if (auxL < 1000) leitura.T3 = auxL/10.0;
                        else leitura.T3 = 999/10.0;

                        auxL = ((Conexao.buffer[cont + 4]%16)*256) + Conexao.buffer[cont + 5];
                        if (auxL < 1000) leitura.T4 = auxL/10.0;
                        else leitura.T4 = 999/10.0;

                        leitura.horario = string.Concat((Conexao.buffer[cont + 7]/16), (Conexao.buffer[cont + 7]%16)) +
                                          ":" +
                                          string.Concat((Conexao.buffer[cont + 6]/16), (Conexao.buffer[cont + 6]%16));
                        leiturasTrat.Add(leitura);
                        cont = cont + 8;
                    }
                }

                ciclo.nlAntesTrat = ciclo.NLIniTrat - 1;
                int iniResf;
                if (ciclo.baseTempo == 0)
                {
                    iniResf = ciclo.NLIniTrat + ciclo.tempoTrat;
                }
                else
                {
                    iniResf = ciclo.NLIniTrat + 1;
                }
                if (ciclo.nl - iniResf >= 19 && ciclo.baseTempo == 0)
                {
                    ciclo.nlPostTrat = 20;
                }
                else if (ciclo.nl - iniResf >= 9 && ciclo.baseTempo == 1)
                {
                    ciclo.nlPostTrat = 10;
                }
                else if (ciclo.nl >= iniResf)
                {
                    ciclo.nlPostTrat = ((ciclo.nl - iniResf) + 1);
                }

                ciclo.nlPostTrat = Conexao.buffer[28];

                ciclo.situacao = 0;
                if (!atualiza)
                {
                    bool retorno = CicloDAO.inserirCiclo(ciclo);
                    if (retorno)
                    {
                        ciclo.id = CicloDAO.retornaId(ciclo);
                        foreach (var l in listaProdutos)
                        {
                            l.ciclo = ciclo;
                            ProdutoCicloDAO.inserirProdutoCiclo(l);
                        }
                        if (leiturasCiclo.Count > 0)
                        {
                            LeiturasCicloDAO.inserirLeiturasCiclo(leiturasCiclo, 0, ciclo);
                        }
                        if (leiturasTrat.Count > 0)
                        {
                            LeiturasTratDAO.inserirLeiturasTratamento(leiturasTrat, 0, ciclo);
                        }
                    }
                }
                else
                {
                    bool retorno = CicloDAO.alteraCiclo(ciclo);
                    if (retorno)
                    {
                        ProdutoCicloDAO.DeletaProdutosCiclo(ciclo.id, ciclo.crg);
                        for (int i = 0; i < listaProdutos.Count; i++)
                        {
                            listaProdutos[i].ciclo = ciclo;
                            ProdutoCicloDAO.inserirProdutoCiclo(listaProdutos[i]);
                        }
                        if (leiturasCiclo.Count > 0)
                        {
                            LeiturasCicloDAO.inserirLeiturasCiclo(leiturasCiclo, indiceLeitCiclo, ciclo);
                        }
                        if (leiturasTrat.Count > 0)
                        {
                            LeiturasTratDAO.inserirLeiturasTratamento(leiturasTrat, indiceLeitTrat, ciclo);
                        }
                    }
                }


                return true;
            }
            catch (Exception error)
            {
                LogErro logErro = new LogErro();
                logErro.crg = ciclo.crg;
                logErro.data = DateTime.Now;
                logErro.descricao = "Erro ao tentar processar os dados do Tratamento e salvá-lo";
                logErro.maisDetalhes = error.Message + " " + error.StackTrace;
                return false;
            }
        }

        public static string decimalParaBinario(int numero)
        {
            string valor = "";
            int cont = 8;
            int dividendo = Convert.ToInt32(numero);

            while (valor.Length < 8)
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

        public static bool Comunicacao(string porta, int numeroDoDispositivo)
        {
            try
            {
                if (Conexao.srpComm != null && Conexao.srpComm.IsOpen)
                {
                    Conexao.srpComm.Close();
                }
                var srpComm = new SerialPort(porta, 19200, Parity.None, 8, StopBits.One);
                srpComm.DtrEnable = true;
                srpComm.RtsEnable = false;
                srpComm.ReadBufferSize = 50000;
                srpComm.WriteBufferSize = 50000;
                bool retorno = false;

                Conexao.srpComm = srpComm;

                Conexao.srpComm.Open();
                Thread.Sleep(100);

                int cont = 0; // Contador até 3 para verificar se tem  byte na porta Serial
                byte numBytes = 0;
                do
                {
                    Conexao.srpComm.Write(((char)19).ToString());
                    Thread.Sleep(100);
                    Conexao.srpComm.Write(((char)17).ToString());
                    Thread.Sleep(100);
                    Conexao.srpComm.Write(((char)numeroDoDispositivo).ToString());
                    Thread.Sleep(500);

                    // Rotina para verifica se algum dado foi recebido da comunicação serial
                    if (Conexao.srpComm.BytesToRead != 0)
                    {
                        numBytes = byte.Parse(Conexao.srpComm.BytesToRead.ToString());
                        Conexao.buffer = new byte[numBytes];
                        Conexao.srpComm.Read(Conexao.buffer, 0, numBytes);
                    }
                    cont++;
                } while (cont < 3 && numBytes == 0);

                if (numBytes != 0)
                {
                    switch (Conexao.buffer[0])
                    {
                        case 166: // Verificador de versão Versão correta: 168
                            return true;
                    }
                }
                return false;
            }
            catch (Exception error)
            {
                if (Conexao.srpComm.IsOpen)
                {
                    Conexao.srpComm.Close();
                }
                LogErro logErro = new LogErro();
                logErro.crg = numeroDoDispositivo;
                logErro.descricao = "Erro ao testar comunicação";
                logErro.data = DateTime.Now;
                logErro.maisDetalhes = error.Message;
                LogErroDAO.inserirLogErro(logErro, logErro.crg);
                return false;

            }
        }

        public static void MostrarLista()
        {

        }
    }
}
