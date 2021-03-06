﻿using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using System.Collections.Generic;

namespace Paddys.SupermarketCheckout.Services.Services.Offers.Data
{
    public interface IOfferQueries
    {
        OfferEntity GetOffer(int id);
        IEnumerable<OfferEntity> GetOffers();
        IEnumerable<OfferEntity> GetOffers(IEnumerable<int> offerIds);

        IEnumerable<OfferEntity> GetOpenOffers(IEnumerable<int> offerIds);
    }
}
