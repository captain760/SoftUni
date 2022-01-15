using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(cups);
            int[] bottles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(bottles);
            int wasted = 0;
            while (queue.Count>0 && stack.Count>0)
            {
                int currCup = queue.Peek();
                int currBtl = stack.Peek();
                if (currBtl>=currCup)
                {
                    wasted += stack.Pop() - queue.Dequeue();
                }
                else
                {
                    while (currCup>0 && stack.Count>0)
                    {
                        currCup -= stack.Pop();
                        if (currCup<=0)
                        {
                            wasted += 0 - currCup;
                            queue.Dequeue();
                        }
                    }
                }
            }
            if (queue.Count==0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",stack)}");
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }
            if (stack.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", queue)}");
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }

        }
    }
}
