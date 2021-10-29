using System;

namespace _09_SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int nextNumbers = int.Parse(Console.ReadLine());
            int k = 0;
            int n = 1;
            int sum = 0;
            while (k<nextNumbers)
            {
                if (n%2==1)
                {
                    Console.WriteLine(n);
                    sum += n;
                    k++;
                }
                n++;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
