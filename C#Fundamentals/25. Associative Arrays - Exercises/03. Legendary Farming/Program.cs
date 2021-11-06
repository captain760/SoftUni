using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryQuantity = new Dictionary<string, int>();
            bool legendaryFound = false;
            while (true)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                for (int i = 0; i < input.Length; i+=2)
                {
                    int quantity = int.Parse(input[i]);
                    string resource = input[i + 1].ToLower();
                    if (legendaryQuantity.ContainsKey(resource))
                    {
                        legendaryQuantity[resource] += quantity;
                        if ((legendaryQuantity.ContainsKey("shards") && legendaryQuantity["shards"] >= 250) || (legendaryQuantity.ContainsKey("fragments") && legendaryQuantity["fragments"] >= 250) || (legendaryQuantity.ContainsKey("motes") && legendaryQuantity["motes"] >= 250))
                        {
                            legendaryFound = true;
                            break;
                        }
                    }
                    else
                    {
                        
                        legendaryQuantity.Add(resource, quantity);
                        if ((legendaryQuantity.ContainsKey("shards") && legendaryQuantity["shards"] >= 250) || (legendaryQuantity.ContainsKey("fragments") && legendaryQuantity["fragments"] >= 250) || (legendaryQuantity.ContainsKey("motes") && legendaryQuantity["motes"] >= 250))
                        {
                            legendaryFound = true;
                            break;
                        }
                    }
                }
                if (legendaryFound)
                {
                    break;
                }
                
            }
            string legendary = "";
            if (legendaryQuantity.ContainsKey("shards") && legendaryQuantity["shards"] >= 250)
            {
                legendary = "Shadowmourne";
            }
            else if (legendaryQuantity.ContainsKey("fragments") && legendaryQuantity["fragments"] >= 250)
            {
                legendary = "Valanyr";
            }
            else 
            {
                legendary = "Dragonwrath";
            }
            Console.WriteLine($"{legendary} obtained!");
            Dictionary<string, int> legendOnlyQuantity = new Dictionary<string, int>();
            if (legendaryQuantity.ContainsKey("fragments"))
            {

                if (legendaryQuantity["fragments"]>=250)
                {
                    legendOnlyQuantity.Add("fragments", legendaryQuantity["fragments"]-250);
                }
                else
                {
                    legendOnlyQuantity.Add("fragments", legendaryQuantity["fragments"]);
                }
                    
            }
            else
            {
                legendOnlyQuantity.Add("fragments", 0);
            }
            if (legendaryQuantity.ContainsKey("shards"))
            {
                if (legendaryQuantity["shards"]>=250)
                {
                    legendOnlyQuantity.Add("shards", legendaryQuantity["shards"]-250);
                }
                else
                {
                    legendOnlyQuantity.Add("shards", legendaryQuantity["shards"]);
                }
               
            }
            else
            {
                legendOnlyQuantity.Add("shards", 0);
            }
            if (legendaryQuantity.ContainsKey("motes"))
            {
                if (legendaryQuantity["motes"]>=250)
                {
                    legendOnlyQuantity.Add("motes", legendaryQuantity["motes"]-250);
                }
                else
                {
                    legendOnlyQuantity.Add("motes", legendaryQuantity["motes"]);
                }
                
            }
            else
            {
                legendOnlyQuantity.Add("motes", 0);
            }
            
            legendOnlyQuantity = legendOnlyQuantity.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x=>x.Value);
            foreach (var item in legendOnlyQuantity)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            legendaryQuantity = legendaryQuantity.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in legendaryQuantity)
            {
                if (item.Key!="fragments" && item.Key != "shards" && item.Key !="motes")
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
                
            }
        }
    }
}
