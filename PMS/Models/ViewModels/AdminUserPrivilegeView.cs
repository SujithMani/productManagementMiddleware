using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class AdminUserPrivilegeView
    {
        public int Id { get; set; }
        [ForeignKey("AdminDetail")]
        public int AdminUserId { get; set; }
        [ForeignKey("Privilege")]
        public int PrivilegeId { get; set; }
        public virtual AdminDetailsVIew AdminDetail { get; set; }
        public virtual PrivilegeView Privilege { get; set; }
    }
}