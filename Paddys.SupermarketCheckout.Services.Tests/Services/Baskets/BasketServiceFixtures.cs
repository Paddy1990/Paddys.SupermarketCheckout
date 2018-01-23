using Moq;
using Paddys.SupermarketCheckout.Services.Services.Baskets;
using Paddys.SupermarketCheckout.Services.Services.Baskets.Models;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using Paddys.SupermarketCheckout.Services.Services.Products.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Paddys.SupermarketCheckout.Services.Tests.Services.Baskets
{
    public class BasketServiceFixtures
    {
        private readonly Mock<IOfferQueries> _offerQueries;

        private readonly BasketService _basketService;

        public BasketServiceFixtures()
        {
            _offerQueries = new Mock<IOfferQueries>();

            _basketService = new BasketService(_offerQueries.Object);
        }

        [Fact]
        public void GetBasketSummary_ReturnsTotal()
        {
            //Arrange
            var basket = ArrangeSingleBasket();

            //Act
            var result = _basketService.GetBasketSummary(basket);

            //Assert
            result.Total.ShouldBe(1.50m);
            result.Items.Count.ShouldBe(1);
            result.Items[0].Total.ShouldBe(1.50m);
        }

        [Fact]
        public void GetBasketSummary_ReturnsTotal_WhenMultipleProducts()
        {
            //Arrange
            var basket = ArrangeMultiBasket();

            //Act
            var result = _basketService.GetBasketSummary(basket);

            //Assert
            result.Total.ShouldBe(6.50m);
            result.Items.Count.ShouldBe(2);
            result.Items[0].Total.ShouldBe(1.50m);
            result.Items[1].Total.ShouldBe(5.00m);
        }

        [Fact]
        public void GetBasketSummary_ReturnsTotal_WhenOffersApply()
        {
            //Arrange
            var basket = ArrangeSingleBasketWithOffers();
            
            _offerQueries.Setup(x => x.GetOpenOffers(basket.Items[0].Product.Offers.Select(y => y.Id)))
                .Returns(new List<OfferEntity> { ArrangeSingleOffer() });

            //Act
            var result = _basketService.GetBasketSummary(basket);

            //Assert
            result.Total.ShouldBe(3.00m);
            result.Items.Count.ShouldBe(1);
            result.Items[0].Total.ShouldBe(3.00m);
        }

        [Fact]
        public void GetBasketSummary_ReturnsTotal_WhenMultipleProductsAndOffersApply()
        {
            //Arrange
            var basket = ArrangeMultiBasketWithOffers();

            _offerQueries.Setup(x => x.GetOpenOffers(basket.Items[0].Product.Offers.Select(y => y.Id)))
                .Returns(new List<OfferEntity> { ArrangeSingleOffer() });

            //Act
            var result = _basketService.GetBasketSummary(basket);

            //Assert
            result.Total.ShouldBe(4.50m);
            result.Items.Count.ShouldBe(2);
            result.Items[0].Total.ShouldBe(1.50m);
            result.Items[1].Total.ShouldBe(3.00m);
        }

        private static Basket ArrangeSingleBasket()
        {
            //Arrange
            return new Basket
            {
                Items = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = new Product { Name = "test", Price = 0.50m },
                        Quantity = 3
                    }
                }
            };
        }

        private static Basket ArrangeMultiBasket()
        {
            //Arrange
            return new Basket
            {
                Items = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = new Product { Name = "test", Price = 0.50m },
                        Quantity = 3
                    },
                    new BasketItem
                    {
                        Product = new Product { Name = "test 2", Price = 1.00m },
                        Quantity = 5
                    }
                }
            };
        }

        private static Basket ArrangeSingleBasketWithOffers()
        {
            //Arrange
            return new Basket
            {
                Items = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = new Product
                        {
                            Name = "test 2",
                            Price = 1.00m,
                            Offers = new List<OfferEntity> { ArrangeSingleOffer() }
                        },
                        Quantity = 5
                    }
                }
            };
        }

        private static Basket ArrangeMultiBasketWithOffers()
        {
            //Arrange
            return new Basket
            {
                Items = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = new Product { Name = "test", Price = 0.50m },
                        Quantity = 3
                    },
                    new BasketItem
                    {
                        Product = new Product
                        {
                            Name = "test 2",
                            Price = 1.00m,
                            Offers = new List<OfferEntity> { ArrangeSingleOffer() }
                        },
                        Quantity = 5
                    }
                }
            };
        }

        private static OfferEntity ArrangeSingleOffer()
        {
            return new OfferEntity
            {
                Id = 1,
                Name = "Test Offer",
                Price = 3.00m,
                Quantity = 5,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(5)
            };
        }

    }
}
