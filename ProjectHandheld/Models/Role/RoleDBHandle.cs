using Oracle;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace LISMVC.Models.Role
{
    public static class RoleDBHandle
    {
        internal static List<RoleModel> GetUserRoles()
        {
            List<RoleModel> userRoles = new List<RoleModel>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "SELECT ROLE_FK_USER_NAME, ROLE_FK_GROUP_NAME " +
                    "FROM DC_ROLE_LIS_T ORDER BY ROLE_FK_USER_NAME ASC";
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string groupName = reader["ROLE_FK_GROUP_NAME"].ToString();
                    userRoles.Add(new RoleModel {
                        ROLE_FK_USER_NAME = reader["ROLE_FK_USER_NAME"].ToString(),
                        ROLE_FK_GROUP_NAME = groupName
                    });
                }
                reader.Dispose();
                cmd.Dispose();
                PostgresDBConnection.Close();
                return userRoles;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static List<AllUser> GetAllUsers()
        {
            List<AllUser> users = new List<AllUser>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "SELECT USER_NAME FROM DC_USER_T ORDER BY USER_NAME ASC";
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new AllUser
                    {
                        USER_NAME = reader["USER_NAME"].ToString()
                    });
                }
                reader.Dispose();
                cmd.Dispose();
                PostgresDBConnection.Close();
                return users;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static List<Roles> GetRoles()
        {
            List<Roles> roles = new List<Roles>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "SELECT MENU_NAME FROM DC_MENU_LIS_T " +
                    "WHERE MENU_PARENT IS NULL AND CONTROLLER_NAME IS NULL AND ACTION_NAME IS NULL " +
                    "ORDER BY MENU_NAME ASC";
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string roleName = reader["MENU_NAME"].ToString();
                    roles.Add(new Roles
                    {
                        ROLE_NAME = roleName
                    });
                }
                reader.Dispose();
                cmd.Dispose();
                PostgresDBConnection.Close();
                return roles;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static List<UserRoles> GetRoles(string username)
        {
            List<UserRoles> userroles = new List<UserRoles>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "SELECT ROLE_FK_GROUP_NAME FROM DC_ROLE_LIS_T " +
                    "WHERE ROLE_FK_USER_NAME = '"+ username +"'";
                Debug.WriteLine("Get ROles: " + username);
                cmd.Parameters.Add(new OracleParameter("username", username));
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                Debug.WriteLine("Reader roles: " + reader.HasRows);
                while (reader.Read())
                {
                    string roleName = reader["ROLE_FK_GROUP_NAME"].ToString();
                    userroles.Add(new UserRoles
                    {
                        ROLE_NAME = roleName
                    });
                }
                Debug.WriteLine("Roles count in handleer: " + userroles.Count);
                reader.Dispose();
                cmd.Dispose();
                PostgresDBConnection.Close();
                return userroles;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static Boolean IsAlreadyInRole(string user, string role)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM DC_ROLE_LIS_T " +
                "WHERE ROLE_FK_USER_NAME = :username AND ROLE_FK_GROUP_NAME = :rolename";
            cmd.Parameters.Add(new OracleParameter("username", user));
            cmd.Parameters.Add(new OracleParameter("rolename", role));
            object cekRole = FuncEQ.ExecScalarPostgres(cmd);
            if (Convert.ToInt32(cekRole) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static int AddRole(string user, string role, string updrecid)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "INSERT INTO DC_ROLE_LIS_T" +
                    "(ROLE_FK_USER_NAME, ROLE_FK_GROUP_NAME, ROLE_UPDREC_DATE, ROLE_UPDREC_ID) " +
                    "VALUES(UPPER(:username), UPPER(:rolename), NOW(), UPPER(:updrecid))";
                cmd.Parameters.Add(new OracleParameter("username", user));
                cmd.Parameters.Add(new OracleParameter("rolename", role));
                cmd.Parameters.Add(new OracleParameter("updrecid", updrecid));

                return FuncEQ.ExecQueryPostgres(cmd);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static int DeleteUserRole(string user, string role)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "DELETE FROM DC_ROLE_LIS_T " +
                    "WHERE ROLE_FK_USER_NAME = :username AND ROLE_FK_GROUP_NAME = :rolename";
                cmd.Parameters.Add(new OracleParameter("username", user));
                cmd.Parameters.Add(new OracleParameter("rolename", role));

                return FuncEQ.ExecQueryPostgres(cmd);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}