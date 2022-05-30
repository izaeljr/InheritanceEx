using System.Collections.Generic;
using System.Globalization;
using InheritanceEx.Entities;

namespace InheritanceEx
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> prod = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Product {(i+1)} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(ch == 'i' || ch == 'I')
                {
                    Console.Write("Custom fee: ");
                    double fee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    prod.Add(new ImportedProduct(name, price, fee));
                }
                else if(ch == 'u' || ch == 'U')
                {
                    Console.Write("Manufacture date (dd/mm/yyyy): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    prod.Add(new UsedProduct(name, price, date));
                }
                else if(ch == 'c' || ch == 'C')
                {
                    prod.Add(new Product(name, price));
                }
                else Console.WriteLine("Invalid code. No product has been added.");
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS");
            foreach(Product product in prod)
            {
                Console.WriteLine(product.PriceTag());
            }
        }
    }
}