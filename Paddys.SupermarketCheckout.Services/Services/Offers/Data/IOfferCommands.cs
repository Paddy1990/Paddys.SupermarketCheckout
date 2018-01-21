using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;

namespace Paddys.SupermarketCheckout.Services.Services.Offers.Data
{
    public interface IOfferCommands
    {
        void InsertOffer(OfferEntity offerEntity);
        void UpdateOffer(OfferEntity offerEntity);
        void DeleteOffer(int id);
    }
}
