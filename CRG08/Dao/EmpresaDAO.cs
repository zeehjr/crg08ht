using System;
using System.Collections.Generic;
using CRG08.VO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Dao
{
    public class EmpresaDAO
    {
        public static bool insereEmpresa(Empresa empresa)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "INSERT INTO EMPRESA(ID,NOME,ENDERECO,CEP,CIDADE,UF,FONE,FAX,CNPJ,IE,NCREDENCIAMENTO,LOGO) " +
                                          "VALUES(@ID,@NOME,@ENDERECO,@CEP,@CIDADE,@UF,@FONE,@FAX,@CNPJ,@IE,@NCREDENCIAMENTO,@LOGO)";
                        cmd.Parameters.AddWithValue("@ID", 1);
                        cmd.Parameters.AddWithValue("@NOME", empresa.Nome);
                        cmd.Parameters.AddWithValue("@ENDERECO", empresa.Endereco);
                        cmd.Parameters.AddWithValue("@CEP", empresa.Cep);
                        cmd.Parameters.AddWithValue("@CIDADE", empresa.Cidade);
                        cmd.Parameters.AddWithValue("@UF", empresa.UF);
                        cmd.Parameters.AddWithValue("@FONE", empresa.Fone);
                        cmd.Parameters.AddWithValue("@FAX", empresa.Fax);
                        cmd.Parameters.AddWithValue("@CNPJ", empresa.CNPJ);
                        cmd.Parameters.AddWithValue("@IE", empresa.IE);
                        cmd.Parameters.AddWithValue("@NCREDENCIAMENTO", empresa.NCredenciamento);
                        cmd.Parameters.AddWithValue("@LOGO", empresa.Logo);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao inserir Empresa";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao inserir Empresa";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool alteraEmpresa(Empresa empresa)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "UPDATE EMPRESA SET NOME = @NOME,ENDERECO = @ENDERECO, CEP = @CEP, CIDADE = @CIDADE, UF = @UF, FONE = @FONE," +
                            "FAX = @FAX, CNPJ = @CNPJ, IE = @IE, NCREDENCIAMENTO = @NCREDENCIAMENTO WHERE ID =" +
                            empresa.id;
                        cmd.Parameters.AddWithValue("@NOME", empresa.Nome);
                        cmd.Parameters.AddWithValue("@ENDERECO", empresa.Endereco);
                        cmd.Parameters.AddWithValue("@CEP", empresa.Cep);
                        cmd.Parameters.AddWithValue("@CIDADE", empresa.Cidade);
                        cmd.Parameters.AddWithValue("@UF", empresa.UF);
                        cmd.Parameters.AddWithValue("@FONE", empresa.Fone);
                        cmd.Parameters.AddWithValue("@FAX", empresa.Fax);
                        cmd.Parameters.AddWithValue("@CNPJ", empresa.CNPJ);
                        cmd.Parameters.AddWithValue("@IE", empresa.IE);
                        cmd.Parameters.AddWithValue("@NCREDENCIAMENTO", empresa.NCredenciamento);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro no alterar Empresa";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro no alterar Empresa";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool alteraEmpresaComLogo(Empresa empresa)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "UPDATE EMPRESA SET NOME = @NOME,ENDERECO = @ENDERECO, CEP = @CEP, CIDADE = @CIDADE, UF = @UF, FONE = @FONE," +
                            "FAX = @FAX, CNPJ = @CNPJ, IE = @IE, NCREDENCIAMENTO = @NCREDENCIAMENTO, LOGO = @LOGO WHERE ID =" +
                            empresa.id;
                        cmd.Parameters.AddWithValue("@NOME", empresa.Nome);
                        cmd.Parameters.AddWithValue("@ENDERECO", empresa.Endereco);
                        cmd.Parameters.AddWithValue("@CEP", empresa.Cep);
                        cmd.Parameters.AddWithValue("@CIDADE", empresa.Cidade);
                        cmd.Parameters.AddWithValue("@UF", empresa.UF);
                        cmd.Parameters.AddWithValue("@FONE", empresa.Fone);
                        cmd.Parameters.AddWithValue("@FAX", empresa.Fax);
                        cmd.Parameters.AddWithValue("@CNPJ", empresa.CNPJ);
                        cmd.Parameters.AddWithValue("@IE", empresa.IE);
                        cmd.Parameters.AddWithValue("@NCREDENCIAMENTO", empresa.NCredenciamento);
                        cmd.Parameters.AddWithValue("@LOGO", empresa.Logo);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro no alterar Empresa";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro no alterar Empresa";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool deletaEmpresa()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "DELETE FROM EMPRESA WHERE ID = 1";
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao deletar Empresa";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao deletar Empresa";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static Empresa retornaEmpresa()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM EMPRESA WHERE ID = 1";
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Empresa empresa = new Empresa();
                            empresa.id = (int) dr["ID"];
                            empresa.Nome = dr["NOME"].ToString();
                            empresa.Endereco = dr["ENDERECO"].ToString();
                            empresa.Cep = dr["CEP"].ToString();
                            empresa.Cidade = dr["CIDADE"].ToString();
                            empresa.UF = (int) dr["UF"];
                            empresa.Fone = dr["FONE"].ToString();
                            empresa.Fax = dr["FAX"].ToString();
                            empresa.CNPJ = dr["CNPJ"].ToString();
                            empresa.IE = dr["IE"].ToString();
                            empresa.NCredenciamento = dr["NCREDENCIAMENTO"].ToString();
                            if(DBNull.Value != dr["LOGO"])empresa.Logo = (byte[])dr["LOGO"];
                            return empresa;
                        }
                        return null;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao retornar Empresa";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao retornar Empresa";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }
        public static Empresa buscaEmpresa()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM EMPRESA";
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Empresa e = new Empresa();
                            e.id = (int)dr["ID"];
                            e.Nome = dr["NOME"].ToString();
                            e.Endereco = dr["ENDERECO"].ToString();
                            e.Cep = dr["CEP"].ToString();
                            e.Cidade = dr["CIDADE"].ToString();
                            e.UF = (int)dr["UF"];
                            e.Fone = dr["FONE"].ToString();
                            e.Fax = dr["FAX"].ToString();
                            e.CNPJ = dr["CNPJ"].ToString();
                            e.IE = dr["IE"].ToString();
                            if (dr["LOGO"] != DBNull.Value) e.Logo = (byte[])(dr["LOGO"]);
                            else e.Logo = null;
                            return e;
                        }
                        dr.Close();
                        return null;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao tentar buscar empresa";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, logErro.crg);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao tentar buscar empresa";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, logErro.crg);
                        return null;
                    }
                }
            }
        }
    }
}
