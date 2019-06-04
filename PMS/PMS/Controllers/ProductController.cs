using Models.ViewModels;
using PMS_SERVICE.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class ProductController : Controller
    {
        private MainCategorySevice categorySevice = new MainCategorySevice();
        private ProductService productService = new ProductService();
        // GET: Product
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                List<ProductView> products = productService.GetAllMainCategory();
                return View("Index", "_LayoutAdmin", products);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            if(Session["username"] != null)
            {
                ProductView product_cat = new ProductView();
                product_cat = productService.GetSingleProduct(id);
                //List<MainCategoryView> category = categorySevice.GetAllMainCategory();
                //roduct_cat.category = category;
                return View("Details", "_LayoutAdmin", product_cat);
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
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
                        categoryView.product.Image = "~/Images/" + filename;
                        filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                        categoryView.product.ImageFile.SaveAs(filename);

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
            if (Session["username"] != null)
            {
                ProductCategoryView product_cat = new ProductCategoryView();
                product_cat.product = productService.GetSingleProduct(id);
                List<MainCategoryView> category = categorySevice.GetAllMainCategory();
                product_cat.category = category;
                return View("Edit", "_LayoutAdmin", product_cat);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCreateRequestView categoryView)
        {
            ProductCategoryView product_cat = new ProductCategoryView();
            if (Session["username"] != null)
            {
                try
                {
                    product_cat.product = productService.GetSingleProduct(categoryView.product.Id);
                    List<MainCategoryView> category = categorySevice.GetAllMainCategory();
                    product_cat.category = category;
                    if (ModelState.IsValid)
                    {
                        string filename = Path.GetFileNameWithoutExtension(categoryView.product.ImageFile.FileName);
                        string extension = Path.GetExtension(categoryView.product.ImageFile.FileName);
                        filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                        categoryView.product.Image = "~/Images/" + filename;
                        filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                        categoryView.product.ImageFile.SaveAs(filename);

                        int res = productService.InsertProduct(categoryView.product);
                        if (res != 0)
                        {
                            int productId = res;
                            bool deleteCategoryByProduct = productService.DeleteCategoryByProduct(productId);
                            foreach (int role in categoryView.category)
                            {
                                MainCategoryProductView categoryProductView = new MainCategoryProductView { CategoryId = role, ProductId = productId };
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
                            //List<MainCategoryView> categories = categorySevice.GetAllMainCategory();
                            //product_cat.category = categories;
                            ModelState.AddModelError(string.Empty, "Something happend");
                            return View("Edit", "_LayoutAdmin", product_cat);
                        }


                    }
                    else
                    {
                        //List<MainCategoryView> categories = categorySevice.GetAllMainCategory();
                        //product_cat.category = categories;
                        return View("Edit", "_LayoutAdmin", product_cat);
                    }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    //List<MainCategoryView> categories = categorySevice.GetAllMainCategory();
                    //product_cat.category = categories;
                    return View("Edit", "_LayoutAdmin", product_cat);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["username"] != null)
            {
                bool deleteProduct = productService.DeleteProduct(id);
                if (deleteProduct)
                {
                    bool deleteCategoryByProduct = productService.DeleteCategoryByProduct(id);

                    if (deleteCategoryByProduct)
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
                    List<ProductView> products = productService.GetAllMainCategory();
                    ModelState.AddModelError(string.Empty, "Something happend");
                    return View("Index", "_LayoutAdmin", products);
                }

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
