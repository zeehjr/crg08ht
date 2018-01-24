using System;
using System.Collections.Generic;
using CRG08.VO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Dao
{
    public class CicloDAO
    {
        public static bool inserirCiclo(Ciclos ciclo)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "INSERT INTO CICLO(CRG,NL,BASETEMPO,NLT,DESCRICAO,NLINICIOTRAT,TEMPERATURACONTROLE,TEMPERATURATRAT,TEMPOTRATAMENTO," +
                            "RESPONSAVEL,OPERADOR,SITUACAO,NUMEROSERIE,DATAINICIO,DATAFIM,DATAINITRAT,DATACOLETA, NTRAT, HISTERESE,TCONTROL,NLANTESTRAT," +
                            "NLPOSTRAT,SENSOR, VERSAOEQUIP, TIPOCRG, VOLUMEFIXO_TIPO, VOLUMEFIXO_MAIOR, VOLUMEFIXO_TOTAL) VALUES(@CRG, @NL,@BASETEMPO,@NLT,@DESCRICAO,@NLINICIOTRAT,@TEMPERATURACONTROLE,@TEMPERATURATRAT," +
                            "@TEMPOTRATAMENTO, @RESPONSAVEL,@OPERADOR,@SITUACAO,@NUMEROSERIE,@DATAINICIO,@DATAFIM,@DATAINITRAT,@DATACOLETA,@NTRAT,@HISTERESE," +
                            "@TCONTROL,@NLANTESTRAT, @NLPOSTRAT,@SENSOR, @VERSAOEQUIP, @TIPOCRG, @VOLUMEFIXO_TIPO, @VOLUMEFIXO_MAIOR, @VOLUMEFIXO_TOTAL)";
                        cmd.Parameters.AddWithValue("@CRG", ciclo.crg);
                        cmd.Parameters.AddWithValue("@NL", ciclo.nl);
                        cmd.Parameters.AddWithValue("@BASETEMPO", ciclo.baseTempo);
                        cmd.Parameters.AddWithValue("@NLT", ciclo.nlt);
                        cmd.Parameters.AddWithValue("@DESCRICAO", ciclo.descricao);
                        cmd.Parameters.AddWithValue("@NLINICIOTRAT", ciclo.NLIniTrat);
                        cmd.Parameters.AddWithValue("@TEMPERATURACONTROLE", ciclo.temperaturaControle);
                        cmd.Parameters.AddWithValue("@TEMPERATURATRAT", ciclo.temperaturaTrat);
                        cmd.Parameters.AddWithValue("@TEMPOTRATAMENTO", ciclo.tempoTrat);
                        cmd.Parameters.AddWithValue("@RESPONSAVEL", ciclo.responsavel);
                        cmd.Parameters.AddWithValue("@OPERADOR", ciclo.operador);
                        cmd.Parameters.AddWithValue("@SITUACAO", ciclo.situacao);
                        cmd.Parameters.AddWithValue("@NUMEROSERIE", ciclo.numSerie);
                        cmd.Parameters.AddWithValue("@DATAINICIO", ciclo.dataInicio.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@DATAFIM", ciclo.dataFim.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@DATAINITRAT", ciclo.dataIniTrat.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@DATACOLETA", ciclo.dataColeta.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@NTRAT", ciclo.nTrat);
                        cmd.Parameters.AddWithValue("@HISTERESE", ciclo.histerese);
                        cmd.Parameters.AddWithValue("@TCONTROL", ciclo.tControl);
                        cmd.Parameters.AddWithValue("@NLANTESTRAT", ciclo.nlAntesTrat);
                        cmd.Parameters.AddWithValue("@NLPOSTRAT", ciclo.nlPostTrat);
                        cmd.Parameters.AddWithValue("@SENSOR", ciclo.sensor);
                        cmd.Parameters.AddWithValue("@VERSAOEQUIP", ciclo.versaoEquip);
                        cmd.Parameters.AddWithValue("@TIPOCRG", ciclo.tipoCRG);
                        cmd.Parameters.AddWithValue("@VOLUMEFIXO_TIPO", ciclo.IsMetrosCubicos ? "1" : "0");
                        cmd.Parameters.AddWithValue("@VOLUMEFIXO_MAIOR", ciclo.IsVolumeMaiorQue60 ? "1" : "0");
                        cmd.Parameters.AddWithValue("@VOLUMEFIXO_TOTAL", ciclo.VolumeFixo ?? string.Empty);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro no inserir Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro no inserir Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool alteraCiclo(Ciclos ciclo)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "UPDATE CICLO SET CRG=@CRG, NL=@NL,BASETEMPO = @BASETEMPO, NLT=@NLT, DESCRICAO = @DESCRICAO," +
                                          "NLINICIOTRAT = @NLINICIOTRAT, TEMPERATURACONTROLE = @TEMPERATURACONTROLE, TEMPERATURATRAT= @TEMPERATURATRAT," +
                                          "TEMPOTRATAMENTO = @TEMPOTRATAMENTO, RESPONSAVEL = @RESPONSAVEL,OPERADOR = @OPERADOR, SITUACAO = @SITUACAO," +
                                          "NUMEROSERIE = @NUMEROSERIE, DATAINICIO = @DATAINICIO, DATAFIM = @DATAFIM, DATAINITRAT = @DATAINITRAT, " +
                                          "DATACOLETA = @DATACOLETA, NTRAT = @NTRAT, HISTERESE = @HISTERESE, TCONTROL = @TCONTROL, NLANTESTRAT = @NLANTESTRAT, " +
                                          "NLPOSTRAT = @NLPOSTRAT, VERSAOEQUIP = @VERSAOEQUIP, TIPOCRG = @TIPOCRG, VOLUMEFIXO_TIPO = @VOLUMEFIXO_TIPO, VOLUMEFIXO_MAIOR = @VOLUMEFIXO_MAIOR, VOLUMEFIXO_TOTAL = @VOLUMEFIXO_TOTAL WHERE ID ="+ciclo.id;
                        cmd.Parameters.AddWithValue("@CRG", ciclo.crg);
                        cmd.Parameters.AddWithValue("@NL", ciclo.nl);
                        cmd.Parameters.AddWithValue("@BASETEMPO", ciclo.baseTempo);
                        cmd.Parameters.AddWithValue("@NLT", ciclo.nlt);
                        cmd.Parameters.AddWithValue("@DESCRICAO", ciclo.descricao);
                        cmd.Parameters.AddWithValue("@NLINICIOTRAT", ciclo.NLIniTrat);
                        cmd.Parameters.AddWithValue("@TEMPERATURACONTROLE", ciclo.temperaturaControle);
                        cmd.Parameters.AddWithValue("@TEMPERATURATRAT", ciclo.temperaturaTrat);
                        cmd.Parameters.AddWithValue("@TEMPOTRATAMENTO", ciclo.tempoTrat);
                        cmd.Parameters.AddWithValue("@RESPONSAVEL", ciclo.responsavel);
                        cmd.Parameters.AddWithValue("@OPERADOR", ciclo.operador);
                        cmd.Parameters.AddWithValue("@SITUACAO", ciclo.situacao);
                        cmd.Parameters.AddWithValue("@NUMEROSERIE", ciclo.numSerie);
                        cmd.Parameters.AddWithValue("@DATAINICIO", ciclo.dataInicio.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@DATAFIM", ciclo.dataFim.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@DATAINITRAT", ciclo.dataIniTrat.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@DATACOLETA", ciclo.dataColeta.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@NTRAT", ciclo.nTrat);
                        cmd.Parameters.AddWithValue("@HISTERESE", ciclo.histerese);
                        cmd.Parameters.AddWithValue("@TCONTROL", ciclo.tControl);
                        cmd.Parameters.AddWithValue("@NLANTESTRAT", ciclo.nlAntesTrat);
                        cmd.Parameters.AddWithValue("@NLPOSTRAT", ciclo.nlPostTrat);
                        cmd.Parameters.AddWithValue("@SENSOR", ciclo.sensor);
                        cmd.Parameters.AddWithValue("@VERSAOEQUIP", ciclo.versaoEquip);
                        cmd.Parameters.AddWithValue("@TIPOCRG", ciclo.tipoCRG);
                        cmd.Parameters.AddWithValue("@VOLUMEFIXO_TIPO", ciclo.IsMetrosCubicos ? "1" : "0");
                        cmd.Parameters.AddWithValue("@VOLUMEFIXO_MAIOR", ciclo.IsVolumeMaiorQue60 ? "1" : "0");
                        cmd.Parameters.AddWithValue("@VOLUMEFIXO_TOTAL", ciclo.VolumeFixo ?? string.Empty);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro no alterar Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro no alterar Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static List<Ciclos> listaCiclosPorSituacaoAll(int situacao)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM CICLO WHERE SITUACAO = "+situacao +" ORDER BY CRG,NTRAT";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<Ciclos> listaCiclos = new List<Ciclos>();
                        while (dr.Read())
                        {
                            Ciclos ciclo = new Ciclos();
                            ciclo.id = (int) dr["ID"];
                            ciclo.crg = (int) dr["CRG"];
                            ciclo.nl = (int) dr["NL"];
                            ciclo.baseTempo = (int) dr["BASETEMPO"];
                            ciclo.nlt = (int) dr["NLT"];
                            ciclo.descricao = dr["DESCRICAO"].ToString();
                            ciclo.NLIniTrat = (int)dr["NLINICIOTRAT"];
                            ciclo.temperaturaControle = Convert.ToSingle(dr["TEMPERATURACONTROLE"]);
                            ciclo.temperaturaTrat = Convert.ToSingle(dr["TEMPERATURATRAT"]);
                            ciclo.tempoTrat = (int) dr["TEMPOTRATAMENTO"];
                            ciclo.responsavel = dr["RESPONSAVEL"].ToString();
                            ciclo.operador = dr["OPERADOR"].ToString();
                            ciclo.situacao = (int) dr["SITUACAO"];
                            ciclo.numSerie = dr["NUMEROSERIE"].ToString();
                            ciclo.dataInicio = Convert.ToDateTime(dr["DATAINICIO"]);
                            ciclo.dataFim = Convert.ToDateTime(dr["DATAFIM"]);
                            ciclo.dataIniTrat = Convert.ToDateTime(dr["DATAINITRAT"]);
                            ciclo.dataColeta = Convert.ToDateTime(dr["DATACOLETA"]);
                            ciclo.nTrat = Convert.ToInt32(dr["NTRAT"]);
                            ciclo.histerese = Convert.ToInt32(dr["HISTERESE"]);
                            ciclo.tControl = Convert.ToInt32(dr["TCONTROL"]);
                            ciclo.nlAntesTrat = Convert.ToInt32(dr["NLANTESTRAT"]);
                            ciclo.nlPostTrat = Convert.ToInt32(dr["NLPOSTRAT"]);
                            ciclo.sensor = Convert.ToInt32(dr["SENSOR"]);
                            ciclo.versaoEquip = dr["VERSAOEQUIP"].ToString();
                            ciclo.tipoCRG = (int)dr["TIPOCRG"];
                            ciclo.IsMetrosCubicos = dr["VOLUMEFIXO_TIPO"] != DBNull.Value && dr["VOLUMEFIXO_TIPO"].ToString() == "1";
                            ciclo.IsVolumeMaiorQue60 = dr["VOLUMEFIXO_MAIOR"] != DBNull.Value && dr["VOLUMEFIXO_MAIOR"].ToString() == "1";
                            ciclo.VolumeFixo = dr["VOLUMEFIXO_TOTAL"] == DBNull.Value
                                ? string.Empty
                                : dr["VOLUMEFIXO_TOTAL"].ToString();
                            listaCiclos.Add(ciclo);
                        }
                        return listaCiclos;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao listar ciclos por situação";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao listar ciclos por situação";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static List<Ciclos> listaCiclosPorSituacaoEq(int crg, int situacao)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM CICLO WHERE SITUACAO = " + situacao + " AND CRG = " + crg + " ORDER BY CRG,NTRAT";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<Ciclos> listaCiclos = new List<Ciclos>();
                        while (dr.Read())
                        {
                            Ciclos ciclo = new Ciclos();
                            ciclo.id = (int)dr["ID"];
                            ciclo.crg = (int)dr["CRG"];
                            ciclo.nl = (int)dr["NL"];
                            ciclo.baseTempo = (int)dr["BASETEMPO"];
                            ciclo.nlt = (int)dr["NLT"];
                            ciclo.descricao = dr["DESCRICAO"].ToString();
                            ciclo.NLIniTrat = (int)dr["NLINICIOTRAT"];
                            ciclo.temperaturaControle = Convert.ToSingle(dr["TEMPERATURACONTROLE"]);
                            ciclo.temperaturaTrat = Convert.ToSingle(dr["TEMPERATURATRAT"]);
                            ciclo.tempoTrat = (int)dr["TEMPOTRATAMENTO"];
                            ciclo.responsavel = dr["RESPONSAVEL"].ToString();
                            ciclo.operador = dr["OPERADOR"].ToString();
                            ciclo.situacao = (int)dr["SITUACAO"];
                            ciclo.numSerie = dr["NUMEROSERIE"].ToString();
                            ciclo.dataInicio = Convert.ToDateTime(dr["DATAINICIO"]);
                            ciclo.dataFim = Convert.ToDateTime(dr["DATAFIM"]);
                            ciclo.dataIniTrat = Convert.ToDateTime(dr["DATAINITRAT"]);
                            ciclo.dataColeta = Convert.ToDateTime(dr["DATACOLETA"]);
                            ciclo.nTrat = Convert.ToInt32(dr["NTRAT"]);
                            ciclo.histerese = Convert.ToInt32(dr["HISTERESE"]);
                            ciclo.tControl = Convert.ToInt32(dr["TCONTROL"]);
                            ciclo.nlAntesTrat = Convert.ToInt32(dr["NLANTESTRAT"]);
                            ciclo.nlPostTrat = Convert.ToInt32(dr["NLPOSTRAT"]);
                            ciclo.sensor = Convert.ToInt32(dr["SENSOR"]);
                            ciclo.versaoEquip = dr["VERSAOEQUIP"].ToString();
                            ciclo.tipoCRG = (int)dr["TIPOCRG"];
                            ciclo.IsMetrosCubicos = dr["VOLUMEFIXO_TIPO"] != DBNull.Value && dr["VOLUMEFIXO_TIPO"].ToString() == "1";
                            ciclo.IsVolumeMaiorQue60 = dr["VOLUMEFIXO_MAIOR"] != DBNull.Value && dr["VOLUMEFIXO_MAIOR"].ToString() == "1";
                            ciclo.VolumeFixo = dr["VOLUMEFIXO_TOTAL"] == DBNull.Value
                                ? string.Empty
                                : dr["VOLUMEFIXO_TOTAL"].ToString();
                            listaCiclos.Add(ciclo);
                        }
                        return listaCiclos;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao listar ciclos por situação e crg";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao listar ciclos por situação e crg";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static List<Ciclos> listaCiclosPorSituacaoMes(int crg, int situacao, int mes)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM CICLO WHERE SITUACAO = " + situacao + " AND CRG = " + crg +
                                " AND DATAINICIO > '" + DateTime.Today.AddMonths(mes).ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY CRG,NTRAT";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<Ciclos> listaCiclos = new List<Ciclos>();
                        while (dr.Read())
                        {
                            Ciclos ciclo = new Ciclos();
                            ciclo.id = (int)dr["ID"];
                            ciclo.crg = (int)dr["CRG"];
                            ciclo.nl = (int)dr["NL"];
                            ciclo.baseTempo = (int)dr["BASETEMPO"];
                            ciclo.nlt = (int)dr["NLT"];
                            ciclo.descricao = dr["DESCRICAO"].ToString();
                            ciclo.NLIniTrat = (int)dr["NLINICIOTRAT"];
                            ciclo.temperaturaControle = Convert.ToSingle(dr["TEMPERATURACONTROLE"]);
                            ciclo.temperaturaTrat = Convert.ToSingle(dr["TEMPERATURATRAT"]);
                            ciclo.tempoTrat = (int)dr["TEMPOTRATAMENTO"];
                            ciclo.responsavel = dr["RESPONSAVEL"].ToString();
                            ciclo.operador = dr["OPERADOR"].ToString();
                            ciclo.situacao = (int)dr["SITUACAO"];
                            ciclo.numSerie = dr["NUMEROSERIE"].ToString();
                            ciclo.dataInicio = Convert.ToDateTime(dr["DATAINICIO"]);
                            ciclo.dataFim = Convert.ToDateTime(dr["DATAFIM"]);
                            ciclo.dataIniTrat = Convert.ToDateTime(dr["DATAINITRAT"]);
                            ciclo.dataColeta = Convert.ToDateTime(dr["DATACOLETA"]);
                            ciclo.nTrat = Convert.ToInt32(dr["NTRAT"]);
                            ciclo.histerese = Convert.ToInt32(dr["HISTERESE"]);
                            ciclo.tControl = Convert.ToInt32(dr["TCONTROL"]);
                            ciclo.nlAntesTrat = Convert.ToInt32(dr["NLANTESTRAT"]);
                            ciclo.nlPostTrat = Convert.ToInt32(dr["NLPOSTRAT"]);
                            ciclo.sensor = Convert.ToInt32(dr["SENSOR"]);
                            ciclo.versaoEquip = dr["VERSAOEQUIP"].ToString();
                            ciclo.tipoCRG = (int)dr["TIPOCRG"];
                            ciclo.IsMetrosCubicos = dr["VOLUMEFIXO_TIPO"] != DBNull.Value && dr["VOLUMEFIXO_TIPO"].ToString() == "1";
                            ciclo.IsVolumeMaiorQue60 = dr["VOLUMEFIXO_MAIOR"] != DBNull.Value && dr["VOLUMEFIXO_MAIOR"].ToString() == "1";
                            ciclo.VolumeFixo = dr["VOLUMEFIXO_TOTAL"] == DBNull.Value
                                ? string.Empty
                                : dr["VOLUMEFIXO_TOTAL"].ToString();
                            listaCiclos.Add(ciclo);
                        }
                        return listaCiclos;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao listar ciclos por situação e crg";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao listar ciclos por situação e crg";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static List<Ciclos> listaCiclosPorSituacaoEntre(int crg, int situacao, DateTime dataInicio, DateTime dataFim)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM CICLO WHERE SITUACAO = " + situacao + " AND CRG = " + crg +
                                " AND DATAINICIO >= '" + dataInicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND DATAINICIO <= '" +
                                          " " + dataFim.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY CRG,NTRAT";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<Ciclos> listaCiclos = new List<Ciclos>();
                        while (dr.Read())
                        {
                            Ciclos ciclo = new Ciclos();
                            ciclo.id = (int)dr["ID"];
                            ciclo.crg = (int)dr["CRG"];
                            ciclo.nl = (int)dr["NL"];
                            ciclo.baseTempo = (int)dr["BASETEMPO"];
                            ciclo.nlt = (int)dr["NLT"];
                            ciclo.descricao = dr["DESCRICAO"].ToString();
                            ciclo.NLIniTrat = (int)dr["NLINICIOTRAT"];
                            ciclo.temperaturaControle = Convert.ToSingle(dr["TEMPERATURACONTROLE"]);
                            ciclo.temperaturaTrat = Convert.ToSingle(dr["TEMPERATURATRAT"]);
                            ciclo.tempoTrat = (int)dr["TEMPOTRATAMENTO"];
                            ciclo.responsavel = dr["RESPONSAVEL"].ToString();
                            ciclo.operador = dr["OPERADOR"].ToString();
                            ciclo.situacao = (int)dr["SITUACAO"];
                            ciclo.numSerie = dr["NUMEROSERIE"].ToString();
                            ciclo.dataInicio = Convert.ToDateTime(dr["DATAINICIO"]);
                            ciclo.dataFim = Convert.ToDateTime(dr["DATAFIM"]);
                            ciclo.dataIniTrat = Convert.ToDateTime(dr["DATAINITRAT"]);
                            ciclo.dataColeta = Convert.ToDateTime(dr["DATACOLETA"]);
                            ciclo.nTrat = Convert.ToInt32(dr["NTRAT"]);
                            ciclo.histerese = Convert.ToInt32(dr["HISTERESE"]);
                            ciclo.tControl = Convert.ToInt32(dr["TCONTROL"]);
                            ciclo.nlAntesTrat = Convert.ToInt32(dr["NLANTESTRAT"]);
                            ciclo.nlPostTrat = Convert.ToInt32(dr["NLPOSTRAT"]);
                            ciclo.sensor = Convert.ToInt32(dr["SENSOR"]);
                            ciclo.versaoEquip = dr["VERSAOEQUIP"].ToString();
                            ciclo.tipoCRG = (int)dr["TIPOCRG"];
                            ciclo.IsMetrosCubicos = dr["VOLUMEFIXO_TIPO"] != DBNull.Value && dr["VOLUMEFIXO_TIPO"].ToString() == "1";
                            ciclo.IsVolumeMaiorQue60 = dr["VOLUMEFIXO_MAIOR"] != DBNull.Value && dr["VOLUMEFIXO_MAIOR"].ToString() == "1";
                            ciclo.VolumeFixo = dr["VOLUMEFIXO_TOTAL"] == DBNull.Value
                                ? string.Empty
                                : dr["VOLUMEFIXO_TOTAL"].ToString();
                            listaCiclos.Add(ciclo);
                        }
                        return listaCiclos;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao listar ciclos por situação e crg";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao listar ciclos por situação e crg";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static Ciclos testaCicloExistente(Ciclos ciclo)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM CICLO WHERE CRG = " + ciclo.crg + " AND DATAINICIO = '" +
                                          ciclo.dataInicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND NUMEROSERIE = '" + ciclo.numSerie+
                                          "' AND NTRAT = "+ciclo.nTrat;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            ciclo = new Ciclos();
                            ciclo.id = (int)dr["ID"];
                            ciclo.crg = (int)dr["CRG"];
                            ciclo.nl = (int)dr["NL"];
                            return ciclo;
                        }
                        else
                        {
                            return null;    
                        }
                        
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro ao testar ciclo já existente";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro ao testar ciclo já existente";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static int retornaId(Ciclos ciclo)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT ID FROM CICLO WHERE CRG = " + ciclo.crg + " AND DATAINICIO = '" +
                                          ciclo.dataInicio.ToString("yyyy-MM-dd HH:mm:ss:00") +
                                          "' AND NUMEROSERIE = '" + ciclo.numSerie+"' AND NTRAT = "+ciclo.nTrat;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            return (int) dr["ID"];
                        }
                        return -1;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro no retornar id";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro no retornar id";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                }
            }
        }

        public static bool DeletaCiclo(int id, int crg)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "DELETE FROM CICLO WHERE ID = " + id;
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro no deletar Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro no deletar Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static Ciclos buscaCicloPorNTrat(int crg, int nTrat)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM CICLO WHERE NTRAT = " + nTrat;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Ciclos ciclo = new Ciclos();
                            ciclo.id = (int)dr["ID"];
                            ciclo.crg = (int)dr["CRG"];
                            ciclo.nl = (int)dr["NL"];
                            ciclo.baseTempo = (int)dr["BASETEMPO"];
                            ciclo.nlt = (int)dr["NLT"];
                            ciclo.descricao = dr["DESCRICAO"].ToString();
                            ciclo.NLIniTrat = (int)dr["NLINICIOTRAT"];
                            ciclo.temperaturaControle = Convert.ToSingle(dr["TEMPERATURACONTROLE"]);
                            ciclo.temperaturaTrat = Convert.ToSingle(dr["TEMPERATURATRAT"]);
                            ciclo.tempoTrat = (int)dr["TEMPOTRATAMENTO"];
                            ciclo.responsavel = dr["RESPONSAVEL"].ToString();
                            ciclo.operador = dr["OPERADOR"].ToString();
                            ciclo.situacao = (int)dr["SITUACAO"];
                            ciclo.numSerie = dr["NUMEROSERIE"].ToString();
                            ciclo.dataInicio = Convert.ToDateTime(dr["DATAINICIO"]);
                            ciclo.dataFim = Convert.ToDateTime(dr["DATAFIM"]);
                            ciclo.dataIniTrat = Convert.ToDateTime(dr["DATAINITRAT"]);
                            ciclo.dataColeta = Convert.ToDateTime(dr["DATACOLETA"]);
                            ciclo.nTrat = Convert.ToInt32(dr["NTRAT"]);
                            ciclo.histerese = Convert.ToInt32(dr["HISTERESE"]);
                            ciclo.tControl = Convert.ToInt32(dr["TCONTROL"]);
                            ciclo.nlAntesTrat = Convert.ToInt32(dr["NLANTESTRAT"]);
                            ciclo.nlPostTrat = Convert.ToInt32(dr["NLPOSTRAT"]);
                            ciclo.sensor = Convert.ToInt32(dr["SENSOR"]);
                            ciclo.versaoEquip = dr["VERSAOEQUIP"].ToString();
                            ciclo.tipoCRG = (int)dr["TIPOCRG"];
                            ciclo.IsMetrosCubicos = dr["VOLUMEFIXO_TIPO"] != DBNull.Value && dr["VOLUMEFIXO_TIPO"].ToString() == "1";
                            ciclo.IsVolumeMaiorQue60 = dr["VOLUMEFIXO_MAIOR"] != DBNull.Value && dr["VOLUMEFIXO_MAIOR"].ToString() == "1";
                            ciclo.VolumeFixo = dr["VOLUMEFIXO_TOTAL"] == DBNull.Value
                                ? string.Empty
                                : dr["VOLUMEFIXO_TOTAL"].ToString();
                            return ciclo;
                        }
                        return null;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro no buscar ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro no buscar ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static Ciclos buscaCiclo(int crg, int id)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM CICLO WHERE ID = "+id;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Ciclos ciclo = new Ciclos();
                            ciclo.id = (int) dr["ID"];
                            ciclo.crg = (int) dr["CRG"];
                            ciclo.nl = (int) dr["NL"];
                            ciclo.baseTempo = (int) dr["BASETEMPO"];
                            ciclo.nlt = (int) dr["NLT"];
                            ciclo.descricao = dr["DESCRICAO"].ToString();
                            ciclo.NLIniTrat = (int) dr["NLINICIOTRAT"];
                            ciclo.temperaturaControle = Convert.ToSingle(dr["TEMPERATURACONTROLE"]);
                            ciclo.temperaturaTrat = Convert.ToSingle(dr["TEMPERATURATRAT"]);
                            ciclo.tempoTrat = (int) dr["TEMPOTRATAMENTO"];
                            ciclo.responsavel = dr["RESPONSAVEL"].ToString();
                            ciclo.operador = dr["OPERADOR"].ToString();
                            ciclo.situacao = (int) dr["SITUACAO"];
                            ciclo.numSerie = dr["NUMEROSERIE"].ToString();
                            ciclo.dataInicio = Convert.ToDateTime(dr["DATAINICIO"]);
                            ciclo.dataFim = Convert.ToDateTime(dr["DATAFIM"]);
                            ciclo.dataIniTrat = Convert.ToDateTime(dr["DATAINITRAT"]);
                            ciclo.dataColeta = Convert.ToDateTime(dr["DATACOLETA"]);
                            ciclo.nTrat = Convert.ToInt32(dr["NTRAT"]);
                            ciclo.histerese = Convert.ToInt32(dr["HISTERESE"]);
                            ciclo.tControl = Convert.ToInt32(dr["TCONTROL"]);
                            ciclo.nlAntesTrat = Convert.ToInt32(dr["NLANTESTRAT"]);
                            ciclo.nlPostTrat = Convert.ToInt32(dr["NLPOSTRAT"]);
                            ciclo.sensor = Convert.ToInt32(dr["SENSOR"]);
                            ciclo.versaoEquip = dr["VERSAOEQUIP"].ToString();
                            ciclo.tipoCRG = (int)dr["TIPOCRG"];
                            ciclo.IsMetrosCubicos = dr["VOLUMEFIXO_TIPO"] != DBNull.Value && dr["VOLUMEFIXO_TIPO"].ToString() == "1";
                            ciclo.IsVolumeMaiorQue60 = dr["VOLUMEFIXO_MAIOR"] != DBNull.Value && dr["VOLUMEFIXO_MAIOR"].ToString() == "1";
                            ciclo.VolumeFixo = dr["VOLUMEFIXO_TOTAL"] == DBNull.Value
                                ? string.Empty
                                : dr["VOLUMEFIXO_TOTAL"].ToString();
                            return ciclo;
                        }
                        return null;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro no buscar ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro no buscar ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static Ciclos testaCiclo(Ciclos cic)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM CICLO WHERE CRG = " + cic.crg + " AND NUMEROSERIE = '" + cic.numSerie + "' " +
                                          "AND DATAINICIO = '" + cic.dataInicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND NTRAT = " + cic.nTrat;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Ciclos ciclo = new Ciclos();
                            ciclo.id = (int)dr["ID"];
                            ciclo.crg = (int)dr["CRG"];
                            ciclo.nl = (int)dr["NL"];
                            ciclo.baseTempo = (int)dr["BASETEMPO"];
                            ciclo.nlt = (int)dr["NLT"];
                            ciclo.descricao = dr["DESCRICAO"].ToString();
                            ciclo.NLIniTrat = (int)dr["NLINICIOTRAT"];
                            ciclo.temperaturaControle = Convert.ToSingle(dr["TEMPERATURACONTROLE"]);
                            ciclo.temperaturaTrat = Convert.ToSingle(dr["TEMPERATURATRAT"]);
                            ciclo.tempoTrat = (int)dr["TEMPOTRATAMENTO"];
                            ciclo.responsavel = dr["RESPONSAVEL"].ToString();
                            ciclo.operador = dr["OPERADOR"].ToString();
                            ciclo.situacao = (int)dr["SITUACAO"];
                            ciclo.numSerie = dr["NUMEROSERIE"].ToString();
                            ciclo.dataInicio = Convert.ToDateTime(dr["DATAINICIO"]);
                            ciclo.dataFim = Convert.ToDateTime(dr["DATAFIM"]);
                            ciclo.dataIniTrat = Convert.ToDateTime(dr["DATAINITRAT"]);
                            ciclo.dataColeta = Convert.ToDateTime(dr["DATACOLETA"]);
                            ciclo.nTrat = Convert.ToInt32(dr["NTRAT"]);
                            ciclo.histerese = Convert.ToInt32(dr["HISTERESE"]);
                            ciclo.tControl = Convert.ToInt32(dr["TCONTROL"]);
                            ciclo.nlAntesTrat = Convert.ToInt32(dr["NLANTESTRAT"]);
                            ciclo.nlPostTrat = Convert.ToInt32(dr["NLPOSTRAT"]);
                            ciclo.sensor = Convert.ToInt32(dr["SENSOR"]);
                            ciclo.versaoEquip = dr["VERSAOEQUIP"].ToString();
                            ciclo.tipoCRG = (int)dr["TIPOCRG"];
                            ciclo.IsMetrosCubicos = dr["VOLUMEFIXO_TIPO"] != DBNull.Value && dr["VOLUMEFIXO_TIPO"].ToString() == "1";
                            ciclo.IsVolumeMaiorQue60 = dr["VOLUMEFIXO_MAIOR"] != DBNull.Value && dr["VOLUMEFIXO_MAIOR"].ToString() == "1";
                            ciclo.VolumeFixo = dr["VOLUMEFIXO_TOTAL"] == DBNull.Value
                                ? string.Empty
                                : dr["VOLUMEFIXO_TOTAL"].ToString();
                            return ciclo;
                        }
                        return null;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = cic.crg;
                        logErro.descricao = "Erro no testar ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = cic.crg;
                        logErro.descricao = "Erro no testar ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static bool testanoBanco(Ciclos ciclo)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM CICLO WHERE CRG = " + ciclo.crg + " AND DATAINICIO = '" +
                                          ciclo.dataInicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND NTRAT = " + ciclo.nTrat +
                                          " AND NL = "+ciclo.nl;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return true;
                        return false;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro ao testar ciclo já existente";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro ao testar ciclo já existente";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool alteraSituacao(int crg, int id)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "UPDATE CICLO SET SITUACAO = 1 WHERE ID = " + id;
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao enviar para finalizadas";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao enviar para finalizadas";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }
    }
}
