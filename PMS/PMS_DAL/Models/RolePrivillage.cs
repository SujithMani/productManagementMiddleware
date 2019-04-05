using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMS_DAL.Models
{
    public class RolePrivilege
    {
        public int Id { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [ForeignKey("Privilege")]
        public int PrivilegeId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Privilege Privilege{ get; set; }
    }
}