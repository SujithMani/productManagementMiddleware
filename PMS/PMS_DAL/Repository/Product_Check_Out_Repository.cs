using PMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Repository
{
    public class Product_Check_Out_Repository
    {
        private Context DB = new Context();

        public bool Product_Create(Product_Check_Out pdt)
        {
            try
            {
                if (pdt.Id != 0)
                {
                    Product_Check_Out Update = DB.Product_Check_Out.Find(pdt.Id);
                    Update.ProductName = pdt.ProductName;
                    Update.Offers = pdt.Offers;
                    Update.Discount = pdt.Discount;
                    Update.Shipping_Charges = pdt.Shipping_Charges;
                    Update.TotalCharges = pdt.TotalCharges;
                    Update.DestPoint = pdt.DestPoint;
                    return true;
                }

                //Create
                else
                {
                    DB.Product_Check_Out.Add(pdt);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Product_Check_Out> User_ReadAll()
        {
            try
            {

                List<Product_Check_Out> user_List = DB.Product_Check_Out.ToList();
                return user_List;
            }

            catch
            {
                return null;
            }
        }

        //Read a particular ID
        public Product_Check_Out User_Read_By_Id(int Id)
        {
            try

            {
                if (Id != 0)
                {
                    Product_Check_Out user_By_Id = DB.Product_Check_Out.Find(Id);
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

        //Delete
        public bool Delete_By_Id(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    Product_Check_Out delete_By_Id = DB.Product_Check_Out.Find(Id);
                    DB.Product_Check_Out.Remove(delete_By_Id);
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

            


