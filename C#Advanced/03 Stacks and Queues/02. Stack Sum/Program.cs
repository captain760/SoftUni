using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(array);
            string input = Console.ReadLine().ToLower();
            int sum = 0;
            while (input !="end")
            {
                string[] cmd = input.Split();
                if (cmd[0] == "add")
                {
                    stack.Push(int.Parse(cmd[1]));
                    stack.Push(int.Parse(cmd[2]));
                }
                else
                {
                    if (cmd[0] == "remove")
                    {
                        if (int.Parse(cmd[1])<=stack.Count)
                        {
                            for (int i = 0; i < int.Parse(cmd[1]); i++)
                            {
                                stack.Pop();
                            }
                        }
                    }
                }
                input = Console.ReadLine().ToLower();
            }
            int stackLength = stack.Count;
            for (int i = 0; i < stackLength; i++) 
            {
                sum += stack.Pop();
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
