using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;
namespace PMS_DAL.Repository
{
    class OfferProductRepository
    {

        Context DB = new Context();

        public List<OfferProduct> GetOfferProducts()
        {
            try
            {
                List<OfferProduct> OfferProducts = DB.OfferProduct.ToList();
                return OfferProducts;
            }
            catch
            {
                return null;
            }
        }
        public bool InsertOfferProduct(OfferProduct OfferProduct)
        {
            try
            {
                if (OfferProduct.Id != 0)
                {
                    OfferProduct OfferProductDetails = DB.OfferProduct.Find(OfferProduct.Id);
                    OfferProductDetails.OfferId = OfferProduct.OfferId;
                    OfferProductDetails.ProductId = OfferProduct.ProductId;
                    DB.SaveChanges();
                    return true;
                }
                else if (OfferProduct != null)
                {
                    DB.OfferProduct.Add(OfferProduct);
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
        public bool DeleteOfferProduct(int OfferProductId)
        {
            try
            {
                if (OfferProductId != 0)
                {
                    OfferProduct OfferProductDetails = DB.OfferProduct.Find(OfferProductId);
                    DB.OfferProduct.Remove(OfferProductDetails);
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
