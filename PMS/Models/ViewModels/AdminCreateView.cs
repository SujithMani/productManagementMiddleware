using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ViewModels;
using System.ComponentModel.DataAnnotations;
namespace Models.ViewModels
{
    public class AdminCreateView
    {
        public AdminDetailsVIew adminDetails{get; set;}
        public List<RoleView> roles { get; set; }
    }
}
