using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS_Client.Controllers
{
    public class RegistrationpageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            ViewBag.Message = "Registration Form";
            return View();
        }
    }
}