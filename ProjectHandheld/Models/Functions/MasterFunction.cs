using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;
using Oracle;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;

namespace LISMVC.Models
{
    public class MasterFunction
    {
        internal static List<Departemen> GetDepartemen()
        {
            List<Departemen> listDep = new List<Departemen>();
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT tbl_dep_kode, tbl_dep_nama " +
                    "FROM DC_TABEL_DEPARTEMEN_T ORDER BY 1");
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listDep.Add(new Departemen { 
                        DEP_KODE = reader[0].ToString(),
                        DEP_NAMA = reader[1].ToString()
                    });
                }
                reader.Close();
                PostgresDBConnection.Close();
                cmd.Dispose();
                return listDep;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        //RUDDY
        internal static List<Zona> GetListZona()
        {
            List<Zona> listZona = new List<Zona>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct my_client as zona,upper(my_tipe) as jenis from dpd_gway order by MY_CLIENT";

            DataTable dt = FuncEQ.SqlServerGetDT(cmd);
            foreach(DataRow dr in dt.Rows)
            {
                Zona zona = new Zona();
                zona.ZONA = dr["zona"].ToString();
                zona.JENIS = dr["jenis"].ToString();
                listZona.Add(zona);
            }

            return listZona;
        }

        internal static List<PLU> GetPluByDC(string dcid)
        {
            List<PLU> listPLU = new List<PLU>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "SELECT mbr_fk_pluid, mbr_plukode, mbr_singkatan" +
                                                          " FROM dc_barang_dc_v" +
                                                          " WHERE mbr_fk_dcid='" + dcid + "'" +
                                                          " ORDER BY 1";
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listPLU.Add(new PLU { 
                        PLU_ID = reader[0].ToString(),
                        PLU_KODE = reader[1].ToString(),
                        PLU_NAMA = reader[2].ToString()
                    });
                }
                reader.Close();
                PostgresDBConnection.Close();
                cmd.Dispose();
                return listPLU;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static List<Divisi> GetDivisi()
        {
            List<Divisi> listDiv = new List<Divisi>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "SELECT tbl_div_kode, tbl_div_nama FROM DC_TABEL_DIVISI_T ORDER BY 1";
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listDiv.Add(new Divisi
                    {
                        DIV_KODE = reader[0].ToString(),
                        DIV_NAMA = reader[1].ToString()
                    });
                }
                reader.Close();
                PostgresDBConnection.Close();
                cmd.Dispose();
                return listDiv;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static List<Supplier> GetSupplierByDC(string dcid)
        {
            List<Supplier> listSup = new List<Supplier>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "SELECT DISTINCT kode_sup, nama_sup, sup_supkode FROM dc_sup_v WHERE mbr_fk_dcid='" + dcid + "' ORDER BY 1";
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listSup.Add(new Supplier
                    {
                        SUP_KODE = reader[0].ToString(),
                        SUP_NAMA = reader[1].ToString(),
                        SUP_SUPKODE = reader[2].ToString()
                    });
                }
                reader.Close();
                PostgresDBConnection.Close();
                cmd.Dispose();
                return listSup;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static List<Kategori> GetKategoriByDept(string dept_id)
        {
            List<Kategori> listKat = new List<Kategori>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "SELECT tbl_kat_kode, tbl_kat_nama " +
                    "FROM DC_TABEL_KATEGORI_T WHERE tbl_fk_dep_kode='" + dept_id + "' ORDER BY 1";
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                //Debug.WriteLine("reader: " + reader.RowSize + ", deptid: "+ dept_id);
                while (reader.Read())
                {
                    listKat.Add(new Kategori
                    {
                        KAT_KODE = reader[0].ToString(),
                        KAT_NAMA = reader[1].ToString()
                    });
                }
                reader.Close();
                PostgresDBConnection.Close();
                cmd.Dispose();
                return listKat;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static List<ListDCModel> GetListDC()
        {
            List<ListDCModel> listDC = new List<ListDCModel>();
            try
            {
                OracleCommand cmd = new OracleCommand("select tbl_dc_nama,tbl_dcid,tbl_dc_kode from dc_tabel_dc_t order by 2");
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listDC.Add(new ListDCModel
                    {
                        DC_KODE = reader["tbl_dc_kode"].ToString(),
                        DC_ID = reader["tbl_dcid"].ToString(),
                        DC_NAMA = reader["tbl_dc_nama"].ToString()
                    });
                }
                return listDC;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static List<Depo> GetDepoByDC(string param, string dcid, string username, string namadc)
        {
            List<Depo> listDepo = new List<Depo>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                if(param == "rptListingKartuStok")
                {
                    cmd.CommandText = "SELECT tbl_gudang_nama, tbl_gudangid " +
                               "FROM DC_TABEL_GUDANG_T " +
                                "WHERE tbl_gudangid IN(SELECT gd_id " +
                                                      "FROM dc_user_depo_v " +
                                                      "WHERE user_name = '" + username +"'"+
                                                      "AND dc_id = " +
                            "(SELECT DISTINCT tbl_dcid FROM dc_dc_full_v WHERE tbl_dc_nama = '"+namadc+"'))";
                    //cmd.Parameters.Add(new OracleParameter("username", username));
                    //cmd.Parameters.Add(new OracleParameter("namadc", namadc));
                }
                else
                {
                    cmd.CommandText = "select distinct tbl_gudang_type, tbl_gudangid " +
                        "from dc_dc_full_v where tbl_dcid = '"+dcid+"' order by 2";
                    //cmd.Parameters.Add(new OracleParameter("dcid", dcid));
                }
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listDepo.Add(new Depo
                        {
                            GUDANG_ID = reader[1].ToString(),
                            GUDANG_TYPE = reader[0].ToString()
                        });
                    }
                }
                reader.Close();
                cmd.Dispose();
                PostgresDBConnection.Close();
                return listDepo;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static List<Location> GetLocationByDepo(string param, string username, string namadc, string gudang_id)
        {
            List<Location> listLoc = new List<Location>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                if (param == "rptListingKartuStok")
                {
                    cmd.CommandText = "SELECT tbl_lokasi_nama, tbl_lokasiid" +
                                    "  FROM DC_TABEL_LOKASI_T" +
                                    " WHERE tbl_lokasiid IN (" +
                                    "          SELECT lok_id" +
                                    "            FROM dc_user_lokasi_v" +
                                    "           WHERE user_name = '"+username+"'" +
                                    "             AND dc_id = (SELECT DISTINCT tbl_dcid FROM dc_dc_full_v WHERE tbl_dc_nama = '" + namadc + "')" +
                                    "             AND gd_id = '" + gudang_id + "')";
                    //cmd.Parameters.Add(new OracleParameter("username", username));
                    //cmd.Parameters.Add(new OracleParameter("namadc", namadc));
                    //cmd.Parameters.Add(new OracleParameter("gudangid", gudang_id));
                }
                else if(param == "DCRCTKBAP_NEW")
                {
                    cmd.CommandText = "select distinct tbl_lokasi_type,tbl_lokasiid " +
                                      "from dc_dc_full_v " +
                                      "where tbl_gudangid = '" + gudang_id + "' and tbl_lokasi_type='RUSAK' order by 2 ";
                    //cmd.Parameters.Add(new OracleParameter("depoid", gudang_id));
                }
                else if (param == "DCRLIST_NRB")
                {
                    cmd.CommandText = "select distinct tbl_lokasi_type,tbl_lokasiid " +
                                      " from dc_dc_full_v" +
                                      " where tbl_gudangid='" + gudang_id + "' and tbl_lokasi_type='RETUR'" +
                                      " order by 2  ";
                }
                else
                {
                    cmd.CommandText = "select distinct tbl_lokasi_type,tbl_lokasiid " +
                                      "from dc_dc_full_v " +
                                      "where tbl_gudangid= '" + gudang_id + "' order by 2 ";
                   // cmd.Parameters.Add(new OracleParameter("depoid", gudang_id));
                }
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listLoc.Add(new Location
                        {
                            LOKASI_NAMA = reader[0].ToString(),
                            LOKASI_ID = reader[1].ToString()
                        });
                    }
                }
                reader.Close();
                cmd.Dispose();
                PostgresDBConnection.Close();

                return listLoc;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal string GetTanggalFromObj(Object dr)
        {
            try
            {
                if (dr != DBNull.Value)
                    if (dr.ToString().Length > 0)
                        return Convert.ToDateTime(dr).ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch { }

            return "";
        }

        internal string GetTanggalFromObjnoYearSec(Object dr)
        {
            try
            {
                if (dr != DBNull.Value)
                    if (dr.ToString().Length > 0)
                        return Convert.ToDateTime(dr).ToString("dd/MM HH:mm");
            }
            catch { }

            return "";
        }

        internal string GetstringFromObj(Object dr)
        {
            string ret = "";
            try
            {
                ret = dr.ToString();
            }
            catch { }
            return ret;
        }

        internal int GetIntFromObj(Object dr)
        {
            int ret = 0;
            try
            {
                ret = Convert.ToInt32(dr);
            }
            catch { }

            return ret;
        }

        internal List<SupirModel> GetListSupirDC(String kodedc)
        {
            List<SupirModel> lsm = new List<Models.SupirModel>();

            OracleCommand cmd = new OracleCommand ("select kddc, NIK, NAMA from cluster_tbsupir where KDDC = :pkodedc order by NAMA");
            cmd.Parameters.Add(new OracleParameter("pkodedc", kodedc));            
            DataTable dt = FuncEQ.PostgresGetDT(cmd);
            foreach (DataRow dr in dt.Rows)
            {
                SupirModel sm = new Models.SupirModel();
                sm.nama = dr["NAMA"].ToString();
                sm.nik = dr["NIK"].ToString();
                sm.niknama = dr["NAMA"].ToString() + " - " + dr["NIK"].ToString();
                lsm.Add(sm);
            }
            return lsm;
        }

        internal static List<Toko> GetToko(string param)
        {
            List<Toko> listToko = new List<Toko>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                if(param == "rptServiceLevelDcTokoPerTag")
                {
                    cmd.CommandText = "SELECT TOK_CODE, TOK_NAME FROM DC_TOKO_T " +
                                        "where tok_tgl_tutup is null ORDER BY TOK_CODE ASC";
                }
                
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listToko.Add(new Toko
                    {
                        TOK_CODE = reader["TOK_CODE"].ToString(),
                        TOK_NAME = reader["TOK_NAME"].ToString()
                    });
                }
                reader.Close();
                PostgresDBConnection.Close();
                cmd.Dispose();

                return listToko;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        //Ruddy
        internal static List<Toko> GetListToko()
        {
            List<Toko> listToko = new List<Toko>();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "SELECT tok_code||' - '|| tok_name toko from dc_toko_t order by 1";

            DataTable dt = FuncEQ.PostgresGetDT(cmd);

            foreach (DataRow dr in dt.Rows)
            {
                Toko toko = new Toko();
                toko.TOKO = dr["toko"].ToString();
                listToko.Add(toko);
            }

            return listToko;
        }
        internal string getNamaHari(string hari)
        {
            try
            {

                string getNamaHari = "";

                if (hari.ToUpper() == "SUNDAY")
                {
                    getNamaHari = "MINGGU";
                }
                else if (hari.ToUpper() == "MONDAY")
                {
                    getNamaHari = "SENIN";
                }
                else if (hari.ToUpper() == "TUESDAY")
                {
                    getNamaHari = "SELASA";
                }
                else if (hari.ToUpper() == "WEDNESDAY")
                {
                    getNamaHari = "RABU";
                }
                else if (hari.ToUpper() == "THURSDAY")
                {
                    getNamaHari = "KAMIS";
                }
                else if (hari.ToUpper() == "FRIDAY")
                {
                    getNamaHari = "JUMAT";
                }
                else if (hari.ToUpper() == "SATURDAY")
                {
                    getNamaHari = "SABTU";
                }
                return getNamaHari;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            return "";
        }
        internal static List<TokoByDate> getStrSQLTokoIssuingByDate(string tgl)
        {
            List<TokoByDate> getTokoByDate = new List<TokoByDate>();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = $"SELECT a.seq_no_ba as SEQ_NO_BA, a.kdtoko,b.TOK_NAME " +
                                  $"  FROM dc_ba_issuing_hdr_t a, dc_toko_t b " +
                                  $" WHERE a.KDTOKO = b.TOK_CODE and DATE_TRUNC ('day', a.seq_date_ba) = TO_DATE ('" + tgl + "', 'mm/dd/yyyy')";
                cmd.Parameters.Add(new OracleParameter("tgl", tgl));
                PostgresDBConnection.Open(cmd);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    getTokoByDate.Add(new TokoByDate
                    {
                        SEQ_NO_BA = reader[0].ToString()
                    });

                }
                reader.Close();
                PostgresDBConnection.Close();
                cmd.Dispose();
                return getTokoByDate;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        internal static OracleCommand getDC()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $" select tbl_dc_nama,tbl_dcid from dc_tabel_dc_t order by 2 ";
            return cmd;
        }

        internal static string GetTigaBulanTrakhir(int bln, int thn)
        {
            try 
            {
                int tahun = thn - 1;
                switch (bln)
                {
                    case 0:
                        return "12/" + tahun + "";
                        break;
                    case -1:
                        return "11/" + tahun + "";
                        break;
                    case 10:
                        return "" + bln + "/" + thn + "";
                        break;
                    case 11:
                        return "" + bln + "/" + thn + "";
                        break;
                    case 12:
                        return "" + bln + "/" + thn + "";
                        break;
                    default:
                        return "0" + bln + "/" + thn + "";
                        break;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

        }

    }
}