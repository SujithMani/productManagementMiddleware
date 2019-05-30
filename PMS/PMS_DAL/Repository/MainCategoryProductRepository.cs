using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;
using Models.ViewModels;

namespace PMS_DAL.Repository
{
    public class MainCategoryProductRepository
    {

        Context DB = new Context();

        public List<MainCategoryProduct> GetMainCategoryProducts()
        {
            try
            {
                List<MainCategoryProduct> MainCategoryProducts = DB.MainCategoryProduct.ToList();
                return MainCategoryProducts;
            }
            catch
            {
                return null;
            }
        }
        public bool InsertMainCategoryProduct(MainCategoryProductView MainCategoryProduct)
        {
            try
            {
                if (MainCategoryProduct.Id != 0)
                {
                    MainCategoryProduct MainCategoryProductDetails = DB.MainCategoryProduct.Find(MainCategoryProduct.Id);
                    MainCategoryProductDetails.CategoryId = MainCategoryProduct.CategoryId;
                    MainCategoryProductDetails.ProductId = MainCategoryProduct.ProductId;
                    DB.SaveChanges();
                    return true;
                }
                else if (MainCategoryProduct != null)
                {
                    MainCategoryProduct MainCategoryProductDetails = new MainCategoryProduct();
                    MainCategoryProductDetails.CategoryId = MainCategoryProduct.CategoryId;
                    MainCategoryProductDetails.ProductId = MainCategoryProduct.ProductId;
                    DB.MainCategoryProduct.Add(MainCategoryProductDetails);
                    DB.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteMainCategoryProduct(int MainCategoryProductId)
        {
            try
            {
                if (MainCategoryProductId != 0)
                {
                    MainCategoryProduct MainCategoryProductDetails = DB.MainCategoryProduct.Find(MainCategoryProductId);
                    DB.MainCategoryProduct.Remove(MainCategoryProductDetails);
                    DB.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
