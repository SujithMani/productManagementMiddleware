using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS_DAL.Models
{
    public class MainCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public virtual ICollection<MainCategoryProduct> MainCategoryProducts { get; set; }
    }
}