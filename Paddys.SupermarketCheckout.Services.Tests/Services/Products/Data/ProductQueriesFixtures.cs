using Moq;
using Paddys.SupermarketCheckout.Services.Data;
using Paddys.SupermarketCheckout.Services.Services.Products;
using Paddys.SupermarketCheckout.Services.Services.Products.Data;
using Paddys.SupermarketCheckout.Services.Services.Products.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Paddys.SupermarketCheckout.Services.Tests.Services.Products
{
    public class ProductQueriesFixtures
    {
        private readonly Mock<ISupermarketDatabase> _database;

        private readonly ProductQueries _productQueries;

        public ProductQueriesFixtures()
        {
            _database = new Mock<ISupermarketDatabase>();

            _productQueries = new ProductQueries(_database.Object);
        }

        [Fact]
        public void GetProducts_ShouldReturn_ProductsList()
        {
            //Arrange
            var products = ArrangeProductsList();
            var productCount = products.Count;

            _database.Setup(x => x.GetProducts()).Returns(products);

            //Act
            var results = _productQueries.GetProducts().ToList();
                    
            //Assert
            results.ShouldBe(products);
        }

        [Fact]
        public void GetProducts_ShouldReturn_CorrectCount()
        {
            //Arrange
            var products = ArrangeProductsList();
            var productCount = products.Count;

            _database.Setup(x => x.GetProducts()).Returns(products);

            //Act
            var results = _productQueries.GetProducts().ToList();

            //Assert
            results.Count.ShouldBe(productCount);
        }

        private List<Product> ArrangeProductsList()
        {
            return new List<Product>
            {
                new Product 
                {
                    Id = 1,
                    Sku = "A01",
                    Name = "Apple",
                    Description = "Apple",
                    CategoryId = 1,
                    CategoryName = "Fruit And Veg",
                    Price = 0.50M
                },
                new Product
                {
                    Id = 2,
                    Sku = "B15",
                    Name = "Biscuits",
                    Description = "Biscuits",
                    CategoryId = 2,
                    CategoryName = "Bakery",
                    Price = 2.50M
                }
            };
        }
    }
}
