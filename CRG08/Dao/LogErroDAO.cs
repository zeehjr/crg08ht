using System;
using System.Collections.Generic;
using CRG08.VO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Dao
{
    public class LogErroDAO
    {
        public static void inserirLogErro(LogErro logErro, int crg)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "INSERT INTO LOGERRO(DESCRICAO, CRG, MAISDETALHES, DATA, HORA) VALUES(@DESCRICAO, @CRG, @MAISDETALHES, @DATA, @HORA)";
                        cmd.Parameters.AddWithValue("@DESCRICAO", logErro.descricao);
                        cmd.Parameters.AddWithValue("@CRG", logErro.crg);
                        cmd.Parameters.AddWithValue("@MAISDETALHES", logErro.maisDetalhes);
                        cmd.Parameters.AddWithValue("@DATA", logErro.data.ToString("dd.MM.yyyy"));
                        cmd.Parameters.AddWithValue("@HORA", logErro.data.ToString("HH:mm:ss"));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    catch (FbException fbError)
                    {
                        LogErro LogErro = new LogErro();
                        LogErro.descricao = "Erro ao inserir LogErro";
                        LogErro.crg = crg;
                        LogErro.data = DateTime.Now;
                        LogErro.maisDetalhes = fbError.Message;
                        inserirLogErro(LogErro, crg);
                    }
                    catch (Exception error)
                    {
                        LogErro LogErro = new LogErro();
                        LogErro.descricao = "Erro ao inserir LogErro";
                        LogErro.crg = crg;
                        LogErro.data = DateTime.Now;
                        LogErro.maisDetalhes = error.Message;
                        inserirLogErro(LogErro, crg);
                    }
                }
            }   
        }

        public static int deletaLogErro(DateTime data, DateTime dataFim)
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
                            cmd.CommandText = "SELECT FIRST 1 CODERRO FROM LOGERRO WHERE DATA = '" +
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
                                retorno = (int)dr["CODERRO"];
                                continua = true;
                                dr.Close();
                            }
                        } while (!continua);
                        return retorno;

                    }
                    catch (FbException fbError)
                    {
                        LogErro log = new LogErro();
                        log.crg = 0;
                        log.descricao = "Erro ao buscar codigo para deletar erros antigos";
                        string dataHora = DateTime.Now.ToString();
                        log.data = Convert.ToDateTime(dataHora.Substring(0, 10) + " " +dataHora.Substring(11, 8));
                        log.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(log, log.crg);
                        return -1;
                    }
                    catch (Exception error)
                    {
                        LogErro log = new LogErro();
                        log.crg = 0;
                        log.descricao = "Erro ao buscar codigo para deletar erros antigos";
                        string dataHora = DateTime.Now.ToString();
                        log.data = Convert.ToDateTime(dataHora.Substring(0, 10) + " " + dataHora.Substring(11, 8));
                        log.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(log, log.crg);
                        return -1;
                    }
                }
            }
        }

        public static List<LogErro> ListaErros()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM LOGERRO ORDER BY CODERRO";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<LogErro> listaErros = new List<LogErro>();
                        while (dr.Read())
                        {
                            LogErro logErro = new LogErro();
                            logErro.codErro = (int)dr["CODERRO"];
                            logErro.descricao = dr["DESCRICAO"].ToString();
                            logErro.data = Convert.ToDateTime(dr["DATA"].ToString()+" "+dr["HORA"].ToString());
                            logErro.crg = (int)dr["CRG"];
                            logErro.maisDetalhes = dr["MAISDETALHES"].ToString();
                            listaErros.Add(logErro);
                        }
                        return listaErros;
                    }
                    catch (FbException fbError)
                    {
                        LogErro log = new LogErro();
                        log.crg = 0;
                        log.descricao = "Erro ao listar log erro";
                        string dataHora = DateTime.Now.ToString();
                        log.data = Convert.ToDateTime(dataHora.Substring(0, 10) + " " + dataHora.Substring(11, 8));
                        log.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(log, log.crg);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro log = new LogErro();
                        log.crg = 0;
                        log.descricao = "Erro ao listar log erro";
                        string dataHora = DateTime.Now.ToString();
                        log.data = Convert.ToDateTime(dataHora.Substring(0, 10) + " " + dataHora.Substring(11, 8));
                        log.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(log, log.crg);
                        return null;
                    }
                }
            }
        }

        public static string RetornaMaisDetalhes(int codigo)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT MAISDETALHES FROM LOGERRO WHERE CODERRO = " + codigo;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return dr["MAISDETALHES"].ToString();
                        else return null;
                        dr.Close();
                    }
                    catch (FbException fbError)
                    {
                        LogErro log = new LogErro();
                        log.crg = 0;
                        log.descricao = "Erro ao selecionar mais detalhes log erro";
                        string dataHora = DateTime.Now.ToString();
                        log.data = Convert.ToDateTime(dataHora.Substring(0, 10) + " " + dataHora.Substring(11, 8));
                        log.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(log, log.crg);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro log = new LogErro();
                        log.crg = 0;
                        log.descricao = "Erro ao selecionar mais detalhes log erro";
                        string dataHora = DateTime.Now.ToString();
                        log.data = Convert.ToDateTime(dataHora.Substring(0, 10) + " " + dataHora.Substring(11, 8));
                        log.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(log, log.crg);
                        return null;
                    }
                }
            }
        }

        public static List<LogErro> listaErrosPorPeriodo(string dataInicio, string dataFim)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        int codI = retornaCodIniPeriodo(dataInicio, Convert.ToDateTime(dataFim));
                        int codF = retornaCodFim(Convert.ToDateTime(dataInicio), dataFim);
                        if (codI != -1 && codF != -1)
                        {
                            cmd.CommandText = "SELECT * FROM LOGERRO WHERE CODERRO >= " + codI + " AND CODERRO <= " + codF + " ORDER BY CODERRO";
                            FbDataReader dr = cmd.ExecuteReader();
                            List<LogErro> listaErros = new List<LogErro>();
                            while (dr.Read())
                            {
                                LogErro logErro = new LogErro();
                                logErro.codErro = (int)dr["CODERRO"];
                                logErro.descricao = dr["DESCRICAO"].ToString();
                                logErro.data = Convert.ToDateTime(dr["DATA"] + " " + dr["HORA"]);
                                logErro.crg = (int)dr["CRG"];
                                logErro.maisDetalhes = dr["MAISDETALHES"].ToString();
                                listaErros.Add(logErro);
                            }
                            dr.Close();
                            return listaErros;
                        }
                        return new List<LogErro>();
                    }
                    catch (FbException fbError)
                    {
                        LogErro log = new LogErro();
                        log.crg = 0;
                        log.descricao = "Erro ao listar log erro por periodo";
                        string dataHora = DateTime.Now.ToString();
                        log.data = Convert.ToDateTime(dataHora.Substring(0, 10) + " " + dataHora.Substring(11, 8));
                        log.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(log, log.crg);
                        return new List<LogErro>();
                    }
                    catch (Exception error)
                    {
                        LogErro log = new LogErro();
                        log.crg = 0;
                        log.descricao = "Erro ao listar log erro por periodo";
                        string dataHora = DateTime.Now.ToString();
                        log.data = Convert.ToDateTime(dataHora.Substring(0, 10) + " " + dataHora.Substring(11, 8));
                        log.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(log, log.crg);
                        return new List<LogErro>();
                    }
                }
            }
        }

        public static int retornaCodIniPeriodo(string data, DateTime dataFim)
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
                            cmd.CommandText = "SELECT FIRST 1 CODERRO FROM LOGERRO WHERE DATA = '" + data.ToString().Substring(0,2) + "."+
                                data.ToString().Substring(3,2) + "." + data.ToString().Substring(6,4)+"'";
                            FbDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                retorno = (int)dr["CODERRO"];
                                continua = true;
                                dr.Close();
                            }
                            else
                            {
                                data = Convert.ToDateTime(data).AddDays(1).ToString().Substring(0, 10);
                                if (Convert.ToDateTime(data) > dataFim)
                                {
                                    continua = true;
                                    retorno = -1;
                                }
                            }
                        } while (!continua);
                        return retorno;
                    }
                    catch (FbException fbError)
                    {
                        LogErro log = new LogErro();
                        log.crg = 0;
                        log.descricao = "Erro ao retornar codigo inicio do periodo";
                        string dataHora = DateTime.Now.ToString();
                        log.data = Convert.ToDateTime(dataHora.Substring(0, 10) + " " + dataHora.Substring(11, 8));
                        log.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(log, log.crg);
                        return -1;
                    }
                    catch (Exception error)
                    {
                        LogErro log = new LogErro();
                        log.crg = 0;
                        log.descricao = "Erro ao retornar codigo inicio do periodo";
                        string dataHora = DateTime.Now.ToString();
                        log.data = Convert.ToDateTime(dataHora.Substring(0, 10) + " " + dataHora.Substring(11, 8));
                        log.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(log, log.crg);
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
                            cmd.CommandText = "SELECT MAX(CODERRO) AS CODERRO FROM LOGERRO WHERE DATA ='" + dataFim.ToString().Substring(0,2) + "." +
                                dataFim.ToString().Substring(3,2)+ "." + dataFim.ToString().Substring(6,4) + "'";
                            FbDataReader dr = cmd.ExecuteReader();
                            if (dr.Read() && dr["CODERRO"] != DBNull.Value)
                            {
                                retorno = (int)dr["CODERRO"];
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
                        LogErro log = new LogErro();
                        log.crg = 0;
                        log.descricao = "Erro ao retornar codigo fim da pesquisa por periodo";
                        string dataHora = DateTime.Now.ToString();
                        log.data = Convert.ToDateTime(dataHora.Substring(0, 10) + " " + dataHora.Substring(11, 8));
                        log.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(log, log.crg);
                        return -1;
                    }
                    catch (Exception error)
                    {
                        LogErro log = new LogErro();
                        log.crg = 0;
                        log.descricao = "Erro ao retornar codigo fim da pesquisa por periodo";
                        string dataHora = DateTime.Now.ToString();
                        log.data = Convert.ToDateTime(dataHora.Substring(0, 10) + " " + dataHora.Substring(11, 8));
                        log.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(log, log.crg);
                        return -1;
                    }
                }
            }
        }
    }
}
