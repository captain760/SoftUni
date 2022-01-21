using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>>continentCountry = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string continent = input[0];
                string country = input[1];
                string city = input[2];
                if (!continentCountry.ContainsKey(continent))
                {
                    continentCountry.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continentCountry[continent].ContainsKey(country))
                {
                    continentCountry[continent].Add(country, new List<string>());
                }
                
                    continentCountry[continent][country].Add(city);
                
               
            }
            foreach (var continent in continentCountry)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.Write($"  {country.Key} -> ");
                    Console.WriteLine(string.Join(", ",country.Value));
                }
            }
        }
    }
}
