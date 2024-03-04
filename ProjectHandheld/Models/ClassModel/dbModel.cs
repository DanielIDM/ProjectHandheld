using System;
using System.Configuration;
using LibReport;
using System.Data;
using System.Diagnostics;
using Npgsql;
using Oracle.ManagedDataAccess.Client;

namespace LISMVC.Models
{
    internal class variable
    {
        public string IPPostgres { get; set; }
        public string DbPostgres { get; set; }
        public string UsrPostgres { get; set; }
        public string PassPostgres { get; set; }
        public string PortPostgres { get; set; }
        
        /*public string cUsrOra { get; set; }
        public string cPassOra { get; set; }        
        public string cTnsOra { get; set; }*/

        public string IPSQL { get; set; }
        public string DbSQL { get; set; }
        public string UsrSQL { get; set; }
        public string PassSQL { get; set; }
    }

    internal static class GetDCInfo
    {
        internal static string KodeDC;
        internal static string NamaDC;

        internal static void initInfoDC()
        {
            //Get KODE DC dan Nama DC
            string query = "SELECT tbl_dc_kode, tbl_dc_nama from dc_tabel_dc_t";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = query;
            DataTable dt = FuncEQ.PostgresGetDT(cmd);
            if (dt.Rows.Count > 0)
            {
                KodeDC = dt.Rows[0]["tbl_dc_kode"].ToString();
                NamaDC = dt.Rows[0]["tbl_dc_nama"].ToString();
            }
        }
    }

    internal static class SetConStr
    {
        internal static variable variabel = new variable();
        internal static String constrPostgres;
        internal static String constrSql;
        internal static AppSetting appsetting = new AppSetting();
        internal static string lokasi_kunci = "";
        internal static void initConStr()
        {
            
            //ambil ip user
            SettingLibWS.Class1 ls = new SettingLibWS.Class1();
            lokasi_kunci = ConfigurationManager.AppSettings.Get("kunci");

            //SQL Connection
            variabel.IPSQL = ls.GetVariabel("IPSql", lokasi_kunci);
            variabel.DbSQL = ls.GetVariabel("DatabaseSql", lokasi_kunci);
            variabel.UsrSQL = ls.GetVariabel("UserSql", lokasi_kunci);
            variabel.PassSQL = ls.GetVariabel("PasswordSql", lokasi_kunci);
            Debug.WriteLine("IP: " + variabel.IPSQL);
            Debug.WriteLine("DB: " + variabel.DbSQL);
            Debug.WriteLine("User: " + variabel.UsrSQL);
            Debug.WriteLine("Pass: " + variabel.PassSQL);
            constrSql = "Data Source=" + variabel.IPSQL + ";Initial Catalog=" + variabel.DbSQL + ";User ID=" + variabel.UsrSQL + ";Password=" + variabel.PassSQL + ";";

            //PostgreSQL Connection
            variabel.IPPostgres = ls.GetVariabel("IPPostgres", lokasi_kunci);
            variabel.DbPostgres = ls.GetVariabel("DatabasePostgres", lokasi_kunci);
            variabel.UsrPostgres = ls.GetVariabel("UserPostgres", lokasi_kunci);
            variabel.PassPostgres = ls.GetVariabel("PasswordPostgres", lokasi_kunci);
            variabel.PortPostgres = ls.GetVariabel("PortPostgres", lokasi_kunci);
            
            Debug.WriteLine("IPPostgres: " + variabel.IPPostgres);
            Debug.WriteLine("DatabasePostgres: " + variabel.DbPostgres);
            Debug.WriteLine("UserPostgres: " + variabel.UsrPostgres);
            Debug.WriteLine("PasswordPostgres: " + variabel.PassPostgres);

            constrPostgres = "Server=" + variabel.IPPostgres + ";Database=" + variabel.DbPostgres + ";User Id=" + variabel.UsrPostgres + ";Password=" + variabel.PassPostgres + ";Port=" + variabel.PortPostgres + ";Maximum Pool Size=300;Pooling=true;Timeout=60;Command Timeout=100;";

            //Oracle Connection
            /*variabel.cUsrOra = ls.GetVariabel("UserOrcl", lokasi_kunci);
            variabel.cPassOra = ls.GetVariabel("PasswordOrcl", lokasi_kunci);
            variabel.cTnsOra = ls.GetVariabel("ODPOrcl", lokasi_kunci);
            Debug.WriteLine("UserOra: " + variabel.cUsrOra);
            Debug.WriteLine("PassOra: " + variabel.cPassOra);
            Debug.WriteLine("TnsOra: " + variabel.cTnsOra);

            constrPostgres = "Data Source=" + variabel.cTnsOra + ";User ID=" + variabel.cUsrOra + ";Password=" + variabel.cPassOra + ";";*/


        }
    }

    internal class ReturnDT
    {
        public string status { get; set; }
        public string keterangan { get; set; }
        public DataTable dt { get; set; }
    }

    internal class LISUSER
    {
        public string User_Privs { get; set; }
        public string cUser_NAMA { get; set; }
        public string cUser_NIK { get; set; }
        public string cDC_ID { get; set; }
        public string cDC_KODE { get; set; }
        public string cDC_NAMA { get; set; }
        
    }

    public class SupirModel
    {
        public string nik { get; set; }
        public string nama { get; set; }
        public string niknama { get; set; }
    }
}