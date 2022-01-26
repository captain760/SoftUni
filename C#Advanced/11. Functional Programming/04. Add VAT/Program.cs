using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVAT = n => n + n * 0.2;
            double[] prices = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(n=>double.Parse(n)).ToArray();
            foreach (var price in prices)
            {
                Console.WriteLine($"{addVAT(price):f2}");
            }
        }
    }
}
