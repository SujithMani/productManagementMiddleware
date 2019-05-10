using PMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace PMS_DAL.Repository
{
    public class User_Registration_Repository
    {
        private Context DB = new Context();

        public bool User_Create(User_Registration user)
        {
            try
            {
                //Update
                if (user.Id != 0)
                {                  
                    User_Registration old_User = DB.User_Registration.Find(user.Id);
                    old_User.FirstName = user.FirstName;
                    old_User.LastName = user.LastName;
                    old_User.User_Name = user.User_Name;
                    old_User.User_Email_Id = user.User_Email_Id;
                    old_User.User_Address = user.User_Address;
                    old_User.User_Password = user.User_Password;
                    old_User.Confirm_Password = user.Confirm_Password;
                    DB.SaveChanges();
                    return true;
                }

                //Create
                else
                {
                    DB.User_Registration.Add(user);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        //Read all ID's
        public List<User_Registration> User_ReadAll()
        {
            try
            {

                List<User_Registration> user_List = DB.User_Registration.ToList();
                return user_List;
            }

            catch
            {
                return null;
            }
        }

        //Read a particular ID
        public User_Registration User_Read_By_Id(int Id)
        {
            try

            {
                if (Id != 0)
                {
                    User_Registration user_By_Id = DB.User_Registration.Find(Id);
                    return user_By_Id;
                }
                else
                {
                    return null;
                }
            }

            catch
            {
                return null;
            }
        }

        //public List<User_Registration> user_read_by_id(int id)
        //{
        //    if (id != 0)
        //    {
        //        List<User_Registration> customernames = new List<User_Registration>();
        //        var user_by_id = DB.User_Registration.Find(id);
        //        customernames.Add(user_by_id);
        //        return customernames;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //Delete
        public bool Delete_By_Id(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    User_Registration delete_By_Id = DB.User_Registration.Find(Id);
                    DB.User_Registration.Remove(delete_By_Id);
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
