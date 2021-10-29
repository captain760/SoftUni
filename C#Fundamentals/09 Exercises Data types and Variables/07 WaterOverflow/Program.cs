using System;

namespace _07_WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFills = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= numberOfFills; i++)
            {
                int currentFill = int.Parse(Console.ReadLine());
                if ((sum+currentFill)<=255)
                {
                    sum += currentFill;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                
            }
            Console.WriteLine(sum);
        }
    }
}
