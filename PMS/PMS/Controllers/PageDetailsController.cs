using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.ViewModels;

namespace PMS.Controllers
{
    public class PageDetailsController : Controller
    {
        // GET: PageDetails
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: PageDetails/Details/5
        public ActionResult Details(int id)
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: PageDetails/Create
        public ActionResult Create()
        {
            if (Session["username"] != null)
            {
                return View("Create", "_LayoutAdmin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: PageDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PageDetailsView pageDetails)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: PageDetails/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: PageDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: PageDetails/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: PageDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
