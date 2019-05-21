using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class AdminCreateRequestView
    {
        public AdminDetailsVIew adminDetails { get; set; }
        public int[] roles { get; set; }
    }
}
