using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;

namespace PMS_DAL.Repository
{
    public class ProductRepository
    {
        private Context DB = new Context();

        public List<Product> GetAllProduct()
        {
            try
            {
                List<Product> Product = DB.Product.ToList();
                return Product;
            }
            catch
            {
                return null;
            }
        }
        public bool InsertProduct(Product ProductDetails)
        {
            int CurrentId = ProductDetails.Id;
            try
            {
                if (ProductDetails.Id != 0)
                {
                    Product ProductDetailsById = DB.Product.Find(CurrentId);
                    ProductDetailsById.ProductName = ProductDetails.ProductName;
                    ProductDetailsById.Description = ProductDetails.Description;
                    ProductDetailsById.Sku = ProductDetails.Sku;
                    ProductDetailsById.Keyword = ProductDetails.Keyword;
                    ProductDetailsById.Prize = ProductDetails.Prize;
                    ProductDetailsById.Image = ProductDetails.Image;
                    DB.SaveChanges();
                    return true;
                }
                else if (ProductDetails != null)
                {
                    DB.Product.Add(ProductDetails);
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
        public bool DeleteProduct(int ProductId)
        {
            try
            {
                if (ProductId != 0)
                {
                    Product Product = DB.Product.Find(ProductId);
                    DB.Product.Remove(Product);
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
