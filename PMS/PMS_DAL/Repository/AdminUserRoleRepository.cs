using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;

namespace PMS_DAL.Repository
{
    class AdminUserRoleRepository
    {

        Context DB = new Context();

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
        public bool InsertAdminUserRole(AdminUserRole AdminUserRole)
        {
            try
            {
                if (AdminUserRole.Id != 0)
                {
                    AdminUserRole AdminUserRoleDetails = DB.AdminUserRole.Find(AdminUserRole.Id);
                    AdminUserRoleDetails.AdminUserId = AdminUserRole.AdminUserId;
                    AdminUserRoleDetails.AdminRoleId = AdminUserRole.AdminRoleId;
                    DB.SaveChanges();
                    return true;
                }
                else if (AdminUserRole != null)
                {
                    DB.AdminUserRole.Add(AdminUserRole);
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
