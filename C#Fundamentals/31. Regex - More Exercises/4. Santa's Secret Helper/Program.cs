using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _4._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input !="end")
            {
                StringBuilder line = new StringBuilder();
                for (int i = 0; i < input.Length; i++)
                {
                    line.Append((char)(input[i] - key));
                }
                string regexValid = @"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<type>[NG])!";
                MatchCollection kids = Regex.Matches(line.ToString(), regexValid);
                foreach (Match kid in kids)
                {
                    if (kid.Groups["type"].Value.ToString() == "G")
                    {
                        Console.WriteLine(kid.Groups["name"].Value);
                    }
                }


                input = Console.ReadLine();
            }
        }
    }
}
