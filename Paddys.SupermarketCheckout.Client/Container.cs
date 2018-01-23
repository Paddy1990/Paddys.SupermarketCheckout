using Microsoft.Extensions.DependencyInjection;
using Paddys.SupermarketCheckout.Services.Services.Products;
using Paddys.SupermarketCheckout.Services.Services.Offers;
using System;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data;
using Paddys.SupermarketCheckout.Services.Services.Products.Data;
using Paddys.SupermarketCheckout.Services.Data;
using Paddys.SupermarketCheckout.Client.App;
using Paddys.SupermarketCheckout.Services.Services.Baskets;

namespace Paddys.SupermarketCheckout.Client
{
    public class Container : IContainer
    {
        private ServiceCollection _serviceCollection;

        public Container(ServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public IServiceProvider ConfigureServices()
        {
            //setup our DI
            var _serviceProvider = _serviceCollection
                .AddSingleton<IBasketService, BasketService>()
                .AddSingleton<IProductService, ProductService>()
                .AddSingleton<IProductQueries, ProductQueries>()
                .AddSingleton<IProductCommands, ProductCommands>()
                .AddSingleton<IOfferService, OfferService>()
                .AddSingleton<IOfferQueries, OfferQueries>()
                .AddSingleton<IOfferCommands, OfferCommands>()
                .AddSingleton<ISupermarketDatabase, SupermarketDatabase>()
                .AddSingleton<ISupermarketCheckoutApp, SupermarketCheckoutApp>()
                .BuildServiceProvider();
            
            return _serviceProvider;
        }
    }

    public interface IContainer
    {
        IServiceProvider ConfigureServices();
    }
}
