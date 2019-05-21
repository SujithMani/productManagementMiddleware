using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class MainCategoryProductView
    {
        public int Id { get; set; }
        [ForeignKey("MainCategory")]
        public int CategoryId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual MainCategoryView MainCategory { get; set; }
        public virtual ProductView Product { get; set; }
    }
}