using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexKey = @"(?<str>\D+)(?<num>\d+)";
            string input = Console.ReadLine();
            List<char> usedSymmols = new List<char>();
            MatchCollection sequences = Regex.Matches(input, regexKey);
            foreach (Match item in sequences)
            {
                int numSymbols = item.Groups["str"].Value.Length;
                if (int.Parse(item.Groups["num"].Value) != 0)
                {


                    for (int i = 0; i < numSymbols; i++)
                    {
                        if (!usedSymmols.Contains(item.Groups["str"].Value.ToUpper()[i]))
                        
                        {
                            usedSymmols.Add(item.Groups["str"].Value.ToUpper()[i]);
                        }
                    }
                }
            }
            int total = usedSymmols.Count;
            usedSymmols.Sort();
            Console.WriteLine($"Unique symbols used: {total}");
            foreach (Match seq in sequences)
            {
                string symbols = seq.Groups["str"].Value.ToUpper();
                int counts = int.Parse(seq.Groups["num"].Value);
                
                for (int i = 0; i < counts; i++)
                {
                    Console.Write(symbols);
                }
            }
        }
    }
}
