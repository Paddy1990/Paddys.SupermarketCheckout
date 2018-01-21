using System;
using System.Collections.Generic;
using System.Text;
using Paddys.SupermarketCheckout.Services.Services.Products.Data.Models;
using Paddys.SupermarketCheckout.Services.Data;

namespace Paddys.SupermarketCheckout.Services.Services.Products.Data
{
    public class ProductQueries : IProductQueries
    {
        private readonly ISupermarketDatabase _database;

        public ProductQueries(ISupermarketDatabase database)
        {
            _database = database;
        }

        public IEnumerable<ProductEntity> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
