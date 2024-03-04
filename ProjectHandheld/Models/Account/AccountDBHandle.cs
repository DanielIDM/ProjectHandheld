using LISMVC.Models.Role;
using Oracle;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Diagnostics;

namespace LISMVC.Models
{
    public class AccountDBHandle
    {
        OracleCommand cmd;
        internal MasterUser CheckLogin(LoginViewModel logmodel)
        {
            MasterUser masteruser = new MasterUser();
            try
            {
                string cUser = logmodel.UserName.ToUpper();
                string cPass = logmodel.Password.ToUpper();

                //cek user dan password
                cmd = new OracleCommand("SELECT COUNT(*) AS JUM FROM DC_USER_T WHERE USER_PRIVS = 'Y' AND UPPER(USER_NAME)= :userName AND UPPER(USER_PASSWORD)= :password");
                cmd.Parameters.Add(new OracleParameter("userName", cUser));
                cmd.Parameters.Add(new OracleParameter("password", cPass));

                PostgresDBConnection.Open(cmd);
                object cekLogin = FuncEQ.ExecScalarPostgres(cmd);
                
                if (Convert.ToInt32(cekLogin) == 0)
                {
                    masteruser.keterangan = "Username atau Password salah!";
                    cmd.Dispose();
                    PostgresDBConnection.Close();
                    return masteruser;
                }
                //END CEK USER PASSWORD

                //AMBIL DATA USER
                OracleCommand command = new OracleCommand();
                command.CommandText = "SELECT U.USER_NAME, U.USER_NIK, U.USER_PRIVS, U.USER_FLAG_HO, U.LAST_PASS_CHANGE+(U.PASS_VALID_DAYS || 'days')::interval AS TGL_GANTI_PASSWORD, " +
                                    "U.USER_UPDREC_ID, DC.TBL_DCID, DC.TBL_DC_KODE, DC.TBL_DC_NAMA, DC.TBL_JENIS_DC, \n" +
                                    "U.USER_FK_TBL_DEPOID, G.TBL_GUDANG_KODE, G.TBL_GUDANG_NAMA, U.USER_FK_TBL_LOKASIID \n" +
                                    "FROM DC_USER_T U LEFT JOIN DC_TABEL_DC_T DC ON U.USER_FK_TBL_DCID = DC.TBL_DCID \n" +
                                    "AND U.USER_PRIVS = 'Y' \n" +
                                    "LEFT JOIN DC_TABEL_GUDANG_T G ON U.USER_FK_TBL_DEPOID=G.TBL_GUDANGID \n" +
                                    "WHERE 1 = 1 AND UPPER (USER_NAME)= '" + cUser + "' AND UPPER (USER_PASSWORD)= '" + cPass + "'";
                PostgresDBConnection.Open(command);
                OracleDataReader reader = command.ExecuteReader();
                Debug.WriteLine("Row user: " + reader.HasRows);
                //cek data user dan password
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        masteruser.USER_PRIVS = reader["USER_PRIVS"].ToString();
                        masteruser.USER_NAMA = reader["USER_NAME"].ToString();
                        masteruser.USER_NIK = reader["USER_NIK"].ToString();
                        masteruser.USER_FLAG_HO = reader["USER_FLAG_HO"].ToString();
                        masteruser.TGL_GANTI_PASS = (DateTime)reader["TGL_GANTI_PASSWORD"];
                        masteruser.USER_UPDREC_ID = reader["USER_UPDREC_ID"].ToString();
                        masteruser.ID_DC = reader["TBL_DCID"].ToString();
                        masteruser.DC_KODE = reader["TBL_DC_KODE"].ToString();
                        masteruser.DC_NAMA = reader["TBL_DC_NAMA"].ToString();
                        masteruser.cGUDANG_ID = reader["USER_FK_TBL_DEPOID"].ToString();
                        masteruser.cGUDANG_KODE = reader["TBL_GUDANG_KODE"].ToString();
                        masteruser.cGUDANG_NAMA = reader["TBL_GUDANG_NAMA"].ToString();
                        masteruser.cJENIS_GUDANG = reader["TBL_JENIS_DC"].ToString();
                        masteruser.nama_server = SetConStr.variabel.IPPostgres;
                        masteruser.user_server = SetConStr.variabel.UsrPostgres;
                        masteruser.pass_server = SetConStr.variabel.PassPostgres;

                        if (masteruser.ID_DC == "")
                        {
                            masteruser.keterangan = "User Tidak Punya ID DC.";
                            return masteruser;
                        };

                        if (masteruser.cGUDANG_KODE == "")
                        {
                            masteruser.keterangan = "Tidak Ada Data Gudang.";
                            return masteruser;
                        };

                        if (masteruser.cJENIS_GUDANG == "")
                        {
                            if (masteruser.cJENIS_GUDANG == "INDUK")
                            {
                                masteruser.cJENIS_GUDANG = "DCI";
                            }
                            else if (masteruser.cJENIS_GUDANG == "DEPO")
                            {
                                masteruser.cJENIS_GUDANG = "DEPO";
                            }
                        }
                        masteruser.key = SetConStr.lokasi_kunci;
                    }
                }
                masteruser.USER_ROLES = RoleDBHandle.GetRoles(cUser);
                //cleanup
                cmd.Dispose();
                PostgresDBConnection.Close();
                
                return masteruser;
            }
            catch (Exception ex)
            {
                masteruser.keterangan = ex.ToString();
                throw;
            }
        }

        internal string InsertUserLogin(MasterUser user, string IP)
        {
            string ret = "";
            cmd = new OracleCommand();
            cmd.CommandText = "INSERT INTO DC_USER_LOGIN_RPT_H VALUES(" + user.ID_DC + ",'" + user.DC_KODE + "','" + user.USER_NIK + "','" + user.USER_NAMA + "', now(), '" + IP + "')";
            //execquery
            int hasil = FuncEQ.ExecQueryPostgres(cmd);

            if (hasil > 0)
            {
                ret = "BERHASIL";
            }
            else
            {
                ret = "GAGAL";
            }
            return ret;
        }

        internal int UpdatePassword(string newPassword, string userName)
        {
            try
            {
                
                //OracleDataAdapter adapter = new OracleDataAdapter();
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "UPDATE DC_USER_T " +
                                    "SET USER_PASSWORD = '" + newPassword + "', " +
                                        "USER_UPDREC_DATE = now(), " +
                                        "LAST_PASS_CHANGE = now() " +
                                  "WHERE USER_NAME = '" + userName + "'";
                //cmd.Parameters.Add(new OracleParameter(":newPassword", newPassword));
                //cmd.Parameters.Add(new OracleParameter(":userName", userName));
                cmd.CommandType = CommandType.Text;
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