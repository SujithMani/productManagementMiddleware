﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Clients_ViewModels
{
    public class User_Login_View
    {
       
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Enter User Name")]
        [Display(Name = "Username")]
        public string User_Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Invalid Password entered")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string User_Password { get; set; }
    }
}
