using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;

namespace PMS_DAL.Repository
{
    public class AdminUserPrivilegeRepository
    {

        Context DB = new Context();

        public List<AdminUserPrivilege> GetAdminUserPrivileges()
        {
            try
            {
                List<AdminUserPrivilege> AdminUserPrivileges = DB.AdminUserPrivilege.ToList();
                return AdminUserPrivileges;
            }
            catch
            {
                return null;
            }
        }
        public bool InsertAdminUserPrivilege(AdminUserPrivilege AdminUserPrivilege)
        {
            try
            {
                if (AdminUserPrivilege.Id != 0)
                {
                    AdminUserPrivilege AdminUserPrivilegeDetails = DB.AdminUserPrivilege.Find(AdminUserPrivilege.Id);
                    AdminUserPrivilegeDetails.AdminUserId = AdminUserPrivilege.AdminUserId;
                    AdminUserPrivilegeDetails.PrivilegeId = AdminUserPrivilege.PrivilegeId;
                    DB.SaveChanges();
                    return true;
                }
                else if (AdminUserPrivilege != null)
                {
                    DB.AdminUserPrivilege.Add(AdminUserPrivilege);
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
        public bool DeleteAdminUserPrivilege(int AdminUserPrivilegeId)
        {
            try
            {
                if (AdminUserPrivilegeId != 0)
                {
                    AdminUserPrivilege AdminUserPrivilegeDetails = DB.AdminUserPrivilege.Find(AdminUserPrivilegeId);
                    DB.AdminUserPrivilege.Remove(AdminUserPrivilegeDetails);
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
