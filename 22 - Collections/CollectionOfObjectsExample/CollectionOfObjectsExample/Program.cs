using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using ECommerce;

namespace CollectionOfObjectsExample
{
    internal class Program
    {
        static void Main()
        {
            // create an empty collection
            List<Product> products = new List<Product>();

            // loop to read data from user
            string choice;
            do
            {
                Console.WriteLine("Enter Product ID: ");
                int productId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Product Name: ");
                string productName = Console.ReadLine();
                Console.WriteLine("Enter Product Price: ");
                double productPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Product Date of Manufacturer (yyyy-MM-dd): ");
                DateTime productDateOfManufacturer = DateTime.Parse(Console.ReadLine());

                // create new Product
                Product product = new Product()
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = productPrice,
                    DateOfManufacture = productDateOfManufacturer
                };

                // Add product to collection
                products.Add(product);
                Console.WriteLine("Product added successfully");

                Console.WriteLine("Whould you like to register a new products? (Yes/No)");
                choice = Console.ReadLine();
            } while (choice != "No" && choice != "no" && choice != "n");

            // foreach to display each products
            foreach(Product product in products)
            {
                Console.WriteLine("ID: " + product.ProductId);
                Console.WriteLine("Name: " + product.ProductName);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("Date of Manufacturer: " + product.DateOfManufacture.ToShortDateString());
            }

            Console.ReadKey();
        }
    }
}
