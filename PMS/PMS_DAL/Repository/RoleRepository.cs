using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;
using Models.ViewModels;
namespace PMS_DAL.Repository
{
    public class RoleRepository
    {

        private Context DB = new Context();

        public List<Role> GetAllRole()
        {
            try
            {
                List<Role> Role = DB.Role.ToList();
                return Role;
            }
            catch
            {
                return null;
            }
        }public List<Role> GetAllRoleByStatus()
        {
            try
            {
                List<Role> Role = DB.Role.Where(role => role.Status == 1).ToList();
                return Role;
            }
            catch
            {
                return null;
            }
        }
        public Role GetSingleRole(int id)
        {
            try
            {
                Role Role = DB.Role.Find(id);
                return Role;
            }
            catch
            {
                return null;
            }
        }
        public bool InsertRole(RoleView RoleDetails)
        {
            int CurrentId = RoleDetails.Id;
            try
            {
                if (RoleDetails.Id != 0)
                {
                    Role RoleDetailsById = DB.Role.Find(CurrentId);
                    RoleDetailsById.RoleName = RoleDetails.RoleName;
                    RoleDetailsById.Status = RoleDetails.Status;
                    DB.SaveChanges();
                    return true;
                }
                else if (RoleDetails != null)
                {
                    Role role = new Role();
                    role.RoleName = RoleDetails.RoleName;
                    role.Status = RoleDetails.Status;
                    DB.Role.Add(role);
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
        public bool DeleteRole(int RoleId)
        {
            try
            {
                if (RoleId != 0)
                {
                    Role Role = DB.Role.Find(RoleId);
                    DB.Role.Remove(Role);
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
