using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;
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
        public bool InsertMainCategory(MainCategory MainCategory)
        {
            try
            {
                if (MainCategory.Id != 0)
                {
                    MainCategory MainCategoryDetails = DB.MainCategory.Find(MainCategory.Id);
                    MainCategoryDetails.CategoryName = MainCategory.CategoryName;
                    DB.SaveChanges();
                    return true;
                }
                else if (MainCategory != null)
                {
                    DB.MainCategory.Add(MainCategory);
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
