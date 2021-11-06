using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal[]> products = new Dictionary<string, decimal[]>();
            string input = Console.ReadLine();
            while (input!="buy")
            {
                string[] token = input.Split().ToArray();
                string name = token[0];
                decimal price = decimal.Parse(token[1]);
                decimal quantity = decimal.Parse(token[2]);
                decimal[] priceQuantity = new decimal[2];
                priceQuantity[0] = price;
                priceQuantity[1] = quantity;
                if (products.ContainsKey(name))
                {
                    products[name][0] = price;
                    products[name][1] += quantity;
                }
                else
                {
                    products.Add(name, priceQuantity);
                }
                


                input = Console.ReadLine();
            }
            foreach (var item in products)
            {
                
                Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):f2}");
            }
        }
    }
}
