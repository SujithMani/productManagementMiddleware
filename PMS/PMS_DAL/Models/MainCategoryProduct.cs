using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class MainCategoryProduct
    {
        public int Id { get; set; }
        [ForeignKey("MainCategory")]
        public int CategoryId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual MainCategory MainCategory { get; set; }
        public virtual Product Product { get; set; }
    }
}