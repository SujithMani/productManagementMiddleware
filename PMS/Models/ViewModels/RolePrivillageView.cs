using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class RolePrivilege
    {
        public int Id { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [ForeignKey("Privilege")]
        public int PrivilegeId { get; set; }
        public virtual RoleView Role { get; set; }
        public virtual PrivilegeView Privilege{ get; set; }
    }
}