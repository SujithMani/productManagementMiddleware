using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS_Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
           // Response.Redirect("~/Registration.aspx");
        }

        public ActionResult PMS()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Shoe()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Electronic()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Sneaker()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult HomeGadget()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Appliance()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Mobile()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult TandB()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Stationary()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult FandB()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
    }
}