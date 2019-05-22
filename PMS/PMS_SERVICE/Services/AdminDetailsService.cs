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
        PageDetailsRepository pagerepo = new PageDetailsRepository();
        public List<AdminDetailsVIew> GetAdminDetails()
        {
            List<AdminDetails> adminDetails = adminrepo.GetAllAdminDetails();
            List<AdminDetailsVIew> adminDetailsView = new List<AdminDetailsVIew>();
            adminDetailsView.AddRange(adminDetails.Select(ad => new AdminDetailsVIew { Name = ad.Name, Id = ad.Id, Email = ad.Email, Password = ad.Password, Username = ad.Username, AdminUserRoles = ad.AdminUserRoles.Select(add => new AdminUserRoleView { AdminUserId = add.AdminUserId, Role = new RoleView { RoleName = add.Role.RoleName} }).ToList() }));
            return adminDetailsView;
        }
        public AdminDetailsVIew GetSingleAdminDetails(int id)
        {
            AdminDetails adminDetails = adminrepo.GetSingleAdminDetails(id);
            AdminDetailsVIew adminDetailsView = new AdminDetailsVIew()
            {
                Id = adminDetails.Id,
                Name = adminDetails.Name,
                Password = adminDetails.Password,
                Email = adminDetails.Email,
                Username = adminDetails.Username,
                AdminUserRoles = adminDetails.AdminUserRoles.Select(ad => new AdminUserRoleView {
                    Role = new RoleView
                    {
                        RoleName = ad.Role.RoleName,
                        Id = ad.Role.Id,
                        Status = ad.Role.Status
                    },
                    AdminUserId = ad.AdminUserId,
                    AdminRoleId = ad.AdminRoleId,
                    Id = ad.Id
                }).Where(add =>add.AdminUserId == adminDetails.Id).ToList(),
            };
            
            return adminDetailsView;
        }

        public bool GetAdminByNameAndPassword(LoginDetailsView user)
        {
            bool result = adminrepo.GetAdminByNameAndPassword(user);
            return result;
        }
        public int InsertAdminDetails(AdminDetailsVIew user)
        {
            int result = adminrepo.InsertAdminDetails(user);
            return result;
        }
        public bool CheckUserNameAvailable(string username)
        {
            bool result = adminrepo.CheckUserNameAvailable(username);
            return result;
        }
        public bool DeleteAdminById(int id)
        {
            bool result = adminrepo.DeleteAdminDetails(id);
            return result;
        }
        public List<PageDetailsView> GetAllPageDetails()
        {
            List<PageDetails> pageDetails = pagerepo.GetPageDetailss();
            List<PageDetailsView> pageDetailsViews = new List<PageDetailsView>();
            pageDetailsViews.AddRange(pageDetails.Select(ad => new PageDetailsView {
                Id = ad.Id,
                PageDescription = ad.PageDescription,
                PageKey = ad.PageKey
            }));
            return pageDetailsViews;

        }
        public bool InsertPageDetails(PageDetailsView pageDetails)
        {
            bool result = pagerepo.InsertPageDetails(pageDetails);
            return result;
        }
        public bool DeletePageDetails(int id)
        {
            bool result = pagerepo.DeletePageDetails(id);
            return result;
        }
        public PageDetailsView GetSinglePageDetails(int id)
        {
            PageDetails pageDetails = pagerepo.GetSinglePageDetailss(id);
            PageDetailsView pageDetailsView = new PageDetailsView
            {
                Id = pageDetails.Id,
                PageDescription = pageDetails.PageDescription,
                PageKey = pageDetails.PageKey
            };
            return pageDetailsView;
        }
    }
}
