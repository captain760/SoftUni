using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffects = Console.ReadLine()
                     .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();
            int[] bombCasings = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            var effects = new Queue<int>(bombEffects);
            var casings = new Stack<int>(bombCasings);
            var bombs = new Dictionary<string, int>()
            {
                {"Datura Bombs", 0 },
                {"Cherry Bombs", 0 },
                {"Smoke Decoy Bombs", 0 }
            };
            while (casings.Count > 0 && effects.Count > 0 && (bombs["Datura Bombs"] < 3 || bombs["Cherry Bombs"] < 3 || bombs["Smoke Decoy Bombs"] < 3))
            {
                int sum = effects.Peek() + casings.Peek();
                if (sum == 40)
                {
                    bombs["Datura Bombs"]++;
                    effects.Dequeue();
                    casings.Pop();
                    continue;
                }
                if (sum == 60)
                {
                    bombs["Cherry Bombs"]++;
                    effects.Dequeue();
                    casings.Pop();
                    continue;
                }
                if (sum == 120)
                {
                    bombs["Smoke Decoy Bombs"]++;
                    effects.Dequeue();
                    casings.Pop();
                    continue;
                }
                casings.Push(casings.Pop() - 5);
            }
            if (bombs["Datura Bombs"] >= 3 && bombs["Cherry Bombs"] >= 3 && bombs["Smoke Decoy Bombs"] >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (effects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (casings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            foreach (var item in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
