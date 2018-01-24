using System;
using System.Configuration;
using System.IO;
using CRG08.VO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Dao
{
    public class ConfiguracaoDAO
    {
        public static bool insereConfiguracao(Configuracao config)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "INSERT INTO CONFIGURACOES(ID,PORTA,ATUALIZACAO,INTERVALO) VALUES(@ID,@PORTA,@ATUALIZACAO,@INTERVALO)";
                        cmd.Parameters.AddWithValue("@ID", 1);
                        cmd.Parameters.AddWithValue("@PORTA", config.porta);
                        cmd.Parameters.AddWithValue("@ATUALIZACAO", config.atualizacao);
                        cmd.Parameters.AddWithValue("@INTERVALO", config.intervalo);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao inserir as Configurações";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao inserir as Configurações";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool alterarConfiguracao(Configuracao config)
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "UPDATE CONFIGURACOES SET PORTA = @PORTA, ATUALIZACAO = @ATUALIZACAO, INTERVALO = @INTERVALO WHERE ID = 1";
                        cmd.Parameters.AddWithValue("@PORTA", config.porta);
                        cmd.Parameters.AddWithValue("@ATUALIZACAO", config.atualizacao);
                        cmd.Parameters.AddWithValue("@INTERVALO", config.intervalo);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao alterar as Configurações";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao alterar as Configurações";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static bool deletaConfiguracao()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "DELETE FROM ATUALIZACOES WHERE ID = 1";
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao deletar as Configurações";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao deletar as Configurações";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return false;
                    }
                }
            }
        }

        public static Configuracao retornaConfiguracao()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT * FROM CONFIGURACOES";
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Configuracao config = new Configuracao();
                            config.id = (int) dr["ID"];
                            config.porta = dr["PORTA"].ToString();
                            config.atualizacao = (int) dr["ATUALIZACAO"];
                            config.intervalo = (int) dr["INTERVALO"];
                            return config;
                        }
                        return null;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao retornar as Configurações";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao retornar as Configurações";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static string retornaPorta()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT PORTA FROM CONFIGURACOES WHERE ID=1";
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read()) return dr["PORTA"].ToString();
                        return "";
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao retornar a porta";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return "";
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao retornar a porta";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return "";
                    }
                }
            }
        }

        public static int[] RetornaAtualizacao()
        {
            using (FbConnection fbConn = new FbConnection(Util.DAO.Conn))
            {
                using (FbCommand cmd = new FbCommand())
                {
                    try
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = "SELECT ATUALIZACAO, INTERVALO FROM CONFIGURACOES WHERE ID = 1";
                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            int[] retorno = new int[2];
                            retorno[0] = (int)dr["ATUALIZACAO"];
                            retorno[1] = (int)dr["INTERVALO"];
                            return retorno;
                        }
                        return null;
                    }
                    catch (FbException fbError)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao retornar os dados da atualização";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = fbError.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                    catch (Exception error)
                    {
                        LogErro logErro = new LogErro();
                        logErro.crg = 0;
                        logErro.descricao = "Erro ao retornar os dados da atualização";
                        logErro.data = DateTime.Now;
                        logErro.maisDetalhes = error.Message;
                        LogErroDAO.inserirLogErro(logErro, 0);
                        return null;
                    }
                }
            }
        }

        public static ConfiguracaoRelatorio PegarConfigRelatorio()
        {
            var padrao = PadraoConfigRelatorio();
            if (!File.Exists("relatorio.crg08cfg"))
            {
                GravarConfigRelatorio(10, 20, 10);
                return padrao;
            }
            using (var sr = new StreamReader("relatorio.crg08cfg"))
            {
                var config = sr.ReadToEnd();
                if (config == String.Empty)
                {
                    GravarConfigRelatorio(10, 20, 10);
                    return padrao;
                }
                var arrConf = config.Split(';');
                var linhasAntes = Convert.ToInt32(arrConf[0].Split(':')[1]);
                var linhasTrat = Convert.ToInt32(arrConf[1].Split(':')[1]);
                var linhasDepois = Convert.ToInt32(arrConf[2].Split(':')[1]);
                return new ConfiguracaoRelatorio(linhasAntes, linhasTrat, linhasDepois);
            }
        }

        public static bool GravarConfigRelatorio(int lAntes, int lTrat, int lDepois)
        {
            using (var sw = new StreamWriter("relatorio.crg08cfg"))
            {
                sw.WriteLine("LAntes:" + lAntes + ";LTrat:" + lTrat + ";lDepois:" + lDepois);
            }
            return true;
        }

        public static ConfiguracaoRelatorio PadraoConfigRelatorio()
        {
            return new ConfiguracaoRelatorio(10, 20, 10);
        }
    }
}
