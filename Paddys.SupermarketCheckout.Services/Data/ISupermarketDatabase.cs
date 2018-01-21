using Paddys.SupermarketCheckout.Services.Services.Offers.Models;
using Paddys.SupermarketCheckout.Services.Services.Products.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paddys.SupermarketCheckout.Services.Data
{
    public interface ISupermarketDatabase
    {
        Product GetUser(int id);
        IEnumerable<Product> GetUsers();

        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        int UpdateProduct(Product product);
        int InsertProduct(Product product);
        int DeleteProduct(Product product);

        Product GetOffer(int id);
        IEnumerable<Offer> GetOffers();
        int UpdateOffer(Offer product);
        int DeleteOffer(Offer product);

    }
}
