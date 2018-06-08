using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CRG08.BO;
using FirebirdSql.Data.FirebirdClient;
using CRG08.DataMigration;

namespace CRG08.DataMigration
{
    public static class Migration
    {
        public static void Ultimos() // Utilizado até a versão 1.1.9.1
        {
            if (Utils.TabelaExistente("ULTIMOS")) return;

            Dao.Utils.ExecutaQuery(
                "CREATE TABLE ULTIMOS (id Integer not null primary key, crg integer, responsavel varchar(50), operador varchar(50), valorfiltro integer, datainicio Timestamp, datafim Timestamp, equipamento integer, qtdmeses integer, logo varchar(100), corest1 varchar(11), corest2 varchar(11), corest3 varchar(11), corest4 varchar(11), coresca varchar(11), legendat1 varchar(50), legendat2 varchar(50), legendat3 varchar(50), legendat4 varchar(50), legendaca varchar(50), primeira_inicializacao smallint, comunicacao_tipo smallint, comunicacao_apenasaparelho smallint);");

            if (ErrorHandler.GetLastError != null) return;

            Utils.CriarAutoIncrement("ULTIMOS");

            if (ErrorHandler.GetLastError != null) return;

            Dao.Utils.ExecutaQuery("INSERT INTO ULTIMOS(crg, responsavel, operador, valorfiltro, datainicio, datafim, equipamento, qtdmeses, logo, corest1, corest2, corest3, corest4, coresca, legendat1, legendat2, legendat3, legendat4, legendaca, primeira_inicializacao, comunicacao_tipo, comunicacao_apenasaparelho) values (1, '', '', 0, null, null, 1, 0, '', '255,0,0', '0,255,0', '0,0,255', '128,0,128', '255,0,128', 'T1', 'T2', 'T3', 'T4', 'CA', 1, 1, 1)");
        }

        public static void VolumeFixo() // Atualização para aceitar secagens com VolumeFixo
        {
            if (Utils.ColunaExistente("PRODUTO_CICLO", "DESCRICAO") && Utils.ColunaExistente("CICLO", "VOLUMEFIXO_TOTAL") && Utils.ColunaExistente("CICLO", "VOLUMEFIXO_MAIOR") && Utils.ColunaExistente("CICLO", "VOLUMEFIXO_TIPO")) return;

            Dao.Utils.ExecutaQuery("ALTER TABLE PRODUTO_CICLO ADD DESCRICAO VARCHAR(50);");
            Dao.Utils.ExecutaQuery("UPDATE PRODUTO_CICLO SET DESCRICAO = ''");

            Dao.Utils.ExecutaQuery("ALTER TABLE CICLO ADD VOLUMEFIXO_TIPO VARCHAR(1);");
            Dao.Utils.ExecutaQuery("ALTER TABLE CICLO ADD VOLUMEFIXO_MAIOR VARCHAR(1);");
            Dao.Utils.ExecutaQuery("ALTER TABLE CICLO ADD VOLUMEFIXO_TOTAL VARCHAR(6);");
            Dao.Utils.ExecutaQuery("UPDATE CICLO SET VOLUMEFIXO_TIPO = '0', VOLUMEFIXO_MAIOR = '0', VOLUMEFIXO_TOTAL = ''");
        }

        public static void NovaTelaComunicacao()
        {
            if (Utils.ColunaExistente("ULTIMOS", "COMUNICACAO_TIPO")) return;
            Dao.Utils.ExecutaQuery("ALTER TABLE ULTIMOS ADD COMUNICACAO_TIPO SMALLINT");
            Dao.Utils.ExecutaQuery("ALTER TABLE ULTIMOS ADD COMUNICACAO_APENASAPARELHO SMALLINT");
            Dao.Utils.ExecutaQuery("UPDATE ULTIMOS SET COMUNICACAO_TIPO = 0, COMUNICACAO_APENASAPARELHO = 0");
        }

        public static void ModificacoesDadosEmpresa()
        {
            if (Utils.LengthColuna("EMPRESA", "CNPJ") == 20) return;
            Dao.Utils.ExecutaQuery("ALTER TABLE EMPRESA ALTER COLUMN CNPJ TYPE VARCHAR(20)");
        }

        public static void AumentoDoTamanhoDaDescricao()
        {
            if (Utils.LengthColuna("CICLO", "DESCRICAO") == 100) return;
            Dao.Utils.ExecutaQuery("ALTER TABLE CICLO ALTER COLUMN DESCRICAO TYPE VARCHAR(100)");
        }

        /// <summary>
        /// Esta função executará todas as funções de migração de banco,
        /// em ordem do mais antigo ao mais recente, fazendo com que sempre haja
        /// integridade no banco.
        /// </summary>
        public static void Exec()
        {
            ErrorHandler.ClearErrors();
            
            Ultimos(); // Utilizado até a versão 1.1.9.1
            if (ErrorHandler.GetAllErrors.Count > 0) goto Erro;
            VolumeFixo(); // Utilizado até a versão 1.2
            if (ErrorHandler.GetAllErrors.Count > 0) goto Erro;
            ModificacoesDadosEmpresa();
            if (ErrorHandler.GetAllErrors.Count > 0) goto Erro;
            NovaTelaComunicacao();
            if (ErrorHandler.GetAllErrors.Count > 0) goto Erro;
            AumentoDoTamanhoDaDescricao();

            Erro:
            if (ErrorHandler.GetAllErrors.Count > 0)
            {
                var str = "Algum erro ocorreu:";
                foreach (var item in ErrorHandler.GetAllErrors)
                {
                    str += Environment.NewLine + "(" + ")" + item.Identifier + " " + item.ErrorMessage;
                }
                MessageBox.Show(str);
                ErrorHandler.ClearErrors();
            }
        }
    }
}
