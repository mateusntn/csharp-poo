using System;
using System.Collections.Generic;
using InheritancePolymorphism.Entities;

namespace InheritancePolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            Console.Write("Enter the number of products: ");
            int quantity = int.Parse(Console.ReadLine());
            for(int i = 1; i <= quantity; i++)
            {
                Console.WriteLine($"Product #{i} data: ");
                Console.Write($"Common, used or imported (c/u/i)? ");
                string type = Console.ReadLine();
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());
                if(type == "u")
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    products.Add(new UsedProduct(name, price, date));
                }
                else if (type == "i")
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine());
                    products.Add(new ImportedProduct(name, price, customsFee));   
                }
                else if (type == "c")
                {
                    products.Add(new Product(name, price));
                }
                else{
                    Console.WriteLine("Invalid data.");
                }
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS: ");
            foreach(Product product in products)
            {
                Console.WriteLine(product.PriceTag());
            }
        }
    }
}
