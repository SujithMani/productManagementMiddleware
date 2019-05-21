using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class OfferProductView
    {
        public int Id { get; set; }
        [ForeignKey("Offer")]
        public int OfferId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public  virtual OfferView Offer { get; set; }
        public virtual ProductView Product { get; set; }
    }
}