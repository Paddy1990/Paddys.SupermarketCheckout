using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using Paddys.SupermarketCheckout.Services.Services.Products.Data.Models;
using System.Collections.Generic;

namespace Paddys.SupermarketCheckout.Services.Data
{
    public interface ISupermarketDatabase
    {
        //User GetUser(int id);
        //IEnumerable<User> GetUsers();

        ProductEntity GetProduct(int id);
        IEnumerable<ProductEntity> GetProducts();
        void InsertProduct(ProductEntity productEntity);
        void UpdateProduct(ProductEntity productEntity);
        void DeleteProduct(int id);

        OfferEntity GetOffer(int id);
        IEnumerable<OfferEntity> GetOffers();
        void InsertOffer(OfferEntity offerEntity);
        void UpdateOffer(OfferEntity offerEntity);
        void DeleteOffer(int id);

    }
}
