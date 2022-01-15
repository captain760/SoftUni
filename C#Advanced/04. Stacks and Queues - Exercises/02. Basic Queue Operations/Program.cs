using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] cmd = input.Split().Select(int.Parse).ToArray();
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < cmd[0]; i++)
            {
                queue.Enqueue(array[i]);
            }
            for (int i = 0; i < cmd[1]; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            int minNum = int.MaxValue;
            int queueLength = queue.Count;
            for (int i = 0; i < queueLength; i++)
            {
                if (queue.Peek() == cmd[2])
                {
                    Console.WriteLine("true");
                    return;
                }
                else
                {
                    if (minNum >= queue.Peek())
                    {
                        minNum = queue.Dequeue();
                    }
                    else
                    {
                        queue.Dequeue();
                    }
                }
            }
            Console.WriteLine(minNum);
        }
    }
}
