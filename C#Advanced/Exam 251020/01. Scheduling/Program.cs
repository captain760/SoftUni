using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] taskElements = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            Stack<int> tasks = new Stack<int>(taskElements);
            int[] threadsElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            Queue<int> threads = new Queue<int>(threadsElements);
            int taskToKill = int.Parse(Console.ReadLine());
            bool taskKilled = false;
            while (tasks.Count>0 && threads.Count>0)
            {
                if (tasks.Peek() == taskToKill)
                {
                    taskKilled = true;
                    break;
                }
                if (threads.Peek()>=tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }
            if (taskKilled)
            {
                Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
            }
            Console.WriteLine(string.Join(" ",threads));
        }
    }
}
