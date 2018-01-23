using System.Collections.Generic;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using Paddys.SupermarketCheckout.Services.Services.Products.Data.Models;
using System.Linq;
using System;

namespace Paddys.SupermarketCheckout.Services.Data
{
    public class SupermarketDatabase : ISupermarketDatabase
    {
        private IList<ProductEntity> Products { get; set; }
        private IList<OfferEntity> Offers { get; set; }

        public SupermarketDatabase()
        {
            Products = new List<ProductEntity>();
            AddProducts();

            Offers = new List<OfferEntity>();
            AddOffers();
        }

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

        private void AddProducts()
        {
            InsertProduct(new ProductEntity { Id = 1, Name = "Apple", Description = "Fruit & Veg", Price = 0.50m, Sku = "A15", OfferIds = new List<int> { 1 } });
            InsertProduct(new ProductEntity { Id = 2, Name = "Biscuits", Description = "Biscuits & Cerial", Price = 1.50m, Sku = "B24", OfferIds = new List<int> { 2 } });
            InsertProduct(new ProductEntity { Id = 3, Name = "Chicken", Description = "Meat", Price = 6m, Sku = "C17", OfferIds = new List<int> { 3 } });
            InsertProduct(new ProductEntity { Id = 4, Name = "Yogurt", Description = "Yogurts", Price = 3.75m, Sku = "Y56", OfferIds = new List<int> { 4 } });
        }

        private void AddOffers()
        {
            InsertOffer(new OfferEntity { Id = 1, Name = "3 Apples for £1.00", Price = 1.00m, Quantity = 3, StartDate = new DateTime(2018, 01, 21).Date, EndDate = new DateTime(2018, 01, 21).AddDays(7).Date });
            InsertOffer(new OfferEntity { Id = 2, Name = "5 Biscuits for £5.99", Price = 5.99m, Quantity = 5, StartDate = new DateTime(2018, 01, 21).Date, EndDate = new DateTime(2018, 01, 21).AddDays(7).Date });
            InsertOffer(new OfferEntity { Id = 3, Name = "3 Chickens for £15", Price = 15.00m, Quantity = 3, StartDate = new DateTime(2018, 01, 21).Date, EndDate = new DateTime(2018, 01, 21).AddDays(7).Date });
            InsertOffer(new OfferEntity { Id = 4, Name = "2 Yogurts for £5.99", Price = 5.99m, Quantity = 2, StartDate = new DateTime(2018, 01, 28).Date, EndDate = new DateTime(2018, 01, 21).AddDays(14).Date });

        }

    }
}
