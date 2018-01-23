using Moq;
using Paddys.SupermarketCheckout.Services.Services.Offers;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data;

namespace Paddys.SupermarketCheckout.Services.Tests.Services.Offers
{
    public class OfferServiceFixtures
    {
        private readonly Mock<IOfferQueries> _offerQueries;

        private readonly OfferService _offerService;

        public OfferServiceFixtures()
        {
            _offerQueries = new Mock<IOfferQueries>();

            _offerService = new OfferService(_offerQueries.Object);
        }
    }
}
