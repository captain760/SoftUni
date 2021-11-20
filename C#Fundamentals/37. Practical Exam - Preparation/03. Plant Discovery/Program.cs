using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> plantRarity = new Dictionary<string, int>();
            Dictionary<string, List<int>> plantRating = new Dictionary<string, List<int>>();
            for (int i = 0; i < n; i++)
            {
                string[] initialPlants = Console.ReadLine().Split("<->");
               
                string name = initialPlants[0];
                int rarity = int.Parse(initialPlants[1]);
                
                if (!plantRarity.ContainsKey(name))
                {
                    
                    plantRarity.Add(name, rarity);
                }
                else
                {
                    plantRarity[name] = rarity;
                }
                if (!plantRating.ContainsKey(name))
                {
                    List<int> ratings = new List<int>();
                    
                    plantRating.Add(name, ratings);
                }
                

            }
            string input = Console.ReadLine();
            while (input != "Exhibition")
            {
                string[] token = input.Split(": ");
                string cmd = token[0];
                string pointers = token[1];
                
                if (cmd == "Rate")
                {
                    string[] plantings = pointers.Split(" - ");
                    string plant = plantings[0];
                    int rating = int.Parse(plantings[1]);
                    if (plantRating.ContainsKey(plant))
                    {
                        
                        plantRating[plant].Add(rating);
                        
                        
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmd == "Update")
                {
                    string[] plantings = pointers.Split(" - ");
                    string plant = plantings[0];
                    int newRarity = int.Parse(plantings[1]);
                    if (plantRarity.ContainsKey(plant))
                    {

                        plantRarity[plant]=newRarity;


                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmd == "Reset")
                {
                    string plant = token[1];
                    if (plantRating.ContainsKey(plant))
                    {
                        plantRating[plant].Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");
            plantRarity = plantRarity.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var plant in plantRarity)
            {


                foreach (var item in plantRating)
                {

                    if (plant.Key == item.Key)
                    {


                        double ave = 0;
                        if (item.Value.Any())
                        {
                            ave = item.Value.Average();
                        }
                        Console.WriteLine($"- {item.Key}; Rarity: {plantRarity[item.Key]}; Rating: {ave:f2}");
                    }
                }
            }
        }
    }
}
