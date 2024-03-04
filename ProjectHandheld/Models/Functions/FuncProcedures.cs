using Oracle;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace LISMVC.Models.Functions
{
    public static class FuncProcedures
    {
        //internal static int RunProc_LAP_BRG_KSG_PLANO(string namaProc, string P_DCID, string P_TGL, string P_IP, string P_DIVLOW, string P_DIVHIGH)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}({P_DCID}, '{P_TGL}', '{P_IP}', '{P_DIVLOW}', '{P_DIVHIGH}')";
        //        //cmd.Parameters.Add(new OracleParameter("P_DCID", OracleDbType.Integer, 2000));
        //        //cmd.Parameters.Add(new OracleParameter("P_TGL", OracleDbType.Varchar, 2000));
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar, 2000));
        //        //cmd.Parameters.Add(new OracleParameter("P_DIVLOW", OracleDbType.Varchar, 2000));
        //        //cmd.Parameters.Add(new OracleParameter("P_DIVHIGH", OracleDbType.Varchar, 2000));

        //        //cmd.Parameters[0].Value = P_DCID;
        //        //cmd.Parameters[1].Value = P_TGL;
        //        //cmd.Parameters[2].Value = P_IP;
        //        //cmd.Parameters[3].Value = P_DIVLOW;
        //        //cmd.Parameters[4].Value = P_DIVHIGH;

        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        int hasil = FuncEQ.ExecQueryPostgres(cmd);
        //        return hasil;
        //    }
        //    catch(Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static int RunProc_LAP_BRG_KSG(string namaProc, string P_DCID, string P_TGL, string P_IP, string P_DIVLOW, string P_DIVHIGH, string P_TAG)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}({P_DCID}, '{P_TGL}', '{P_IP}', '{P_DIVLOW}', '{P_DIVHIGH}', '{P_TAG}')";
        //        //cmd.Parameters.Add(new OracleParameter("P_DCID", OracleDbType.Integer, 2000));
        //        //cmd.Parameters.Add(new OracleParameter("P_TGL", OracleDbType.Varchar, 2000));
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar, 2000));
        //        //cmd.Parameters.Add(new OracleParameter("P_DIVLOW", OracleDbType.Varchar, 2000));
        //        //cmd.Parameters.Add(new OracleParameter("P_DIVHIGH", OracleDbType.Varchar, 2000));
        //        //cmd.Parameters.Add(new OracleParameter("P_TAG", OracleDbType.Varchar, 2000));

        //        //cmd.Parameters[0].Value = P_DCID;
        //        //cmd.Parameters[1].Value = P_TGL;
        //        //cmd.Parameters[2].Value = P_IP;
        //        //cmd.Parameters[3].Value = P_DIVLOW;
        //        //cmd.Parameters[4].Value = P_DIVHIGH;
        //        //cmd.Parameters[5].Value = P_TAG;

        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        int hasil = FuncEQ.ExecQueryPostgres(cmd);
        //        return hasil;
        //    }
        //    catch(Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static int RunProcInsertClusterTBKirim(string namaProc, string p_tgl1, string p_tgl2)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + p_tgl1 + "','" + p_tgl2 + "')";
        //        //cmd.Parameters.Add(new OracleParameter("p_tgl_awal", OracleDbType.Date, 200));
        //        //cmd.Parameters.Add(new OracleParameter("p_tgl_akhir", OracleDbType.Date, 200));

        //        //cmd.Parameters[0].Value = p_tgl1;
        //        //cmd.Parameters[1].Value = p_tgl2;

        //        cmd.CommandType = CommandType.Text;

        //        int hasil = 0;
        //        using(OracleConnection conn = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            if (conn.State == ConnectionState.Closed)
        //                conn.Open();
        //            cmd.Connection = conn;
        //            hasil = cmd.ExecuteNonQuery();
        //        }
        //        return hasil;
        //        //return FuncEQ.ExecQueryPostgres(cmd);
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static void Run_Proc_UPDLOG_LIS(string nama_proc, string user, string log_menu, string log_title, string log_class)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = "call " + nama_proc.ToUpper() + "('" + user + "', '" + log_menu + "', '" + log_title + "', '" + log_class + "')";
        //        //cmd.Parameters.Clear();
        //        //cmd.Parameters.Add(new OracleParameter("p_user", user));
        //        //cmd.Parameters.Add(new OracleParameter("p_menu", log_menu));
        //        //cmd.Parameters.Add(new OracleParameter("p_title", log_title));
        //        //cmd.Parameters.Add(new OracleParameter("p_class", log_class));
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        int result = FuncEQ.ExecQueryPostgres(cmd);
        //        //Debug.WriteLine("UPDLOG: " + result);
        //    }
        //    catch(Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static string Run_Proc_DCLAP_PENY(string namaProc, string P_LOKID, string P_TIPE, string P_TGL1, string P_TGL2, string P_DIV, string P_IP)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "(:P_LOKID, :P_TIPE, :P_TGL1, :P_TGL2, :P_DIV, :P_IP)";

        //        cmd.Parameters.Add(new OracleParameter("P_LOKID", P_LOKID));
        //        cmd.Parameters.Add(new OracleParameter("P_TIPE", P_TIPE.ToUpper()));
        //        cmd.Parameters.Add(new OracleParameter("P_TGL1", P_TGL1));
        //        cmd.Parameters.Add(new OracleParameter("P_TGL2", P_TGL2));
        //        cmd.Parameters.Add(new OracleParameter("P_DIV", P_DIV));
        //        cmd.Parameters.Add(new OracleParameter("P_IP", P_IP));

        //        //cmd.Parameters[0].Value = P_LOKID;
        //        //cmd.Parameters[1].Value = P_TIPE;
        //        //cmd.Parameters[2].Value = P_TGL1;
        //        //cmd.Parameters[3].Value = P_TGL2;
        //        //cmd.Parameters[4].Value = P_DIV;
        //        //cmd.Parameters[5].Value = P_IP;

        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        FuncEQ.ExecQueryPostgres(cmd);

        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static int Run_Proc_Hist_Pemb(string namaProc, string P_KodeDC, string P_Flag, string P_Data, string P_Count, string P_IP)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "(:p_dc, :p_flag, :p_data, :p_count, :p_ip)";
        //        cmd.Parameters.Add(new OracleParameter("p_dc", P_KodeDC.ToUpper()));
        //        cmd.Parameters.Add(new OracleParameter("p_flag", P_Flag.ToUpper()));
        //        cmd.Parameters.Add(new OracleParameter("p_data", P_Data.ToUpper()));
        //        cmd.Parameters.Add(new OracleParameter("p_count", P_Count));
        //        cmd.Parameters.Add(new OracleParameter("p_ip", P_IP));

                
        //        //cmd.Parameters[0].Value = P_KodeDC;
        //        //cmd.Parameters[1].Value = P_Flag;
        //        //cmd.Parameters[2].Value = P_Data;
        //        //cmd.Parameters[3].Value = P_Count;
        //        //cmd.Parameters[4].Value = P_IP;

        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        int hasil = FuncEQ.ExecQueryPostgres(cmd);
        //        return hasil;
        //    }
        //    catch(Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        
        //internal static int Run_Proc_Det_Pick_ScanOracle(string namaProc, string kodedc, string tgl, string toko, string nonpb, string p_ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}('{kodedc}', '{tgl}', '{toko}', '{nonpb}', '{p_ip}')";
        //        //cmd.Parameters.Add(new OracleParameter("P_DCKODE", kodedc));
        //        //cmd.Parameters.Add(new OracleParameter("P_TGL", tgl));
        //        //cmd.Parameters.Add(new OracleParameter("P_TOKO", toko));
        //        //cmd.Parameters.Add(new OracleParameter("P_NPB", nonpb));
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", p_ip));

        //        //cmd.Parameters[0].Value = "'" + kodedc + "'";
        //        //cmd.Parameters[1].Value = "'" + tgl + "'"; 
        //        //cmd.Parameters[2].Value = "'" + toko + "'"; 
        //        //cmd.Parameters[3].Value = "'" + nonpb + "'"; 
        //        //cmd.Parameters[4].Value = "'" + p_ip + "'"; 

        //        cmd.CommandType = CommandType.Text;   
        //        int hasil = FuncEQ.ExecQueryPostgres(cmd);
        //        return hasil;
        //    }
        //    catch(Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static int Run_Proc_Det_Pick_ScanSQL(string namaProc, string kodedc, string tgl, string toko, string nonpb, string p_ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
                
        //        cmd.CommandText = namaProc.ToUpper();
        //        cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar, 2000));
        //        cmd.Parameters.Add(new OracleParameter("P_TGL", OracleDbType.Date, 200));
        //        cmd.Parameters.Add(new OracleParameter("P_TOKO", OracleDbType.Varchar2, 2000));
        //        cmd.Parameters.Add(new OracleParameter("P_NPB", OracleDbType.Integer, 100));
        //        cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar, 2000));

        //        cmd.Parameters[0].Value = kodedc;
        //        cmd.Parameters[1].Value = tgl;
        //        cmd.Parameters[2].Value = toko;
        //        cmd.Parameters[3].Value = nonpb;
        //        cmd.Parameters[4].Value = p_ip;

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        return FuncEQ.ExecQueryPostgres(cmd);
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static int Run_Proc_RCTKLPP_BNH2A(string namaProc, string p_plulow, string p_pluhigh, string p_tgl1, string p_tgl2, string p_tag, string p_lokasiid, string p_ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}('{p_plulow}', '{p_pluhigh}', '{p_tgl1}', '{p_tgl2}', '{p_tag}', '{p_lokasiid}', '{p_ip}')";
        //        cmd.Parameters.Add(new OracleParameter("v_plulow", OracleDbType.Varchar, 200)).Value = p_plulow;
        //        cmd.Parameters.Add(new OracleParameter("v_pluhigh", OracleDbType.Varchar, 200)).Value = p_pluhigh;
        //        cmd.Parameters.Add(new OracleParameter("v_tgllow", OracleDbType.Varchar, 200)).Value = p_tgl1;
        //        cmd.Parameters.Add(new OracleParameter("v_tglhigh", OracleDbType.Varchar, 200)).Value = p_tgl2;
        //        cmd.Parameters.Add(new OracleParameter("v_tag", OracleDbType.Varchar, 200)).Value = p_tag;
        //        cmd.Parameters.Add(new OracleParameter("v_lokasi_id", OracleDbType.Varchar, 200)).Value = p_lokasiid;
        //        cmd.Parameters.Add(new OracleParameter("v_ip", OracleDbType.Varchar, 200)).Value = p_ip;

        //        //cmd.Parameters[0].Value = p_plulow;
        //        //cmd.Parameters[1].Value = p_pluhigh;
        //        //cmd.Parameters[2].Value = p_tgl1;
        //        //cmd.Parameters[3].Value = p_tgl2;
        //        //cmd.Parameters[4].Value = p_tag;
        //        //cmd.Parameters[5].Value = p_lokasiid;
        //        //cmd.Parameters[6].Value = p_ip;

        //        //cmd.CommandType = CommandType.Text;
        //        cmd.CommandTimeout = 30 * 60 * 1;
        //        int hasil = FuncEQ.ExecQueryPostgres(cmd);
        //        return hasil;
        //    }
        //    catch(Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static int Run_Proc_RCTKLPP_LAN_BNH2A(string namaProc, string p_linelow, string p_linehigh, string p_raklow, string p_rakhigh, string p_selflow, string p_selfhigh, string p_celllow, string p_cellhigh, string p_tgl1, string p_tgl2, string p_tag, string p_lokasiid, string p_ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}('{p_linelow}', '{p_linehigh}', '{p_raklow}', '{p_rakhigh}', '{p_selflow}', '{p_selfhigh}', '{p_celllow}', '{p_cellhigh}', '{p_tgl1}', '{p_tgl2}', '{p_tag}', '{p_lokasiid}', '{p_ip}')";
        //        cmd.Parameters.Add(new OracleParameter("p_linelow", OracleDbType.Varchar, 2000)).Value = p_linelow;
        //        cmd.Parameters.Add(new OracleParameter("p_linehigh", OracleDbType.Varchar, 2000)).Value = p_linehigh;
        //        cmd.Parameters.Add(new OracleParameter("p_raklow", OracleDbType.Varchar, 2000)).Value = p_raklow;
        //        cmd.Parameters.Add(new OracleParameter("p_rakhigh", OracleDbType.Varchar, 2000)).Value = p_rakhigh;
        //        cmd.Parameters.Add(new OracleParameter("p_selflow", OracleDbType.Varchar, 2000)).Value = p_selflow;
        //        cmd.Parameters.Add(new OracleParameter("p_selfhigh", OracleDbType.Varchar, 2000)).Value = p_selfhigh;
        //        cmd.Parameters.Add(new OracleParameter("p_celllow", OracleDbType.Varchar, 2000)).Value = p_celllow;
        //        cmd.Parameters.Add(new OracleParameter("p_cellhigh", OracleDbType.Varchar, 2000)).Value = p_cellhigh;
        //        cmd.Parameters.Add(new OracleParameter("p_tgl1", OracleDbType.Varchar, 2000)).Value = p_tgl1;
        //        cmd.Parameters.Add(new OracleParameter("p_tgl2", OracleDbType.Varchar, 2000)).Value = p_tgl2;
        //        cmd.Parameters.Add(new OracleParameter("p_tag", OracleDbType.Varchar, 2000)).Value = p_tag;
        //        cmd.Parameters.Add(new OracleParameter("p_lokasiid", OracleDbType.Varchar, 2000)).Value = p_lokasiid;
        //        cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 2000)).Value = p_ip;

        //        //cmd.CommandType = CommandType.Text;
        //        cmd.CommandTimeout = 30 * 60 * 1;
        //        int hasil = FuncEQ.ExecQueryPostgres(cmd);
        //        return hasil;
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static string RunProcedure_Jawab_Retur_Proforma(string namaProc, string param1, string param2, string param3) {
        //    try {
        //        OracleCommand cmd = new OracleCommand();
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}('{param1}', '{param2}', '{param3}')";

        //        cmd.Parameters.Add(new OracleParameter(param1, OracleDbType.Varchar, 2000)).Value = param1;
        //        cmd.Parameters.Add(new OracleParameter(param2, OracleDbType.Varchar, 2000)).Value = param2;
        //        cmd.Parameters.Add(new OracleParameter(param3, OracleDbType.Varchar, 2000)).Value = param3;

        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        FuncEQ.ExecQueryPostgres(cmd);

        //        return "Y";
        //    }
        //    catch(Exception e) {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static int Run_Proc_RCTKLPP_KAT_BNH2A(string namaProc, string p_katlow, string p_kathigh,  string p_tgl1, string p_tgl2, string p_tag, string p_lokasiid, string p_ip, string p_dep)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}('{p_katlow}', '{p_kathigh}', '{p_tgl1}', '{p_tgl2}', '{p_tag}', '{p_lokasiid}', '{p_ip}', '{p_dep}')";
        //        cmd.Parameters.Add(new OracleParameter("p_katlow", OracleDbType.Varchar, 2000)).Value = p_katlow;
        //        cmd.Parameters.Add(new OracleParameter("p_kathigh", OracleDbType.Varchar, 2000)).Value = p_kathigh;
        //        cmd.Parameters.Add(new OracleParameter("p_tgl1", OracleDbType.Varchar, 2000)).Value = p_tgl1;
        //        cmd.Parameters.Add(new OracleParameter("p_tgl2", OracleDbType.Varchar, 2000)).Value = p_tgl2;
        //        cmd.Parameters.Add(new OracleParameter("p_tag", OracleDbType.Varchar, 2000)).Value = p_tag;
        //        cmd.Parameters.Add(new OracleParameter("p_lokasiid", OracleDbType.Varchar, 2000)).Value = p_lokasiid;
        //        cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 2000)).Value = p_ip;
        //        cmd.Parameters.Add(new OracleParameter("p_dep", OracleDbType.Varchar, 2000)).Value = p_dep;

        //        //cmd.CommandType = CommandType.Text;
        //        cmd.CommandTimeout = 30 * 60 * 1;
        //        int hasil = FuncEQ.ExecQueryPostgres(cmd);
        //        return hasil;
        //    }
        //    catch(Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static int Run_Proc_Sum_pick_Scan(string namaProc, string dckode, string p_tgl, string p_ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}('{dckode}', '{p_tgl}', '{p_ip}')";
        //        //cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        //cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar, 2000));
        //        //cmd.Parameters.Add(new OracleParameter("P_TGL", OracleDbType.Date, 200));
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar, 2000));

        //        //cmd.Parameters[0].Direction = ParameterDirection.Input;
        //        //cmd.Parameters[0].Value = dckode;

        //        //cmd.Parameters[1].Direction = ParameterDirection.Input;
        //        //cmd.Parameters[1].Value = p_tgl;

        //        //cmd.Parameters[2].Direction = ParameterDirection.Input;
        //        //cmd.Parameters[2].Value = p_ip;

        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        return FuncEQ.ExecQueryPostgres(cmd);
        //    }
        //    catch (SqlException ex)
        //    {
        //        Debug.WriteLine(ex.ToString());
        //        //Debug.WriteLine(e.Message);
        //        throw;
        //    }
        //}

        //internal static string RunProc_Rekap_NKL_DCI(string namaProc, string dcKode, string tgl1, string tgl2, string ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}('{dcKode}', '{tgl1}', '{tgl2}', '{ip}','')";
        //        //cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar, 2000)).Value = dcKode;
        //        //cmd.Parameters.Add(new OracleParameter("P_PERIODE_AWAL", OracleDbType.Varchar, 2000)).Value = tgl1;
        //        //cmd.Parameters.Add(new OracleParameter("P_PERIODE_AKHIR", OracleDbType.Varchar, 2000)).Value = tgl2;
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar, 2000)).Value = ip;
        //        cmd.Parameters.Add(new OracleParameter("P_MSG", OracleDbType.Varchar, 2000)).Direction = ParameterDirection.ReturnValue;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int x = cmd.ExecuteNonQuery();
        //            string hasil = cmd.Parameters["P_MSG"].Value.ToString();
        //            if (hasil != "")
        //            {
        //                return hasil;
        //            }
        //        }
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string RunProc_Rekap_NKL_DCI2(string namaProc, string dcKode, string tgl1, string tgl2, string div1, string div2, string ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}('{dcKode}', '{tgl1}', '{tgl2}', '{div1}', '{div2}', '{ip}', '')" ;
        //        //cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar, 2000)).Value = dcKode;
        //        //cmd.Parameters.Add(new OracleParameter("P_PERIODE_AWAL", OracleDbType.Varchar, 2000)).Value = tgl1;
        //        //cmd.Parameters.Add(new OracleParameter("P_PERIODE_AKHIR", OracleDbType.Varchar, 2000)).Value = tgl2;
        //        //cmd.Parameters.Add(new OracleParameter("P_DIV_AWAL", OracleDbType.Varchar, 2000)).Value = div1;
        //        //cmd.Parameters.Add(new OracleParameter("P_DIV_AKHIR", OracleDbType.Varchar, 2000)).Value = div2;
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar, 2000)).Value = ip;
        //        cmd.Parameters.Add(new OracleParameter("P_MSG", OracleDbType.Varchar, 2000)).Direction = ParameterDirection.ReturnValue;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int x = cmd.ExecuteNonQuery();
        //            string hasil = cmd.Parameters["P_MSG"].Value.ToString();
        //            if (hasil != "")
        //            {
        //                return hasil;
        //            }
        //        }
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string RunProc_Rekap_NKL_DCI3(string namaProc, string dcKode, string tgl1, string tgl2, string item1, string item2, string ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}('{dcKode}', '{tgl1}', '{tgl2}', '{item1}', '{item2}', '{ip}', '')";
        //        //cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar, 2000)).Value = dcKode;
        //        //cmd.Parameters.Add(new OracleParameter("P_PERIODE_AWAL", OracleDbType.Varchar, 2000)).Value = tgl1;
        //        //cmd.Parameters.Add(new OracleParameter("P_PERIODE_AKHIR", OracleDbType.Varchar, 2000)).Value = tgl2;
        //        //cmd.Parameters.Add(new OracleParameter("P_PLU_AWAL", OracleDbType.Varchar, 2000)).Value = item1;
        //        //cmd.Parameters.Add(new OracleParameter("P_PLU_AKHIR", OracleDbType.Varchar, 2000)).Value = item2;
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar, 2000)).Value = ip;
        //        cmd.Parameters.Add(new OracleParameter("P_MSG", OracleDbType.Varchar, 2000)).Direction = ParameterDirection.ReturnValue;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int x = cmd.ExecuteNonQuery();
        //            string hasil = cmd.Parameters["P_MSG"].Value.ToString();
        //            if (hasil != "")
        //            {
        //                return hasil;
        //            }
        //        }
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string Run_Proc_MonPenjRetProf(string namaProc, string p_periodeawal, string p_periodeakhir, string p_tipe, string p_ip) {
        //    try {
        //        OracleCommand cmd = new OracleCommand();
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}('{p_periodeawal}', '{p_periodeakhir}', '{p_tipe}', '{p_ip}')";

        //        cmd.Parameters.Add(new OracleParameter("p_periodeawal", OracleDbType.Varchar, 2000)).Value = p_periodeawal;
        //        cmd.Parameters.Add(new OracleParameter("p_periodeakhir", OracleDbType.Varchar, 2000)).Value = p_periodeakhir;
        //        cmd.Parameters.Add(new OracleParameter("p_tipe", OracleDbType.Varchar, 2000)).Value = p_tipe;
        //        cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 2000)).Value = p_ip;

        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        FuncEQ.ExecQueryPostgres(cmd);

        //        return "Y";
        //    }
        //    catch(Exception e) {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string jalanproclaporanbongkar(string kddc, string tglawl, string tglakh, string ipkomp) {
        //    //string hasil = "T";
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "CALL Ins_Lamabongkar('" + kddc + "', '" + tglawl + "', '" + tglakh + "', '" + ipkomp + "')";

        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            cmd.ExecuteNonQuery();
        //        }

        //        return "Y";
        //    }
        //    catch (Exception e) {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}
        //internal static string RunLama_bongkar_sup_new(string tgl1, string tgl2, int rumus)
        //{
        //    string hasil = "Y";
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "CETAK_BONGKAR_DETAIL_SUP_NEW";

        //        cmd.Parameters.Add(new OracleParameter("p_tgl1", OracleDbType.Varchar, 2000)).Value = tgl1;
        //        cmd.Parameters.Add(new OracleParameter("p_tgl2", OracleDbType.Varchar, 2000)).Value = tgl2;
        //        cmd.Parameters.Add(new OracleParameter("p_idrumus", OracleDbType.Integer, 8)).Value = rumus;

        //        FuncEQ.ExecQueryPostgres(cmd);

        //        return hasil;
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static int Run_Proc_IntRetProf(string namaProc, string p_periodeawal, string p_periodeakhir, string p_ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = namaProc.ToUpper();

        //        cmd.Parameters.Add(new OracleParameter("p_periodeawal", OracleDbType.Date, 200)).Value = p_periodeawal;
        //        cmd.Parameters.Add(new OracleParameter("p_periodeakhir", OracleDbType.Date, 200)).Value = p_periodeakhir;
        //        cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 2000)).Value = p_ip;

        //        return FuncEQ.ExecQueryPostgres(cmd);
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}


        //internal static string Run_Proc_BPBSUP_BATASUMUR(string namaProc, string P_DCkode, string P_Tgl1, string P_Tgl2, string P_IP) {
        //    try {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = namaProc.ToUpper();

        //        cmd.Parameters.Add(new OracleParameter("P_DCKODE", P_DCkode));
        //        cmd.Parameters.Add(new OracleParameter("P_TGL1", P_Tgl1));
        //        cmd.Parameters.Add(new OracleParameter("P_TGL2", P_Tgl2));
        //        cmd.Parameters.Add(new OracleParameter("P_IP", P_IP));

        //        //cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar, 2000)).Value = P_DCkode;
        //        //cmd.Parameters.Add(new OracleParameter("P_TGL1", OracleDbType.Date, 2000)).Value = P_Tgl1;
        //        //cmd.Parameters.Add(new OracleParameter("P_TGL2", OracleDbType.Date, 2000)).Value = P_Tgl2;
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar, 2000)).Value = P_IP;

        //        int hasil = FuncEQ.ExecQueryPostgres(cmd);

        //        if(hasil != 0)
        //        {
        //            return "Y";
        //        }
        //        else
        //        {
        //            return "T";
        //        }
        //    }
        //    catch(Exception e) {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string RunProc_DCLAPNKLDC(string namaProc, string P_LOK, string P_LOKID, string P_DC, string P_TGL1, string P_TGL2, string P_LOW, string P_HIGH, string P_IP)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = namaProc.ToUpper();
        //        cmd.Parameters.Add(new OracleParameter("P_LOK", OracleDbType.Varchar, 2000)).Value = P_LOK;
        //        cmd.Parameters.Add(new OracleParameter("P_LOKID", OracleDbType.Integer, 2000)).Value = P_LOKID;
        //        cmd.Parameters.Add(new OracleParameter("P_DC", OracleDbType.Integer, 2000)).Value = P_DC;
        //        cmd.Parameters.Add(new OracleParameter("P_TGL1", OracleDbType.Varchar, 2000)).Value = P_TGL1;
        //        cmd.Parameters.Add(new OracleParameter("P_TGL2", OracleDbType.Varchar, 2000)).Value = P_TGL2;
        //        cmd.Parameters.Add(new OracleParameter("P_LOW", OracleDbType.Varchar, 2000)).Value = P_LOW;
        //        cmd.Parameters.Add(new OracleParameter("P_HIGH", OracleDbType.Varchar, 2000)).Value = P_HIGH;
        //        cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar, 2000)).Value = P_IP;

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        //cmd.Parameters.Add(new OracleParameter("P_LOK", P_LOK));
        //        //cmd.Parameters.Add(new OracleParameter("P_LOKID", P_LOKID));
        //        //cmd.Parameters.Add(new OracleParameter("P_DC", P_DC));
        //        //cmd.Parameters.Add(new OracleParameter("P_TGL1", P_TGL1));
        //        //cmd.Parameters.Add(new OracleParameter("P_TGL2", P_TGL2));
        //        //cmd.Parameters.Add(new OracleParameter("P_LOW", P_LOW));
        //        //cmd.Parameters.Add(new OracleParameter("P_HIGH", P_HIGH));
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", P_IP));
        //        int hasil = FuncEQ.ExecQueryPostgres(cmd);

        //        if (hasil != 0)
        //        {
        //            return "Y";
        //        }
        //        else
        //        {
        //            return "T";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}
        //internal static string RunProcedureSeasonal(string namaProc, string p_thn_sea, string p_dckode) {
        //    try {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = namaProc.ToUpper();

        //        cmd.Parameters.Add(new OracleParameter("p_thn_sea", OracleDbType.Varchar, 2000)).Value = p_thn_sea;
        //        cmd.Parameters.Add(new OracleParameter("p_dckode", OracleDbType.Varchar, 2000)).Value = p_dckode;

        //        FuncEQ.ExecQueryPostgres(cmd);

        //        return "Y";
        //    }
        //    catch(Exception e) {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string RunProcedureSeasonalNew(string namaProc, string p_thn_sea, string p_dckode, string p_ip) {
        //    try {
        //        OracleCommand cmd = new OracleCommand();
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + p_thn_sea + "', '" + p_dckode + "', '" + p_ip + "')";

        //        //cmd.Parameters.Add(new OracleParameter("p_thn_sea", OracleDbType.Varchar, 2000)).Value = p_thn_sea;
        //        //cmd.Parameters.Add(new OracleParameter("p_dckode", OracleDbType.Varchar, 2000)).Value = p_dckode;
        //        //cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 2000)).Value = p_ip;
        //        int hasil = 0;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            hasil = cmd.ExecuteNonQuery();
        //        }

        //        if(hasil == 0)
        //        {
        //            return "T";
        //        }
        //        else
        //        {
        //            return "Y";
        //        }
        //    }
        //    catch(Exception e) {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string exec_procSQL_nonParam(string namaProc) {
        //    try {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "" + namaProc.ToUpper() + "";
        //        FuncEQ.ExecQuerySqlServer(cmd);
        //        return "Y";
        //    }
        //    catch(Exception e) {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string Run_Proc_ListBPBNoPB(string namaProc, string P_IP, string P_SupExc)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = namaProc.ToUpper();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new OracleParameter("p_userid", OracleDbType.Varchar, 2000)).Value = P_IP;
        //        cmd.Parameters.Add(new OracleParameter("p_supp_exc", OracleDbType.Varchar, 2000)).Value = P_SupExc;
        //        cmd.Parameters.Add(new OracleParameter("p_supp_exc", OracleDbType.Varchar, 2000)).Direction = ParameterDirection.Output;

        //        int hasil = FuncEQ.ExecQueryPostgres(cmd);
        //        Debug.WriteLine("runproc: " + hasil);
        //        if(hasil == 0)
        //        {
        //            return "T";
        //        }
        //        else
        //        {
        //            return "Y";
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static string Run_Proc_DC_BRG_OVR_STK(string namaProc, string p_dcid, string p_by, string p_ip) {
        //    try {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "" + namaProc.ToUpper() + "";
        //        cmd.Parameters.Add(new OracleParameter("p_dcid", OracleDbType.Varchar, 2000)).Value = p_dcid;
        //        cmd.Parameters.Add(new OracleParameter("p_by", OracleDbType.Varchar, 2000)).Value = p_by;
        //        cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 2000)).Value = p_ip;
        //        FuncEQ.ExecQueryPostgres(cmd);
        //        return "Y";
        //    }
        //    catch(Exception e) {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string RunProcLaprecvsupp(string namaProc, string p_dc, string p_tglawal, string p_tglakhir, string p_ip) {
        //    try {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "" + namaProc.ToUpper() + "";
        //        cmd.Parameters.Add(new OracleParameter("p_dc", OracleDbType.Varchar, 2000)).Value = p_dc;
        //        cmd.Parameters.Add(new OracleParameter("p_tglawal", OracleDbType.Date, 2000)).Value = p_tglawal;
        //        cmd.Parameters.Add(new OracleParameter("p_tglakhir", OracleDbType.Date, 2000)).Value = p_tglakhir;
        //        cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 2000)).Value = p_ip;
        //        FuncEQ.ExecQueryPostgres(cmd);
        //        return "Y";
        //    }
        //    catch(Exception e) {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string Run_Proc_LPP02(string namaProc, string V_IP)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = namaProc.ToUpper();
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
        //        cmd.Parameters.Add(new OracleParameter("V_IP", OracleDbType.Varchar, 2000)).Value = V_IP;
        //        int hasil = FuncEQ.ExecQueryPostgres(cmd);
                
        //        if(hasil != 0)
        //        {
        //            return "Y";
        //        }
        //        else
        //        {
        //            return "N";
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        //internal static string Run_Proc_print_lpp_dep_all_instk(string namaProc, string v_deplow, string v_dephigh, string v_tgllow, string v_tglhigh, string v_tag, string v_lokasi_id, string v_ip) {
        //    try {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}('{v_deplow}', '{v_dephigh}', '{v_tgllow}', '{v_tglhigh}', '{v_tag}', '{v_lokasi_id}', '{v_ip}')";
        //        cmd.Parameters.Add(new OracleParameter("v_deplow", OracleDbType.Varchar, 2000)).Value = v_deplow;
        //        cmd.Parameters.Add(new OracleParameter("v_dephigh", OracleDbType.Varchar, 2000)).Value = v_dephigh;
        //        cmd.Parameters.Add(new OracleParameter("v_tgllow", OracleDbType.Varchar, 2000)).Value = v_tgllow;
        //        cmd.Parameters.Add(new OracleParameter("v_tglhigh", OracleDbType.Varchar, 2000)).Value = v_tglhigh;
        //        cmd.Parameters.Add(new OracleParameter("v_tag", OracleDbType.Varchar, 2000)).Value = v_tag;
        //        cmd.Parameters.Add(new OracleParameter("v_lokasi_id", OracleDbType.Varchar, 2000)).Value = v_lokasi_id;
        //        cmd.Parameters.Add(new OracleParameter("v_ip", OracleDbType.Varchar, 2000)).Value = v_ip;
        //        cmd.CommandTimeout = 30 * 60 * 1;
        //        int hasil = FuncEQ.ExecQueryPostgres(cmd);
        //        if(hasil != 0)
        //        {
        //            return "Y";
        //        } else
        //        {
        //            return "N";
        //        }
        //    }
        //    catch(Exception e) {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}

        ////Ruddy
        //internal static int Run_Proc_Jumlah_Paket(string namaProc, string KODEDC, string JENIS, string TGLAWAL, string TGLAKHIR, string p_ip)
        //{
        //    try
        //    {
        //        int hasil = 0;
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + KODEDC + "','" + JENIS + "', '" + TGLAWAL + "', '" + TGLAKHIR + "', '" +p_ip +"')";
        //        cmd.CommandType = CommandType.Text;
        //        //cmd.Parameters.Add(new OracleParameter("p_dckode", OracleDbType.Varchar, 2000)).Value = KODEDC;
        //        //cmd.Parameters.Add(new OracleParameter("p_jenis", OracleDbType.Varchar, 2000)).Value = JENIS;
        //        //cmd.Parameters.Add(new OracleParameter("p_tgl_awal", OracleDbType.Date, 2000)).Value = TGLAWAL;
        //        //cmd.Parameters.Add(new OracleParameter("p_tgl_akhir", OracleDbType.Date, 2000)).Value = TGLAKHIR;
        //        //cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 2000)).Value = p_ip;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            hasil = cmd.ExecuteNonQuery();
        //        }
        //        return hasil;
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw;
        //    }
        //}
        //internal static string RunProc_insert_lap_nrbprof(string namaProc, string p_prdlow, string p_prdhi, string p_sup)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + p_prdlow + "', '" + p_prdhi + "', '" + p_sup + "')";
        //        //cmd.Parameters.Add(new OracleParameter("p_prdlow", OracleDbType.Varchar, 2000)).Value = p_prdlow;
        //        //cmd.Parameters.Add(new OracleParameter("p_prdhi", OracleDbType.Varchar, 2000)).Value = p_prdhi;
        //        //cmd.Parameters.Add(new OracleParameter("p_sup", OracleDbType.Varchar, 2000)).Value = p_sup;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int hasil = cmd.ExecuteNonQuery();
        //        }
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}
        //internal static string RunProcKirimDCkeToko(string namaProc, DateTime tgl1, DateTime tgl2, string jml, string ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + tgl1 + "', '" + tgl2 + "', '" + jml + "', '" + ip + "')";
        //        //cmd.Parameters.Add(new OracleParameter("P_TGL1", OracleDbType.Date, ParameterDirection.Input)).Value = tgl1;
        //        //cmd.Parameters.Add(new OracleParameter("P_TGL2", OracleDbType.Date, ParameterDirection.Input)).Value = tgl2;
        //        //cmd.Parameters.Add(new OracleParameter("P_JML", OracleDbType.Int32, ParameterDirection.Input)).Value = jml;
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar2, 200, ParameterDirection.Input)).Value = ip;
        //        //cmd.Parameters.Add(new OracleParameter("P_MSG", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.Output;
        //        using (OracleConnection conn = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            conn.Open();
        //            cmd.Connection = conn;
        //            int hasil = cmd.ExecuteNonQuery();
        //        }
        //        //int hasil = FuncEQ.ExecQueryOracle(cmd);
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}
        //internal static string RunProcRekapNKLiPro(string namaProc, string dckode, string tglawl, string tglakh, string user, string ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + dckode + "', '" + tglawl + "', '" + tglakh + "', '" + user + "', '" + ip + "')";

        //        //cmd.Parameters.Add(new OracleParameter("p_dckode", OracleDbType.Varchar2, 2000)).Value = dckode;
        //        //cmd.Parameters.Add(new OracleParameter("p_awal", OracleDbType.Date, 2000)).Value = tglawl;
        //        //cmd.Parameters.Add(new OracleParameter("p_akhir", OracleDbType.Date, 2000)).Value = tglakh;
        //        //cmd.Parameters.Add(new OracleParameter("p_user", OracleDbType.Varchar2, 2000)).Value = user;
        //        //cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar2, 2000)).Value = ip;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int hasil = cmd.ExecuteNonQuery();
        //        }
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        ////Ruddy
        //internal static int RunProcedurePbtoko(string namaProc, string Kodedc, string tgl1, string tgl2, string toko1, string toko2, string IP)
        //{
        //    try
        //    {
        //        int hasil = 0;
        //        OracleCommand cmd = new OracleCommand();
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc + "('" + Kodedc + "', '" + tgl1 + "', '" + tgl2 + "', '" + toko1 + "', '" + toko2 + "', '" + IP + "')";
        //        //cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar2, 10, ParameterDirection.Input)).Value = Kodedc;
        //        //cmd.Parameters.Add(new OracleParameter("P_TGLPIC_AWAL", OracleDbType.Varchar2, 20, ParameterDirection.Input)).Value = tgl1;
        //        //cmd.Parameters.Add(new OracleParameter("P_TGLPIC_AKHIR", OracleDbType.Varchar2, 20, ParameterDirection.Input)).Value = tgl2;
        //        //cmd.Parameters.Add(new OracleParameter("P_TOKO_AWAL", OracleDbType.Varchar2, 10, ParameterDirection.Input)).Value = toko1;
        //        //cmd.Parameters.Add(new OracleParameter("P_TOKO_AKHIR", OracleDbType.Varchar2, 10, ParameterDirection.Input)).Value = toko2;
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar2, 30, ParameterDirection.Input)).Value = IP;

        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            hasil = cmd.ExecuteNonQuery();
        //        }
        //        return hasil;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        throw;
        //    }
        //}
        //internal static string Procedure_retprof(string namaProc, string dckode, string tgl1, string tgl2, string ip, string user)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + dckode + "', '" + tgl1 + "', '" + tgl2 + "', '" + ip + "', '" + user +  "', '')";
        //        //cmd.Parameters.Add(new OracleParameter("dckode", OracleDbType.Varchar2, 2000)).Value = dckode;
        //        //cmd.Parameters.Add(new OracleParameter("tgl1", OracleDbType.Date, 2000)).Value = tgl1;
        //        //cmd.Parameters.Add(new OracleParameter("tgl2", OracleDbType.Date, 2000)).Value = tgl2;
        //        //cmd.Parameters.Add(new OracleParameter("ip", OracleDbType.Varchar2, 2000)).Value = ip;
        //        //cmd.Parameters.Add(new OracleParameter("user", OracleDbType.Varchar2, 2000)).Value = user;
        //        //cmd.Parameters.Add(new OracleParameter("p_msg", OracleDbType.Varchar2, 2000)).Value = ParameterDirection.Output;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int hasil = cmd.ExecuteNonQuery();
        //        }
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}
        //internal static string Run_Proc_DCLISTNPB_VCR(string namaProc, DateTime p_tgl1, DateTime p_tgl2)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + p_tgl1 + "', '" + p_tgl2  + "')";
        //        //cmd.Parameters.Add(new OracleParameter("p_tgl1", OracleDbType.Date, 2000)).Value = p_tgl1;
        //        //cmd.Parameters.Add(new OracleParameter("p_tgl2", OracleDbType.Date, 2000)).Value = p_tgl2;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int x = cmd.ExecuteNonQuery();
        //        }
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}
        //internal static string Procedure_MasalahContainer(string namaProc, string tgl1, string tgl2, string user, string ip)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = namaProc.ToUpper();

        //        cmd.Parameters.Add(new SqlParameter("tgl_awal", SqlDbType.VarChar, 2000)).Value = tgl1;
        //        cmd.Parameters.Add(new SqlParameter("tgl_akhir", SqlDbType.VarChar, 2000)).Value = tgl2;
        //        cmd.Parameters.Add(new SqlParameter("user", SqlDbType.VarChar, 2000)).Value = user;
        //        cmd.Parameters.Add(new SqlParameter("ip", SqlDbType.VarChar, 2000)).Value = ip;
        //        cmd.Parameters.Add(new SqlParameter("status", SqlDbType.VarChar, 2000)).Direction = ParameterDirection.Output;

        //        cmd.Parameters[0].Direction = ParameterDirection.Input;
        //        cmd.Parameters[1].Direction = ParameterDirection.Input;
        //        cmd.Parameters[2].Direction = ParameterDirection.Input;
        //        cmd.Parameters[3].Direction = ParameterDirection.Input;
        //        cmd.Parameters[4].Value = "";

        //        //using(SqlConnection conn = new SqlConnection(SetConStr.constrSql))
        //        //{
        //        //    if (conn.State == ConnectionState.Open)
        //        //        conn.Close();
        //        //    else
        //        //        conn.Open();

        //        //    cmd.Connection = conn;
        //        //    int x = cmd.ExecuteNonQuery();
        //        //}
        //        int x = FuncEQ.ExecQuerySqlServer(cmd);
        //        return "Y";

        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw e;
        //        return "T";
        //    }
        //}
        //internal static int RunProcMonNRBSepihak(string namaProc, int kodelap, string tglawal, string tglakhir, string p_ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "(" + kodelap + ", '" + tglawal + "', '" + tglakhir + "', '" + p_ip + "')";
        //        //cmd.Parameters.Add(new OracleParameter("p_kodelap", OracleDbType.Varchar2, 10, ParameterDirection.Input)).Value = dckode;
        //        //cmd.Parameters.Add(new OracleParameter("p_tglawal", OracleDbType.Date, 20, ParameterDirection.Input)).Value = tglawal;
        //        //cmd.Parameters.Add(new OracleParameter("p_tglakhir", OracleDbType.Date, 20, ParameterDirection.Input)).Value = tglakhir;
        //        //cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar2, 10, ParameterDirection.Input)).Value = p_ip;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int x = cmd.ExecuteNonQuery();

        //            return x;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        throw;
        //    }
        //}

        //internal static string Run_Proc_DCRCTKNRBNO(string namaProc, string p_nodoc, string p_tgldoc, string p_lokid, string p_IP)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = $@"CALL {namaProc.ToUpper()}('{p_nodoc}','{p_tgldoc}','{p_lokid}','{p_IP}')";
        //        cmd.Parameters.Add(new OracleParameter("p_nodoc", OracleDbType.Varchar, 2000)).Value = p_nodoc;
        //        cmd.Parameters.Add(new OracleParameter("p_tgldoc", OracleDbType.Varchar, 2000)).Value = p_tgldoc;
        //        cmd.Parameters.Add(new OracleParameter("p_lokid", OracleDbType.Varchar, 2000)).Value = p_lokid;
        //        cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 2000)).Value = p_IP;
        //        FuncEQ.ExecQueryPostgres(cmd);
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string RunProcedureLPR_SLS_GUDANG_SEWA_PROC(string tglAwal, string tglAkhir, string tglProses, string jenis, string persentaseBawah)
        //{
        //    string msg_out = "";
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL Cetak_Sesional_Perplu('" + tglAwal + "','" + tglAkhir + "','" + tglProses + "','')";
        //        //cmd.Parameters.Add(new OracleParameter("p_awal", OracleDbType.Varchar, 2000, ParameterDirection.Input)).Value = tglAwal;
        //        //cmd.Parameters.Add(new OracleParameter("p_akhir", OracleDbType.Varchar, 2000, ParameterDirection.Input)).Value = tglAkhir;
        //        //cmd.Parameters.Add(new OracleParameter("v_proses", OracleDbType.Varchar, 2000, ParameterDirection.Input)).Value = tglProses;
        //        cmd.Parameters.Add(new OracleParameter("c_sqlerrm", OracleDbType.Varchar, 2000, "", ParameterDirection.Output, false, 0, 0, DataRowVersion.Current, null));
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int x = cmd.ExecuteNonQuery();

        //            if (!DBNull.Value.Equals(cmd.Parameters[0].Value) && cmd.Parameters[0].Value.ToString() != "null")
        //            {
        //                msg_out = cmd.Parameters[0].Value.ToString();
        //            }
        //        }
        //        return msg_out;
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw e;
        //    }
        //}

        //internal static string RunProcedure_Stok_toko_Perplu(string namaProc, string dc, string plu, string tgl1, string tgl2, string ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + dc + "'," + plu + ",'" + tgl1 + "','" + tgl2 + "','" + ip + "','')";
        //        //cmd.Parameters.Add(new OracleParameter("p_dckode", OracleDbType.Varchar, 2000)).Value = dc;
        //        //cmd.Parameters.Add(new OracleParameter("p_pluid", OracleDbType.Bigint, 10)).Value = plu;
        //        //cmd.Parameters.Add(new OracleParameter("p_awal", OracleDbType.Varchar, 2000)).Value = tgl1;
        //        //cmd.Parameters.Add(new OracleParameter("p_akhir", OracleDbType.Varchar, 2000)).Value = tgl2;
        //        //cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 2000)).Value = ip;
        //        cmd.Parameters.Add(new OracleParameter("p_result", OracleDbType.Varchar, 2000)).Direction = ParameterDirection.Output;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int x = cmd.ExecuteNonQuery();
        //            string hasil = cmd.Parameters["p_result"].Value.ToString();
        //            if (hasil != "")
        //            {
        //                return hasil;
        //            }
        //        }
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        throw e;
        //    }
        //}
        //internal static string Run_Proc_BagiRata(string namaProc, string Tgl1, string Tgl2, string IP)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + Tgl1 + "'," + Tgl2 + ",'" + IP + "')";
        //        //cmd.Parameters.Add(new OracleParameter("P_TGLPIC_AWAL", OracleDbType.Varchar2, 2000)).Value = Tgl1;
        //        //cmd.Parameters.Add(new OracleParameter("P_TGLPIC_AKHIR", OracleDbType.Varchar2, 2000)).Value = Tgl2;
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar2, 2000)).Value = IP;
        //        using (OracleConnection conn = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            conn.Open();
        //            cmd.Connection = conn;
        //            int hasil = cmd.ExecuteNonQuery();
        //        }
        //        //int hasil = FuncEQ.ExecQueryOracle(cmd);
        //        return "Y";
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //        return "T";
        //    }
        //}

        //internal static string Run_Proc_DC_TRF_F(string namaProc, string p_dc, string p_toko, string p_tgl1, string p_tgl2, string p_ip)
        //{
        //    try
        //    {

        //        OracleCommand cmd = new OracleCommand();
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "(:p_dc,:p_toko,:p_tgl1,:p_tgl2,:p_ip)";
        //        cmd.Parameters.Add(new OracleParameter("p_dc", OracleDbType.Text, 2000)).Direction = ParameterDirection.Input;
        //        cmd.Parameters["p_dc"].Value = p_dc;
        //        cmd.Parameters.Add(new OracleParameter("p_toko", OracleDbType.Text, 2000)).Direction = ParameterDirection.Input;
        //        if (string.IsNullOrEmpty(p_toko))
        //        {
        //            cmd.Parameters["p_toko"].Value = DBNull.Value;
        //        }
        //        else
        //        {
        //            cmd.Parameters["p_toko"].Value = p_toko;
        //        }
                
        //        cmd.Parameters.Add(new OracleParameter("p_tgl1", OracleDbType.Text, 2000)).Direction = ParameterDirection.Input;
        //        cmd.Parameters["p_tgl1"].Value = p_tgl1;
        //        cmd.Parameters.Add(new OracleParameter("p_tgl2", OracleDbType.Text, 2000)).Direction = ParameterDirection.Input;
        //        cmd.Parameters["p_tgl2"].Value = p_tgl2;
        //        cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Text, 2000)).Direction = ParameterDirection.Input;
        //        cmd.Parameters["p_ip"].Value = p_ip;
        //        int x = FuncEQ.ExecQueryPostgres(cmd);

        //        if(x != 0)
        //        {
        //            return "Y";
        //        }
        //        else
        //        {
        //            return "N";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string RunProcedureWaktuNilai(string namaProc, string tgl1, string tgl2)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "" + namaProc.ToUpper() + "";
        //        // cmd.Parameters.Add(new OracleParameter("P_TGL_AWAL", OracleDbType.Date, 2000)).Value = tgl1;
        //        // cmd.Parameters.Add(new OracleParameter("P_TGL_AKHIR ", OracleDbType.Date, 2000)).Value = tgl2;
        //        FuncEQ.ExecQueryPostgres(cmd);
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string Run_Proc_DC_TRF(string namaProc, string dcKode, string toko, string tgl1, string tgl2, string ip)
        //{
        //    try
        //    {
        //        int x = 0;
        //        OracleCommand cmd = new OracleCommand();
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + dcKode + "', '" + toko + "', '" + tgl1 + "', '" + tgl2 + "', '" + ip + "')";
        //        //cmd.Parameters.Clear();
        //        //cmd.Parameters.Add(new OracleParameter("p_dc", OracleDbType.Varchar, 2000)).Value = dcKode;
        //        //cmd.Parameters.Add(new OracleParameter("p_toko", OracleDbType.Varchar, 2000)).Value = toko;
        //        //cmd.Parameters.Add(new OracleParameter("p_tgl1", OracleDbType.Varchar, 2000)).Value = tgl1;
        //        //cmd.Parameters.Add(new OracleParameter("p_tgl2", OracleDbType.Varchar, 2000)).Value = tgl2;
        //        //cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 2000)).Value = ip;
        //        using(OracleConnection conn = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            conn.Open();
        //            cmd.Connection = conn;
        //            x = cmd.ExecuteNonQuery();
        //        }

        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static int RunProcLapPdgBkr(string namaProc, int dckode, string tglawal, string tglakhir, string p_ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = namaProc;
        //        cmd.Parameters.Add(new OracleParameter("p_dc", OracleDbType.Varchar, 10)).Value = dckode;
        //        cmd.Parameters.Add(new OracleParameter("p_tglawal", OracleDbType.Date, 20)).Value = tglawal;
        //        cmd.Parameters.Add(new OracleParameter("p_tglakhir", OracleDbType.Date, 20)).Value = tglakhir;
        //        cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 10)).Value = p_ip;

        //        return FuncEQ.ExecQueryPostgres(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        throw;
        //    }
        //}

        //internal static string RunProcPendingBongkar(string namaProc, string kodedc, string tglawl, string tglakh, string ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "" + namaProc.ToUpper() + "";
        //        cmd.Parameters.Add(new OracleParameter("p_dc", OracleDbType.Varchar, 2000)).Value = kodedc;
        //        cmd.Parameters.Add(new OracleParameter("p_tglawal", OracleDbType.Date, 2000)).Value = tglawl;
        //        cmd.Parameters.Add(new OracleParameter("p_tglakhir", OracleDbType.Date, 2000)).Value = tglakh;
        //        cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar, 2000)).Value = ip;
        //        int x = FuncEQ.ExecQueryPostgres(cmd);
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string Run_Proc_LapPdgBkr(string namaProc, string dcKode, string TglAwal, string TglAkhir, string IP)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "" + namaProc.ToUpper() + "";
        //        cmd.Parameters.Add(new OracleParameter("P_DC", OracleDbType.Varchar, 2000)).Value = dcKode;
        //        cmd.Parameters.Add(new OracleParameter("P_TGLAWAL", OracleDbType.Varchar, 2000)).Value = TglAwal;
        //        cmd.Parameters.Add(new OracleParameter("P_TGLAKHIR", OracleDbType.Varchar, 2000)).Value = TglAkhir;
        //        cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar, 2000)).Value = IP;
        //        FuncEQ.ExecQueryPostgres(cmd);
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string Run_Proc_DCSERVICE_LEVEL_PB(string namaProc, string p_tgl1, string p_tgl2, string p_tag, string p_toko, string p_dckode, string p_ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "" + namaProc.ToUpper() + "";
        //        cmd.Parameters.Add(new OracleParameter("P_TGL1", OracleDbType.Varchar, 2000)).Value = p_tgl1;
        //        cmd.Parameters.Add(new OracleParameter("P_TGL2", OracleDbType.Varchar, 2000)).Value = p_tgl2;
        //        cmd.Parameters.Add(new OracleParameter("P_TAG", OracleDbType.Varchar, 2000)).Value = p_tag;
        //        cmd.Parameters.Add(new OracleParameter("P_TOKO", OracleDbType.Varchar, 2000)).Value = p_toko;
        //        cmd.Parameters.Add(new OracleParameter("P_DCKODE", OracleDbType.Varchar, 2000)).Value = p_dckode;
        //        cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar, 2000)).Value = p_ip;
        //        FuncEQ.ExecQueryPostgres(cmd);
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string RunCETAK_DAFTAR_SUPPLIER(string tanggal1, string tanggal2, string sSupco)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = $@"CALL {"CETAK_DAFTAR_SUPPLIER".ToUpper()}('{sSupco}','{tanggal1}','{tanggal2}')";
        //        cmd.Parameters.Add(new OracleParameter("p_supco", OracleDbType.Varchar, 2000)).Value = sSupco;
        //        cmd.Parameters.Add(new OracleParameter("p_tgllow", OracleDbType.Varchar, 2000)).Value = tanggal1;
        //        cmd.Parameters.Add(new OracleParameter("p_tglhigh", OracleDbType.Varchar, 2000)).Value = tanggal2;
        //        FuncEQ.ExecQueryPostgres(cmd);
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string RunProc_LapPdgBkr(string namaProc, string dcKode, string tglAwal, string tglAkhir, string ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = $"CALL {namaProc.ToUpper()}('{dcKode}', '{tglAwal}', '{tglAkhir}', '{ip}')";
        //        //cmd.Parameters.Add(new OracleParameter("P_DC", OracleDbType.Varchar, 2000)).Value = dcKode;
        //        //cmd.Parameters.Add(new OracleParameter("P_TGLAWAL", OracleDbType.Varchar, 2000)).Value = tglAwal;
        //        //cmd.Parameters.Add(new OracleParameter("P_TGLAKHIR", OracleDbType.Varchar, 2000)).Value = tglAkhir;
        //        //cmd.Parameters.Add(new OracleParameter("P_IP", OracleDbType.Varchar, 2000)).Value = ip;
        //         using (OracleConnection conn = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            conn.Open();
        //            cmd.Connection = conn;
        //            int hasil = cmd.ExecuteNonQuery();
        //        }
        //        //int hasil = FuncEQ.ExecQueryOracle(cmd);
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}
        //internal static string lapnpbhighimpact(string namaProc, string dckode, string tglawl, string tglakh, string user)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + dckode + "', '" + tglawl + "', '" + tglakh + "', '" + user + "', '')";
        //        //cmd.Parameters.Add(new OracleParameter("p_tgl1", OracleDbType.Date, 2000)).Value = p_tgl1;
        //        //cmd.Parameters.Add(new OracleParameter("p_tgl2", OracleDbType.Date, 2000)).Value = p_tgl2;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int x = cmd.ExecuteNonQuery();
        //        }
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}

        //internal static string run_Trend_Cluster(string namaProc, string bulantahun)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "" + namaProc.ToUpper() + "";
        //        cmd.Parameters.Add(new OracleParameter("p_blnthn", OracleDbType.Varchar, 2000)).Value = bulantahun;
        //        int x = FuncEQ.ExecQueryPostgres(cmd);
        //        return "Y";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return "T";
        //    }
        //}
        //internal static int RunProcListUsulNRBSepihak(string namaProc, int kodelap, string tglawal, string tglakhir, string p_ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "(" + kodelap + ", '" + tglawal + "', '" + tglakhir + "', '" + p_ip + "')";
        //        //cmd.Parameters.Add(new OracleParameter("p_kodelap", OracleDbType.Varchar2, 10, ParameterDirection.Input)).Value = dckode;
        //        //cmd.Parameters.Add(new OracleParameter("p_tglawal", OracleDbType.Date, 20, ParameterDirection.Input)).Value = tglawal;
        //        //cmd.Parameters.Add(new OracleParameter("p_tglakhir", OracleDbType.Date, 20, ParameterDirection.Input)).Value = tglakhir;
        //        //cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar2, 10, ParameterDirection.Input)).Value = p_ip;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int x = cmd.ExecuteNonQuery();
        //            return x;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        throw;
        //    }
        //}

        //internal static int Proc_Resiko_StokOut(string namaProc, string DCID, string tgl, string tag, string p_ip)
        //{
        //    try
        //    {
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "CALL " + namaProc.ToUpper() + "('" + DCID + "', '" + tgl + "', '" + tag + "', '" + p_ip + "')";
        //        //cmd.Parameters.Add(new OracleParameter("p_kodelap", OracleDbType.Varchar2, 10, ParameterDirection.Input)).Value = dckode;
        //        //cmd.Parameters.Add(new OracleParameter("p_tglawal", OracleDbType.Date, 20, ParameterDirection.Input)).Value = tglawal;
        //        //cmd.Parameters.Add(new OracleParameter("p_tglakhir", OracleDbType.Date, 20, ParameterDirection.Input)).Value = tglakhir;
        //        //cmd.Parameters.Add(new OracleParameter("p_ip", OracleDbType.Varchar2, 10, ParameterDirection.Input)).Value = p_ip;
        //        using (OracleConnection connection = new OracleConnection(SetConStr.constrPostgres))
        //        {
        //            cmd.Connection = connection;
        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            int x = cmd.ExecuteNonQuery();
        //            return x;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //        throw;
        //    }
        //}
    }
}