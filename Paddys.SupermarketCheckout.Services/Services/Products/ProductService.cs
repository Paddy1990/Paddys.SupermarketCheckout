using System;
using System.Collections.Generic;
using System.Text;
using Paddys.SupermarketCheckout.Services.Services.Products.Models;
using Paddys.SupermarketCheckout.Services.Services.Products.Data;

namespace Paddys.SupermarketCheckout.Services.Services.Products
{
    public class ProductService : IProductService
        {
            private readonly IProductQueries _productQueries;

        public ProductService(IProductQueries productQueries)
        {
            _productQueries = productQueries;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productQueries.GetProducts();
        }
        
    }
}
