﻿using System;

namespace GenericBoxOfString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string stringValue = Console.ReadLine();
                 var box = new Box<string>(stringValue);
                box.ToString();
            }
        }
    }
}
