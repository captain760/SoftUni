using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a regular expression to match a valid phone number from Sofia.After you find all valid phones, print them on the console, separated by a comma and a space “, ”.
            string input = Console.ReadLine();
            string key = @" *\+[3][5][9](?<separator>[- ])[2](\k<separator>)[0-9]{3}(\k<separator>)[0-9]{4} *\b";
            MatchCollection numbers = Regex.Matches(input, key);
            
            var correctPhones = numbers.Cast<Match>().Select(a => a.Value.Trim()).ToArray();
            
                Console.Write(string.Join(", ", correctPhones));
            
        }
    }
}
