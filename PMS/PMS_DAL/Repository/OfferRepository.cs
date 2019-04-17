using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Models;
namespace PMS_DAL.Repository
{
    public class OfferRepository
    {

        Context DB = new Context();

        public List<Offer> GetOffers()
        {
            try
            {
                List<Offer> Offers = DB.Offer.ToList();
                return Offers;
            }
            catch
            {
                return null;
            }
        }
        public bool InsertOffer(Offer Offer)
        {
            try
            {
                if (Offer.Id != 0)
                {
                    Offer OfferDetails = DB.Offer.Find(Offer.Id);
                    OfferDetails.Description = Offer.Description;
                    OfferDetails.DiscountAmount = Offer.DiscountAmount;
                    OfferDetails.StartDate = Offer.StartDate;
                    OfferDetails.EndDate = Offer.EndDate;
                    DB.SaveChanges();
                    return true;
                }
                else if (Offer != null)
                {
                    DB.Offer.Add(Offer);
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
        public bool DeleteOffer(int OfferId)
        {
            try
            {
                if (OfferId != 0)
                {
                    Offer OfferDetails = DB.Offer.Find(OfferId);
                    DB.Offer.Remove(OfferDetails);
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
