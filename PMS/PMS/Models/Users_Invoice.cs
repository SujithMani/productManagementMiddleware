using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Invoice
    {
        public string Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Price { get; set; }
        public DateTime Product_Purchase_Date { get; set; }
    }
}