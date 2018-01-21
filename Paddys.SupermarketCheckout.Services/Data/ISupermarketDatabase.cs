using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using Paddys.SupermarketCheckout.Services.Services.Products.Data.Models;
using Paddys.SupermarketCheckout.Services.Services.Products.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Data
{
    public interface ISupermarketDatabase
    {
        //User GetUser(int id);
        //IEnumerable<User> GetUsers();

        Product GetProduct(int id);
        IEnumerable<ProductEntity> GetProducts();
        int UpdateProduct(ProductEntity product);
        int InsertProduct(ProductEntity product);
        int DeleteProduct(ProductEntity product);

        Product GetOffer(int id);
        IEnumerable<OfferEntity> GetOffers();
        int UpdateOffer(OfferEntity product);
        int DeleteOffer(OfferEntity product);

    }
}
