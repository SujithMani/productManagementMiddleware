using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;

namespace PMS_DAL.Repository
{
    public class RolePrivillageRepository
    {
        Context DB = new Context();

        public bool InsertRolePrivilege(RolePrivilege rolePrivilege)
        {
            try
            {
                if(rolePrivilege.Id != 0)
                {
                    RolePrivilege rolePrivilegeDetails = DB.RolePrivilege.Find(rolePrivilege.Id);
                    rolePrivilegeDetails.RoleId = rolePrivilege.RoleId;
                    rolePrivilegeDetails.PrivilegeId = rolePrivilege.PrivilegeId;
                    DB.SaveChanges();
                    return true;
                }
                else
                if(rolePrivilege != null)
                {
                    DB.RolePrivilege.Add(rolePrivilege);
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
        //public List<RolePrivilege> GetAllRoles()
        //{

        //}
        public bool DeleteRole(int RoleId)
        {
            try
            {
                if (RoleId != 0)
                {
                    RolePrivilege rolePrivilege = DB.RolePrivilege.Find(RoleId);
                    DB.RolePrivilege.Remove(rolePrivilege);
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
