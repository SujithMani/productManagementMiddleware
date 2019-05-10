﻿using PMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Repository
{
    public class AdminDetailsRepository
    {

        private Context DB = new Context();


        public List<AdminDetails> GetAllAdminDetails()
        {
            try
            {
                List<AdminDetails> adminDetails = DB.AdminDetails.ToList();               
                //adminDetails.ForEach(it => it.AdminUserRoles = DB.AdminUserRole.Where(itr => itr.AdminUserId == it.Id).ToList());
                return adminDetails;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public bool GetAdminByNameAndPassword(LoginDetails AdminDetails)
        {
            string name = AdminDetails.Username;
            string pass = AdminDetails.Password;
            try
            {
                if(name != null && pass !=null)
                {
                    AdminDetails adminDetails = DB.AdminDetails.Where(a => a.Username == name && a.Password == pass).FirstOrDefault();
                    if (adminDetails != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool InsertAdminDetails(AdminDetails AdminDetails)
        {
            int CurrentId = AdminDetails.Id;
            try
            {
                if (AdminDetails.Id != 0)
                {
                    AdminDetails adminDetails = DB.AdminDetails.Find(AdminDetails.Id);
                    adminDetails.Name = AdminDetails.Name;
                    adminDetails.Password = AdminDetails.Password;
                    adminDetails.Username = AdminDetails.Username;
                    adminDetails.Email = AdminDetails.Email;
                    DB.SaveChanges();
                    return true;
                }
                else if (AdminDetails != null)
                {
                    DB.AdminDetails.Add(AdminDetails);
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
        public bool DeleteAdminDetails(int AdminId)
        {
            try
            {
                if (AdminId != 0)
                {
                    AdminDetails adminDetails = DB.AdminDetails.Find(AdminId);
                    DB.AdminDetails.Remove(adminDetails);
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
