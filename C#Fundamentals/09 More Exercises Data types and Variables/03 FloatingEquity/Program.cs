using System;

namespace _03_FloatingEquity
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberA = double.Parse(Console.ReadLine()); 
            double numberB = double.Parse(Console.ReadLine());
            double difference = Math.Abs(numberA - numberB);
            const double eps = 0.000001;
            if (difference<eps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
