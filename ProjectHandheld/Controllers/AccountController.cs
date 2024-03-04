using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using LISMVC.Models;
using System.Diagnostics;
using System.Collections.Generic;
using LISMVC.Models.Role;
using Authorize;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using ProjectHandheld.Models.DBConnection;

namespace LISMVC.Controllers
{
    [CustomAuthorize]
    public class AccountController : Controller
    {

        public AccountController()
        {
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            string connectionString = SiteSettings.ConnectionString;
            OracleConnection conn = new OracleConnection(connectionString);

            conn.Open();
            OracleCommand cmd1 = new OracleCommand("SELECT PROPOSALNO_SEQ.NEXTVAL FROM dual", conn);
            cmd1.CommandType = CommandType.Text;
            var no = cmd1.ExecuteScalar();
            conn.Close();

            ViewBag.ReturnUrl = returnUrl;
            ViewBag.KodeDC = GetDCInfo.KodeDC;
            ViewBag.NamaDC = GetDCInfo.NamaDC;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            Session.Clear();
            ViewBag.KodeDC = GetDCInfo.KodeDC;
            ViewBag.NamaDC = GetDCInfo.NamaDC;
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AccountDBHandle acc = new AccountDBHandle();

            MasterUser masterUser = acc.CheckLogin(model);

            //var ident = new ClaimsIdentity(
            //    getClaims(masterUser.USER_NAMA, masterUser.key),
            //    CookieAuthenticationDefaults.AuthenticationScheme);
            //HttpContext.GetOwinContext().Authentication.SignIn(
            //   new AuthenticationProperties { IsPersistent = false }, ident);

            string IP = Request.UserHostAddress;

            //buat record login di DC_USER_LOGIN_RPT_H
            string insertUser = acc.InsertUserLogin(masterUser, IP);
            if (insertUser == "GAGAL")
            {
                ModelState.AddModelError("", "MEMASUKKAN DATA LOGIN KE DC_USER_LOGIN_RPT_H GAGAL");
                return View();
            }
            else
            {
                //tambah ke session
                Session.Add("JENIS_GUDANG", masterUser.cJENIS_GUDANG);
                Session.Add("USER_FLAG_HO", masterUser.USER_FLAG_HO);
                Session.Add("TGL_GANTI_PASSWORD", masterUser.TGL_GANTI_PASS);
                Session.Add("USER_NIK", masterUser.USER_NIK);
                Session.Add("USER_NAMA", masterUser.USER_NAMA);
                Session.Add("USER_UPDREC_ID", masterUser.USER_UPDREC_ID);
                Session.Add("DCI", masterUser.DCI);
                Session.Add("DC_KODE", masterUser.DC_KODE);
                Session.Add("DC_NAMA", masterUser.DC_NAMA);
                Session.Add("ID_DC", masterUser.ID_DC);
                Session.Add("nama_server", masterUser.nama_server);
                Session.Add("user_server", masterUser.USER_NAMA);
                Session.Add("pass_server", masterUser.pass_server);
                Session.Add("PASSLPM", "block");
                Session.Add("USER_ROLES", masterUser.USER_ROLES);

                Session["SS_USER"] = masterUser;

                //cek password valid days
                if (masterUser.TGL_GANTI_PASS < DateTime.Now)
                {
                    return RedirectToAction("ChangePassword");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userkey"></param>
        /// <returns></returns>
        //private Claim[] getClaims(string username, string userkey)
        //{
        //    List<Claim> claims = new List<Claim>();
        //    claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
        //    claims.Add(new Claim(ClaimTypes.Sid, userkey));
        //    foreach (UserRoles role in RoleDBHandle.GetRoles(username))
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role.ROLE_NAME));
        //        Debug.WriteLine("Isi role: " + role.ROLE_NAME);
        //    }
        //    Debug.WriteLine("Isi role: " + claims.ToArray());
        //    return claims.ToArray();
        //}

        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(FormCollection collection)
        {
            Debug.WriteLine("jalan");
            string newPass = collection["newpassword"];

            AccountDBHandle account = new AccountDBHandle();
            int result = account.UpdatePassword(newPass, Session["USER_NAMA"].ToString());

            if (result > 0)
            {
                TempData["ChangePassword"] = "Success";
            }

            Debug.WriteLine("Password baru: " + newPass + "\n User: " + Session["USER_NAMA"].ToString());
            return RedirectToAction("LogOff", "Account");
        }


        // POST: /Account/LogOff
        public ActionResult LogOff()
        {
            Session.Clear();
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }


        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}

        //private void AddErrors(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //}

        //private ActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        //internal class ChallengeResult : HttpUnauthorizedResult
        //{
        //    public ChallengeResult(string provider, string redirectUri)
        //        : this(provider, redirectUri, null)
        //    {
        //    }

        //    public ChallengeResult(string provider, string redirectUri, string userId)
        //    {
        //        LoginProvider = provider;
        //        RedirectUri = redirectUri;
        //        UserId = userId;
        //    }

        //    public string LoginProvider { get; set; }
        //    public string RedirectUri { get; set; }
        //    public string UserId { get; set; }

        //    public override void ExecuteResult(ControllerContext context)
        //    {
        //        var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
        //        if (UserId != null)
        //        {
        //            properties.Dictionary[XsrfKey] = UserId;
        //        }
        //        context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
        //    }
        //}
        #endregion
    }
}