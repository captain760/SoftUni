using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> furniturePrice = new Dictionary<string, decimal>();
            string input = Console.ReadLine();
            string regKey = @"^>>(?<name>[A-z]+)<<(?<price>[0-9]+\.{0,1}[0-9]*)!(?<quantity>[0-9]+)";
            Console.WriteLine("Bought furniture:");
            while (input !="Purchase")
            {
                Match furniture = Regex.Match(input, regKey);
                if (!furniture.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }
                
                    string name = furniture.Groups["name"].Value;
                    decimal price = decimal.Parse(furniture.Groups["price"].Value);
                    int quantity = int.Parse(furniture.Groups["quantity"].Value);
                    if (!furniturePrice.ContainsKey(name))
                    {
                        furniturePrice.Add(name, price * quantity);
                    }
                    else
                    {
                        furniturePrice[name] += price * quantity;
                    }
                Console.WriteLine(name);
                
                input = Console.ReadLine();
            }
            
            decimal money = 0;
            foreach (var furn in furniturePrice)
            {
                
                money += furn.Value;
            }

            Console.WriteLine($"Total money spend: {money:f2}");
        }
    }
}
