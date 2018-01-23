using Paddys.SupermarketCheckout.Services.Services.Products.Models;

namespace Paddys.SupermarketCheckout.Services.Services.Baskets.Models
{
    public class BasketItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
