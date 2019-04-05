using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;

namespace PMS_DAL.Repository
{
    class PrivilegeRepository
    {

        Context DB = new Context();

        public List<Privilege> GetPrivileges()
        {
            try
            {
                List<Privilege> privileges = DB.Privilege.ToList();
                return privileges;
            }
            catch
            {
                return null;
            }
        }
        public bool InsertPrivilege(Privilege privilege)
        {
            try
            {
                if (privilege.Id != 0)
                {
                    Privilege privilegeDetails = DB.Privilege.Find(privilege.Id);
                    privilegeDetails.PrivilegeName = privilege.PrivilegeName;
                    DB.SaveChanges();
                    return true;
                }else if (privilege != null)
                {
                    DB.Privilege.Add(privilege);
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
        public bool DeletePrivilege(int privilegeId)
        {
            try
            {
                if (privilegeId != 0)
                {
                    Privilege privilegeDetails = DB.Privilege.Find(privilegeId);
                    DB.Privilege.Remove(privilegeDetails);
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
