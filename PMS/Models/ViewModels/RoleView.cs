using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class RoleView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Role is Required")]
        public string RoleName { get; set; }
        public int Status { get; set; }
        public ICollection<AdminUserRole> AdminUserRoles { get;set; }
        public ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}