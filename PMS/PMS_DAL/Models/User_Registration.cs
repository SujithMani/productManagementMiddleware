using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class User_Registration
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string User_Name { get; set; }
        public string User_Email_Id { get; set; }
        public string User_Address { get; set; }
        public string Phone_Number { get; set; }
        public string User_Password { get; set; }
    }
}