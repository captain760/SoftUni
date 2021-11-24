using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> cityPopulation = new Dictionary<string, int>();
            Dictionary<string, int> cityGold = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "Sail")
            {
                string[] token = input.Split("||");
                string city = token[0];
                int population = int.Parse(token[1]);
                int gold = int.Parse(token[2]);
                if (cityPopulation.ContainsKey(city))
                {
                    cityPopulation[city] += population;
                    cityGold[city] += gold;
                }
                else
                {
                    cityPopulation.Add(city, population);
                    cityGold.Add(city, gold);
                }
                

                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input!="End")
            {
                string[] token = input.Split("=>");
                if (token[0] == "Plunder")
                {
                    string town = token[1];
                    int people = int.Parse(token[2]);
                    int gold = int.Parse(token[3]);
                    cityPopulation[town] -= people;
                    cityGold[town] -= gold;
                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    if (cityPopulation[town]<=0 || cityGold[town]<=0)
                    {
                        cityPopulation.Remove(town);
                        cityGold.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (token[0] == "Prosper")
                {
                    string town = token[1];
                    int gold = int.Parse(token[2]);
                    if (gold<0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        input = Console.ReadLine();
                        continue;
                    }
                    cityGold[town] += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cityGold[town]} gold.");
                }


                input = Console.ReadLine();
            }
            cityGold = cityGold.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            if (cityGold.Count>0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cityGold.Count} wealthy settlements to go to:");
                foreach (var city in cityGold)
                {
                    Console.WriteLine($"{city.Key} -> Population: {cityPopulation[city.Key]} citizens, Gold: {city.Value} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
