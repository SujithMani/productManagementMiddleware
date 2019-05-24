using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ViewModels;
using PMS_DAL.Repository;
using PMS_DAL.Models;

namespace PMS_SERVICE.Services
{
    public class PrivillageService
    {
        private PrivilegeRepository privilegeRepo = new PrivilegeRepository();
        public List<PrivilegeView> GetAllPrivillages()
        {
            List<Privilege> privileges = privilegeRepo.GetPrivileges();
            List<PrivilegeView> privilegeViews = new List<PrivilegeView>();
            privilegeViews.AddRange(
                privileges.Select(
                    par => new PrivilegeView
                    {
                        Id = par.Id,
                        PrivilegeName = par.PrivilegeName
                    }
                    )
                );
            return privilegeViews;
        }
        public bool InsertPrivillage(PrivilegeView privilegeView)
        {
            bool result = privilegeRepo.InsertPrivilege(privilegeView);
            return result;
        }
        public bool DeletePrivillage(int id)
        {
            bool result = privilegeRepo.DeletePrivilege(id);
            return result;
        }
        public PrivilegeView GetSinglePrivillege(int id)
        {
            Privilege privilege = privilegeRepo.GetSinglePrivillage(id);
            PrivilegeView privilegeView = new PrivilegeView
            {
                Id = privilege.Id,
                PrivilegeName = privilege.PrivilegeName
            };
            return privilegeView;
        }
    }
}
