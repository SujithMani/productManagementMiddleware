using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class MainCategoryView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public ICollection<MainCategoryProductView> MainCategoryProducts { get; set; }
    }
}