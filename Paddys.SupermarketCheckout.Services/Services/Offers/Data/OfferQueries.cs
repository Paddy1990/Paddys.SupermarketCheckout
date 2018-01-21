using System;
using System.Collections.Generic;
using System.Text;
using Paddys.SupermarketCheckout.Services.Data;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;

namespace Paddys.SupermarketCheckout.Services.Services.Offers.Data
{
    public class OfferQueries : IOfferQueries
    {
        private readonly ISupermarketDatabase _database;

        public OfferQueries(ISupermarketDatabase database)
        {
            _database = database;
        }

        public IEnumerable<OfferEntity> GetOffers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OfferEntity> GetOffers(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
