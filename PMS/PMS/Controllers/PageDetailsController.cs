using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.ViewModels;
using PMS_SERVICE.Services;
namespace PMS.Controllers
{
    public class PageDetailsController : Controller
    {
        private AdminDetailsService adminDetailsService = new AdminDetailsService();
        // GET: PageDetails
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                List<PageDetailsView> pageDetails = adminDetailsService.GetAllPageDetails();
                return View("Index","_LayoutAdmin", pageDetails);
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
                PageDetailsView pageDetails = adminDetailsService.GetSinglePageDetails(id);
                return View("Details", "_LayoutAdmin", pageDetails);
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
                    if(ModelState.IsValid)
                    {
                        bool result = adminDetailsService.InsertPageDetails(pageDetails); 
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Something happened");
                        return View(pageDetails);
                    }
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
                PageDetailsView pageDetails = adminDetailsService.GetSinglePageDetails(id);
                return View("Edit","_LayoutAdmin", pageDetails);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: PageDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(PageDetailsView pageDetails)
        {
            if (Session["username"] != null)
            {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            bool result = adminDetailsService.InsertPageDetails(pageDetails);
                        }
                        else
                        {
                        ModelState.AddModelError(string.Empty, "Something happened");
                            return View("_LayoutAdmin",pageDetails);
                        }
                        // TODO: Add insert logic here

                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return RedirectToAction("Index");
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
                bool result = adminDetailsService.DeletePageDetails(id);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
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
