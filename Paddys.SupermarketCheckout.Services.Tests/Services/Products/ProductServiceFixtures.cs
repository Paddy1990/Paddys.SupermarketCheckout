using Moq;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using Paddys.SupermarketCheckout.Services.Services.Products;
using Paddys.SupermarketCheckout.Services.Services.Products.Data;
using Paddys.SupermarketCheckout.Services.Services.Products.Data.Models;
using Paddys.SupermarketCheckout.Services.Services.Products.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Paddys.SupermarketCheckout.Services.Tests.Services.Products
{
    public class ProductServiceFixtures
    {
        private readonly Mock<IProductQueries> _productQueries;
        private readonly Mock<IOfferQueries> _offerQueries;

        private readonly ProductService _productService;

        public ProductServiceFixtures()
        {
            _productQueries = new Mock<IProductQueries>();
            _offerQueries = new Mock<IOfferQueries>();

            _productService = new ProductService(_productQueries.Object, _offerQueries.Object);
        }

        [Fact]
        public void GetProducts_ShouldReturn_EmptyProductsList_WhenNoProducts()
        {
            //Arrange
            var products = new List<ProductEntity>();
            var productCount = 0;
            _productQueries.Setup(x => x.GetProducts()).Returns(products);

            //Act
            var results = _productService.GetProducts().ToList();

            //Assert
            results.Count.ShouldBe(productCount);
        }

        [Fact]
        public void GetProducts_ShouldReturn_ProductsList()
        {
            //Arrange
            var products = ArrangeProductsList();
            var productCount = products.Count;
            _productQueries.Setup(x => x.GetProducts()).Returns(products);

            //Act
            var results = _productService.GetProducts().ToList();

            //Assert
            results.ShouldNotBeEmpty();
            results.Count.ShouldBe(productCount);

            results[0].Id.ShouldBe(products[0].Id);
            results[1].Id.ShouldBe(products[1].Id);
        }

        [Fact]
        public void GetProducts_ShouldReturn_ProductsList_WithNoOffers()
        {
            //Arrange
            var products = ArrangeProductsList();
            var productCount = products.Count;
            _productQueries.Setup(x => x.GetProducts()).Returns(products);
            
            //Act
            var results = _productService.GetProducts().ToList();

            //Assert
            var offers1 = results[0].Offers.ToList();
            offers1.ShouldBeEmpty();
            offers1.Count.ShouldBe(0);

            var offers2 = results[1].Offers.ToList();
            offers2.ShouldBeEmpty();
            offers2.Count.ShouldBe(0);
        }

        [Fact]
        public void GetProducts_ShouldReturn_ProductsList_WithOffers()
        {
            //Arrange
            var products = ArrangeProductsListWithOfferIds();
            var productCount = products.Count;
            _productQueries.Setup(x => x.GetProducts()).Returns(products);

            var offers = ArrangeOffersList(products);
            var offerIds = offers.Select(x => x.Id);
            _offerQueries.Setup(x => x.GetOffers(offerIds)).Returns(offers);

            //Act
            var results = _productService.GetProducts().ToList();

            //Assert
            var offers1 = results[0].Offers.ToList();
            results[0].Id.ShouldBe(products[0].Id);
            offers1.ShouldNotBeEmpty();
            offers1.Count.ShouldBe(1);
            offers1[0].Id.ShouldBe(products[0].OfferIds.First());
            
            var offers2 = results[1].Offers.ToList();
            results[1].Id.ShouldBe(products[1].Id);
            offers2.ShouldNotBeEmpty();
            offers2.Count.ShouldBe(1);
            offers2[0].Id.ShouldBe(products[1].OfferIds.First());
        }

        private List<ProductEntity> ArrangeProductsList()
        {
            return new List<ProductEntity>
            {
                new ProductEntity { Id = 1, Sku = "A01", Name = "Apple", Description = "Apple", Price = 0.50M },
                new ProductEntity { Id = 2, Sku = "B15", Name = "Biscuits", Description = "Biscuits", Price = 2.50M }
            };
        }

        private List<ProductEntity> ArrangeProductsListWithOfferIds()
        {
            return new List<ProductEntity>
            {
                new ProductEntity { Id = 1, Sku = "A01", Name = "Apple", Description = "Apple", Price = 0.50M, OfferIds = new List<int> { 1 } },
                new ProductEntity { Id = 2, Sku = "B15", Name = "Biscuits", Description = "Biscuits", Price = 2.50M, OfferIds = new List<int> { 2 } }
            };
        }

        private List<OfferEntity> ArrangeOffersList(List<ProductEntity> products)
        {
            var model = new List<OfferEntity>();
            
            foreach (var product in products)
            {
                foreach (var offerId in product.OfferIds)
                {
                    model.Add(new OfferEntity
                    {
                        Id = offerId,
                        Name = string.Format("{0} - Buy 3 for 2!", product.Name),
                        Description = string.Format("Buy 3 for 2 on {0} products!", product.Name),
                        Count = 3,
                        Price = (product.Price * 3) - product.Price // buy 3 for 2
                    });

                }
                var offers = product.OfferIds;
            }

            return model;
        }

    }
}
