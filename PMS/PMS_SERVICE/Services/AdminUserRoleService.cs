using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ViewModels;
using PMS_DAL.Models;
using PMS_DAL.Repository;
namespace PMS_SERVICE.Services
{
    public class AdminUserRoleService
    {
        private AdminUserRoleRepository adminUserRoleRepository = new AdminUserRoleRepository();
        public List<AdminUserRoleView> GetAdminUserRoles()
        {
            try
            {
                List<AdminUserRole> AdminUserRoles = adminUserRoleRepository.GetAdminUserRoles();
                List<AdminUserRoleView> adminUserRoleViews = new List<AdminUserRoleView>();
                adminUserRoleViews.AddRange(AdminUserRoles.Select(ad => new AdminUserRoleView {
                    AdminRoleId = ad.AdminRoleId,
                    AdminUserId = ad.AdminUserId,
                    Id = ad.Id,
                    Role = new RoleView
                    {
                        Id = ad.Role.Id,
                        RoleName = ad.Role.RoleName,
                        Status = ad.Role.Status
                    }
                }
                ));
                return adminUserRoleViews;
            }
            catch
            {
                return null;
            }
        }
        public bool InsertAdminUserRole(AdminUserRoleView roleView)
        {
            bool result = adminUserRoleRepository.InsertAdminUserRole(roleView);
            return result;
        }
        public List<AdminEditRoleView> GetRoleIDByAdminId(int id)
        {
            List<AdminUserRole> result = adminUserRoleRepository.GetRoleIDByAdminId(id);
            List<AdminEditRoleView> adminUserRoleView = new List<AdminEditRoleView>();
            adminUserRoleView.AddRange(result.Select(adm => new AdminEditRoleView { AdminUserId = adm.AdminUserId, roles = new RoleView { RoleName = adm.Role.RoleName, Id = adm.Role.Id} }));
            return adminUserRoleView;
        }
    }
}
