using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Product_Check_Out
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Offers { get; set; }
        public string Discount { get; set; }        
        public string Shipping_Charges { get; set; }
        public string TotalCharges { get;set; }
        public string DestPoint { get; set; }
    }
}