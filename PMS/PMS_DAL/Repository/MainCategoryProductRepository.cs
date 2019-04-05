using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;
namespace PMS_DAL.Repository
{
    class MainCategoryProductRepository
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
        public bool InsertMainCategoryProduct(MainCategoryProduct MainCategoryProduct)
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
                    DB.MainCategoryProduct.Add(MainCategoryProduct);
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
