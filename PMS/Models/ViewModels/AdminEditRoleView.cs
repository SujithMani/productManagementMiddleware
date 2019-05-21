using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class AdminEditRoleView
    {
        public RoleView roles { get; set; }
        public int AdminUserId { get; set; }
    }
}
