using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;
using Models.ViewModels;

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
        public Product GetSingleProduct(int Id)
        {
            try
            {
                Product Product = DB.Product.Find(Id);
                return Product;
            }
            catch
            {
                return null;
            }
        }
        public int InsertProduct(ProductView ProductDetails)
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
                    ProductDetailsById.Status = ProductDetails.Status;
                    ProductDetailsById.Image = ProductDetails.Image;
                    DB.SaveChanges();
                    int id = ProductDetailsById.Id;
                    return id;
                }
                else if (ProductDetails != null)
                {
                    Product Products = new Product();
                    Products.ProductName = ProductDetails.ProductName;
                    Products.Description = ProductDetails.Description;
                    Products.Sku = ProductDetails.Sku;
                    Products.Keyword = ProductDetails.Keyword;
                    Products.Prize = ProductDetails.Prize;
                    Products.Image = ProductDetails.Image;
                    Products.Status = ProductDetails.Status;
                    DB.Product.Add(Products);
                    DB.SaveChanges();
                    int id = Products.Id;
                    return id;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return -1;
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
