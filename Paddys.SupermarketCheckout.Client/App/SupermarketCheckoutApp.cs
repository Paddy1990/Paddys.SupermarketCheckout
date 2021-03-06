﻿using ConsoleTables;
using Paddys.SupermarketCheckout.Client.Constants;
using Paddys.SupermarketCheckout.Services.Services.Baskets;
using Paddys.SupermarketCheckout.Services.Services.Baskets.Models;
using Paddys.SupermarketCheckout.Services.Services.Offers;
using Paddys.SupermarketCheckout.Services.Services.Offers.Data.Models;
using Paddys.SupermarketCheckout.Services.Services.Products;
using Paddys.SupermarketCheckout.Services.Services.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paddys.SupermarketCheckout.Client.App
{
    public class SupermarketCheckoutApp : ISupermarketCheckoutApp
    {
        private IList<Product> Products { get; set; }
        private IList<OfferEntity> Offers { get; set; }
        private Basket Basket { get; set; }

        private readonly IProductService _productService;
        private readonly IOfferService _offerService;
        private readonly IBasketService _basketService;

        public SupermarketCheckoutApp(IProductService productService, IOfferService offerService, IBasketService basketService)
        {
            _productService = productService;
            _offerService = offerService;
            _basketService = basketService;

        }

        public void Run()
        {
            //Step 1. Display initial text.
            DisplayWelcomeText();
            DisplayChooseUserText();

            //Step 2. Capture the user input and validate against user keys.
            var userInput = CaptureUserInput();

            //Step 3. Get the products and offers.
            Products = _productService.GetProducts().ToList();
            Offers = _offerService.GetOffers().ToList();
            Basket = new Basket();

            if (userInput.Key == InputKeys.AdminUserKey)
                RunAdministratorApp();
            else if (userInput.Key == InputKeys.CustomerUserKey)
                RunCustomerApp();
        }

        private void RunCustomerApp()
        {
            if (Products.Count < 1)
            {
                Console.WriteLine();
                Console.WriteLine("Could not find any products!");
                return;
            }

            //Step 1. Display the products list.
            DisplayProductTable();

            //Step 2. Capture the product input and validate against product Sku
            var productInput = CaptureProductInput();
            var product = Products.FirstOrDefault(x => x.Sku.ToUpper() == productInput.ToUpper());
            var basketItem = new BasketItem { Product = product };

            //Step 3. Display Choose Quantity Text
            DisplayChooseQuantityText(product.Name);

            //Step 4. Capture the Quantity
            var productQuantity = CaptureProductQuantityInput(product.Name);
            basketItem.Quantity = productQuantity;
            Basket.Items.Add(basketItem);

            //Step 5. Display The Basket Options
            DisplayBasketOptionsText();

            //Step 6. Capture Basket Option
            var basketOption = CaptureBasketOptionsInput();

            //Step 7. Loop if we want to add another product
            if (basketOption.Key == InputKeys.AnotherProductKey)
                RunCustomerApp();
            else if (basketOption.Key != InputKeys.GoToBasketKey)
                throw new Exception("An error has occured - the basket option input is incorrect");

            //Step 8. Go and get the basket total from the service.
            var basketSummary = _basketService.GetBasketSummary(Basket);
            if (basketSummary.Items.Count < 1)
            {
                Console.WriteLine();
                Console.WriteLine("Nothing to display in the basket.");
                return;
            }

            //Step 9. Display the basket summary
            DisplayBasketSummaryTable(basketSummary);
        }

        private void RunAdministratorApp()
        {
            if (Products.Count < 1)
            {
                Console.WriteLine();
                Console.WriteLine("Could not find any products!");
                Console.WriteLine();
                return;
            }

            //Step 1. Display the products list.
            DisplayProductTable();

            //Step 2. Capture the product input and validate against product Sku
            var productInput = CaptureProductInput();
            var product = Products.FirstOrDefault(x => x.Sku.ToUpper() == productInput.ToUpper());
            var basketItem = new BasketItem { Product = product };

            if (Offers.Count < 1)
            {
                Console.WriteLine();
                Console.WriteLine("Could not find any offers!");
                Console.WriteLine();
            }

            //Step 3. Display Offer Table
            DisplayOfferTable();

            //Step 5. Display The Administrator Options
            DisplayAdminOptionsText();

            //Choose Offer from list.
            var adminOption = CaptureAdminOptionsInput();

            if (adminOption.Key == InputKeys.AdminAddOfferKey)
            {
                //Add new offer
            }

            if (adminOption.Key == InputKeys.AdminEditOfferKey)
            {
                //Edit existing offer
            }
            
        }

        private void DisplayAdminOptionsText()
        {
            Console.WriteLine("Please choose an option:");

            Console.WriteLine("[A] Add Offer");
            //if (Offers.Count > 0)
            //    Console.WriteLine("[E] Edit Offer");
        }

        private ConsoleKeyInfo CaptureAdminOptionsInput()
        {
            var input = Console.ReadKey();
            if (!AdminOptionsValid(input))
            {
                Console.WriteLine();
                Console.WriteLine("Input incorrect, Please input an option using their key.");

                DisplayAdminOptionsText();
                return CaptureAdminOptionsInput();
            }

            return input;
        }

        private bool AdminOptionsValid(ConsoleKeyInfo input)
        {
            if (input.Key != InputKeys.AdminAddOfferKey && input.Key != InputKeys.AdminEditOfferKey)
                return false;

            return true;
        }


        private void DisplayOfferTable()
        {
            if (Offers.Count < 1)
                return;

            Console.WriteLine();

            var table = new ConsoleTable("Id", "Name", "Price", "Quantity", "Start Date", "End Date");
            foreach (var offer in Offers)
            {
                table.AddRow(offer.Id, offer.Name, offer.Price, offer.Quantity, offer.StartDate, offer.EndDate);
            }

            table.Write();

            Console.WriteLine();
            Console.WriteLine("Please choose an offer by inputting their SKU:");
        }

        private string CaptureOfferInput()
        {
            string input = Console.ReadLine();
            var inputValid = OfferInputValid(input);
            if (!inputValid)
            {
                Console.WriteLine();
                Console.WriteLine($"Could not find an offer with the Id {input}, please choose another!");

                DisplayOfferTable();
                return CaptureOfferInput();
            }

            return input;
        }

        private bool OfferInputValid(string input)
        {
            if (!int.TryParse(input, out int value))
                return false;

            var selectedOffer = Offers.FirstOrDefault(x => x.Id == value);
            if (selectedOffer == null)
                return false;

            return true;
        }

        
        private void CaptureOfferDetails()
        {
            var offer = new OfferEntity();
            //DisplayEditOfferPropertyText("Name");

        }


        private void DisplayWelcomeText()
        {
            Console.WriteLine("Welcome To Paddy's Supermarket.");
        }

        private void DisplayChooseUserText()
        {
            Console.WriteLine("Please choose a user from below by selecting their key:");

            Console.WriteLine($"[{InputKeys.AdminUserKey}] Administrator");
            Console.WriteLine($"[{InputKeys.CustomerUserKey}] Customer");
        }
        
        private ConsoleKeyInfo CaptureUserInput()
        {
            var input = Console.ReadKey();
            if (!UserInputValid(input))
            {
                Console.WriteLine();
                Console.WriteLine("Could not find a user with the key, please choose another!");

                DisplayChooseUserText();
                return CaptureUserInput();
            }
            
            return input;
        }

        private bool UserInputValid(ConsoleKeyInfo input)
        {
            if (input.Key != InputKeys.AdminUserKey && input.Key != InputKeys.CustomerUserKey)
                return false;

            return true;
        }
        

        private void DisplayProductTable()
        {
            if (Products.Count < 1)
                return;

            Console.WriteLine();

            var table = new ConsoleTable("SKU", "Description", "Unit Price", "Special Offer");

            foreach (var product in Products)
            {
                var offers = product.Offers.OrderBy(x => x.StartDate).ToList();
                var offersText = string.Empty;
                foreach (var offer in offers)
                    offersText += offer.Name + " | " ;

                table.AddRow(product.Sku, $"{product.Name} - {product.Description}", product.Price, offersText);
            }
            
            table.Write();

            Console.WriteLine();
            Console.WriteLine("Please choose a product by inputting their SKU:");
        }

        private string CaptureProductInput()
        {
            string input = Console.ReadLine();
            var inputValid = ProductInputValid(input);
            if (!inputValid)
            {
                Console.WriteLine();
                Console.WriteLine($"Could not find a product with the SKU {input}, please choose another!");

                DisplayProductTable();
                return CaptureProductInput();
            }
            
            return input;
        }

        private bool ProductInputValid(string input)
        {
            var selectedProduct = Products.FirstOrDefault(x => x.Sku.ToUpper() == input.ToUpper());
            if (selectedProduct == null)
                return false;

            return true;
        }


        private void DisplayChooseQuantityText(string productName)
        {
            Console.WriteLine($"Please choose the quantity of {productName}:");
        }

        private int CaptureProductQuantityInput(string productName)
        {
            string input = Console.ReadLine();
            var inputValid = ProductQuantityValid(input);
            if (!inputValid)
            {
                Console.WriteLine();
                Console.WriteLine("Input incorrect, Please input an integer.");

                DisplayChooseQuantityText(productName);
                return CaptureProductQuantityInput(productName);
            }

            return int.Parse(input);
        }

        private bool ProductQuantityValid(string input)
        {
            if (!int.TryParse(input, out int value))
                return false;

            return true;
        }


        private void DisplayBasketOptionsText()
        {
            Console.WriteLine("Please choose an option:");

            Console.WriteLine("[A] Choose Another Product");
            Console.WriteLine("[B] Go To Basket");
        }

        private ConsoleKeyInfo CaptureBasketOptionsInput()
        {
            var input = Console.ReadKey();
            if (!BasketOptionValid(input))
            {
                Console.WriteLine();
                Console.WriteLine("Input incorrect, Please input an option using their key.");

                DisplayBasketOptionsText();
                return CaptureBasketOptionsInput();
            }
            
            return input;
        }

        private bool BasketOptionValid(ConsoleKeyInfo input)
        {
            if (input.Key != InputKeys.AnotherProductKey && input.Key != InputKeys.GoToBasketKey)
                return false;

            return true;
        }


        private void DisplayBasketSummaryTable(Basket basket)
        {
            if (basket.Items.Count < 1)
                return;

            Console.WriteLine();

            var table = new ConsoleTable("SKU", "Description", "Quantity", "Unit Price", "Total");
            foreach (var item in basket.Items)
                table.AddRow(item.Product.Sku, $"{item.Product.Name} - {item.Product.Description}", item.Quantity, item.Product.Price, item.Total);

            table.AddRow(string.Empty, string.Empty, string.Empty, string.Empty, basket.Total);
            table.Write();
        }


    }
}
