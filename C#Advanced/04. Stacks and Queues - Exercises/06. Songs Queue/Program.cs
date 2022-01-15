using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(", ").ToArray();
            Queue<string> playList = new Queue<string>(array);
            string input = Console.ReadLine();
            while (true)
            {
                string[] cmd = input.Split("Add ").ToArray();
                if (cmd[0] == "Play")
                {
                    if (playList.Count > 0)
                    {
                        playList.Dequeue();
                    }
                }
                else if (cmd[0] == "Show")
                {
                    if (playList.Count > 0)
                    {
                        Console.WriteLine(string.Join(", ", playList));
                    }
                }
                else
                {
                    if (!playList.Contains(cmd[1]))
                    {
                        playList.Enqueue(cmd[1]);
                    }
                    else
                    {
                        Console.WriteLine($"{cmd[1]} is already contained!");
                    }
                }
                if (playList.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
