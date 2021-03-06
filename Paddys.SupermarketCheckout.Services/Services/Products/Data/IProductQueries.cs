﻿using Paddys.SupermarketCheckout.Services.Services.Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Services.Products.Data
{
    public interface IProductQueries
    {
        ProductEntity GetProduct(int id);
        IEnumerable<ProductEntity> GetProducts();
        IEnumerable<ProductEntity> GetProducts(IEnumerable<int> ids);
    }
}
