using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Sku { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public int Prize { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public int InvokerStatus { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<OfferProduct> OfferProducts { get; set; }
    }
}