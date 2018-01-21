using System;
using System.Collections.Generic;
using Paddys.SupermarketCheckout.Services.Services.Products.Data.Models;
using Paddys.SupermarketCheckout.Services.Data;
using System.Linq;

namespace Paddys.SupermarketCheckout.Services.Services.Products.Data
{
    public class ProductQueries : IProductQueries
    {
        private readonly ISupermarketDatabase _database;

        public ProductQueries(ISupermarketDatabase database)
        {
            _database = database;
        }

        public ProductEntity GetProduct(int id)
        {
            return _database.GetProduct(id);
        }

        public IEnumerable<ProductEntity> GetProducts()
        {
            return _database.GetProducts();
        }

        public IEnumerable<ProductEntity> GetProducts(IEnumerable<int> ids)
        {
            var products = _database.GetProducts();
            return products.Where(x => ids.Any(y => y == x.Id));
        }
    }
}
