using System;
using System.Collections.Generic;
using CRG08.VO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Dao
{
    public class EmpresaCicloDAO
    {
        public static bool InsereEmpresa(EmpresaCiclo empresa)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "INSERT INTO EMPRESA_CICLO(NOME) VALUES(@NOME)";
                        cmd.Parameters.AddWithValue("@NOME", empresa.nome);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao inserir Empresas para o Ciclo";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao inserir Empresas para o Ciclo";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool alterarEmpresa(EmpresaCiclo empresa)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "UPDATE EMPRESA_CICLO SET NOME = @NOME WHERE ID = " + empresa.idEmpresa;
                        cmd.Parameters.AddWithValue("@NOME", empresa.nome);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao alterar as Empresas para o Ciclo";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao alterar as Empresas para o Ciclo";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static List<EmpresaCiclo> retornaEmpresas()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM EMPRESA_CICLO";
                        FbDataReader dr = cmd.ExecuteReader();
                        List<EmpresaCiclo> listEmpresa = new List<EmpresaCiclo>();
                        while (dr.Read())
                        {
                            EmpresaCiclo empresa = new EmpresaCiclo();
                            empresa.idEmpresa = (int)dr["ID"];
                            empresa.nome = dr["NOME"].ToString();
                            listEmpresa.Add(empresa);
                        }
                        return listEmpresa;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao listar todas Empresas para Ciclo";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao listar todas Empresas para Ciclo";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }
        
        public static string retornaEmpresa(int idEmpresa, int crg)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM EMPRESA_CICLO WHERE ID = " + idEmpresa;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            EmpresaCiclo empresa = new EmpresaCiclo();
                            empresa.idEmpresa = (int)dr["ID"];
                            empresa.nome = dr["NOME"].ToString();
                            return empresa.nome;
                        }
                        return null;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao buscar Empresa dos Ciclos";
                        logErro.crg = crg;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, crg);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao buscar Empresa dos Ciclos";
                        logErro.crg = crg;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, crg);
                        return null;
                    }
                }
            }
        }

        public static bool deletaEmpresa(int id)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "DELETE FROM EMPRESA_CICLO WHERE ID = " + id;
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao deletar Empresa do Ciclo";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao deletar Empresa do Ciclo";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool testaNome(string nome)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM EMPRESA_CICLO WHERE NOME = '" + nome + "'";
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return false;
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao testar nome da Empresa para Ciclos";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao testar nome da Empresa para Ciclos";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static int retornaID(string nome)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT ID FROM EMPRESA_CICLO WHERE NOME = '" + nome + "'";
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return (int) dr["ID"];
                        return -1;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao retornar id da Empresa para Ciclos";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao retornar id da Empresa para Ciclos";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return -1;
                    }
                }
            }
        }

        public static bool testaUsoEmpresa(int id)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM PRODUTO_CICLO WHERE EMPRESA = " + id;
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return true;
                        return false;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao testar uso da empresa";
                        logErro.crg = 0;
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.descricao = "Erro ao testar uso da empresa";
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
