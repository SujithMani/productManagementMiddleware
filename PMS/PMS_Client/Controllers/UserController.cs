using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.ViewModels.Clients_ViewModels;
using PMS_SERVICE.Services;

namespace PMS_Client.Controllers
{
    public class UserController : Controller
    {
        private Client_ManagementService reg = new Client_ManagementService();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {          
            return View();
        }

        [HttpPost]
       // [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(User_Login_View user_Login)
        {
            if (ModelState.IsValid)
            {
                bool res = reg.Login_User(user_Login);

                  if (res == true)
                {
                    User_Registration_View user_Login2 = new User_Registration_View();
                    user_Login2 = reg.User_By_Username(user_Login.User_Name);


                    //var profileData = new User_Login_View
                    //{
                    //    User_Name = user_Login.User_Name,
                    //    User_Email_Id = user_Login.User_Email_Id,
                    //    Phone_Number = user_Login.Phone_Number
                    //};
                    //  this.Session["Login"] = user_Login.User_Name;
                   
                    Session["Login"] = user_Login.User_Name;
                    Session["Email"] = user_Login2.User_Email_Id;
                    Session["Mobile"] = user_Login2.Phone_Number;
                    return View();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid credentials");
                    return View(user_Login);
                }
                
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials");
                return View(user_Login);
            }
           
        }

       
        #region Register

        //
        //GET:/User/Registration
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        //
        //POST:/User/Registration
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User_Registration_View user_Registration)
        {
                if(ModelState.IsValid)
            {
                bool res = reg.InsertData(user_Registration);
                if (res==true)
                {
                    
                }
                else
                {

                }
            }
            return View(user_Registration);
        }

        #endregion


    }
}
