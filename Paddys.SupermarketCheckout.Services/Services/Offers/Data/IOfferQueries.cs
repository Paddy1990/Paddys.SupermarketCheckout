using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Services.Offers.Data
{
    public interface IOfferQueries
    {
        IEnumerable<OfferEntity> GetOffers();
        IEnumerable<OfferEntity> GetOffers(IEnumerable<int> ids);
    }
}
