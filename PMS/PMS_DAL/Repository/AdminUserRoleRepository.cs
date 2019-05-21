using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;
using Models.ViewModels;
namespace PMS_DAL.Repository
{
    public class AdminUserRoleRepository
    {

        Context DB = new Context();
        public List<AdminUserRole> GetRoleIDByAdminId(int id)
        {
            try
            {
                List<AdminUserRole> AdminUserRoles = DB.AdminUserRole.Where(adm => adm.AdminUserId.Equals(id)).ToList();
                return AdminUserRoles;
            }
            catch
            {
                return null;
            }
        }
        public List<AdminUserRole> GetAdminUserRoles()
        {
            try
            {
                List<AdminUserRole> AdminUserRoles = DB.AdminUserRole.ToList();
                return AdminUserRoles;
            }
            catch
            {
                return null;
            }
        }
        public bool InsertAdminUserRole(AdminUserRoleView roleView)
        {
            try
            {
                if (roleView.Id != 0)
                {
                    AdminUserRole AdminUserRoleDetails = DB.AdminUserRole.Find(roleView.Id);
                    AdminUserRoleDetails.AdminUserId = roleView.AdminUserId;
                    AdminUserRoleDetails.AdminRoleId = roleView.AdminRoleId;
                    DB.SaveChanges();
                    return true;
                }
                else if (roleView != null)
                {
                    AdminUserRole AdminUserRoleDetails = new AdminUserRole();
                    AdminUserRoleDetails.AdminUserId = roleView.AdminUserId;
                    AdminUserRoleDetails.AdminRoleId = roleView.AdminRoleId;
                    DB.AdminUserRole.Add(AdminUserRoleDetails);
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
        public bool DeleteAdminUserRole(int AdminUserRoleId)
        {
            try
            {
                if (AdminUserRoleId != 0)
                {
                    AdminUserRole AdminUserRoleDetails = DB.AdminUserRole.Find(AdminUserRoleId);
                    DB.AdminUserRole.Remove(AdminUserRoleDetails);
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
