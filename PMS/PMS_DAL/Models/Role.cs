using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS_DAL.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int Status { get; set; }
        public ICollection<AdminUserRole> AdminUserRoles { get;set; }
        public ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}