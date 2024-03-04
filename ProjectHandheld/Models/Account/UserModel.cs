using LISMVC.Models.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LISMVC.Models
{
    public class UserModel
    {
        
    }
    public class MasterUser : UserStatus
    {
        public string key { get; set; }
        public string orirole { get; set; }
        public string oricabang { get; set; }
        public string oridc { get; set; }
        public string keterangan { get; set; }
    }

    public class UserStatus : Gudang
    {
        public string USER_PRIVS { get; set; }
        public string USER_NIK { get; set; }
        public string USER_NAMA { get; set; }
        public string USER_FLAG_HO { get; set; }
        public DateTime TGL_GANTI_PASS { get; set; }
        public string USER_UPDREC_ID { get; set; }
        public string DCI { get; set; }
        public string DC_KODE { get; set; }
        public string DC_NAMA { get; set; }
        public string ID_DC { get; set; }
        public string nama_server { get; set; }
        public string user_server { get; set; }
        public string pass_server { get; set; }
        public List<UserRoles> USER_ROLES { get; set; }
    }

    public class Gudang
    {
        public string cGUDANG_ID { get; set; }
        public string cGUDANG_KODE { get; set; }
        public string cGUDANG_NAMA { get; set; }
        public string cJENIS_GUDANG { get; set; }
    }

    //public class UserRole
    //{
    //    public string ROLE_FK_USER_NAME { get; set; }
    //    public string ROLE_FK_GROUP_NAME { get; set; }
    //}
}