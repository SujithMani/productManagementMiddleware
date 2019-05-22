using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;
using Models.ViewModels;
namespace PMS_DAL.Repository
{
    public class PageDetailsRepository
    {
        Context DB = new Context();

        public List<PageDetails> GetPageDetailss()
        {
            try
            {
                List<PageDetails> PageDetailss = DB.PageDetails.ToList();
                return PageDetailss;
            }
            catch
            {
                return null;
            }
        }
        public PageDetails GetSinglePageDetailss(int id)
        {
            try
            {
                PageDetails PageDetailss = DB.PageDetails.Find(id);
                return PageDetailss;
            }
            catch
            {
                return null;
            }
        }
        public bool InsertPageDetails(PageDetailsView PageDetails)
        {
            try
            {
                if (PageDetails.Id != 0)
                {
                    PageDetails PageDetailsDetails = DB.PageDetails.Find(PageDetails.Id);
                    PageDetailsDetails.PageKey = PageDetails.PageKey;
                    PageDetailsDetails.PageDescription = PageDetails.PageDescription;
                    DB.SaveChanges();
                    return true;
                }
                else if (PageDetails != null)
                {
                    PageDetails PageDetailsDetails = new PageDetails();
                    PageDetailsDetails.PageKey = PageDetails.PageKey;
                    PageDetailsDetails.PageDescription = PageDetails.PageDescription;
                    DB.PageDetails.Add(PageDetailsDetails);
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
        public bool DeletePageDetails(int PageDetailsId)
        {
            try
            {
                if (PageDetailsId != 0)
                {
                    PageDetails PageDetailsDetails = DB.PageDetails.Find(PageDetailsId);
                    DB.PageDetails.Remove(PageDetailsDetails);
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
