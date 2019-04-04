using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public ICollection<OfferProduct> OfferProducts { get; set; }
    }
}