using System;
using CRG08.VO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Dao
{
    public class BackupDAO
    {
        public static bool InserirBackup(Backup backup)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "INSERT INTO BACKUP(ID,PERIODO,PASTADESTINO) VALUES(@ID,@PERIODO,@PASTADESTINO)";
                        cmd.Parameters.AddWithValue("@ID", 1);
                        cmd.Parameters.AddWithValue("@PERIODO", backup.Periodo);
                        cmd.Parameters.AddWithValue("@PASTADESTINO", backup.CaminhoBackup);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no inserir Backup";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no inserir Backup";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static Backup RetornaBackup()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM BACKUP";
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Backup backup = new Backup();
                            backup.ID = (int)dr["ID"];
                            backup.Periodo = (int)dr["PERIODO"];
                            backup.CaminhoBackup = dr["PASTADESTINO"].ToString();
                            backup.DataUltimoBackup = dr["DATAULTIMOBACKUP"].ToString();
                            return backup;
                        }
                        dr.Close();
                        return null;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no retornar Backup";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no retornar Backup";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static bool AlteraBackup(Backup backup)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText =
                            "UPDATE BACKUP SET PERIODO = @PERIODO, PASTADESTINO=@PASTADESTINO" +
                            " WHERE ID = 1";
                        cmd.Parameters.AddWithValue("@PERIODO", backup.Periodo);
                        cmd.Parameters.AddWithValue("@PASTADESTINO", backup.CaminhoBackup);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no alterar Backup";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no alterar Backup";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool AlterarDataUltimoBackup(string data)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "UPDATE BACKUP SET DATAULTIMOBACKUP=@DATAULTIMOBACKUP WHERE ID = 1";
                        cmd.Parameters.AddWithValue("@DATAULTIMOBACKUP", data);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no alterar Data ultimo Backup";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no alterar Data ultimo Backup";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static void DeletaBackup()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "DELETE FROM BACKUP";
                        cmd.ExecuteNonQuery();
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no deletar Backup";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro no deletar Backup";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                    }
                }
            }
        }
    }
}
