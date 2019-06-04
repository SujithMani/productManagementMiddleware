using Models.ViewModels;
using PMS_DAL.Models;
using PMS_DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PMS_SERVICE.Services
{
    public class ProductService
    {
        private ProductRepository productRepo = new ProductRepository();
        private MainCategoryProductRepository categoryProductRepository = new MainCategoryProductRepository();
        public List<ProductView> GetAllMainCategory()
        {
            List<Product> products = productRepo.GetAllProduct();
            List<ProductView> productViews = new List<ProductView>();
            productViews.AddRange(
                products.Select(
                    par => new ProductView
                    {
                        Id = par.Id,
                        ProductName = par.ProductName,
                        Image = par.Image,
                        Keyword = par.Keyword,
                        Sku = par.Sku,
                        Description = par.Description,
                        Prize = par.Prize,
                        Status = par.Status,
                        MainCategoryProducts = par.MainCategoryProducts.Select(cat => new MainCategoryProductView
                        {
                            MainCategory = new MainCategoryView
                            {
                                CategoryName = cat.MainCategory.CategoryName
                            },
                            Id = cat.Id
                        }).ToList()
                    }
                    )
                );
            return productViews;
        }
        public int InsertProduct(ProductView product)
        {
            int res = productRepo.InsertProduct(product);
            return res;
        }
        public bool InsertProductCategory(MainCategoryProductView product)
        {
            bool res = categoryProductRepository.InsertMainCategoryProduct(product);
            return res;
        }
        public bool DeleteCategoryByProduct(int productId)
        {
            bool res = categoryProductRepository.DeleteCategoryByProduct(productId);
            return res;
        }
        public bool DeleteProduct(int productId)
        {
            bool res = categoryProductRepository.DeleteProduct(productId);
            return res;
        }
        public ProductView GetSingleProduct(int Id)
        {
            Product products = productRepo.GetSingleProduct(Id);
            ProductView productViews = new ProductView
            {
                Id = products.Id,
                ProductName = products.ProductName,
                Image = products.Image,
                Keyword = products.Keyword,
                Sku = products.Sku,
                Description = products.Description,
                Prize = products.Prize,
                Status = products.Status,
                MainCategoryProducts = products.MainCategoryProducts.Select(cat => new MainCategoryProductView
                {
                    MainCategory = new MainCategoryView
                    {
                        CategoryName = cat.MainCategory.CategoryName,
                        Id = cat.MainCategory.Id
                    },
                    Id = cat.Id
                }).ToList()
            };
            return productViews;
        }

    }
}
