using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LISMVC.Models.Issuing
{
    public class ReportParam
    {
        [Required]
        [Display(Name = "Kode DC")]
        public String kodedc { get; set; }
        [Required]
        [Display(Name = "Tanggal Dari :")]
        public DateTime startdate { get; set; }
        [Required]
        [Display(Name = "Tanggal Sampai :")]
        public DateTime enddate { get; set; }
    }

    // untuk parameter multiple nik driver WaktuTungguDeliveryDriver
    public class multipleNikModel
    {
        public string nikDriver { get; set; }
        public string namaDriver { get; set; }
    }
    public class checkedNikList
    {
        //use CheckBoxModel class as list
        public List<multipleNikModel> nikList { get; set; }
    }

    public class SupirModel
    {
        public string nik { get; set; }
        public string nama { get; set; }
        public string niknama { get; set; }
    }
}