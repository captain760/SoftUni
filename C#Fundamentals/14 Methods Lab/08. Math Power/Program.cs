using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a method that calculates and returns the value of a number raised to a given power.
           double num = double.Parse(Console.ReadLine());
            int pow = int.Parse(Console.ReadLine());
            if (pow>=0)
            {
                Console.WriteLine(Powered(num, pow));
            }
            
        }
        static double Powered(double num, int pow)
        {
            if (pow == 0)
            {
                return 1;
            }
            double power = 1;
            for (int i = 1; i <= pow; i++)
            {
                power *= num;
            } 

            return power;
        }
    }
}
