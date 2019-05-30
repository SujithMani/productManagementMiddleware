using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ProductCreateRequestView
    {
        public ProductView product { get; set; }
        public int[] category { get; set; }
    }
}
