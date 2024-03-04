using Authorize;
using LISMVC.Models.Role;
using System.Diagnostics;
using System.Web.Mvc;

namespace LISMVC.Controllers
{
    [CustomAuthorize]
    public class RoleController : Controller
    {
        // GET: Role
        public PartialViewResult Index()
        {
            return PartialView(RoleDBHandle.GetUserRoles());
        }

        //GET: AddRole
        public ActionResult AddRole()
        {
            ViewBag.Users = RoleDBHandle.GetAllUsers();
            ViewBag.Roles = RoleDBHandle.GetRoles();
            return View();
        }

        //POST: AddRole
        [HttpPost]
        public ActionResult AddRole(FormCollection collection)
        {
            string user = collection["username"].ToString();
            string role = collection["rolename"].ToString();
            string updrecid = Session["USER_UPDREC_ID"].ToString();
            TempData["UserName"] = user;
            TempData["RoleName"] = role.Substring(role.LastIndexOf(".")+1);
            Debug.WriteLine(user + ", " + role + ", " + updrecid);

            if(!RoleDBHandle.IsAlreadyInRole(user, role))
            {
                int result = RoleDBHandle.AddRole(user, role, updrecid);
                Debug.WriteLine("Add Role: " + result);
                if (result > 0)
                {
                    TempData["AddRole"] = "Success";
                }
                else
                {
                    TempData["AddRole"] = "Failed";
                }
            }
            else
            {
                TempData["AddRole"] = "InRole";
            }

            return RedirectToAction("Index", "Role");
        }

        public ActionResult DeleteUserRole(string user, string role)
        {
            int result = RoleDBHandle.DeleteUserRole(user, role);

            TempData["UserName"] = user;
            TempData["RoleName"] = role;
            if (result > 0)
            {
                TempData["DeleteUserRole"] = "Success";
            }
            else
            {
                TempData["DeleteUserRole"] = "Failed";
            }

            return RedirectToAction("Index", "Role");
        }
    }
}