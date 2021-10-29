using System;

namespace _10_LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());
            string lowerSymbol = symbol.ToString();
            string symbolString = symbol.ToString();
            lowerSymbol = symbolString.ToLower();
            if (lowerSymbol == symbolString)
            {
                Console.WriteLine("lower-case");
            }
            else
            {
                Console.WriteLine("upper-case");
            }

        }
    }
}
