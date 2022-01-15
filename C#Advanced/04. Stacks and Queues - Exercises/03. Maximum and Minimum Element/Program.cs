using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] cmd = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (cmd[0] == 1)
                {
                    stack.Push(cmd[1]);
                }
                else if (cmd[0] == 2)
                {
                    stack.Pop();
                }
                else if (cmd[0] == 3 && stack.Count != 0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (cmd[0] == 4 && stack.Count != 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(string.Join(", ", stack));

        }
    }
}
