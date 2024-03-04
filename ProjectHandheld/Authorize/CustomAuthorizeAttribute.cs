using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LISMVC.Models;

namespace Authorize
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller  
                return;
            }

            bool ret = false;
            try
            {
                var infoUser = HttpContext.Current.Session["SS_USER"];
                if (infoUser != null)
                {
                    MasterUser mu = new MasterUser();
                    mu = (MasterUser)infoUser;
                    ret = mu.key == SetConStr.lokasi_kunci ? true : false;
                }
                else
                    ret = false;
            }
            catch (Exception ex)
            {
                ret = false;
            }

            // Check for authorization  
            if (!ret)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }
    }

    //public class CustomAuthorizeAttribute : AuthorizeAttribute
    //{

    //    protected override bool AuthorizeCore(HttpContextBase httpContextBase)
    //    {
    //        bool ret;
    //        if (!httpContextBase.User.Identity.IsAuthenticated)
    //            ret = false;
    //        try
    //        {
    //            var infoUser = httpContextBase.Session["SS_USER"];
    //            if (infoUser != null)
    //            {
    //                MasterUser mu = new MasterUser();
    //                mu = (MasterUser)infoUser;
    //                ret = mu.key == SetConStr.lokasi_kunci ? true : false;
    //            }
    //            else
    //                ret = false;
    //        }
    //        catch
    //        {
    //            ret = false;
    //        }

    //        if (!ret)
    //            removeallcookie();
    //        return ret;
    //    }

    //    private void removeallcookie()
    //    {
    //        string[] myCookies = HttpContext.Current.Request.Cookies.AllKeys;
    //        foreach (string cookie in myCookies)
    //        {
    //            HttpContext.Current.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
    //        }
    //    }

    internal class UserSession
    {
        public MasterUser mu;
        internal UserSession()
        {
            var infoUser = HttpContext.Current.Session["SS_USER"];
            try
            {
                mu = new MasterUser();
                mu = (MasterUser)infoUser;
            }
            catch (Exception ex)
            {
                mu.keterangan = ex.ToString();
            }
        }
    }
}

