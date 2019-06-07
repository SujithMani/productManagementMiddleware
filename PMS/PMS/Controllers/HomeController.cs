using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS_SERVICE.Services;
using PMS.Controllers;
using Models.ViewModels;
using System.Web.Security;

namespace PMS.Controllers
{
    public class HomeController : Controller
    {
        AdminDetailsService adminservice = new AdminDetailsService();
        public ActionResult Index()
        {
            //AdminDetailsService adminservice = new AdminDetailsService();
            //List<AdminDetails> adminDetails = adminservice.GetAdminDetails();
            //foreach(AdminDetails adm in adminDetails)
            //{
                
            //}
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginDetailsView user)
        {
            if(ModelState.IsValid)
            {
                var Name = user.Username;
                var Password = AdminController.Encrypt(user.Password, "sblw-3hn8-sqoy19");
                user.Password = Password;
                bool result = adminservice.GetAdminByNameAndPassword(user);
                if (result)
                {
                    Session["username"] = user.Username;
                    //FormsAuthentication.SetAuthCookie(user.Username, false);
                    //FormsAuthentication.SignOut();
                    return RedirectToAction("Home");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Credentials");
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
            

        }
        public ActionResult Home()
        {
            if(Session["username"] != null)
            {
                ViewBag.Message = "Your application description page." + Session["username"];

                return View("Home", "_LayoutAdmin");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult Logout()
         {
            if (Session["username"] != null)
            {
                Session.Remove("username");
                Session.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}