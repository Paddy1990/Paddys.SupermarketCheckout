using System.Collections.Generic;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using Paddys.SupermarketCheckout.Services.Services.Products.Data.Models;
using System.Linq;

namespace Paddys.SupermarketCheckout.Services.Data
{
    public class SupermarketDatabase : ISupermarketDatabase
    {
        public IList<ProductEntity> Products { get; set; }
        public IList<OfferEntity> Offers { get; set; }

        public ProductEntity GetProduct(int id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ProductEntity> GetProducts()
        {
            return Products;
        }

        public void InsertProduct(ProductEntity productEntity)
        {
            var product = Products.FirstOrDefault(x => x.Id == productEntity.Id);
            if (product != null)
                return;

            Products.Add(productEntity);
        }

        public void UpdateProduct(ProductEntity productEntity)
        {
            var product = Products.FirstOrDefault(x => x.Id == productEntity.Id);
            if (product == null)
                return;

            Products.Remove(product);
            Products.Add(productEntity);
        }

        public void DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return;

            Products.Remove(product);
        }

        public OfferEntity GetOffer(int id)
        {
            return Offers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<OfferEntity> GetOffers()
        {
            return Offers;
        }

        public void InsertOffer(OfferEntity offerEntity)
        {
            var offer = Offers.FirstOrDefault(x => x.Id == offerEntity.Id);
            if (offer != null)
                return;

            Offers.Add(offerEntity);
        }

        public void UpdateOffer(OfferEntity offerEntity)
        {
            var offer = Offers.FirstOrDefault(x => x.Id == offerEntity.Id);
            if (offer == null)
                return;

            Offers.Remove(offer);
            Offers.Add(offerEntity);
        }

        public void DeleteOffer(int id)
        {
            var offer = Offers.FirstOrDefault(x => x.Id == id);
            if (offer == null)
                return;
            
            Offers.Remove(offer);
        }

    }
}
