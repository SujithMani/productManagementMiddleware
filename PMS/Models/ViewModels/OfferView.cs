using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class OfferView
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public ICollection<OfferProductView> OfferProducts { get; set; }
    }
}