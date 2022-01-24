using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> symbolOccurrances = new SortedDictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (!symbolOccurrances.ContainsKey(symbol))
                {
                    symbolOccurrances.Add(symbol, 0);
                }
                symbolOccurrances[symbol]++;
            }
            foreach (var symbol in symbolOccurrances)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
