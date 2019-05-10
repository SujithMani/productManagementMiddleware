using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Repository;
using PMS_DAL.Models;
namespace PMS_SERVICE.Services
{
    public class RoleDetailService
    {
        private RoleRepository Roles = new RoleRepository();
        public List<Role> GetRoles()
        {
            List<Role> roles = Roles.GetAllRole();
            return roles;
        }
        public bool InsertRole(Role role)
        {
            bool result = Roles.InsertRole(role);
            return result;
        }
        public Role GetSingleRole(int id)
        {
            Role role = Roles.GetSingleRole(id);
            return role;
        }
    }
}
