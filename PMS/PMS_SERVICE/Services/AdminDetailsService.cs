using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Repository;
using PMS_DAL.Models;
using Models.ViewModels;
namespace PMS_SERVICE.Services
{
    public class AdminDetailsService
    {
        AdminDetailsRepository adminrepo = new AdminDetailsRepository();
        public List<AdminDetailsVIew> GetAdminDetails()
        {
            List<AdminDetails> adminDetails = adminrepo.GetAllAdminDetails();
            List<AdminDetailsVIew> adminDetailsView = new List<AdminDetailsVIew>();
            adminDetailsView.AddRange(adminDetails.Select(ad => new AdminDetailsVIew { Name = ad.Name, Id = ad.Id, Email = ad.Email, Password = ad.Password }));
            return adminDetailsView;
        }

        public bool GetAdminByNameAndPassword(LoginDetails user)
        {
            bool result = adminrepo.GetAdminByNameAndPassword(user);
            return result;
        }
    }
}
