using Paddys.SupermarketCheckout.Services.Services.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Tests.Services.Products
{
    public class ProductServiceFixtures
    {
        private readonly ProductsService _productService;

        public ProductServiceFixtures()
        {
            _productService = new ProductsService();
        }
    }
}
