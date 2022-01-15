using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(clothes);
            int capacity = int.Parse(Console.ReadLine());
            int racks = 0;
            if (stack.Count > 0)
            {
                racks = 1;
            }
            int currentCapacity = capacity;
            while (stack.Count > 0)
            {
                if (stack.Peek() <= currentCapacity)
                {
                    currentCapacity -= stack.Pop();
                }
                else
                {
                    racks++;
                    currentCapacity = capacity;
                }
            }
            Console.WriteLine(racks);
        }
    }
}
