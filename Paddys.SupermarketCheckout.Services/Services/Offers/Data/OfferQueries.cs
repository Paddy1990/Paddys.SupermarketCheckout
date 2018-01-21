using System;
using System.Collections.Generic;
using Paddys.SupermarketCheckout.Services.Data;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using System.Linq;

namespace Paddys.SupermarketCheckout.Services.Services.Offers.Data
{
    public class OfferQueries : IOfferQueries
    {
        private readonly ISupermarketDatabase _database;

        public OfferQueries(ISupermarketDatabase database)
        {
            _database = database;
        }

        public OfferEntity GetOffer(int id)
        {
            return _database.GetOffer(id);
        }

        public IEnumerable<OfferEntity> GetOffers()
        {
            return _database.GetOffers();
        }

        public IEnumerable<OfferEntity> GetOffers(IEnumerable<int> ids)
        {
            var offers = _database.GetOffers();
            return offers.Where(x => ids.Any(y => y == x.Id));
        }
    }
}
