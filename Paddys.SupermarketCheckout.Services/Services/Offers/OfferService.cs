using System;
using System.Collections.Generic;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data;
using System.Linq;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;

namespace Paddys.SupermarketCheckout.Services.Services.Offers
{
    public class OfferService : IOfferService
    {
        private readonly IOfferQueries _offerQueries;

        public OfferService(IOfferQueries offerQueries)
        {
            _offerQueries = offerQueries;
        }

        public IList<OfferEntity> GetOffers()
        {
            return _offerQueries.GetOffers().ToList();
        }

        public IList<OfferEntity> GetOpenOffers(IEnumerable<int> ids)
        {
            return _offerQueries.GetOpenOffers(ids).ToList();
        }
    }
}
