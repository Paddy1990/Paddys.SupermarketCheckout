﻿using Paddys.SupermarketCheckout.Services.Services.Products.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Services.Products
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}
