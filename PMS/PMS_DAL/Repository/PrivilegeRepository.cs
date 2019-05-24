using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;
using Models.ViewModels;

namespace PMS_DAL.Repository
{
    public class PrivilegeRepository
    {

        Context DB = new Context();

        public List<Privilege> GetPrivileges()
        {
            try
            {
                List<Privilege> privileges = DB.Privilege.ToList();
                return privileges;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public Privilege GetSinglePrivillage(int id)
        {
            try
            {
                Privilege privileges = DB.Privilege.Find(id);
                return privileges;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public bool InsertPrivilege(PrivilegeView privilege)
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
                    Privilege privilegeDetails = new Privilege();
                    privilegeDetails.PrivilegeName = privilege.PrivilegeName;
                    DB.Privilege.Add(privilegeDetails);
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
