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
        public List<AdminDetails> GetAdminDetails()
        {
            List<AdminDetails> adminDetails = adminrepo.GetAllAdminDetails();
            return adminDetails;
        }

        public bool GetAdminByNameAndPassword(LoginDetails user)
        {
            bool result = adminrepo.GetAdminByNameAndPassword(user);
            return result;
        }
    }
}
