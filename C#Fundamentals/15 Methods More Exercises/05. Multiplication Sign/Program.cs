using System;

namespace _05._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are given a number num1, num2 and num3. Write a program that finds if num1 * num2 * num3(the product)
            //is negative, positive or zero.Try to do this WITHOUT multiplying the 3 numbers.
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            bool sign1 = false;
            bool sign2 = false;
            bool sign3 = false;
            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                if (num1 > 0)
                {
                    sign1 = true;
                }
                if (num2 > 0)
                {
                    sign2 = true;
                }
                if (num3 > 0)
                {
                    sign3 = true;
                }

                if (Signum(sign1, Signum(sign2, sign3)))
                {
                    Console.WriteLine("positive");
                }
                else
                {
                    Console.WriteLine("negative");
                }
            }
        }
        static bool Signum(bool x, bool y)
        {
            if ((x && y)||(!x &&!y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
