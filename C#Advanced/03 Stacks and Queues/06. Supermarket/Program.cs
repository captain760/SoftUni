using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> people = new Queue<string>();
            while (input!="End")
            {
                if (input == "Paid")
                {
                    while (people.Count>0)
                    {
                        Console.WriteLine(people.Dequeue());
                    }
                    
                }
                else
                {
                    people.Enqueue(input);
                    
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}
