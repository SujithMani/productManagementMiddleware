using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.ViewModels;
using PMS_SERVICE.Services;
using System.IO;

namespace PMS.Controllers
{
    public class ProductController : Controller
    {
        private MainCategorySevice categorySevice = new MainCategorySevice();
        private ProductService productService = new ProductService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ProductCategoryView product_cat = new ProductCategoryView();
            if (Session["username"] != null)
            {
                List<MainCategoryView> category = categorySevice.GetAllMainCategory();
                product_cat.category = category;
                return View("Create", "_LayoutAdmin", product_cat);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateRequestView categoryView)
        {
            ProductCategoryView product_cat = new ProductCategoryView();
            if (Session["username"] != null)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        string filename = Path.GetFileNameWithoutExtension(categoryView.product.ImageFile.FileName);
                        string extension = Path.GetExtension(categoryView.product.ImageFile.FileName);
                        filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                        int res = productService.InsertProduct(categoryView.product);
                        if (res != 0)
                        {
                            int adminId = res;
                            foreach (int role in categoryView.category)
                            {
                                MainCategoryProductView categoryProductView = new MainCategoryProductView { CategoryId = role, ProductId = adminId };
                                bool result = productService.InsertProductCategory(categoryProductView);
                                if (result)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            List<MainCategoryView> categories = categorySevice.GetAllMainCategory();
                            product_cat.category = categories;
                            ModelState.AddModelError(string.Empty, "Something happend");
                            return View("Create", "_LayoutAdmin", product_cat);
                        }


                    }
                    else
                    {
                        List<MainCategoryView> categories = categorySevice.GetAllMainCategory();
                        product_cat.category = categories;
                        return View("Create", "_LayoutAdmin", product_cat);
                    }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    List<MainCategoryView> categories = categorySevice.GetAllMainCategory();
                    product_cat.category = categories;
                    return View("Create", "_LayoutAdmin", product_cat);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
