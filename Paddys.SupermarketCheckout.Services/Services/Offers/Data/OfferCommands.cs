using Paddys.SupermarketCheckout.Services.Data;
using Paddys.SupermarketCheckout.Services.Services.Products.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Services.Offers.Data
{
    public class OfferCommands : IOfferCommands
    {
        private readonly ISupermarketDatabase _database;

        public OfferCommands(ISupermarketDatabase database)
        {
            _database = database;
        }
        
    }
}
