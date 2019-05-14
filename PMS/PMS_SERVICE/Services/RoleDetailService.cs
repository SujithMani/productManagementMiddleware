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
    public class RoleDetailService
    {
        private RoleRepository Roles = new RoleRepository();
        public List<RoleView> GetRoles()
        {
            List<Role> roles = Roles.GetAllRole();
            List<RoleView> roless = new List<RoleView>();
            foreach(Role s in roles)
            {
                roless.Add(new RoleView
                {
                    RoleName = s.RoleName,
                    Id = s.Id,
                    Status = s.Status
                });
            }
            return roless;
        }
        public bool InsertRole(RoleView role)
        {
            bool result = Roles.InsertRole(role);
            return result;
        }
        public RoleView GetSingleRole(int id)
        {
            Role role = Roles.GetSingleRole(id);
            RoleView roles = new RoleView()
            {
                RoleName = role.RoleName,
                Id = role.Id,
                Status = role.Status
            };
            return roles;
        }
        public bool DeleteRole(int id)
        {
            bool role = Roles.DeleteRole(id);
            return role;
        }
    }
}
