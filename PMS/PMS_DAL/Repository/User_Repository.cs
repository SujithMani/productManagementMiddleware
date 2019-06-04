using PMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Models.ViewModels.Clients_ViewModels;
using System.Data.Entity.Validation;

namespace PMS_DAL.Repository
{
    public class User_Repository
    {
        private Context DB = new Context();


        public bool User_Check(User_Login_View user1)
        {
            try
            {
                User_Registration User_Login = DB.User_Registration.Where(u => u.User_Name == user1.User_Name
                      && u.User_Password == user1.User_Password).FirstOrDefault();
                 if(User_Login!=null)
                {
                    return true;
                }
                 else
                {
                    return false;
                }
                
            }
            catch(Exception t)
            {
                return false;
            }
        }
        //Updation and Creation
            public bool User_Create(User_Registration_View user)
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
                        User_Registration old_User = new User_Registration();
                        old_User.FirstName = user.FirstName;
                        old_User.LastName = user.LastName;
                        old_User.User_Name = user.User_Name;
                        old_User.User_Email_Id = user.User_Email_Id;
                        old_User.Phone_Number = user.Phone_Number;
                        old_User.User_Address = user.User_Address;
                        old_User.User_Password = user.User_Password;
                        old_User.Confirm_Password = user.Confirm_Password;
                        old_User.Date_Of_Birth = user.Date_Of_Birth;
                        DB.User_Registration.Add(old_User);
                        DB.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
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

        public User_Registration User_By_Username(string userName)
        {
            User_Registration userDetails = DB.User_Registration.Where(det => det.User_Name == userName).FirstOrDefault();
            return userDetails;
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
