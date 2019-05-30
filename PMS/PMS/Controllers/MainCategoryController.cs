using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS_SERVICE.Services;
using Models.ViewModels;

namespace PMS.Controllers
{
    public class MainCategoryController : Controller
    {
        private MainCategorySevice mainCategorySevice = new MainCategorySevice();
        // GET: Privillage
        public ActionResult Index()
        {
            List<MainCategoryView> MainCategoryViews = mainCategorySevice.GetAllMainCategory();
            return View("Index", "_LayoutAdmin", MainCategoryViews);
        }

        // GET: Privillage/Details/5
        public ActionResult Details(int id)
        {
            if (Session["username"] != null)
            {
                MainCategoryView MainCategoryView = mainCategorySevice.GetSingleMainCategory(id);
                return View("Details", "_LayoutAdmin", MainCategoryView);
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
        public ActionResult Create(MainCategoryView MainCategoryView)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add insert logic here
                    if (ModelState.IsValid)
                    {
                        bool result = mainCategorySevice.InsertMainCategory(MainCategoryView);
                        if (result)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Create", "_LayoutAdmin", MainCategoryView);
                        }

                    }
                    else
                    {
                        return View("Create", "_LayoutAdmin", MainCategoryView);
                    }

                }
                catch (Exception e)
                {
                    return View("Create", "_LayoutAdmin", MainCategoryView);
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
                MainCategoryView MainCategoryView = mainCategorySevice.GetSingleMainCategory(id);
                return View("Edit", "_LayoutAdmin", MainCategoryView);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Privillage/Edit/5
        [HttpPost]
        public ActionResult Edit(MainCategoryView MainCategoryView)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add insert logic here
                    if (ModelState.IsValid)
                    {
                        bool result = mainCategorySevice.InsertMainCategory(MainCategoryView);
                        if (result)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Edit", "_LayoutAdmin", MainCategoryView);
                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Something happened");
                        return View("Edit", "_LayoutAdmin", MainCategoryView);
                    }

                }
                catch (Exception e)
                {
                    return View("Edit", "_LayoutAdmin", MainCategoryView);
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
                bool result = mainCategorySevice.DeleteMainCategory(id);
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
