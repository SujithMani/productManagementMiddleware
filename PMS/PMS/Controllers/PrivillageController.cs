using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.ViewModels;
using PMS_SERVICE.Services;

namespace PMS.Controllers
{
    public class PrivillageController : Controller
    {
        private PrivillageService privillageService = new PrivillageService();
        // GET: Privillage
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                List<PrivilegeView> privilegeViews = privillageService.GetAllPrivillages();
                return View("Index", "_LayoutAdmin", privilegeViews);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: Privillage/Details/5
        public ActionResult Details(int id)
        {
            if (Session["username"] != null)
            {
                PrivilegeView privilegeView = privillageService.GetSinglePrivillege(id);
                return View("Details", "_LayoutAdmin", privilegeView);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // GET: Privillage/Create
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

        // POST: Privillage/Create
        [HttpPost]
        public ActionResult Create(PrivilegeView privilegeView)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add insert logic here
                    if (ModelState.IsValid)
                    {
                        bool result = privillageService.InsertPrivillage(privilegeView);
                        if (result)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Create", "_LayoutAdmin", privilegeView);
                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Something happened");
                        return View("Create", "_LayoutAdmin", privilegeView);
                    }

                }
                catch(Exception e)
                {
                    return View("Create", "_LayoutAdmin", privilegeView);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Privillage/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["username"] != null)
            {
                PrivilegeView privilegeView = privillageService.GetSinglePrivillege(id);
                return View("Edit", "_LayoutAdmin",privilegeView);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Privillage/Edit/5
        [HttpPost]
        public ActionResult Edit(PrivilegeView privilegeView)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add insert logic here
                    if (ModelState.IsValid)
                    {
                        bool result = privillageService.InsertPrivillage(privilegeView);
                        if (result)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Edit", "_LayoutAdmin", privilegeView);
                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Something happened");
                        return View("Edit", "_LayoutAdmin", privilegeView);
                    }

                }
                catch (Exception e)
                {
                    return View("Edit", "_LayoutAdmin", privilegeView);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Privillage/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["username"] != null)
            {
                bool result = privillageService.DeletePrivillage(id);
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

        // POST: Privillage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
