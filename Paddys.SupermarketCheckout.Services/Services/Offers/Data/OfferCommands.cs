using Paddys.SupermarketCheckout.Services.Data;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using System;

namespace Paddys.SupermarketCheckout.Services.Services.Offers.Data
{
    public class OfferCommands : IOfferCommands
    {
        private readonly ISupermarketDatabase _database;

        public OfferCommands(ISupermarketDatabase database)
        {
            _database = database;
        }

        public void DeleteOffer(int id)
        {
            _database.DeleteOffer(id);
        }

        public void InsertOffer(OfferEntity offer)
        {
            _database.InsertOffer(offer);
        }

        public void UpdateOffer(OfferEntity offer)
        {
            _database.UpdateOffer(offer);
        }
    }
}
