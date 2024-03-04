using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace LISMVC.Models
{
    internal static class FuncEQ
    {
        internal static DataTable PostgresGetDT(OracleCommand comm)
        {
            DataTable dt = new DataTable();
            OracleDataAdapter postgresAdapt = new OracleDataAdapter();
            try
            {
                using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
                {
                    comm.Connection = connection;
                    postgresAdapt.SelectCommand = comm;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    postgresAdapt.Fill(dt);
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            finally
            {
                comm.Dispose();
            }
            return dt;
        }

        internal static DataTable SqlServerGetDT(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {
                using (SqlConnection connection = new SqlConnection(SetConStr.constrSql))
                {
                    cmd.Connection = connection;
                    adapter.SelectCommand = cmd;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    adapter.Fill(dt);
                    connection.Dispose();
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            finally
            {
                cmd.Dispose();
            }
            return dt;
        }

        internal static int ExecQueryPostgres(OracleCommand comm)
        {
            int hasil;
            try
            {
                using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
                {
                    comm.Connection = connection;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    hasil = comm.ExecuteNonQuery();

                    connection.Dispose();
                    comm.Dispose();
                }
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                Debug.WriteLine(err);
                comm.Dispose();
                hasil = 0;
            }
            finally
            {
                comm.Dispose();
            }
            return hasil;
        }

        internal static int ExecQuerySqlServer(SqlCommand cmd)
        {
            int hasil;
            try
            {
                using (SqlConnection connection = new SqlConnection(SetConStr.constrSql))
                {
                    cmd.Connection = connection;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    hasil = cmd.ExecuteNonQuery();

                    connection.Dispose();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                cmd.Dispose();
                hasil = 0;
            }
            finally
            {
                cmd.Dispose();
            }
            return hasil;
        }

        internal static object ExecScalarPostgres(OracleCommand comm)
        {
            object obj = new object();
            try
            {
                using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
                {
                    comm.Connection = connection;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    obj = comm.ExecuteScalar();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                comm.Dispose();
                obj = ex.ToString();
            }
            finally
            {
                comm.Dispose();
            }
            return obj;
        }

        internal static object ExecScalarSqlServer(SqlCommand comm)
        {
            object obj = new object();
            try
            {
                using (SqlConnection connection = new SqlConnection(SetConStr.constrSql))
                {
                    comm.Connection = connection;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    obj = comm.ExecuteScalar();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                comm.Dispose();
                obj = ex.ToString();
            }
            finally
            {
                comm.Dispose();
            }
            return obj;
        }

        internal static DataView SortDataTable(DataTable dataTable, string ColumnName, bool OrderByAsc)
        {
            DataView dtView = new DataView(dataTable);
            if (OrderByAsc)
                dtView.Sort = $"{ColumnName} ASC";
            else
                dtView.Sort = $"{ColumnName} DESC";
            return dtView;
        }
    }
}