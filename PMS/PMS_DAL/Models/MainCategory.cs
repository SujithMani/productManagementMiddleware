using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class MainCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public ICollection<MainCategoryProduct> MainCategoryProducts { get; set; }
    }
}