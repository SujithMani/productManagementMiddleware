using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class OfferProduct
    {
        public int Id { get; set; }
        [ForeignKey("Offer")]
        public int OfferId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public  virtual Offer Offer { get; set; }
        public virtual Product Product { get; set; }
    }
}