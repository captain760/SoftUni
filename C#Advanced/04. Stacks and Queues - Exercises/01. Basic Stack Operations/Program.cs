using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] cmd = input.Split().Select(int.Parse).ToArray();
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < cmd[0]; i++)
            {
                stack.Push(array[i]);
            }
            for (int i = 0; i < cmd[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            int minNum = int.MaxValue;
            int stackHight = stack.Count;
            for (int i = 0; i < stackHight; i++)
            {
                if (stack.Peek() == cmd[2])
                {
                    Console.WriteLine("true");
                    return;
                }
                else
                {
                    if (minNum >= stack.Peek())
                    {
                        minNum = stack.Pop();
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }
            Console.WriteLine(minNum);
        }
    }
}
