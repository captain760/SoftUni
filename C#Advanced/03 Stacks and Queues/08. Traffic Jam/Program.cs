using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Queue<string> traffic = new Queue<string>();
            int passedCars = 0;
            while (input!="end")
            {
                if (input!="green")
                {
                    traffic.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (traffic.Count>0)
                        {
                            Console.WriteLine($"{traffic.Dequeue()} passed!");
                            passedCars++;
                        }
                        
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
