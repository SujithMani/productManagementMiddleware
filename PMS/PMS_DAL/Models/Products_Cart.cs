using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS_DAL.Models
{
    public class Products_Cart
    {
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Amount { get; set; }
        public int? UserId { get; set; }
        public DateTime Added_Cart_Date { get; set; }
        public string In_Cart_Status { get; set; }
    }
}