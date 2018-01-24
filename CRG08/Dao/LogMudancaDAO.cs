using System;
using System.Collections.Generic;
using CRG08.VO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Dao
{
    public class LogMudancaDAO
    {
        public static bool insereLogMudanca(LogMudanca log)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "INSERT INTO LOGMUDANCA(DESCRICAO,CRG,RESPONSAVEL,DATA,HORA) VALUES(@DESCRICAO, @CRG, @RESPONSAVEL, @DATA, @HORA)";
                        cmd.Parameters.AddWithValue("@DESCRICAO", log.descricao);
                        cmd.Parameters.AddWithValue("@CRG", log.crg);
                        cmd.Parameters.AddWithValue("@RESPONSAVEL", log.responsavel);
                        cmd.Parameters.AddWithValue("@DATA", log.data.ToString("dd.MM.yyyy"));
                        cmd.Parameters.AddWithValue("@HORA", log.data.ToString("HH:mm:ss"));
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no inserir Log de mudança";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro,0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no inserir Log de mudança";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool alteraLogMudanca(LogMudanca log)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "UPDATE LOGMUDANCA SET DESCRICAO = @DESCRICAO, CRG = @CRG, DATA = @DATA, " +
                            "RESPONSAVEL = @RESPONSAVEL, HORA = @HORA WHERE CODMUDANCA = " + log.codMudanca;
                        cmd.Parameters.AddWithValue("@DESCRICAO", log.descricao);
                        cmd.Parameters.AddWithValue("@CRG", log.crg);
                        cmd.Parameters.AddWithValue("@DATA", log.data.ToString().Substring(0,10));
                        cmd.Parameters.AddWithValue("@RESPONSAVEL", log.responsavel);
                        cmd.Parameters.AddWithValue("@HORA", log.data.ToString().Substring(11, 8));
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no alterar Log de mudança";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no alterar Log de mudança";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool deletaLogMudanca(DateTime data, DateTime dataFim)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        int cod = retornaCodDeleta(data, dataFim);
                        if (cod != -1)
                        {
                            cmd.CommandText = "DELETE FROM LOGMUDANCA WHERE CODMUDANCA < " + cod;
                            cmd.ExecuteNonQuery();
                        }
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no deletar Log de mudança";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no deletar Log de mudança";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static List<LogMudanca> listaLogMudancas()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM LOGMUDANCA";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<LogMudanca> listaMudanca = new List<LogMudanca>();
                        while (dr.Read())
                        {
                            LogMudanca log = new LogMudanca();
                            log.codMudanca = (int)dr["CODMUDANCA"];
                            log.descricao = dr["DESCRICAO"].ToString();
                            log.crg = Convert.ToInt32(dr["CRG"]);
                            log.data = Convert.ToDateTime(dr["DATA"]+" " + dr["HORA"]);
                            log.responsavel = dr["RESPONSAVEL"].ToString();
                            listaMudanca.Add(log);
                        }
                        return listaMudanca;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao listar os Logs de mudança";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao listar os Logs de mudança";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static List<LogMudanca> buscaListaPorPeriodo(string dataI, string dataF)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        int codI = retornaCodInicio(dataI, Convert.ToDateTime(dataF));
                        int codF = retornaCodFim(Convert.ToDateTime(dataI), dataF);
                        if (codI != -1 && codF != -1)
                        {
                            cmd.CommandText = "SELECT * FROM LOGMUDANCA WHERE CODMUDANCA >= " + codI +
                                              " AND CODMUDANCA <= " + codF + " ORDER BY CODMUDANCA";
                            FbDataReader dr = cmd.ExecuteReader();
                            List<LogMudanca> listaMudanca = new List<LogMudanca>();
                            while (dr.Read())
                            {
                                LogMudanca log = new LogMudanca();
                                log.codMudanca = (int)dr["CODMUDANCA"];
                                log.descricao = dr["DESCRICAO"].ToString();
                                log.crg = Convert.ToInt32(dr["CRG"]);
                                log.data = Convert.ToDateTime(dr["DATA"] + " " + dr["HORA"]);
                                log.responsavel = dr["RESPONSAVEL"].ToString();
                                listaMudanca.Add(log);
                            }
                            return listaMudanca;
                        }
                        return new List<LogMudanca>();

                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao listar os Logs de mudança por periodo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao listar os Logs de mudança por periodo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static int retornaCodInicio(string data, DateTime dataFim)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        bool continua = false;
                        int retorno = -1;
                        do
                        {
                            cmd.CommandText = "SELECT FIRST 1 CODMUDANCA FROM LOGMUDANCA WHERE DATA ='" + data.ToString().Substring(0,2) + "." + 
                                data.ToString().Substring(3,2) + "." +data.ToString().Substring(6,4) +"'";
                            FbDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                retorno = (int)dr["CODMUDANCA"];
                                continua = true;
                                dr.Close();
                            }
                            else
                            {
                                data = Convert.ToDateTime(data).AddDays(1).ToString().Substring(0, 10);
                                if (Convert.ToDateTime(data) > dataFim)
                                {
                                    continua = true;
                                    dr.Close();
                                }
                            }
                        } while (!continua);
                        return retorno;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao retornar codigo inicio da pesquisa por periodo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao retornar codigo inicio da pesquisa por periodo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                }
            }
        }

        public static int retornaCodFim(DateTime dataI, string dataFim)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        bool continua = false;
                        int retorno = -1;
                        do
                        {
                            cmd.CommandText = "SELECT MAX(CODMUDANCA) AS CODMUDANCA FROM LOGMUDANCA WHERE DATA ='" +
                                              dataFim.ToString().Substring(0, 2) + "." +
                                              dataFim.ToString().Substring(3, 2) + "." +
                                              dataFim.ToString().Substring(6, 4) + "'";
                            FbDataReader dr = cmd.ExecuteReader();
                            if (dr.Read() && dr["CODMUDANCA"] != DBNull.Value)
                            {
                                retorno = (int)dr["CODMUDANCA"];
                                continua = true;
                                dr.Close();
                            }
                            else
                            {
                                dataFim = Convert.ToDateTime(dataFim).AddDays(-1).ToString().Substring(0, 10);
                                if (Convert.ToDateTime(dataFim) < dataI)
                                {
                                    continua = true;
                                    dr.Close();
                                }
                            }
                        } while (!continua);
                        return retorno;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao retornar codigo fim da pesquisa por periodo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao retornar codigo fim da pesquisa por periodo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                }
            }
        }

        public static int retornaCodDeleta(DateTime data, DateTime dataFim)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        bool continua = false;
                        int retorno = -1;
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        do
                        {
                            cmd.CommandText = "SELECT FIRST 1 CODMUDANCA FROM LOGMUDANCA WHERE DATA = '" +
                                              data.ToString().Substring(0, 10) + "'";
                            FbDataReader dr = cmd.ExecuteReader();
                            if (!dr.Read())
                            {
                                data = data.AddDays(1);
                                if (data > dataFim)
                                {
                                    continua = true;
                                    dr.Close();
                                }
                            }
                            else
                            {
                                retorno = (int)dr["CODMUDANCA"];
                                continua = true;
                                dr.Close();
                            }
                        } while (!continua);
                        return retorno;

                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao buscar codigo para deletar mudanças antigas";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao buscar codigo para deletar mudanças antigas";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                }
            }
        }
    }
}
