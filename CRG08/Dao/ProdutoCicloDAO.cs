using System;
using System.Collections.Generic;
using CRG08.VO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Dao
{
    public class ProdutoCicloDAO
    {
        public static bool inserirProdutoCiclo(ProdutoCiclo produto)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "INSERT INTO PRODUTO_CICLO(PRODUTO,VOLUME,UNIDADE,EMPRESA,CICLO) " +
                            "VALUES(@PRODUTO,@VOLUME,@UNIDADE,@EMPRESA,@CICLO)";
                        cmd.Parameters.AddWithValue("@PRODUTO", produto.produto.idProduto);
                        cmd.Parameters.AddWithValue("@VOLUME", produto.volume);
                        cmd.Parameters.AddWithValue("@UNIDADE", produto.unidade.idUnidade);
                        cmd.Parameters.AddWithValue("@EMPRESA", produto.empresa.idEmpresa);
                        cmd.Parameters.AddWithValue("@CICLO", produto.ciclo.id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = produto.ciclo.crg;
                        logErro.descricao = "Erro no inserir Produto do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = produto.ciclo.crg;
                        logErro.descricao = "Erro no inserir Produto do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool alterarProdutoCiclo(ProdutoCiclo produto)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "UPDATE PRODUTO_CICLO SET PRODUTO = @PRODUTO, VOLUME = @VOLUME, UNIDADE = @UNIDADE, EMPRESA = @EMPRESA, CICLO = @CICLO" +
                                          " WHERE ID = "+produto.idProdutoCiclo;
                        cmd.Parameters.AddWithValue("@PRODUTO", produto.produto.idProduto);
                        cmd.Parameters.AddWithValue("@VOLUME", produto.volume);
                        cmd.Parameters.AddWithValue("@UNIDADE", produto.unidade.idUnidade);
                        cmd.Parameters.AddWithValue("@EMPRESA", produto.empresa.idEmpresa);
                        cmd.Parameters.AddWithValue("@CICLO", produto.ciclo.id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = produto.ciclo.crg;
                        logErro.descricao = "Erro no alterar Produto do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = produto.ciclo.crg;
                        logErro.descricao = "Erro no alterar Produto do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool DeletaProdutosCiclo(int id, int crg)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "DELETE FROM PRODUTO_CICLO WHERE CICLO = " + id ;
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro no deletar Produto do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = crg;
                        logErro.descricao = "Erro no deletar Produto do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static List<ProdutoCiclo> listaProdutosCiclo(Ciclos ciclo)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM PRODUTO_CICLO WHERE CICLO = " + ciclo.id + " ORDER BY EMPRESA";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<ProdutoCiclo> listaProdutos = new List<ProdutoCiclo>();
                        while (dr.Read())
                        {
                            ProdutoCiclo produto = new ProdutoCiclo();
                            produto.idProdutoCiclo = (int) dr["ID"];
                            produto.produto = new Produto();
                            produto.produto.idProduto = (int) dr["PRODUTO"];
                            produto.produto.descricao = ProdutoDAO.retornaProduto(produto.produto.idProduto, ciclo.crg);
                            produto.volume = dr["VOLUME"].ToString();
                            produto.unidade = new Unidade();
                            produto.unidade.idUnidade = (int) dr["UNIDADE"];
                            produto.unidade.unidade = UnidadeDAO.retornaUnidade(produto.unidade.idUnidade, ciclo.crg);
                            produto.empresa = new EmpresaCiclo();
                            produto.empresa.idEmpresa = (int) dr["EMPRESA"];
                            produto.empresa.nome = EmpresaCicloDAO.retornaEmpresa(produto.empresa.idEmpresa, ciclo.crg);
                            produto.ciclo = ciclo;
                            listaProdutos.Add(produto);
                        }
                        return listaProdutos;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro ao listar os Produtos do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro ao listar os Produtos do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }   
            }
        }

        public static List<string> retornaEmpresasdoCiclo(Ciclos ciclos)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT EMPRESA FROM PRODUTO_CICLO WHERE CICLO = " + ciclos.id;
                        FbDataReader dr = cmd.ExecuteReader();
                        List<string> empresas = new List<string>();
                        while (dr.Read())
                        {
                            int idEmpresa = (int)dr["EMPRESA"];
                            empresas.Add(EmpresaCicloDAO.retornaEmpresa(idEmpresa, ciclos.crg));
                        }
                        return empresas;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclos.crg;
                        logErro.descricao = "Erro ao listar os Produtos do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclos.crg;
                        logErro.descricao = "Erro ao listar os Produtos do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static List<ProdutoCiclo> listaProdutosCicloPorEmpresa(Ciclos ciclo, int empresa)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM PRODUTO_CICLO WHERE CICLO = " + ciclo.id + " ORDER BY EMPRESA";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<ProdutoCiclo> listaProdutos = new List<ProdutoCiclo>();
                        while (dr.Read())
                        {
                            if (int.Parse(dr["EMPRESA"].ToString()) == empresa)
                            {
                                ProdutoCiclo produto = new ProdutoCiclo();
                                produto.idProdutoCiclo = (int) dr["ID"];
                                produto.produto = new Produto();
                                produto.produto.idProduto = (int) dr["PRODUTO"];
                                produto.produto.descricao = ProdutoDAO.retornaProduto(produto.produto.idProduto,
                                    ciclo.crg);
                                produto.volume = dr["VOLUME"].ToString();
                                produto.unidade = new Unidade();
                                produto.unidade.idUnidade = (int) dr["UNIDADE"];
                                produto.unidade.unidade = UnidadeDAO.retornaUnidade(produto.unidade.idUnidade, ciclo.crg);
                                produto.empresa = new EmpresaCiclo();
                                produto.empresa.idEmpresa = (int) dr["EMPRESA"];
                                produto.empresa.nome = EmpresaCicloDAO.retornaEmpresa(produto.empresa.idEmpresa,
                                    ciclo.crg);
                                produto.ciclo = ciclo;
                                listaProdutos.Add(produto);
                            }
                        }
                        return listaProdutos;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro ao listar os Produtos do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = ciclo.crg;
                        logErro.descricao = "Erro ao listar os Produtos do Ciclo";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }
    }
}
