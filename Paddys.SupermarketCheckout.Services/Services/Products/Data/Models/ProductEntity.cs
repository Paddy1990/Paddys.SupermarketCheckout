using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Services.Products.Data.Models
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> OfferIds { get; set; }

        public ProductEntity()
        {
            OfferIds = new List<int>();
        }
    }
}
