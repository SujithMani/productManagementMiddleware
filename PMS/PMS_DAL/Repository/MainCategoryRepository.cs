using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;
using Models.ViewModels;

namespace PMS_DAL.Repository
{
    public class MainCategoryRepository
    {

        Context DB = new Context();

        public List<MainCategory> GetMainCategorys()
        {
            try
            {
                List<MainCategory> MainCategorys = DB.MainCategory.ToList();
                return MainCategorys;
            }
            catch
            {
                return null;
            }
        }
        public MainCategory GetSingleMainCategory(int id)
        {
            try
            {
                MainCategory MainCategorys = DB.MainCategory.Find(id);
                return MainCategorys;
            }
            catch
            {
                return null;
            }
        }
        public bool InsertMainCategory(MainCategoryView MainCategory)
        {
            try
            {
                if (MainCategory.Id != 0)
                {
                    MainCategory MainCategoryDetails = DB.MainCategory.Find(MainCategory.Id);
                    MainCategoryDetails.CategoryName = MainCategory.CategoryName;
                    MainCategoryDetails.Status = MainCategory.Status;
                    DB.SaveChanges();
                    return true;
                }
                else if (MainCategory != null)
                {
                    MainCategory MainCategoryDetails = new MainCategory();
                    MainCategoryDetails.CategoryName = MainCategory.CategoryName;
                    MainCategoryDetails.Status = MainCategory.Status;
                    DB.MainCategory.Add(MainCategoryDetails);
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
        public bool DeleteMainCategory(int MainCategoryId)
        {
            try
            {
                if (MainCategoryId != 0)
                {
                    MainCategory MainCategoryDetails = DB.MainCategory.Find(MainCategoryId);
                    DB.MainCategory.Remove(MainCategoryDetails);
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
