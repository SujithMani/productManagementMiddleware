using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class AdminUserRoleView
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int AdminUserId { get; set; }
        [ForeignKey("Role")]
        public int AdminRoleId { get; set; }
        public virtual AdminDetailsVIew User { get; set; }
        public virtual RoleView Role { get; set; }

    }
}