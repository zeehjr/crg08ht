using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRG08.Dao;
using CRG08.VO;
using CRG08.Util;
using CRG08.View;
using Ciclos = CRG08.VO.Ciclos;
using LogErro = CRG08.VO.LogErro;
using System.Diagnostics;

namespace CRG08.BO
{
    public static class BytesListExtensions
    {
        /// <summary>
        /// Calcula o checksum de uma lista de bytes.
        /// </summary>
        /// <param name="list">Lista a ser calculada</param>
        /// <param name="startIndex">Index inicial (online = 1, pendrive = 0)</param>
        /// <returns></returns>
        public static bool Checksum(this List<byte> list, int startIndex = 1)
        {
            if (list.Count <= 3) return false;
            int checksum = 0;
            for (var i = startIndex; i < list.Count - 2; i++)
            {
                checksum ^= list[i];
            }
            return checksum == list[list.Count - 2];
        }
    }

    public class ItemSecagem
    {
        public VO.Ciclos ciclo { get; set; }
        public List<LeiturasCiclo> leiturasCiclo { get; set; }
        public List<LeiturasTrat> leiturasTrat { get; set; }
    }

    public class SecagensBO
    {
        public static byte[] GetEnderecoTrat(int nTrat)
        {
            var binario = Convert.ToString(nTrat, 2);
            while (binario.Length < 16)
            {
                binario = "0" + binario;
            }
            var retorno = new byte[2];
            retorno[0] = Convert.ToByte(Convert.ToInt32(binario.Substring(0, 8), 2));
            retorno[1] = Convert.ToByte(Convert.ToInt32(binario.Substring(8, 8), 2));
            return retorno;
        }

        public static ItemSecagem DescriptografarSecagem(List<byte> buffer, int dec = 0)
        {
            var ultimo = buffer.Last();

            if (dec == 1 && ultimo == 19)
            {
                ErrorHandler.ThrowNew(559, "Aparelho não suportado.");
                return null;
            }

            var crg150 = ultimo == 22 || ultimo == 24 || ultimo == 32;
            var novaResolucao = ultimo == 32;
            var possuiProdutoFixo = ultimo == 24 || ultimo == 25 || ultimo == 32;

            int aux2 = buffer.Count - 10;

            var ciclo = new VO.Ciclos();

            ciclo.numSerie = ((char)buffer[aux2]).ToString() +
                             ((char)buffer[aux2 + 1]).ToString() +
                             ((char)buffer[aux2 + 2]).ToString() +
                             ((char)buffer[aux2 + 3]).ToString() +
                             ((char)buffer[aux2 + 4]).ToString() +
                             ((char)buffer[aux2 + 5]).ToString() +
                             ((char)buffer[aux2 + 6]).ToString() +
                             ((char)buffer[aux2 + 7]).ToString();
            ciclo.nTrat = (buffer[1 - dec] * 256) + buffer[2 - dec];

            string dataInicio = string.Empty;
            string dataFim = string.Empty;
            string dataIniTrat = string.Empty;

            if (possuiProdutoFixo)
            {
                dataInicio =
                    string.Concat((buffer[7 - dec] / 16), (buffer[7 - dec] % 16)) +
                    "/" +
                    string.Concat((buffer[8 - dec] / 16), (buffer[8 - dec] % 16)) +
                    "/20" +
                    string.Concat((buffer[9 - dec] / 16), (buffer[9 - dec] % 16)) +
                    " " +
                    string.Concat((buffer[6 - dec] / 16), (buffer[6 - dec] % 16)) +
                    ":" +
                    string.Concat((buffer[5 - dec] / 16), (buffer[5 - dec] % 16));

                dataFim = string.Concat((buffer[12 - dec] / 16), (buffer[12 - dec] % 16)) + "/" +
                          string.Concat((buffer[13 - dec] / 16), (buffer[13 - dec] % 16)) + "/20" +
                          string.Concat((buffer[14 - dec] / 16), (buffer[14 - dec] % 16)) + " " +
                          string.Concat((buffer[11 - dec] / 16), (buffer[11 - dec] % 16)) + ":" +
                          string.Concat((buffer[10 - dec] / 16), (buffer[10 - dec] % 16));

                dataIniTrat = string.Concat((buffer[17 - dec] / 16), (buffer[17 - dec] % 16)) +
                              "/" +
                              string.Concat((buffer[18 - dec] / 16), (buffer[18 - dec] % 16)) +
                              "/20" +
                              string.Concat((buffer[19 - dec] / 16), (buffer[19 - dec] % 16)) +
                              " " +
                              string.Concat((buffer[16 - dec] / 16), (buffer[16 - dec] % 16)) +
                              ":" +
                              string.Concat((buffer[15 - dec] / 16), (buffer[15 - dec] % 16));
            }
            else
            {
                dataInicio =
                    string.Concat((buffer[8 - dec] / 16), (buffer[8 - dec] % 16)) +
                    "/" +
                    string.Concat((buffer[9 - dec] / 16), (buffer[9 - dec] % 16)) +
                    "/20" +
                    string.Concat((buffer[10 - dec] / 16), (buffer[10 - dec] % 16)) +
                    " " +
                    string.Concat((buffer[6 - dec] / 16), (buffer[6 - dec] % 16)) +
                    ":" +
                    string.Concat((buffer[5 - dec] / 16), (buffer[5 - dec] % 16));

                dataFim = string.Concat((buffer[14 - dec] / 16), (buffer[14 - dec] % 16)) + "/" +
                             string.Concat((buffer[15 - dec] / 16), (buffer[15 - dec] % 16)) + "/20" +
                             string.Concat((buffer[16 - dec] / 16), (buffer[16 - dec] % 16)) + " " +
                             string.Concat((buffer[12 - dec] / 16), (buffer[12 - dec] % 16)) + ":" +
                             string.Concat((buffer[11 - dec] / 16), (buffer[11 - dec] % 16));

                dataIniTrat = string.Concat((buffer[20 - dec] / 16), (buffer[20 - dec] % 16)) +
                              "/" +
                              string.Concat((buffer[21 - dec] / 16), (buffer[21 - dec] % 16)) +
                              "/20" +
                              string.Concat((buffer[22 - dec] / 16), (buffer[22 - dec] % 16)) +
                              " " +
                              string.Concat((buffer[18 - dec] / 16), (buffer[18 - dec] % 16)) +
                              ":" +
                              string.Concat((buffer[17 - dec] / 16), (buffer[17 - dec] % 16));
            }
            ciclo.dataInicio = Convert.ToDateTime(dataInicio);


            ciclo.dataFim = Convert.ToDateTime(dataFim);

            ciclo.dataIniTrat = Convert.ToDateTime(dataIniTrat);


            ciclo.dataColeta = DateTime.Now;


            List<LeiturasTrat> leiturasTrat = new List<LeiturasTrat>();
            List<LeiturasCiclo> leiturasCiclo = new List<LeiturasCiclo>();


            ciclo.nl = (buffer[3 - dec] * 256) + buffer[4 - dec];

            //Leitura inicio do Tratamento
            ciclo.NLIniTrat = ((buffer[23 - dec] & 127) * 256) + buffer[24 - dec];


            //Qtde leituras do Tratamento
            ciclo.nlt = buffer[25 - dec];
            //Flags
            string flags = Converters.decimalParaBinario(buffer[26 - dec]);

            if (possuiProdutoFixo)
            {
                ciclo.PossuiProdutoFixo = true;
                ciclo.IsMetrosCubicos = flags.Substring(5, 1) == "1";
                ciclo.IsVolumeMaiorQue60 = flags.Substring(6, 1) == "1";

                var volumeFixo =
                    Convert.ToInt32(Converters.decimalParaBinario(buffer[20 - dec]) + Converters.decimalParaBinario(buffer[21 - dec]), 2);
                var strVolumeFixo = string.Empty;
                if (ciclo.IsMetrosCubicos)
                {
                    strVolumeFixo = volumeFixo.ToString("#####");
                    strVolumeFixo = ciclo.IsVolumeMaiorQue60
                        ? (((decimal)volumeFixo) / 100).ToString("0.00")
                        : (((decimal)volumeFixo) / 1000).ToString("0.000");
                }
                else
                {
                    strVolumeFixo = volumeFixo.ToString();
                }
                ciclo.VolumeFixo = strVolumeFixo.Replace(".", ",");
            }
            else
            {
                ciclo.PossuiProdutoFixo = false;
            }

            ciclo.baseTempo = Convert.ToInt32(flags.Substring(0, 1));
            //TControl e Histerese
            string aux = Converters.decimalParaBinario(buffer[27 - dec]);
            ciclo.tControl = Converters.binarioParaDecimal(aux.Substring(0, 4));
            ciclo.histerese = Converters.binarioParaDecimal(aux.Substring(4, 4));

            ciclo.nlAntesTrat = buffer[28 - dec];
            ciclo.nlPostTrat = buffer[29 - dec];

            //Tempo Tratamento
            ciclo.tempoTrat = buffer[34 - dec];

            //Sensor
            ciclo.sensor = buffer[27 - dec] & 240;


            if (crg150)
            {
                //Tipo 1 é normal e 2 é 150
                ciclo.tipoCRG = 150;
                //Temperatura de Controle e do Tratamento
                int auxT = (buffer[30 - dec] * 256) + buffer[31 - dec];
                if (auxT < 150) ciclo.temperaturaControle = auxT;
                else ciclo.temperaturaControle = 150;
                auxT = (buffer[32 - dec] * 256) + buffer[33 - dec];
                if (auxT < 150) ciclo.temperaturaTrat = auxT;
                else ciclo.temperaturaTrat = 150;

                //leituras do Ciclo
                int cont = 35 - dec;
                if (ciclo.nl > 0)
                {
                    for (int i = 0; i < ciclo.nl; i++)
                    {
                        LeiturasCiclo leitura = new LeiturasCiclo();
                        // Nova resolução (ex 150,0)
                        if (novaResolucao) {
                            int auxL = (buffer[cont + 2] * 16) + (buffer[cont + 3] / 16);
                            if (auxL < 1500) leitura.T1 = Convert.ToDouble((decimal)auxL / 10);
                            else leitura.T1 = 150.0;

                            auxL = ((buffer[cont + 3] % 16) * 256) + buffer[cont + 4];
                            if (auxL < 1500) leitura.T2 = Convert.ToDouble((decimal)auxL / 10);
                            else leitura.T2 = 150.0;

                            auxL = (buffer[cont + 5] * 16) + (buffer[cont + 6] / 16);
                            if (auxL < 1500) leitura.T3 = Convert.ToDouble((decimal)auxL / 10);
                            else leitura.T3 = 150.0;

                            auxL = ((buffer[cont + 6] % 16) * 256) + buffer[cont + 7];
                            if (auxL < 1500) leitura.T4 = Convert.ToDouble((decimal)auxL / 10);
                            else leitura.T4 = 150.0;
                        // Resolução antiga (ex 150)
                        } else { 
                            int auxL = (buffer[cont + 2] * 16) + (buffer[cont + 3] / 16);
                            if (auxL < 150) leitura.T1 = auxL;
                            else leitura.T1 = 150;

                            auxL = ((buffer[cont + 3] % 16) * 256) + buffer[cont + 4];
                            if (auxL < 150) leitura.T2 = auxL;
                            else leitura.T2 = 150;

                            auxL = (buffer[cont + 5] * 16) + (buffer[cont + 6] / 16);
                            if (auxL < 150) leitura.T3 = auxL;
                            else leitura.T3 = 150;

                            auxL = ((buffer[cont + 6] % 16) * 256) + buffer[cont + 7];
                            if (auxL < 150) leitura.T4 = auxL;
                            else leitura.T4 = 150;
                        }

                        leitura.horario =
                            string.Concat((buffer[cont] / 16), (buffer[cont] % 16)) + ":" +
                            string.Concat((buffer[cont + 1] / 16), (buffer[cont + 1] % 16));
                        leiturasCiclo.Add(leitura);
                        cont = cont + 8;
                    }
                }

                var nlIni = leiturasCiclo.IndexOf(leiturasCiclo.FirstOrDefault(x => x.horario == ciclo.dataIniTrat.ToString("HH:mm"))) + 1;
                ciclo.NLIniTrat = nlIni;

                var teste = leiturasCiclo.Where(x => x.horario == ciclo.dataIniTrat.ToString("HH:mm")).ToList();
                //if (nlIni == ciclo.NLIniTrat)
                //{
                //    ErrorHandler.ThrowNew(559, "Tratamento corrompido. Tente puxar os dados do controlador novamente.");
                //    return null;
                //}
                //else
                //{

                //}

                //leituras do Tratamento
                if (ciclo.nlt > 0)
                {
                    for (int i = 0; i < ciclo.nlt; i++)
                    {
                        LeiturasTrat leitura = new LeiturasTrat();
                        
                        if (novaResolucao) {
                            int auxL = (buffer[cont + 2] * 16) + (buffer[cont + 3] / 16);
                            if (auxL < 1500) leitura.T1 = (double)auxL / 10;
                            else leitura.T1 = 150.0;

                            auxL = ((buffer[cont + 3] % 16) * 256) + buffer[cont + 4];
                            if (auxL < 1500) leitura.T2 = (double)auxL / 10;
                            else leitura.T2 = 150.0;

                            auxL = (buffer[cont + 5] * 16) + (buffer[cont + 6] / 16);
                            if (auxL < 1500) leitura.T3 = (double)auxL / 10;
                            else leitura.T3 = 150.0;

                            auxL = ((buffer[cont + 6] % 16) * 256) + buffer[cont + 7];
                            if (auxL < 1500) leitura.T4 = (double)auxL / 10;
                            else leitura.T4 = 150.0;
                        } else { 
                            int auxL = (buffer[cont + 2] * 16) + (buffer[cont + 3] / 16);
                            if (auxL < 150) leitura.T1 = auxL;
                            else leitura.T1 = 150;

                            auxL = ((buffer[cont + 3] % 16) * 256) + buffer[cont + 4];
                            if (auxL < 150) leitura.T2 = auxL;
                            else leitura.T2 = 150;

                            auxL = (buffer[cont + 5] * 16) + (buffer[cont + 6] / 16);
                            if (auxL < 150) leitura.T3 = auxL;
                            else leitura.T3 = 150;

                            auxL = ((buffer[cont + 6] % 16) * 256) + buffer[cont + 7];
                            if (auxL < 150) leitura.T4 = auxL;
                            else leitura.T4 = 150;
                        }

                        string binario = Converters.decimalParaBinario(buffer[cont]);
                        int auxH = Converters.binarioParaDecimal(binario.Substring(1, 7));
                        leitura.horario = string.Concat((auxH / 16), (auxH % 16)) + ":" +
                                          string.Concat((buffer[cont + 1] / 16),
                                              (buffer[cont + 1] % 16));
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
                int auxT = (buffer[30 - dec] * 256) + buffer[31 - dec];
                if (auxT < 1000) ciclo.temperaturaControle = auxT / 10;
                else ciclo.temperaturaControle = 999 / 10;
                auxT = (buffer[32 - dec] * 256) + buffer[33 - dec];
                if (auxT < 1000) ciclo.temperaturaTrat = auxT / 10;
                else ciclo.temperaturaTrat = 999 / 10;

                //leituras do Ciclo
                int cont = 35 - dec;
                if (ciclo.nl > 0)
                {
                    for (int i = 0; i < ciclo.nl; i++)
                    {
                        LeiturasCiclo leitura = new LeiturasCiclo();
                        int auxL = (buffer[cont + 2] * 16) + (buffer[cont + 3] / 16);
                        if (auxL < 1000) leitura.T1 = auxL / 10.0;
                        else leitura.T1 = 999 / 10.0;

                        auxL = ((buffer[cont + 3] % 16) * 256) + buffer[cont + 4];
                        if (auxL < 1000) leitura.T2 = auxL / 10.0;
                        else leitura.T2 = 999 / 10.0;

                        auxL = (buffer[cont + 5] * 16) + (buffer[cont + 6] / 16);
                        if (auxL < 1000) leitura.T3 = auxL / 10.0;
                        else leitura.T3 = 999 / 10.0;

                        auxL = ((buffer[cont + 6] % 16) * 256) + buffer[cont + 7];
                        if (auxL < 1000) leitura.T4 = auxL / 10.0;
                        else leitura.T4 = 999 / 10.0;

                        leitura.horario =
                            string.Concat((buffer[cont] / 16), (buffer[cont] % 16)) + ":" +
                            string.Concat((buffer[cont + 1] / 16), (buffer[cont + 1] % 16));
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

                        int auxL = (buffer[cont + 2] * 16) + (buffer[cont + 3] / 16);
                        if (auxL < 1000) leitura.T1 = auxL / 10.0;
                        else leitura.T1 = 999 / 10.0;

                        auxL = ((buffer[cont + 3] % 16) * 256) + buffer[cont + 4];
                        if (auxL < 1000) leitura.T2 = auxL / 10.0;
                        else leitura.T2 = 999 / 10.0;

                        auxL = (buffer[cont + 5] * 16) + (buffer[cont + 6] / 16);
                        if (auxL < 1000) leitura.T3 = auxL / 10.0;
                        else leitura.T3 = 999 / 10.0;

                        auxL = ((buffer[cont + 6] % 16) * 256) + buffer[cont + 7];
                        if (auxL < 1000) leitura.T4 = auxL / 10.0;
                        else leitura.T4 = 999 / 10.0;

                        string binario = Converters.decimalParaBinario(buffer[cont]);
                        auxL = Converters.binarioParaDecimal(binario.Substring(1, 7));
                        leitura.horario = string.Concat((auxL / 16), (auxL % 16)) + ":" +
                                          string.Concat((buffer[cont + 1] / 16),
                                              (buffer[cont + 1] % 16));
                        leiturasTrat.Add(leitura);
                        cont = cont + 8;
                    }
                }
            }

            if (ciclo.nlt > 0 && leiturasTrat.Where(x =>
                x.T1 < ciclo.temperaturaTrat ||
                x.T2 < ciclo.temperaturaTrat ||
                x.T3 < ciclo.temperaturaTrat ||
                x.T4 < ciclo.temperaturaTrat
            ).Count() > 0)
            {
                ErrorHandler.ThrowNew(559, "Tratamento corrompido! Tente puxar a secagem do aparelho novamente.");
                return null;
            }


            if (leiturasCiclo.Count > 5)
            {
                var fstHorarioSplit = leiturasCiclo.First().horario.Split(':');
                var primeiro = Convert.ToInt32(Convert.ToInt32(fstHorarioSplit[0]) * 60) + Convert.ToInt32(fstHorarioSplit[1]);
                for (var i = 0; i < leiturasCiclo.Count; i++)
                {
                    var spl = leiturasCiclo[i].horario.Split(':');
                    var minutosAtuais = Convert.ToInt32(spl[0]) * 60 + Convert.ToInt32(spl[1]);
                    var properMinutosAtuais = primeiro + i;
                    while (minutosAtuais >= 1440)
                    {
                        minutosAtuais -= 1440;
                    }
                    while (properMinutosAtuais >= 1440)
                    {
                        properMinutosAtuais -= 1440;
                    }
                    if (minutosAtuais < properMinutosAtuais)
                    {
                        ErrorHandler.ThrowNew(559, "Tratamento corrompido! Tente puxar a secagem do aparelho novamente.");
                        return null;
                    }
                }
            }

            ciclo.situacao = 0;
            var retorno = new ItemSecagem();
            retorno.ciclo = ciclo;
            retorno.leiturasCiclo = leiturasCiclo;
            retorno.leiturasTrat = leiturasTrat;
            return retorno;
        }

        public static VO.Ciclos ReceberSecagemPendrive(int nTrat, int crg, string arq = "")
        {
            string arquivo = string.Empty;
            if (arq == string.Empty)
            {
                var drives = DriveInfo.GetDrives().Where(x => x.IsReady && x.DriveType == DriveType.Removable);
                if (!drives.Any())
                {
                    ErrorHandler.ThrowNew(404, "Nenhum pendrive encontrado.");
                    return null;
                }
                if (drives.Count() > 1)
                {
                    foreach (var item in drives)
                    {
                        var dir = item.Name + "CRG" + crg.ToString("00");
                        if (!Directory.Exists(dir)) continue;
                        var arquivos = Directory.GetFiles(dir, "SEC" + nTrat.ToString("000") + ".TRT",
                            SearchOption.AllDirectories);
                        if (arquivos.Length == 1)
                        {
                            arquivo = arquivos.First();
                        }
                    }
                }
                else
                {
                    var item = drives.First();
                    var dir = item.Name + "CRG" + crg.ToString("00");
                    if (Directory.Exists(dir))
                    {
                        var arquivos = Directory.GetFiles(dir, "SEC" + nTrat.ToString("000") + ".TRT",
                            SearchOption.AllDirectories);
                        if (arquivos.Length == 1)
                        {
                            arquivo = arquivos.First();
                        }
                    }
                }
            }
            else
            {
                arquivo = arq;
            }

            if (string.IsNullOrWhiteSpace(arquivo))
            {
                ErrorHandler.ThrowNew(405, "Secagem não encontrada.");
                return null;
            }

            var buffer = File.ReadAllBytes(arquivo).ToList();
            if (!buffer.Checksum(0))
            {
                ErrorHandler.ThrowNew(555, "Erro de Checksum");
                return null;
            }

            var secagem = DescriptografarSecagem(buffer, 1);

            var ciclo = CicloDAO.buscaCicloPorNTrat(crg, nTrat);

            if (ciclo == null)
            {
                var frmNovo = new NovoCiclo(crg, arquivo, nTrat);
                frmNovo.ShowDialog();
                return ciclo;
            }

            if (ciclo.dataInicio != secagem.ciclo.dataInicio || ciclo.numSerie != secagem.ciclo.numSerie)
            {
                ErrorHandler.ThrowNew(0, "Arquivo não pertence ao ciclo.");
                return null;
            }

            if (secagem.ciclo.numSerie == ciclo.numSerie && secagem.ciclo.dataInicio == ciclo.dataInicio && secagem.ciclo.nl == ciclo.nl && ciclo.crg == crg)
            {
                ErrorHandler.ThrowNew(-1, "O ciclo " + secagem.ciclo.nTrat + " já está atualizado!");
                return null;
            }

            if (secagem.ciclo.nTrat != nTrat)
            {
                ErrorHandler.ThrowNew(556, "Erro na integridade dos dados do arquivo.");
                return null;
            }

            int indiceLeitCiclo = LeiturasCicloDAO.retornaQtdeLeituras(ciclo.id, crg);
            int indiceLeitTrat = LeiturasTratDAO.retornaQtdeLeituras(ciclo.id, crg);

            secagem.ciclo.id = ciclo.id;
            secagem.ciclo.crg = ciclo.crg;
            secagem.ciclo.descricao = ciclo.descricao;
            secagem.ciclo.operador = ciclo.operador;
            secagem.ciclo.responsavel = ciclo.responsavel;

            if (!CicloDAO.alteraCiclo(secagem.ciclo))
            {
                ErrorHandler.ThrowNew(0, "Erro ao alterar o ciclo!");
                return null;
            }

            if (secagem.leiturasCiclo.Count > 0)
            {
                if (!LeiturasCicloDAO.inserirLeiturasCiclo(secagem.leiturasCiclo, indiceLeitCiclo, ciclo))
                {
                    ErrorHandler.ThrowNew(0, "Erro ao inserir as leituras do ciclo!");
                    return null;
                }
            }
            if (secagem.leiturasTrat.Count > 0)
            {
                if (!LeiturasTratDAO.inserirLeiturasTratamento(secagem.leiturasTrat, indiceLeitTrat, ciclo))
                {
                    ErrorHandler.ThrowNew(0, "Erro ao inserir as leituras do tratamento!");
                    return null;
                }
            }


            return secagem.ciclo;
        }

        public static List<byte> ReceberSecagem(int nTrat, int numCRG, string port)
        {
            var listaRetorno = new List<byte>();
            try
            {
                SerialConnection.InitializeService(port);
                var endereco = new byte[2];
                var bin = Convert.ToString(nTrat, 2);
                while (bin.Length < 16)
                {
                    bin = "0" + bin;
                }
                endereco[0] = Convert.ToByte(Convert.ToInt32(bin.Substring(0, 8), 2));
                endereco[1] = Convert.ToByte(Convert.ToInt32(bin.Substring(8, 8), 2));
                byte crg = Convert.ToByte(numCRG + 63);
                var dados = new List<byte>();
                dados.Add(19);
                dados.Add(17);
                dados.Add(crg);
                dados.Add(5);
                dados.AddRange(endereco);

                listaRetorno = SerialConnection.SendAndWaitForResponse(dados, 100, 500);
                SerialConnection.TerminateService();

                if (listaRetorno.Count == 0)
                {
                    ErrorHandler.ThrowNew(0, "Não foi possível comunicar com o equipamento.");
                    return null;
                }

                if (!listaRetorno.Checksum())
                {
                    ErrorHandler.ThrowNew(1, "Erro de checksum!");
                    return null;
                }
            }
            catch
            {
                ErrorHandler.ThrowNew(0, "Porta fechada!");
            }
            return listaRetorno;
        }


        public static bool __ReceberSecagem(int nTrat, int numCRG, string port)
        {
            SerialConnection.InitializeService(port);
            var endereco = new byte[2];
            var bin = Convert.ToString(nTrat, 2);
            while (bin.Length < 16)
            {
                bin = "0" + bin;
            }
            endereco[0] = Convert.ToByte(Convert.ToInt32(bin.Substring(0, 8), 2));
            endereco[1] = Convert.ToByte(Convert.ToInt32(bin.Substring(8, 8), 2));
            byte crg = Convert.ToByte(numCRG + 63);
            var dados = new List<byte>();
            dados.Add(19);
            dados.Add(17);
            dados.Add(crg);
            dados.Add(5);
            dados.AddRange(endereco);

            var listaRetorno = SerialConnection.SendAndWaitForResponse(dados, 100, 500);
            SerialConnection.TerminateService();

            if (listaRetorno.Count == 0)
            {
                ErrorHandler.ThrowNew(0, "Não foi possível comunicar com o equipamento.");
                return false;
            }

            if (!listaRetorno.Checksum())
            {
                ErrorHandler.ThrowNew(1, "Erro de checksum!");
                return false;
            }

            var secagem = DescriptografarSecagem(listaRetorno);

            var ciclo = CicloDAO.testaCiclo(secagem.ciclo);

            if (ciclo == null) // Não existe
            {

                return true;
            }

            if (secagem.ciclo.numSerie == ciclo.numSerie && secagem.ciclo.dataInicio == ciclo.dataInicio && secagem.ciclo.nl == ciclo.nl && ciclo.crg == crg)
            {
                ErrorHandler.ThrowNew(15, "O ciclo " + secagem.ciclo.nTrat + " já está atualizado!");
                return false;
            }

            int indiceLeitCiclo = LeiturasCicloDAO.retornaQtdeLeituras(ciclo.id, numCRG);
            int indiceLeitTrat = LeiturasTratDAO.retornaQtdeLeituras(ciclo.id, numCRG);

            secagem.ciclo.id = ciclo.id;
            secagem.ciclo.descricao = ciclo.descricao;
            secagem.ciclo.responsavel = ciclo.responsavel;
            secagem.ciclo.operador = ciclo.operador;
            secagem.ciclo.crg = numCRG;

            if (!CicloDAO.alteraCiclo(secagem.ciclo))
            {
                ErrorHandler.ThrowNew(0, "Erro ao alterar o ciclo!");
                return false;
            }

            if (secagem.leiturasCiclo.Count > 0)
            {
                LeiturasCicloDAO.inserirLeiturasCiclo(secagem.leiturasCiclo, indiceLeitCiclo, ciclo);
            }
            if (secagem.leiturasTrat.Count > 0)
            {
                LeiturasTratDAO.inserirLeiturasTratamento(secagem.leiturasTrat, indiceLeitTrat, ciclo);
            }

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


                ciclo.nl = (Conexao.buffer[2] * 256) + Conexao.buffer[3];
                string dataFim = string.Concat((Conexao.buffer[13] / 16), (Conexao.buffer[13] % 16)) + "/" +
                                 string.Concat((Conexao.buffer[14] / 16), (Conexao.buffer[14] % 16)) + "/20" +
                                 string.Concat((Conexao.buffer[15] / 16), (Conexao.buffer[15] % 16)) + " " +
                                 string.Concat((Conexao.buffer[11] / 16), (Conexao.buffer[11] % 16)) + ":" +
                                 string.Concat((Conexao.buffer[10] / 16), (Conexao.buffer[10] % 16));
                ciclo.dataFim = Convert.ToDateTime(dataFim);
                string dataIniTrat = string.Concat((Conexao.buffer[19] / 16), (Conexao.buffer[19] % 16)) +
                                     "/" +
                                     string.Concat((Conexao.buffer[20] / 16), (Conexao.buffer[20] % 16)) +
                                     "/20" +
                                     string.Concat((Conexao.buffer[21] / 16), (Conexao.buffer[21] % 16)) +
                                     " " +
                                     string.Concat((Conexao.buffer[17] / 16), (Conexao.buffer[17] % 16)) +
                                     ":" +
                                     string.Concat((Conexao.buffer[16] / 16), (Conexao.buffer[16] % 16));
                ciclo.dataIniTrat = Convert.ToDateTime(dataIniTrat);
                //Leitura inicio do Tratamento
                ciclo.NLIniTrat = ((Conexao.buffer[22] & 127) * 256) + Conexao.buffer[23];
                //Qtde leituras do Tratamento
                ciclo.nlt = Conexao.buffer[24];
                //Flags
                string flags = Converters.decimalParaBinario(Conexao.buffer[25]);

                ciclo.baseTempo = Convert.ToInt32(flags.Substring(6, 1));
                //TControl e Histerese
                string aux = Converters.decimalParaBinario(Conexao.buffer[26]);
                ciclo.tControl = Converters.binarioParaDecimal(aux.Substring(0, 4));
                ciclo.histerese = Converters.binarioParaDecimal(aux.Substring(4, 4));

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
                    int auxT = (Conexao.buffer[29] * 256) + Conexao.buffer[30];
                    if (auxT < 150) ciclo.temperaturaControle = auxT;
                    else ciclo.temperaturaControle = 150;
                    auxT = (Conexao.buffer[31] * 256) + Conexao.buffer[32];
                    if (auxT < 150) ciclo.temperaturaTrat = auxT;
                    else ciclo.temperaturaTrat = 150;

                    //leituras do Ciclo
                    int cont = 34;
                    if (ciclo.nl > 0)
                    {
                        for (int i = 0; i < ciclo.nl; i++)
                        {
                            LeiturasCiclo leitura = new LeiturasCiclo();

                            int auxL = (Conexao.buffer[cont + 2] * 16) + (Conexao.buffer[cont + 3] / 16);
                            if (auxL < 150) leitura.T1 = auxL;
                            else leitura.T1 = 150;

                            auxL = ((Conexao.buffer[cont + 3] % 16) * 256) + Conexao.buffer[cont + 4];
                            if (auxL < 150) leitura.T2 = auxL;
                            else leitura.T2 = 150;

                            auxL = (Conexao.buffer[cont + 5] * 16) + (Conexao.buffer[cont + 6] / 16);
                            if (auxL < 150) leitura.T3 = auxL;
                            else leitura.T3 = 150;

                            auxL = ((Conexao.buffer[cont + 6] % 16) * 256) + Conexao.buffer[cont + 7];
                            if (auxL < 150) leitura.T4 = auxL;
                            else leitura.T4 = 150;

                            leitura.horario =
                                string.Concat((Conexao.buffer[cont] / 16), (Conexao.buffer[cont] % 16)) + ":" +
                                string.Concat((Conexao.buffer[cont + 1] / 16), (Conexao.buffer[cont + 1] % 16));
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

                            int auxL = (Conexao.buffer[cont + 2] * 16) + (Conexao.buffer[cont + 3] / 16);
                            if (auxL < 150) leitura.T1 = auxL;
                            else leitura.T1 = 150;

                            auxL = ((Conexao.buffer[cont + 3] % 16) * 256) + Conexao.buffer[cont + 4];
                            if (auxL < 150) leitura.T2 = auxL;
                            else leitura.T2 = 150;

                            auxL = (Conexao.buffer[cont + 5] * 16) + (Conexao.buffer[cont + 6] / 16);
                            if (auxL < 150) leitura.T3 = auxL;
                            else leitura.T3 = 150;

                            auxL = ((Conexao.buffer[cont + 6] % 16) * 256) + Conexao.buffer[cont + 7];
                            if (auxL < 150) leitura.T4 = auxL;
                            else leitura.T4 = 150;

                            string binario = Converters.decimalParaBinario(Conexao.buffer[cont]);
                            auxL = Converters.binarioParaDecimal(binario.Substring(1, 7));
                            leitura.horario = string.Concat((auxL / 16), (auxL % 16)) + ":" +
                                              string.Concat((Conexao.buffer[cont + 1] / 16),
                                                  (Conexao.buffer[cont + 1] % 16));
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
                    int auxT = (Conexao.buffer[29] * 256) + Conexao.buffer[30];
                    if (auxT < 1000) ciclo.temperaturaControle = auxT / 10;
                    else ciclo.temperaturaControle = 999 / 10;
                    auxT = (Conexao.buffer[31] * 256) + Conexao.buffer[32];
                    if (auxT < 1000) ciclo.temperaturaTrat = auxT / 10;
                    else ciclo.temperaturaTrat = 999 / 10;

                    //leituras do Ciclo
                    int cont = 34;
                    if (ciclo.nl > 0)
                    {
                        for (int i = 0; i < ciclo.nl; i++)
                        {
                            LeiturasCiclo leitura = new LeiturasCiclo();

                            int auxL = (Conexao.buffer[cont + 2] * 16) + (Conexao.buffer[cont + 3] / 16);
                            if (auxL < 1000) leitura.T1 = auxL / 10.0;
                            else leitura.T1 = 999 / 10.0;

                            auxL = ((Conexao.buffer[cont + 3] % 16) * 256) + Conexao.buffer[cont + 4];
                            if (auxL < 1000) leitura.T2 = auxL / 10.0;
                            else leitura.T2 = 999 / 10.0;

                            auxL = (Conexao.buffer[cont + 5] * 16) + (Conexao.buffer[cont + 6] / 16);
                            if (auxL < 1000) leitura.T3 = auxL / 10.0;
                            else leitura.T3 = 999 / 10.0;

                            auxL = ((Conexao.buffer[cont + 6] % 16) * 256) + Conexao.buffer[cont + 7];
                            if (auxL < 1000) leitura.T4 = auxL / 10.0;
                            else leitura.T4 = 999 / 10.0;

                            leitura.horario =
                                string.Concat((Conexao.buffer[cont] / 16), (Conexao.buffer[cont] % 16)) + ":" +
                                string.Concat((Conexao.buffer[cont + 1] / 16), (Conexao.buffer[cont + 1] % 16));
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

                            int auxL = (Conexao.buffer[cont + 2] * 16) + (Conexao.buffer[cont + 3] / 16);
                            if (auxL < 1000) leitura.T1 = auxL / 10.0;
                            else leitura.T1 = 999 / 10.0;

                            auxL = ((Conexao.buffer[cont + 3] % 16) * 256) + Conexao.buffer[cont + 4];
                            if (auxL < 1000) leitura.T2 = auxL / 10.0;
                            else leitura.T2 = 999 / 10.0;

                            auxL = (Conexao.buffer[cont + 5] * 16) + (Conexao.buffer[cont + 6] / 16);
                            if (auxL < 1000) leitura.T3 = auxL / 10.0;
                            else leitura.T3 = 999 / 10.0;

                            auxL = ((Conexao.buffer[cont + 6] % 16) * 256) + Conexao.buffer[cont + 7];
                            if (auxL < 1000) leitura.T4 = auxL / 10.0;
                            else leitura.T4 = 999 / 10.0;

                            string binario = Converters.decimalParaBinario(Conexao.buffer[cont]);
                            auxL = Converters.binarioParaDecimal(binario.Substring(1, 7));
                            leitura.horario = string.Concat((auxL / 16), (auxL % 16)) + ":" +
                                              string.Concat((Conexao.buffer[cont + 1] / 16),
                                                  (Conexao.buffer[cont + 1] % 16));
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

        public static List<ItemListaSecagem> ListarSecagens(int numCRG, string port)
        {
            var retorno = new List<ItemListaSecagem>();
            SerialConnection.InitializeService(port);

            byte aux = Convert.ToByte(numCRG + 63);
            var dados = new List<byte>();
            dados.Add(19);
            dados.Add(17);
            dados.Add(aux);
            dados.Add(15);

            var listaRetorno = SerialConnection.SendAndWaitForResponse(dados, 100);

            SerialConnection.TerminateService();

            if (listaRetorno == null || listaRetorno.Count == 0)
            {
                ErrorHandler.ThrowNew(0, "Não foi possível comunicar com o equipamento.");
                return null;
            }

            if (!listaRetorno.Checksum())
            {
                ErrorHandler.ThrowNew(new ErrorItem(0, "Erro de checksum!"));
                return null;
            }

            /*
             * 150ºC: 167, 169
             * 100ºC: 166, 168
             */

            var v = listaRetorno[0];
            if (v < 166 || v > 169)
            {
                ErrorHandler.ThrowNew(new ErrorItem(1, "Este equipamento não suporta essa funcionalidade."));
                return null;
            }

            var is150 = v == 167 || v == 169;

            if (is150)
            {
                for (var i = 1; i < listaRetorno.Count() - 3; i += 10)
                {
                    var secagem = new ItemListaSecagem();
                    secagem.Id = int.Parse((listaRetorno[i] * 256 + listaRetorno[i + 1]).ToString().Trim());

                    secagem.Endereco = new byte[2];
                    secagem.Endereco[0] = listaRetorno[i];
                    secagem.Endereco[1] = listaRetorno[i + 1];

                    secagem.NumeroLeituras = int.Parse((listaRetorno[i + 2] * 256 + listaRetorno[i + 3]).ToString().Trim());


                    var binario = Converters.decimalParaBinario(listaRetorno[i + 4]);
                    secagem.Minuto = Convert.ToInt32(Converters.converterGeral(binario, 0, 4).ToString() +
                                                     Converters.converterGeral(binario, 4, 8));

                    binario = Converters.decimalParaBinario(listaRetorno[i + 5]);
                    secagem.Hora = Convert.ToInt32(Converters.converterGeral(binario, 0, 4).ToString() +
                                                     Converters.converterGeral(binario, 4, 8));

                    binario = Converters.decimalParaBinario(listaRetorno[i + 7]);
                    secagem.Dia = Convert.ToInt32(Converters.converterGeral(binario, 0, 4).ToString() +
                                                     Converters.converterGeral(binario, 4, 8));

                    binario = Converters.decimalParaBinario(listaRetorno[i + 8]);
                    secagem.Mes = Convert.ToInt32(Converters.converterGeral(binario, 0, 4).ToString() +
                                                     Converters.converterGeral(binario, 4, 8));

                    binario = Converters.decimalParaBinario(listaRetorno[i + 9]);
                    secagem.Ano = Convert.ToInt32("20" + Converters.converterGeral(binario, 0, 4).ToString() +
                                                     Converters.converterGeral(binario, 4, 8));

                    retorno.Add(secagem);
                }
            }
            else
            {
                for (var i = 1; i < listaRetorno.Count() - 3; i += 10)
                {
                    var secagem = new ItemListaSecagem();
                    secagem.Id = int.Parse((listaRetorno[i] * 256 + listaRetorno[i + 1]).ToString().Trim());

                    secagem.Endereco = new byte[2];
                    secagem.Endereco[0] = listaRetorno[i];
                    secagem.Endereco[1] = listaRetorno[i + 1];

                    secagem.NumeroLeituras = int.Parse((listaRetorno[i + 2] * 256 + listaRetorno[i + 3]).ToString().Trim());


                    var binario = Converters.decimalParaBinario(listaRetorno[i + 4]);
                    secagem.Minuto = Convert.ToInt32(Converters.converterGeral(binario, 0, 4).ToString() +
                                                     Converters.converterGeral(binario, 4, 8));

                    binario = Converters.decimalParaBinario(listaRetorno[i + 5]);
                    secagem.Hora = Convert.ToInt32(Converters.converterGeral(binario, 0, 4).ToString() +
                                                     Converters.converterGeral(binario, 4, 8));

                    binario = Converters.decimalParaBinario(listaRetorno[i + 6]);
                    secagem.Dia = Convert.ToInt32(Converters.converterGeral(binario, 0, 4).ToString() +
                                                     Converters.converterGeral(binario, 4, 8));

                    binario = Converters.decimalParaBinario(listaRetorno[i + 7]);
                    secagem.Mes = Convert.ToInt32(Converters.converterGeral(binario, 0, 4).ToString() +
                                                     Converters.converterGeral(binario, 4, 8));

                    binario = Converters.decimalParaBinario(listaRetorno[i + 8]);
                    secagem.Ano = Convert.ToInt32("20" + Converters.converterGeral(binario, 0, 4).ToString() +
                                                     Converters.converterGeral(binario, 4, 8));

                    retorno.Add(secagem);
                }
            }

            return retorno;
        }


        public static bool SecagemExistente(ItemSecagem secagem, int crg)
        {


            return false;
        }

        public static StatusSecagem SalvarSecagem(bool soAtualiza, ItemSecagem secagem, View.Ciclos frmCiclos = null, Secagens frmSecagens = null)
        {
            var statusFalha = new StatusSecagem
            {
                Salvo = false,
                Sucesso = false
            };
            var statusOK = new StatusSecagem
            {
                Sucesso = true,
                Salvo = false
            };

            var cicloExistente = CicloDAO.testaCiclo(secagem.ciclo);

            var novo = cicloExistente == null;

            if (novo)
            {
                if (soAtualiza)
                {
                    ErrorHandler.ThrowNew(0, "O ciclo encontrado não corresponde ao ciclo selecionado.");
                    return statusFalha;
                }
                var produtos = new AdicionarCiclo(secagem);
                if (frmCiclos != null)
                {
                    produtos.ShowDialog(frmCiclos);
                }
                else if (frmSecagens != null)
                {
                    produtos.ShowDialog(frmSecagens);
                }
                else
                {
                    produtos.ShowDialog();
                }

                if (!produtos.Confirmado) goto Cancelado;

                secagem.ciclo.descricao = produtos.Descricao;
                secagem.ciclo.operador = produtos.Operador;
                secagem.ciclo.responsavel = produtos.ResponsavelTecnico;

                var listaProdutos = produtos.ListaProdutos;

                if (listaProdutos == null || listaProdutos.Count == 0) goto ErroAoAdicionar;

                var retorno = CicloDAO.inserirCiclo(secagem.ciclo);
                if (!retorno) goto ErroAoAdicionar;
                var idCiclo = CicloDAO.retornaId(secagem.ciclo);
                if (idCiclo <= 0) goto ErroAoAdicionar;
                secagem.ciclo.id = idCiclo;

                if (secagem.leiturasCiclo != null && secagem.leiturasCiclo.Count > 0)
                {
                    retorno = LeiturasCicloDAO.inserirLeiturasCiclo(secagem.leiturasCiclo, 0, secagem.ciclo);
                    if (!retorno) goto ErroAoAdicionar;
                }

                if (secagem.leiturasTrat != null && secagem.leiturasTrat.Count > 0)
                {
                    retorno = LeiturasTratDAO.inserirLeiturasTratamento(secagem.leiturasTrat, 0, secagem.ciclo);
                    if (!retorno) goto ErroAoAdicionar;
                }

                foreach (var item in listaProdutos)
                {
                    retorno = ProdutoCicloDAO.inserirProdutoCiclo(item);
                    if (!retorno) goto ErroAoAdicionar;
                }

                statusOK.Salvo = true;
                return statusOK;

                ErroAoAdicionar:
                ErrorHandler.ThrowNew(0, "Algum erro ocorreu ao adicionar o ciclo ao banco de dados.");
                return statusFalha;

                Cancelado:
                statusFalha.Cancelado = true;
                return statusFalha;
            }
            else
            {
                if (cicloExistente.nl == secagem.ciclo.nl)
                {
                    ErrorHandler.ThrowNew(1, "Ciclo já está atualizado!");
                    return statusFalha;
                }

                secagem.ciclo.descricao = cicloExistente.descricao;
                secagem.ciclo.operador = cicloExistente.operador;
                secagem.ciclo.responsavel = cicloExistente.responsavel;
                secagem.ciclo.id = cicloExistente.id;

                var retorno = CicloDAO.alteraCiclo(secagem.ciclo);
                if (!retorno) goto ErroAoAtualizar;

                var indiceCiclo = LeiturasCicloDAO.retornaQtdeLeituras(secagem.ciclo.id, secagem.ciclo.crg);

                var indiceTrat = LeiturasTratDAO.retornaQtdeLeituras(secagem.ciclo.id, secagem.ciclo.crg);

                retorno = LeiturasCicloDAO.inserirLeiturasCiclo(secagem.leiturasCiclo, indiceCiclo, secagem.ciclo);
                if (!retorno) goto ErroAoAtualizar;

                retorno = LeiturasTratDAO.inserirLeiturasTratamento(secagem.leiturasTrat, indiceTrat, secagem.ciclo);
                if (!retorno) goto ErroAoAtualizar;

                statusOK.Salvo = false;
                return statusOK;

                ErroAoAtualizar:
                ErrorHandler.ThrowNew(0, "Algum erro ocorreu ao atualizar o ciclo ao banco de dados.");
                return statusFalha;
            }
        }
    }
}
