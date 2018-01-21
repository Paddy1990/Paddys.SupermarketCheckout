using Paddys.SupermarketCheckout.Services.Services.Offers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Tests.Services.Offers
{
    public class OfferServiceFixtures
    {
        private readonly OfferService _offerService;

        public OfferServiceFixtures()
        {
            _offerService = new OfferService();
        }
    }
}
