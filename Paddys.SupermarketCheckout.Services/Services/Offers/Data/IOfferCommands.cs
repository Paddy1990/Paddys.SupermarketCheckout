using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;

namespace Paddys.SupermarketCheckout.Services.Services.Offers.Data
{
    public interface IOfferCommands
    {
        void InsertOffer(OfferEntity offer);
        void UpdateOffer(OfferEntity offer);
        void DeleteOffer(int id);
    }
}
