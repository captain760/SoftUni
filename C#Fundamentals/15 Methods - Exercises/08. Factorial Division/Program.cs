using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read two integers.Calculate factorial of each number.Divide the first result by the second and print the result of
            //the division formatted to the second decimal point.
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"{(Fact(num1)/Fact(num2)):f2}");
        }

        private static double Fact(int num1)
        {
            double factorial = 1;
            
            while (num1>1)
            {
                factorial *= num1;
                num1--;
            }
            return factorial;
        }
    }
}
