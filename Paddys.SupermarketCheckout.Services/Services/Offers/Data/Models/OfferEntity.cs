using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models
{
    public class OfferEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
