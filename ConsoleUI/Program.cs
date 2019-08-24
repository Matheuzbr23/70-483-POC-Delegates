using DemoLibrary;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static readonly ShoppingCartModel cart = new ShoppingCartModel();

        static void Main()
        {
            PopulateCartWithDemoData();

            Console.WriteLine($"The total for the cart is {cart.GenerateTotal(SubTotalAlert, CalculateLeveledDiscount, AlertUser):C2}");
            Console.WriteLine();
            Console.WriteLine($"The total for the cart 2 is {cart.GenerateTotal((subTotal) => Console.WriteLine($"The Subtotal for cart 2 is {subTotal:C2}"),(items, subTotal) => subTotal * 0.50M,(message) => Console.WriteLine(message))}");

            Console.WriteLine();
            Console.Write("Please press any key to exit the application...");
            Console.ReadKey();
        }

        private static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"The subtotal is {subTotal:C2}");
        }

        private static decimal CalculateLeveledDiscount(List<ProductModel> items, decimal subTotal)
        {
            if (subTotal > 100)
                return subTotal * 0.80M;

            else if (subTotal > 50)
                return subTotal * 0.85M;

            else if (subTotal > 10)
                return subTotal * 0.95M;

            else
                return subTotal;
        }

        private static void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }
    }
}
