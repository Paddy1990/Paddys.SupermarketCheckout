﻿using System.Collections.Generic;
using Paddys.SupermarketCheckout.Services.Services.Baskets.Models;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using System.Linq;

namespace Paddys.SupermarketCheckout.Services.Services.Baskets
{
    public class BasketService : IBasketService
    {
        private readonly IOfferQueries _offerQueries;

        public BasketService(IOfferQueries offerQueries)
        {
            _offerQueries = offerQueries;
        }

        public Basket GetBasketSummary(Basket basket)
        {
            return new Basket
            {
                Total = CalculateBasketTotal(basket),
                Items = basket.Items
            };
        }

        private decimal CalculateBasketTotal(Basket basket)
        {
            var total = 0m;
            foreach (var item in basket.Items)
            {
                var itemPrice = item.Product.Price * item.Quantity;

                var offers = _offerQueries.GetOpenOffers(item.Product.Offers.Select(x => x.Id)).ToList();
                var newPrice = CalculateOffersDiscount(offers, item.Product.Price, item.Quantity, itemPrice);

                item.Total = newPrice;
                total += item.Total;
            }
            return total;
        }

        private decimal CalculateOffersDiscount(IList<OfferEntity> offers, decimal itemPrice, int quantity, decimal originalPrice)
        {
            var newPrice = originalPrice;
            foreach (var offer in offers)
            {
                var removedPrice = 0m;
                if (quantity < offer.Quantity)
                    continue;
                
                if (quantity == offer.Quantity)
                    removedPrice = originalPrice - offer.Price;

                if (quantity > offer.Quantity)
                    removedPrice = itemPrice * offer.Quantity;

                newPrice -= removedPrice;

            }
            return newPrice;
        }

    }
}
