using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS_SERVICE.Services;
using PMS_DAL.Models;
namespace PMS.Controllers
{
    public class HomeController : Controller
    {
        public List<AdminDetails> Index()
        {
            AdminDetailsService adminservice = new AdminDetailsService();
            List<AdminDetails> adminDetails = adminservice.GetAdminDetails();
            //foreach(AdminDetails adm in adminDetails)
            //{
                
            //}
            return adminDetails;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
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