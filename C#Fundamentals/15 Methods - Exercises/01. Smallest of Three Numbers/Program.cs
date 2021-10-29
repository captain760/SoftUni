using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a method that prints out the smallest of three integer numbers.
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            SmallestOfThree(num1,num2,num3);
        }

        private static void SmallestOfThree(int num1, int num2, int num3)
        {
            if (num1>=num2)
            {
                if (num2>=num3)
                {
                    Console.WriteLine(num3);
                }
                else
                {
                    Console.WriteLine(num2);
                }
            }
            else
            {
                if (num1<num3)
                {
                    Console.WriteLine(num1);
                }
                else
                {
                    Console.WriteLine(num3);
                }
            }
        }
    }
}
