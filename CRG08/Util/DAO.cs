using System;
using System.IO;
using System.Windows.Forms;
using CRG08.Dao;
using CRG08.VO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Util
{
    public class DAO
    {
        public static string Conn
        {
            get
            {
                try
                {
                    //Arquivo não existe no caminho especificado, ou o Arquivo não está com o nome de 'db.fdb'.
                    if (File.Exists(Environment.CurrentDirectory + "\\DB.fdb"))
                    {
#if DEBUG
                        //REMOTO , para desenvolvimento, permite mais de uma conexão. Para utilizar com Flame Robin.
                        return "ServerType=0;Database=" + Environment.CurrentDirectory + "\\DB.fdb; User=SYSDBA;Password=masterkey;Dialect=3";
#endif

                        //EMBARCADO | para o Instalador.
                        return "ServerType=1;Database=" + Environment.CurrentDirectory + "\\DB.fdb; User=SYSDBA;Password=masterkey;Dialect=3";
                    }
                    return null;
                }
                catch (FbException fbError)
                {
                    LogErro logErro = new LogErro();
                    logErro.crg = 0;
                    logErro.descricao = "Erro ao tentar acessar o banco de dados";
                    logErro.data = DateTime.Now;
                    logErro.maisDetalhes = fbError.Message;
                    LogErroDAO.inserirLogErro(logErro, 0);
                    return null;
                }
                catch (Exception error)
                {
                    LogErro logErro = new LogErro();
                    logErro.crg = 0;
                    logErro.descricao = "Erro ao tentar acessar o banco de dados";
                    logErro.data = DateTime.Now;
                    logErro.maisDetalhes = error.Message;
                    LogErroDAO.inserirLogErro(logErro, 0);
                    return null;
                }
            }
        }
    }
}
