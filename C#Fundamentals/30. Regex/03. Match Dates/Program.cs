using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program, which matches a date in the format “dd{ separator}
            //MMM{ separator}
            //yyyy”. Use named capturing groups in your regular expression.
            string input = Console.ReadLine();
            string regexKey = @" *(?<day>[0123][0-9])(?<sep>[\.\-\/])(?<month>[A-Z][a-z][a-z])(\k<sep>)(?<year>[0-9]{4})\b";
            MatchCollection dates = Regex.Matches(input, regexKey);
            foreach (Match date in dates)
            {
                string day = date.Groups["day"].Value.ToString();
                string month = date.Groups["month"].Value.ToString();
                string year = date.Groups["year"].Value.ToString();
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
