using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS_Client.Controllers
{
    public class RegistrationPage
    {
        [HttpPost]
        public ActionResult Login(User_Registration registration)
        {
            var Id = registration.Id;
            var FirstName = registration.FirstName;
            var LastName = registration.LastName;
            var User_Name=registration.User_Name;
            var User_Email_Id = registration.EmailID;
            var User_Address = registration.Address;
            var Phone_Number = registration.PhoneNumber;
            var User_Password = registration.Password;
        }
    }
}