using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class PrivilegeView
    {
        public int Id { get; set; }
        public string PrivilegeName { get; set; }
        public virtual ICollection<AdminUserPrivilegeView> AdminUserPrivileges { get; set; }
        public virtual ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}