using System;

namespace _03_ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            decimal sum = 0M;
            for (int i = 1; i <= numbers; i++)
            {
                decimal current = decimal.Parse(Console.ReadLine());
                sum += current;
            }
            Console.WriteLine(sum);
        }
    }
}
