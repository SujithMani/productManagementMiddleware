using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS_DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Sku Required")]
        public int Sku { get; set; }
        [Required(ErrorMessage = "Keyword Required")]
        public string Keyword { get; set; }
        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price Required")]
        public int Prize { get; set; }
        [Required(ErrorMessage = "Image Required")]
        public string Image { get; set; }
        public int Status { get; set; }
        public int InvokerStatus { get; set; }
        public virtual ICollection<MainCategoryProduct> MainCategoryProducts { get; set; }
        public virtual ICollection<OfferProduct> OfferProducts { get; set; }
    }
}