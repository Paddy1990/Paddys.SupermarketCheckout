using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Services.Offers
{
    public interface IOfferService
    {
        IList<OfferEntity> GetOpenOffers(int productId);
    }
}
