using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<string,Dictionary<string, double>> shopProducts = new SortedDictionary<string, Dictionary<string, double>>();
            while (input!="Revision")
            {
                string[] token = input.Split(", ").ToArray();
                string shop = token[0];
                string product = token[1];
                double price = double.Parse(token[2]);
                if (!shopProducts.ContainsKey(shop))
                {
                    shopProducts.Add(shop, new Dictionary<string, double>());
                }
                shopProducts[shop].Add(product, price);
                input = Console.ReadLine();
            }

            foreach (var shop in shopProducts)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
