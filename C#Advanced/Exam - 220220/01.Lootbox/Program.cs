using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int[] second = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            Queue<int> firstBox = new Queue<int>(first);
            Stack<int> secondBox = new Stack<int>(second);
            List<int> myItems = new List<int>();

            while (firstBox.Count>0 && secondBox.Count>0)
            {
                int sum = firstBox.Peek() + secondBox.Peek();
                if (sum%2==0)
                {
                    myItems.Add(sum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }
            if (firstBox.Count==0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            int total = myItems.Sum();
            if (total>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {total}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {total}");
            }
        }
    }
}
