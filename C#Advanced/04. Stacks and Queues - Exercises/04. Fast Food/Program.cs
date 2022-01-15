using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int dailyFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);
            int maxOrder = queue.Max();
            Console.WriteLine(maxOrder);
            int queueLength = queue.Count;
            for (int i = 0; i < queueLength; i++)
            {
                if (queue.Peek() <= dailyFood)
                {
                    dailyFood -= queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");

            }
        }
    }
}
