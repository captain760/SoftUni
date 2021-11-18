using System;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string mailRegex = @"(?<=\s)[A-Za-z0-9]+([-._]+[A-Za-z0-9]+)*@[a-z\-]+(\.[a-z\-]+)+";
            string input = Console.ReadLine();
            MatchCollection mails = Regex.Matches(input, mailRegex);
            foreach (Match mail in mails)
            {
                Console.WriteLine();
            }
        }
    }
}
