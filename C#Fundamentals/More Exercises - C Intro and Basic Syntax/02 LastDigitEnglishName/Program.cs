using System;

namespace _02_LastDigitEnglishName
{
    class Program
    {
        static string FigConv(int y)
        {
            switch (y)
            {
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                case 0: return "zero";

                default: return "invalid";
                   
            }
        }
        static void Main(string[] args)
        {
            
            string n = Console.ReadLine();
            int l = n.Length;
            int x = n[l - 1]-48;
            Console.WriteLine(FigConv(x));
        }   
    }
}