using System;
using System.Collections.Generic;
using CRG08.VO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Dao
{
    public class UnidadeDAO
    {
        public static bool InsereUnidade(Unidade unidade)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "INSERT INTO UNIDADE(UNIDADE) VALUES(@UNIDADE)";
                        cmd.Parameters.AddWithValue("@UNIDADE", unidade.unidade);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao inserir Unidade";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao inserir Unidade";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool alterarUnidade(Unidade unidade)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "UPDATE UNIDADE SET UNIDADE = @UNIDADE WHERE ID = " + unidade.idUnidade;
                        cmd.Parameters.AddWithValue("@UNIDADE", unidade.unidade);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao alterar Unidade";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro,0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao alterar Unidade";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static List<Unidade> retornaUnidades(int crg)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM UNIDADE";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<Unidade> listUnidades = new List<Unidade>();
                        while (dr.Read())
                        {
                            Unidade unidade = new Unidade();
                            unidade.idUnidade = (int)dr["ID"];
                            unidade.unidade = dr["UNIDADE"].ToString();
                            listUnidades.Add(unidade);
                        }
                        return listUnidades;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao listar todas Unidades";
                        logErro.crg = crg;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, crg);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao listar todas Unidades";
                        logErro.crg = crg;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, crg);
                        return null;
                    }
                }
            }
        }

        public static List<Unidade> retornaUnidades()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM UNIDADE";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<Unidade> listUnidades = new List<Unidade>();
                        while (dr.Read())
                        {
                            Unidade unidade = new Unidade();
                            unidade.idUnidade = (int)dr["ID"];
                            unidade.unidade = dr["UNIDADE"].ToString();
                            listUnidades.Add(unidade);
                        }
                        return listUnidades;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao listar todas Unidades";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao listar todas Unidades";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static string retornaUnidade(int idUnidade, int crg)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM UNIDADE WHERE ID = " + idUnidade;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Unidade unidade = new Unidade();
                            unidade.idUnidade = (int)dr["ID"];
                            unidade.unidade = dr["UNIDADE"].ToString();
                            return unidade.unidade;
                        }
                        return null;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao buscar Unidade";
                        logErro.crg = crg;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, crg);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao buscar Unidade";
                        logErro.crg = crg;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, crg);
                        return null;
                    }
                }
            }
        }

        public static bool deletaUnidade(int id)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "DELETE FROM UNIDADE WHERE ID = " + id;
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao deletar Unidade";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao deletar Unidade";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool testaUnidade(string unidade)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM UNIDADE WHERE UNIDADE = '" + unidade + "'";
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return false;
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao testar Unidade";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao testar Unidade";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static int retornaID(string unidade)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT ID FROM UNIDADE WHERE UNIDADE = '"+unidade+"'";
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return (int) dr["ID"];
                        return -1;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao retornar id da Unidade";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao retornar id da Unidade";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                }
            }
        }

        public static bool testaUsoUnid(int id)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM PRODUTO_CICLO WHERE UNIDADE = " + id;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return true;
                        return false;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao testar uso da unidade";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao testar uso da unidade";
                        logErro.crg = 0;
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
