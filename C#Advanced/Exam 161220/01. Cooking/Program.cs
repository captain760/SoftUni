using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsValues = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
            int[] ingrValuess = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            Queue<int> liquid = new Queue<int>(liquidsValues);
            Stack<int> ingr = new Stack<int>(ingrValuess);
            Dictionary<string, int> food = new Dictionary<string, int>()
            {
                { "Bread", 25 },
                { "Cake", 50 },
                { "Pastry", 75 },
                { "Fruit Pie", 100 }
            };
            Dictionary<string, int> prepared = new Dictionary<string, int>()
            {
                { "Bread", 0 },
                { "Cake", 0 },
                { "Pastry", 0 },
                { "Fruit Pie", 0 }
            };
            while (liquid.Count > 0 && ingr.Count > 0)
            {
                int sum = liquid.Peek() + ingr.Peek();
                
                if (food.Any(x => x.Value == sum))
                {
                    prepared[food.Where(x => x.Value == sum).First().Key]++;
                    liquid.Dequeue();
                    ingr.Pop();
                }
                else
                {
                    liquid.Dequeue();
                    int newIngr = ingr.Pop() + 3;
                    ingr.Push(newIngr);
                }
            }
            if (prepared.All(x => x.Value > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquid.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.Write("Liquids left: ");
                Console.WriteLine(string.Join(", ", liquid));
            }
            if (ingr.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.Write("Ingredients left: ");
                Console.WriteLine(string.Join(", ", ingr));
            }
            Console.WriteLine($"Bread: {prepared["Bread"]}");
            Console.WriteLine($"Cake: {prepared["Cake"]}");
            Console.WriteLine($"Fruit Pie: {prepared["Fruit Pie"]}");
            Console.WriteLine($"Pastry: {prepared["Pastry"]}");
        }
    }
}
