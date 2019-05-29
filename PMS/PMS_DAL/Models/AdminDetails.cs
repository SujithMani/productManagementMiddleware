using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMS_DAL.Models
{
    public class AdminDetails
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        public virtual ICollection<AdminUserRole> AdminUserRoles { get; set; }
        public virtual ICollection<AdminUserPrivilege> AdminUserPrivileges { get; set; }
    }
}