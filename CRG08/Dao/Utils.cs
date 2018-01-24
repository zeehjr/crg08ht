using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRG08.BO;
using FirebirdSql.Data.FirebirdClient;

namespace CRG08.Dao
{
    public static class Utils
    {
        public static List<Dictionary<string, object>> ExecutaQueryDados(string query)
        {
            try
            {
                using (var fbConn = new FbConnection(Util.DAO.Conn))
                {
                    using (var cmd = new FbCommand())
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = query;

                        var retorno = new List<Dictionary<string, object>>();

                        var dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            var tmpObj = new Dictionary<string, object>();
                            for (var i = 0; i < dr.FieldCount; i++)
                            {
                                tmpObj.Add(dr.GetName(i), dr.GetValue(i));
                            }
                            retorno.Add(tmpObj);
                        }

                        return retorno;
                    }
                }
            }
            catch (Exception e)
            {
                ErrorHandler.ThrowNew(-1, e.ToString());
                return null;
            }
        }

        public static void ExecutaQuery(string query)
        {
            try
            {
                using (var fbConn = new FbConnection(Util.DAO.Conn))
                {
                    using (var cmd = new FbCommand())
                    {
                        fbConn.Open();
                        cmd.Connection = fbConn;
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                ErrorHandler.ThrowNew(-1, e.ToString());
            }
        }
    }
}
