using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class AdminUserRole
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int AdminUserId { get; set; }
        [ForeignKey("Role")]
        public int AdminRoleId { get; set; }
        public virtual AdminDetails User { get; set; }
        public virtual Role Role { get; set; }

    }
}