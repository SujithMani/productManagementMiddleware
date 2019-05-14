using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMS_DAL.Models
{
    public class User_Registration
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your First Name ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Enter your Last Name/ Initial ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter User Name")]
        public string User_Name { get; set; }
        [Required(ErrorMessage = "Enter Email ID")]
        public string User_Email_Id { get; set; }
        [Required(ErrorMessage = "Enter User Address")]
        public string User_Address { get; set; }
        [Required(ErrorMessage = "Incorrect Phone Number")]
        public string Phone_Number { get; set; }
        [Required(ErrorMessage = "Enter a password with capital letter, alphanumeric character and punctuations")]
        public string User_Password { get; set; }
        [Required(ErrorMessage = "Enter password to Confirm ")]
        [NotMapped()]
        public string Confirm_Password { get; set; }
        [Required(ErrorMessage ="Enter Date of Birth ")]
        [DataType(DataType.DateTime)]
        public DateTime? Date_Of_Birth { get; set; }
    }
}