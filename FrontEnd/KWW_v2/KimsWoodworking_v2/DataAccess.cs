using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Dapper;
using System.Data;

namespace KimsWoodworking_v2
{
    public static class DataAccess
    {
        //returns a connection string from the web.config that matches the name passed in(defaulted to KWWDB)
        private static string GetConnectionString(string id = "KWWDB") {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


        //returns a list of the model you send it
        public static List<T> LoadDataList<T>(string sql, DynamicParameters p) {

            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GetConnectionString("KWWDB"))) { 
                conn.Open();
                try
                {
                    return conn.Query<T>(sql, p).ToList();
                }
                catch
                {
                    throw;
                }
                finally { 
                    conn.Close();
                }
            }
        }
        //Takes a model in with the datayou want stored. Returns the number of rows affected.
        public static int SaveData<T>(string sql, T data) {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(GetConnectionString("KWWDB"))) { 
                conn.Open();
                try
                {
                    return conn.Execute(sql, data);
                }
                catch
                {
                    throw;
                }
                finally {
                    conn.Close();
                }
            }
        }
    }
}