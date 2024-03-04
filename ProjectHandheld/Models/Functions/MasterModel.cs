using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LISMVC.Models
{
    public class MasterModel
    {
    }

    public class Departemen
    {
        public string DEP_KODE { get; set; }
        public string DEP_NAMA { get; set; }
    }

    //RUDDY
    public class Zona
    {
        public string ZONA { get; set; }
        public string JENIS { get; set; }
    }

    public class PLU
    {
        public string PLU_KODE { get; set; }
        public string PLU_NAMA { get; set; }
        public string PLU_ID { get; set; }
        public string PLU_DES { get; set; }
    }

    public class Periode
    {
        public string PERIODE { get; set; }
        public string PERIODE_AWAL { get; set; }
        public string PERIODE_AKHIR { get; set; }
    }

    public class Divisi
    {
        public string DIV_KODE { get; set; }
        public string DIV_NAMA { get; set; }
    }

    public class Supplier
    {
        public string SUP_KODE { get; set; }
        public string SUP_NAMA { get; set; }
        public string SUP_SUPKODE { get; set; }
    }

    public class Kategori
    {
        public string KAT_KODE { get; set; }
        public string KAT_NAMA { get; set; }
    }

    //public class DC
    //{
    //    public string DC_ID { get; set; }
    //    public string DC_NAMA { get; set; }
    //    public String DC_KODE { get; set; }
    //}

    public class Depo
    {
        public string GUDANG_TYPE { get; set; }
        public string GUDANG_ID { get; set; }
    }

    public class Location
    {
        public string LOKASI_NAMA { get; set; }
        public string LOKASI_ID { get; set; }
    }

    public class TipeAlokasi
    {
        public string ID_ALOKASI { get; set; }
        public string NAMA_ALOKASI { get; set; }
    }

    public class TGL_NPB
    {
        public string P_TglNpbAwal { get; set; }
        public string P_TglNpbAkhir { get; set; }
    }

    public class NoNPB
    {
        public string HDR_HDR_ID { get; set; }
        public string NO_BPB { get; set; }
    }

    public class Toko
    {
        public string TOK_CODE { get; set; }
        public string TOK_NAME { get; set; }
        public string TOKO { get; set; }
    }

    public class DC
    {
        public string DC_ID { get; set; }
        public string DC_NAMA { get; set; }
        public String DC_KODE { get; set; }
    }

    public class ListDCModel
    {
        public string DC_ID { get; set; }
        public string DC_NAMA { get; set; }
        public string DC_KODE { get; set; }
    }

    public class TokoByDate
    {
        public string SEQ_NO_BA { get; set; }
    }

    public class Jns
    {
        public string KODE { get; set; }
        public string NAMA { get; set; }
    }
    
}