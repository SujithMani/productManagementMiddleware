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
                if(res==true)
                {
                    //TempData["Login"] = "user_Login:{0}";
                    return RedirectToAction("Registration");
                }
                else
                {

                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials");
                return View(user_Login);
            }
            return View(user_Login);
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
