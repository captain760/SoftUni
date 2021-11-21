using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regexKey = @"(?<sep>[@#])(?<word>[A-Za-z]{3,})(\k<sep>)(\k<sep>)(?<mirror>[A-Za-z]{3,})(\k<sep>)";
            MatchCollection pairs = Regex.Matches(input, regexKey);
            if (pairs.Count>0)
            {
                Console.WriteLine($"{pairs.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }
            
            Dictionary<string, string> wordMirror = new Dictionary<string, string>();
            foreach (Match pair in pairs)
            {
                wordMirror.Add(pair.Groups["word"].Value, Reverse(pair.Groups["mirror"].Value));
            }
            foreach (var pair in wordMirror)
            {
                if (pair.Key!=pair.Value)
                {
                    wordMirror.Remove(pair.Key);
                }
            }
            if (wordMirror.Count==0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", wordMirror.Select(x => x.Key + " <=> " + Reverse(x.Value))));
                
            }

        }
        public static string Reverse(string s)  //reverse a string
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
