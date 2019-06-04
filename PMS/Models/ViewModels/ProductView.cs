using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class ProductView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Sku Required")]
        public int Sku { get; set; }
        [Required(ErrorMessage = "Keyword Required")]
        public string Keyword { get; set; }
        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price Required")]
        public int Prize { get; set; }
        [DisplayName("Upload File")]
        public string Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public int Status { get; set; }
        public int InvokerStatus { get; set; }
        public virtual ICollection<MainCategoryProductView> MainCategoryProducts { get; set; }
        public virtual ICollection<OfferProductView> OfferProducts { get; set; }
    }
}