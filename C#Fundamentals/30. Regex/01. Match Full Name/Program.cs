using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string key = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            MatchCollection names = Regex.Matches(input, key);
            foreach (Match name in names)
            {
                Console.Write($"{name} ");
            }
        }
    }
}
