using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using CRG08.VO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Dao
{
    public class ProdutoDAO
    {
        public static bool InsereProduto(Produto produto)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "INSERT INTO PRODUTO(DESCRICAO) VALUES(@DESCRICAO)";
                        cmd.Parameters.AddWithValue("@DESCRICAO", produto.descricao);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao inserir Produto";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro,0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao inserir Produto";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool alterarProduto(Produto produto)
        {
            using(FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "UPDATE PRODUTO SET DESCRICAO = @DESCRICAO WHERE ID = "+produto.idProduto;
                        cmd.Parameters.AddWithValue("@DESCRICAO", produto.descricao);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao alterar Produto";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao alterar Produto";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }   
            }
        }

        public static List<Produto> retornaProdutos(int crg)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM PRODUTO";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<Produto> listaProdutos = new List<Produto>();
                        while (dr.Read())
                        {
                            Produto produto = new Produto();
                            produto.idProduto = (int)dr["ID"];
                            produto.descricao = dr["DESCRICAO"].ToString();
                            listaProdutos.Add(produto);
                        }
                        return listaProdutos;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao listar todos Produtos";
                        logErro.crg = crg;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, crg);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao listar todos Produtos";
                        logErro.crg = crg;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, crg);
                        return null;
                    }
                }   
            }
        }

        public static List<Produto> retornaProdutos()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM PRODUTO";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<Produto> listaProdutos = new List<Produto>();
                        while (dr.Read())
                        {
                            Produto produto = new Produto();
                            produto.idProduto = (int)dr["ID"];
                            produto.descricao = dr["DESCRICAO"].ToString();
                            listaProdutos.Add(produto);
                        }
                        return listaProdutos;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao listar todos Produtos";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao listar todos Produtos";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static string retornaProduto(int idProduto, int crg)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM PRODUTO WHERE ID = " + idProduto;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Produto produto = new Produto();
                            produto.idProduto = (int) dr["ID"];
                            produto.descricao = dr["DESCRICAO"].ToString();
                            return produto.descricao;
                        }
                        return null;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao buscar Produto";
                        logErro.crg = crg;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, crg);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao buscar Produto";
                        logErro.crg = crg;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, crg);
                        return null;
                    }
                }
            }
        }

        public static bool deletaProduto(int id)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "DELETE FROM PRODUTO WHERE ID = " + id;
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao deletar Produto";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao deletar Produto";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool testaDescricao(string descricao)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM PRODUTO WHERE DESCRICAO = '" + descricao + "'";
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return false;
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao testar descrição do Produto";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao testar descrição do Produto";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static int retornarIDProduto(string descricao)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT ID FROM PRODUTO WHERE DESCRICAO = '" + descricao + "'";
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return (int) dr["ID"];
                        else return -1;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao buscar id do produto";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao buscar id do produto";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                }
            }
        }

        public static bool testaUsoProd(int id)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM PRODUTO_CICLO WHERE PRODUTO = " + id;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return true;
                        return false;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao testar uso do produto";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao testar uso do produto";
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
