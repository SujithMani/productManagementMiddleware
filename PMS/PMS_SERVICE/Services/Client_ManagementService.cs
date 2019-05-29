using System;
using System.Collections.Generic;
using System.Linq;
using PMS_DAL.Models;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Repository;
using Models.ViewModels.Clients_ViewModels;

namespace PMS_SERVICE.Services
{
    public class Client_ManagementService
    {
        User_Repository Reg = new User_Repository();

     //   public object Reg1 { get; private set; }

        public bool InsertData(User_Registration_View user)
        {
            bool res = Reg.User_Create(user);
            return res;
        }

        public bool Login_User(User_Login_View user1)
        {
            string username = user1.User_Name;
            string password = user1.User_Password;

            if (username != null && password != null)
            {
                bool User_Login = Reg.User_Check(user1);
                return User_Login;
            }
            else
            {
                return false;
            }
        }

        //public bool CheckData(User_Login_View user1)
        //{
            
        //   // bool Result = Reg.Login_User(user1);
        //    if (user1.User_Name != null && user1.User_Password != null)
        //    {
        //        bool User_Login = Reg.User_Check(user1);
               
        //            return true;
                      
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}

