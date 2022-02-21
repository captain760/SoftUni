using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] waterElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            Queue<double> waters = new Queue<double>(waterElements);
            double[] flourElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            Stack<double> flours = new Stack<double>(flourElements);
            Dictionary<string, double> products = new Dictionary<string, double>
            {
                {"Croissant", 50},
                {"Muffin", 40},
                {"Baguette", 30},
                {"Bagel", 20},
            };
            Dictionary<string, int> done = new Dictionary<string, int>
            {
                {"Croissant", 0},
                {"Muffin", 0},
                {"Baguette", 0},
                {"Bagel", 0},
            };
            while (flours.Count>0 && waters.Count>0)
            {
                double sum = waters.Peek() + flours.Peek();
                double waterPerc = (waters.Peek() * 100) / sum;
                if (products.Any(x=>x.Value==waterPerc))
                {
                    done[products.Where(x => x.Value == waterPerc).First().Key]++;
                    waters.Dequeue();
                    flours.Pop();
                }
                else
                {
                    double minProd = Math.Min(waters.Peek(), flours.Peek());
                    if (waters.Peek() == minProd)
                    {
                        done["Croissant"]++;
                        flours.Push(flours.Pop() - waters.Dequeue());
                    }
                    else
                    {
                        done["Croissant"]++;
                        waters.Dequeue();
                        flours.Pop();
                    }
                }
            }
            foreach (var item in done.Where(x=>x.Value>0).OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            if (waters.Count>0)
            {
                Console.WriteLine($"Water left: {string.Join(", ", waters)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flours.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flours)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
