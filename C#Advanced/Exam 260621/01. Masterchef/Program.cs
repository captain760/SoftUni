using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ingredientsValues = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int[] freshnessValuess = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            Queue<int> ingr = new Queue<int>(ingredientsValues);
            Stack<int> fresh = new Stack<int>(freshnessValuess);
            Dictionary<string, int> dishes = new Dictionary<string, int>()
            {
                { "Dipping sauce", 150 },
                { "Green salad", 250 },
                { "Chocolate cake", 300 },
                { "Lobster", 400 }
            };
            Dictionary<string, int> prepared = new Dictionary<string, int>()
            {
                { "Dipping sauce", 0 },
                { "Green salad", 0 },
                { "Chocolate cake", 0 },
                { "Lobster", 0 }
            };
            while (ingr.Count>0 && fresh.Count>0)
            {
                int totalFresh = ingr.Peek() * fresh.Peek();
                if (ingr.Peek()==0)
                {
                    ingr.Dequeue();
                    continue;
                }
                if (dishes.Any(x=>x.Value==totalFresh))
                {
                    prepared[dishes.Where(x => x.Value == totalFresh).First().Key]++;
                    ingr.Dequeue();
                    fresh.Pop();
                }
                else
                {
                    fresh.Pop();
                    int newIngr = ingr.Dequeue() + 5;
                    ingr.Enqueue(newIngr);
                }
            }
            if (prepared.All(x=>x.Value>0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingr.Count>0)
            {
                int ingrSum = 0;
                while (ingr.Count!=0)
                {
                    ingrSum += ingr.Dequeue();
                }
                
                Console.WriteLine($"Ingredients left: {ingrSum}");
            }
            foreach (var item in prepared.Where(x=>x.Value>0).OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }
        }
    }
}
