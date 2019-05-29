using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS_DAL.Models
{
    public class Offer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Offer Description Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Amount Required")]
        public int DiscountAmount { get; set; }
        [Required(ErrorMessage = "Start Date Required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date Required")]
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public virtual ICollection<OfferProduct> OfferProducts { get; set; }
    }
}