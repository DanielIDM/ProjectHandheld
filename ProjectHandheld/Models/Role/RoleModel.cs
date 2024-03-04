using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LISMVC.Models.Role
{
    public class RoleModel
    {
        public string ROLE_FK_USER_NAME { get; set; }
        public string ROLE_FK_GROUP_NAME { get; set; }
    }

    public class Roles
    {
        public string ROLE_NAME { get; set; }
    }

    //get roles for specific user
    public class UserRoles
    {
        public string ROLE_NAME { get; set; }
    }

    //GET ALL USER FROM DC_USER_T
    public class AllUser
    {
        public string USER_NAME { get; set; }
    }
}