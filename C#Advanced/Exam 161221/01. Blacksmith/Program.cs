using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> carbon = new Stack<int>();
            Queue<int> steel = new Queue<int>();
            Dictionary<string, int> swordsResource = new Dictionary<string, int>();
            Dictionary<string, int> swordsDone = new Dictionary<string, int>();
            swordsResource.Add("Gladius", 70);
            swordsResource.Add("Shamshir", 80);
            swordsResource.Add("Katana", 90);
            swordsResource.Add("Sabre", 110);
            swordsResource.Add("Broadsword", 150);
            int[] steelArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            for (int i = 0; i < steelArray.Length; i++)
            {
                steel.Enqueue(steelArray[i]);
            }
            int[] carbonArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            for (int i = 0; i < carbonArray.Length; i++)
            {
                carbon.Push(carbonArray[i]);
            }
            while (carbon.Count !=0 && steel.Count!=0)
            {
                bool isForged = false;
                int resource = steel.Dequeue() + carbon.Peek();
                foreach (var sword in swordsResource)
                {
                    if (sword.Value == resource)
                    {
                        if (!swordsDone.ContainsKey(sword.Key))
                        {
                            swordsDone.Add(sword.Key, 0);
                        }
                        swordsDone[sword.Key]++;
                        carbon.Pop();
                        isForged = true;
                    }
                }
                if (isForged)
                {
                    continue;
                }
                carbon.Push(carbon.Pop() + 5);
            }
            if (swordsDone.Count!=0)
            {
                Console.WriteLine($"You have forged {swordsDone.Sum(x=>x.Value)} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steel.Count==0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.Write("Steel left: ");
                Console.WriteLine(String.Join(", ",steel));                
            }
            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.Write("Carbon left: ");
                Console.WriteLine(String.Join(", ", carbon));
            }
            foreach (var item in swordsDone.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
