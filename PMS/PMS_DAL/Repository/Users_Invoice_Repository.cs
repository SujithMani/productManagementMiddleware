using PMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Repository
{
    public class Users_Invoice_Repository
    {
        private Context DB = new Context();

        public bool Users_Invoice_Create(Users_Invoice invoice)
        {
            try
            {
                if (invoice.Id != 0)
                {
                    Users_Invoice Users_Update = new Users_Invoice();
                    Users_Update.Product_Name = invoice.Product_Name;
                    Users_Update.Product_Price = invoice.Product_Price;
                    Users_Update.Product_Purchase_Date = invoice.Product_Purchase_Date;
                    DB.SaveChanges();
                    return true;
                }

                else
                {
                    DB.Users_Invoice.Add(invoice);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Users_Invoice> Invoice_Read_All()
        {
            try
            {
                List<Users_Invoice> users_List = DB.Users_Invoice.ToList();
                return users_List;
            }
            catch
            {
                return null;
            }
        }

        public Users_Invoice Read_By_Id(int Id)
        {
            try
            {

                Users_Invoice Invoice_Specific_List = DB.Users_Invoice.Find(Id);
                return Invoice_Specific_List;


            }
            catch
            {
                return null;
            }
        }


        public bool Delete_By_Id(int Id)
        {
            try
            {
                Users_Invoice delete_By_Id = DB.Users_Invoice.Find(Id);
                DB.Users_Invoice.Remove(delete_By_Id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

