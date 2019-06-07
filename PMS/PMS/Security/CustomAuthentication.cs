using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Security
{
    public class CustomAuthentication : AuthorizeAttribute
    {
        public string Role { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            string CurrentUserRole = "Admin";
            if (this.Role.Contains(CurrentUserRole))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}