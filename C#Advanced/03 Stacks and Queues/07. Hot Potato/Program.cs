using System;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split();
            Queue<string> players = new Queue<string>(participants);
            int n = int.Parse(Console.ReadLine());
            int currentNumber = 1;
            string potatoPlayer = players.Peek();
            while (players.Count>1)
            {
                
                if (n==currentNumber)
                {
                    Console.WriteLine($"Removed {players.Dequeue()}");
                    currentNumber = 1;
                }
                else
                {
                    potatoPlayer = players.Dequeue();
                    players.Enqueue(potatoPlayer);
                    currentNumber++;
                }
            }
            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
