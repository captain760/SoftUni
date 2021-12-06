using System;
using System.Text.RegularExpressions;

namespace _02_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string regexKey = @"^(?<tag>[$%])(?<name>[A-Z][a-z]{2,})(\k<tag>): (\[(?<first>[0-9]+)\]\|)(\[(?<second>[0-9]+)\]\|)(\[(?<third>[0-9]+)\]\|)$";
                Match msg = Regex.Match(input, regexKey);
                if (!msg.Success)
                {
                    Console.WriteLine("Valid message not found!");
                    continue;
                }
                else
                {
                    Console.WriteLine($"{msg.Groups["name"]}: {(char)int.Parse(msg.Groups["first"].ToString())}{(char)int.Parse(msg.Groups["second"].ToString())}{(char)int.Parse(msg.Groups["third"].ToString())}");
                }
            }
        }
    }
}
