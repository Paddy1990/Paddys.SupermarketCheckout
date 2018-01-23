using Paddys.SupermarketCheckout.Services.Services.Baskets.Models;

namespace Paddys.SupermarketCheckout.Services.Services.Baskets
{
    public interface IBasketService
    {
        Basket GetBasketSummary(Basket basket);
    }
}
