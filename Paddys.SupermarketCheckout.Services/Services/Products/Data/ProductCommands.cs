﻿using Paddys.SupermarketCheckout.Services.Data;
using Paddys.SupermarketCheckout.Services.Services.Products.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Services.Products.Data
{
    public class ProductCommands : IProductCommands
    {
        private readonly ISupermarketDatabase _database;

        public ProductCommands(ISupermarketDatabase database)
        {
            _database = database;
        }
        
    }
}
