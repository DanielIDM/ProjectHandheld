using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHandheld.Models.DBConnection
{
    public class SiteSettings
    {
        public static string ConnectionString
        {
            get { return "DATA SOURCE=VOLVOSIM_46.53;PASSWORD=dcg001;persist security info=True;USER ID=MCGDATA1;"; }
        }
    }
}
