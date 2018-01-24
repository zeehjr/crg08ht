using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRG08.BO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.DataMigration
{
    public static class Utils
    {
        public static int LengthColuna(string nomeTabela, string nomeColuna)
        {
            var retorno = Dao.Utils.ExecutaQueryDados("select F.RDB$FIELD_LENGTH as TAMANHOCAMPO " +
                                                      "from rdb$relation_fields RF " +
                                                      "join rdb$fields F ON (F.RDB$FIELD_NAME = RF.RDB$FIELD_SOURCE) " +
                                                      "where UPPER(RF.rdb$relation_name) = UPPER('" + nomeTabela +
                                                      "') AND UPPER(RF.rdb$field_name) = UPPER('" + nomeColuna + "')");
            if (!retorno.Any()) return -1;

            try
            {
                return Convert.ToInt32(retorno.First()["TAMANHOCAMPO"]);
            }
            catch (Exception e)
            {
                ErrorHandler.ThrowNew(0, e.ToString());
                return -1;
            }
        }

        public static bool ColunaExistente(string nomeTabela, string nomeColuna)
        {
            return Dao.Utils.ExecutaQueryDados(
                "SELECT RDB$RELATION_FIELDS.RDB$FIELD_NAME FROM RDB$RELATION_FIELDS WHERE RDB$RELATION_FIELDS.RDB$RELATION_NAME = UPPER('" +
                nomeTabela + "') AND RDB$RELATION_FIELDS.RDB$FIELD_NAME = UPPER('" + nomeColuna + "')").Count == 1;
        }

        public static bool TabelaExistente(string nomeTabela)
        {
            return Dao.Utils.ExecutaQueryDados("SELECT rdb$relation_name from rdb$relations where rdb$relation_name = '" +
                                nomeTabela.ToUpper() + "'").Count == 1;
        }

        public static void CriarAutoIncrement(string nomeTabela)
        {
            Dao.Utils.ExecutaQuery("CREATE GENERATOR GEN_" + nomeTabela.ToUpper());
            Dao.Utils.ExecutaQuery(
                "" +
                "CREATE TRIGGER " + nomeTabela.ToUpper() + "_PK FOR " + nomeTabela.ToUpper() + " ACTIVE " +
                "BEFORE INSERT POSITION 0 " +
                "AS " +
                "    DECLARE VARIABLE tmp DECIMAL(18, 0); " +
                "BEGIN " +
                "IF(NEW.ID IS NULL) THEN " +
                "NEW.ID = GEN_ID(GEN_" + nomeTabela.ToUpper() + ", 1); " +
                "ELSE " +
                "BEGIN " +
                "    tmp = GEN_ID(GEN_" + nomeTabela.ToUpper() + ", 0); " +
                "if (tmp < new.ID) then " +
                "    tmp = GEN_ID(GEN_" + nomeTabela.ToUpper() + ", new.ID - tmp); " +
                "END " +
                "END; " +
                ""
            );
        }
    }
}
