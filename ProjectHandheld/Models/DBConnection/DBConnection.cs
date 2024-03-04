using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace LISMVC.Models
{
    public static class PostgresDBConnection
    {
        static OracleConnection conn;
        internal static void Open(OracleCommand cmd){
            conn = new OracleConnection(SetConStr.constrPostgres);
            cmd.Connection = conn;
            conn.Open();
        }
        internal static void Close()
        {
            conn.Close();
        } 
    }

    public static class SQLDBConnection
    {
        static SqlConnection conn;
        internal static void Open(SqlCommand cmd)
        {
            try
            {
                conn = new SqlConnection(SetConStr.constrSql);
                cmd.Connection = conn;
                conn.Open();
            }
            catch(Exception e)
            {
                Debug.WriteLine("Koneksi gagal: " + e);
            }
        }
        internal static void Close()
        {
            conn.Close();
        }
    }
}