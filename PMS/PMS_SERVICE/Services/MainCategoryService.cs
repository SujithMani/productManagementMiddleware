using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ViewModels;
using PMS_DAL.Repository;
using PMS_DAL.Models;

namespace PMS_SERVICE.Services
{
    public class MainCategorySevice
    {
        private MainCategoryRepository mainCategoryrepo = new MainCategoryRepository();
        public List<MainCategoryView> GetAllMainCategory()
        {
            List<MainCategory> mainCategories = mainCategoryrepo.GetMainCategorys();
            List<MainCategoryView> MainCategoryViews = new List<MainCategoryView>();
            MainCategoryViews.AddRange(
                mainCategories.Select(
                    par => new MainCategoryView
                    {
                        Id = par.Id,
                        CategoryName = par.CategoryName,
                        Status = par.Status
                    }
                    )
                );
            return MainCategoryViews;
        }
        public bool InsertMainCategory(MainCategoryView MainCategoryView)
        {
            bool result = mainCategoryrepo.InsertMainCategory(MainCategoryView);
            return result;
        }
        public bool DeleteMainCategory(int id)
        {
            bool result = mainCategoryrepo.DeleteMainCategory(id);
            return result;
        }
        public MainCategoryView GetSingleMainCategory(int id)
        {
            MainCategory mainCategory = mainCategoryrepo.GetSingleMainCategory(id);
            MainCategoryView MainCategoryView = new MainCategoryView
            {
                Id = mainCategory.Id,
                CategoryName = mainCategory.CategoryName,
                Status = mainCategory.Status
            };
            return MainCategoryView;
        }
    }
}
