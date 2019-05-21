using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class AdminEditView
    {
        public AdminDetailsVIew adminDetails { get; set; }
        public List<AdminEditRoleView> roles { get; set; }
    }
}
