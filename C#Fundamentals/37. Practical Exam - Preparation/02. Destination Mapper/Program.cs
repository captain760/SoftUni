using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regexKey = @"(?<sep>[=\/])(?<name>[A-Z][A-Za-z]{2,})(\k<sep>)";
            MatchCollection locations = Regex.Matches(input, regexKey);
            List<string> locs = new List<string>();
            int travelPoints = 0;
            foreach (Match location in locations)
            {
                travelPoints += location.Groups["name"].Value.Length;
                locs.Add(location.Groups["name"].Value);
            }
            Console.Write("Destinations: ");
            Console.WriteLine(String.Join(", ", locs));
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
