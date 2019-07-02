using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Models.ViewModels.Clients_ViewModels
{
    public class User_Registration_View 
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage ="Enter you First Name") ]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Enter your Last Name/initial ")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Enter User Name")]
        [Display(Name ="Username")]
        public string User_Name { get; set; }
        [Required]
         [EmailAddress]
         [Display(Name ="Email ID")]
         public string User_Email_Id { get; set; }
        [Required]
        [DataType(DataType.MultilineText, ErrorMessage = "Enter User Address")]
        [Display(Name = "Address")]
        public string User_Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Incorrect Phone Number")]
        [Display(Name ="Phone No.")]
        public string Phone_Number { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Invalid Username or Password", MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string User_Password { get; set; }
        [Required]
        [Display(Name ="Confirm Password")]
        [Compare("User_Password", ErrorMessage = "The password and Confirmation password do not match")]
        public string Confirm_Password { get; set; }
        [Required]        
        [DataType(DataType.DateTime, ErrorMessage = "Entered Date of Birth is not proper")]
        [Display(Name ="Date of Birth")]
        public DateTime? Date_Of_Birth { get; set; }
    }
}

//[DataType(DataType.Password)]
//[Display(Name = "Password")]
//public string Password { get; set; }

//[DataType(DataType.Password)]
//[Display(Name = "Confirm password")]
// [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")] 