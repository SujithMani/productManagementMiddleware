using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class MainCategoryView
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public ICollection<MainCategoryProductView> MainCategoryProducts { get; set; }
    }
}