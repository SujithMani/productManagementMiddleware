using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models.ViewModels
{
    public class ProductCategoryView
    {
        public ProductView product { get; set; }
        public List<MainCategoryView> category { get; set; }
    }
}
