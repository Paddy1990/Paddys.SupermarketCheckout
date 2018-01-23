using System.Collections.Generic;

namespace Paddys.SupermarketCheckout.Services.Services.Baskets.Models
{
    public class Basket
    {
        public decimal Total { get; set; }
        public IList<BasketItem> Items { get; set; }

        public Basket()
        {
            Items = new List<BasketItem>();
        }
    }

}
