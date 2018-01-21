using System;
using System.Collections.Generic;
using System.Text;
using Paddys.SupermarketCheckout.Services.Services.Products.Models;
using Paddys.SupermarketCheckout.Services.Services.Products.Data;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data;
using System.Linq;
using Paddys.SupermarketCheckout.Services.Services.Products.Data.Models;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using Paddys.SupermarketCheckout.Services.Services.Offers.Models;

namespace Paddys.SupermarketCheckout.Services.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductQueries _productQueries;
        private readonly IOfferQueries _offerQueries;

        public ProductService(IProductQueries productQueries, IOfferQueries offerQueries)
        {
            _productQueries = productQueries;
            _offerQueries = offerQueries;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _productQueries.GetProducts().ToList();
            if (products != null && products.Count < 1)
                return Enumerable.Empty<Product>();
            
            var offerIds = products.SelectMany(x => x.OfferIds).ToList();
            if (offerIds != null && offerIds.Count < 1)
                return MapServiceModel(products);

            var offers = _offerQueries.GetOffers(offerIds).ToList();
            if (offers != null && offers.Count < 1)
                return MapServiceModel(products);

            return MapServiceModel(products, offers);
        }

        private List<Product> MapServiceModel(IList<ProductEntity> productEntities, IList<OfferEntity> offerEntities = null)
        {
            var model = new List<Product>();
            foreach (var product in productEntities)
            {
                model.Add(new Product
                {
                    Id = product.Id,
                    Sku = product.Sku,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Offers = MapProductOffers(product, offerEntities)
                });
            }

            return model;
        }
        
        public IEnumerable<Offer> MapProductOffers(ProductEntity productEntity, IList<OfferEntity> offerEntities)
        {
            var model = new List<Offer>();
            if (offerEntities == null || offerEntities.Count < 0)
                return model;

            var productOffers = offerEntities.Where(x => productEntity.OfferIds.Any(y => y == x.Id));
            foreach (var offer in productOffers)
            {
                model.Add(new Offer
                {
                    Id = offer.Id,
                    Name = offer.Name,
                    Description = offer.Description,
                    Count = offer.Count,
                    Price = offer.Price
                });
            }

            return model;
        }

    }
}
