using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> colorClothCounts = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = input[0];
                if (!colorClothCounts.ContainsKey(color))
                {
                    colorClothCounts.Add(color, new Dictionary<string, int>());
                }
                string[] dresses = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (var dress in dresses)
                {
                    if (!colorClothCounts[color].ContainsKey(dress))
                    {
                        colorClothCounts[color].Add(dress, 0);
                    }
                    colorClothCounts[color][dress]++;
                }
            }
            string[] searching = Console.ReadLine().Split().ToArray();
            string searchColor = searching[0];
            string searchCloth = searching[1];
            
            foreach (var color in colorClothCounts)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    Console.Write($"* {cloth.Key} - {cloth.Value}");
                    if (color.Key == searchColor && cloth.Key == searchCloth)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
