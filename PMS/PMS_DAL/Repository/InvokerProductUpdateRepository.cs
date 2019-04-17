using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;
namespace PMS_DAL.Repository
{
    public class InvokerProductUpdateRepository
    {
        Context DB = new Context();

        public List<InvokerProductUpdate> GetInvokerProductUpdates()
        {
            try
            {
                List<InvokerProductUpdate> InvokerProductUpdates = DB.InvokerProductUpdate.ToList();
                return InvokerProductUpdates;
            }
            catch
            {
                return null;
            }
        }
        public bool InsertInvokerProductUpdate(InvokerProductUpdate InvokerProductUpdate)
        {
            try
            {
                if (InvokerProductUpdate.Id != 0)
                {
                    InvokerProductUpdate InvokerProductUpdateDetails = DB.InvokerProductUpdate.Find(InvokerProductUpdate.Id);
                    InvokerProductUpdateDetails.AdminUserId = InvokerProductUpdate.AdminUserId;
                    InvokerProductUpdateDetails.ProductId = InvokerProductUpdate.ProductId;
                    DB.SaveChanges();
                    return true;
                }
                else if (InvokerProductUpdate != null)
                {
                    DB.InvokerProductUpdate.Add(InvokerProductUpdate);
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
        public bool DeleteInvokerProductUpdate(int InvokerProductUpdateId)
        {
            try
            {
                if (InvokerProductUpdateId != 0)
                {
                    InvokerProductUpdate InvokerProductUpdateDetails = DB.InvokerProductUpdate.Find(InvokerProductUpdateId);
                    DB.InvokerProductUpdate.Remove(InvokerProductUpdateDetails);
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
