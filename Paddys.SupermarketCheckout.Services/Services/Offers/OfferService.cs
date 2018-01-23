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

        public IList<OfferEntity> GetOpenOffers(int productId)
        {
            return _offerQueries.GetOpenOffers(productId).ToList();
        }
    }
}
