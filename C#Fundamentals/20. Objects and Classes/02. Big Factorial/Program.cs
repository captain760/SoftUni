﻿using System;
using System.Numerics;

namespace _02._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //You will receive a number N in the range[0 - 1000].
            //Calculate the Factorial of N and print out the result.
            int n = int.Parse(Console.ReadLine());
            BigInteger f = 1;
            for (int i = 1; i <= n; i++)
            {
                f *= i;
            }
            Console.WriteLine(f);
        }
    }
}
