﻿using System;

namespace _06_ReversedChars
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());
            Console.Write($"{third} {second} {first}");
        }
    }
}
