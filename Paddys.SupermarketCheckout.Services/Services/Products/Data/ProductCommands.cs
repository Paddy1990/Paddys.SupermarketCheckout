using Paddys.SupermarketCheckout.Services.Data;
using Paddys.SupermarketCheckout.Services.Services.Products.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Paddys.SupermarketCheckout.Services.Services.Products.Data.Models;

namespace Paddys.SupermarketCheckout.Services.Services.Products.Data
{
    public class ProductCommands : IProductCommands
    {
        private readonly ISupermarketDatabase _database;

        public ProductCommands(ISupermarketDatabase database)
        {
            _database = database;
        }

        public void InsertProduct(ProductEntity productEntity)
        {
            _database.InsertProduct(productEntity);
        }

        public void UpdateProduct(ProductEntity productEntity)
        {
            _database.UpdateProduct(productEntity);
        }

        public void DeleteProduct(int id)
        {
            _database.DeleteProduct(id);
        }

    }
}
