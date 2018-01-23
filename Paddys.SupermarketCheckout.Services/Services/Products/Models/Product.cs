using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Services.Products.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IList<OfferEntity> Offers { get; set; }

        public Product()
        {
            Offers = new List<OfferEntity>();
        }
    }
}
