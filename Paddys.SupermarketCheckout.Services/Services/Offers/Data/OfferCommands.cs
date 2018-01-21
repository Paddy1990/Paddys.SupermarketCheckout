using Paddys.SupermarketCheckout.Services.Data;
using System;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;

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

        public void InsertOffer(OfferEntity offerEntity)
        {
            _database.InsertOffer(offerEntity);
        }

        public void UpdateOffer(OfferEntity offerEntity)
        {
            _database.UpdateOffer(offerEntity);
        }
    }
}
