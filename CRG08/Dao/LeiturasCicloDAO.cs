using System;
using System.Collections.Generic;
using System.Globalization;
using CRG08.VO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Dao
{
    public class LeiturasCicloDAO
    {
        public static bool inserirLeiturasCiclo(List<LeiturasCiclo> leituras, int pIndiceDaLeitura, Ciclos ciclo)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        for (int i = 0; i < leituras.Count; i++)
                        {
                            string inicioComando = "execute block as begin ";
                            string meioComando = string.Empty;
                            for (int j = pIndiceDaLeitura; j < leituras.Count; j++)
                            {
                                var l = leituras[j];
                                /*meioComando = "INSERT INTO LEITURAS_CICLO(HORARIO,T1,T2,T3,T4,CICLO) VALUES('" +
                                              leituras[j].horario + "'," +
                                              leituras[j].T1.ToString("00.0").Substring(0,2) + "." + leituras[j].T1.ToString("00.0").Substring(3,1) +"," +
                                              leituras[j].T2.ToString("00.0").Substring(0, 2) + "." + leituras[j].T2.ToString("00.0").Substring(3, 1) + "," +
                                              leituras[j].T3.ToString("00.0").Substring(0, 2) + "." + leituras[j].T3.ToString("00.0").Substring(3, 1) + "," +
                                              leituras[j].T4.ToString("00.0").Substring(0, 2) + "." + leituras[j].T4.ToString("00.0").Substring(3, 1) + "," +
                                              ciclo.id + ");";*/
                                meioComando = "INSERT INTO LEITURAS_CICLO(HORARIO,T1,T2,T3,T4,CICLO) VALUES('" +
                                              leituras[j].horario + "'," +
                                              leituras[j].T1.ToString().Replace(",", ".") + "," +
                                              leituras[j].T2.ToString().Replace(",", ".") + "," +
                                              leituras[j].T3.ToString().Replace(",", ".") + "," +
                                              leituras[j].T4.ToString().Replace(",", ".") + "," +
                                              ciclo.id + ");";

                                inicioComando += meioComando;
                                if (i == 100)
                                {
                                    inicioComando = inicioComando + "end";
                                    cmd.CommandText = inicioComando;
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                    inicioComando = "execute block as begin ";
                                    i = 0;
                                }
                                else i++;
                            }
                            if (i != 0)
                            {
                                inicioComando = inicioComando + "end";
                                cmd.CommandText = inicioComando;
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                                i = leituras.Count;
                            }
                        }
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro no inserir as Leituras do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro no inserir as Leituras do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool inserirLeiturasCiclo150(List<LeiturasCiclo> leituras, int pIndiceDaLeitura, Ciclos ciclo)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        for (int i = 0; i < leituras.Count; i++)
                        {
                            string inicioComando = "execute block as begin ";
                            string meioComando = string.Empty;
                            for (int j = pIndiceDaLeitura; j < leituras.Count; j++)
                            {
                                var l = leituras[j];
                                meioComando = "INSERT INTO LEITURAS_CICLO(HORARIO,T1,T2,T3,T4,CICLO) VALUES('" +
                                              leituras[j].horario + "'," +
                                              leituras[j].T1 + "," +
                                              leituras[j].T2 + "," +
                                              leituras[j].T3 + "," +
                                              leituras[j].T4 + "," +
                                              ciclo.id + ");";

                                inicioComando += meioComando;
                                if (i == 100)
                                {
                                    inicioComando = inicioComando + "end";
                                    cmd.CommandText = inicioComando;
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                    inicioComando = "execute block as begin ";
                                    i = 0;
                                }
                                else i++;
                            }
                            if (i != 0)
                            {
                                inicioComando = inicioComando + "end";
                                cmd.CommandText = inicioComando;
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                                i = leituras.Count;
                            }
                        }
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro no inserir as Leituras do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro no inserir as Leituras do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }


        public static bool alterarLeiturasCiclo(LeiturasCiclo leituras)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "UPDATE LEITURAS_CICLO SET HORARIO = @HORARIO, T1 = @T1, T2 = @T2, T3 = @T3, T4 = @T4, CICLO = @CICLO" +
                                          " WHERE ID = "+leituras.idLeiturasCiclo;
                        cmd.Parameters.AddWithValue("@HORARIO", leituras.horario);
                        cmd.Parameters.AddWithValue("@T1", leituras.T1);
                        cmd.Parameters.AddWithValue("@T2", leituras.T2);
                        cmd.Parameters.AddWithValue("@T3", leituras.T3);
                        cmd.Parameters.AddWithValue("@T4", leituras.T4);
                        cmd.Parameters.AddWithValue("@CICLO", leituras.ciclo.id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = leituras.ciclo.crg;
                        logErro.descricao = "Erro no alterar as Leituras do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = leituras.ciclo.crg;
                        logErro.descricao = "Erro no alterar as Leituras do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool DeletaLeiturasCiclo(int id, int crg)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "DELETE FROM LEITURAS_CICLO WHERE CICLO = " + id ;
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro no alterar as Leituras do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro no alterar as Leituras do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static List<LeiturasCiclo> ListaLeiturasCiclos(Ciclos ciclo)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM LEITURAS_CICLO WHERE CICLO = " + ciclo.id + " ORDER BY ID" ;
                        FbDataReader dr = cmd.ExecuteReader();
                        List<LeiturasCiclo> listaLeituras = new List<LeiturasCiclo>();
                        while (dr.Read())
                        {
                            LeiturasCiclo leituras = new LeiturasCiclo();
                            leituras.idLeiturasCiclo = (int) dr["ID"];
                            leituras.horario = dr["HORARIO"].ToString();
                            leituras.T1 = Convert.ToSingle(dr["T1"]);
                            leituras.T2 = Convert.ToSingle(dr["T2"]);
                            leituras.T3 = Convert.ToSingle(dr["T3"]);
                            leituras.T4 = Convert.ToSingle(dr["T4"]);
                            leituras.ciclo = ciclo;
                            listaLeituras.Add(leituras);
                        }
                        return listaLeituras;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro ao listar as Leituras do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro ao listar as Leituras do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static int retornaQtdeLeituras(int id, int crg)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT COUNT(ID) AS ID FROM LEITURAS_CICLO WHERE CICLO = " + id;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return (int)dr["ID"];
                        return -1;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao retornar quantidade de leituras do ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro ao retornar quantidade de leituras do ciclo";
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
