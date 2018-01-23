using Microsoft.Extensions.DependencyInjection;
using Paddys.SupermarketCheckout.Client.App;
using System;

namespace Paddys.SupermarketCheckout.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //IOC
            var container = new Container(new ServiceCollection());
            var serviceProvider = container.ConfigureServices();

            //Resolve interface
            var app = serviceProvider.GetService<ISupermarketCheckoutApp>();

            ConsoleKeyInfo input;
            do
            {
                app.Run();
                input = Console.ReadKey();
            }
            while (input.Key != ConsoleKey.Escape);
        }
    }
}
