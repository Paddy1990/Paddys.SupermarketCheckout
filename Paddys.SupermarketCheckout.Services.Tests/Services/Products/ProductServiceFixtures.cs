﻿using Moq;
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
    public class ProductServiceFixtures
    {
        private readonly Mock<IProductQueries> _productQueries;

        private readonly ProductService _productService;

        public ProductServiceFixtures()
        {
            _productQueries = new Mock<IProductQueries>();

            _productService = new ProductService(_productQueries.Object);
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
            results.ShouldBe(products);
        }

        [Fact]
        public void GetProducts_ShouldReturn_CorrectCount()
        {
            //Arrange
            var products = ArrangeProductsList();
            var productCount = products.Count;

            _productQueries.Setup(x => x.GetProducts()).Returns(products);

            //Act
            var results = _productService.GetProducts().ToList();

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
