using System;

namespace _02_Devision
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int maxDevisor = 0;
            if (num%2 == 0)
            {
                maxDevisor = 2;
            }
             if (num%3 == 0)
            {
                maxDevisor = 3;
            }
            if (num % 6 == 0)
            {
                maxDevisor = 6;
            }
            if (num % 7 == 0)
            {
                maxDevisor = 7;
            }
            if (num % 10 == 0)
            {
                maxDevisor = 10;
            }
            if (maxDevisor == 0)
            {
                Console.WriteLine("Not divisible");
            }
            else
            {
                Console.WriteLine($"The number is divisible by {maxDevisor}");
            }
        }
    }
}
