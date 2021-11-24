using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexKey = @"(?<sep>[:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})(\k<sep>)";
            string input = Console.ReadLine();
            BigInteger threshold = 1;
            MatchCollection emojis = Regex.Matches(input, regexKey);
            Dictionary<string, int> emojiCoolness = new Dictionary<string, int>();
            foreach (Match emoji in emojis)
            {
                int coolness = 0;
                for (int i = 2; i < emoji.Length-2; i++)
                {
                    coolness += emoji.ToString()[i];
                }

                if (!emojiCoolness.ContainsKey(emoji.ToString()))
                {
                    emojiCoolness.Add(emoji.ToString(), coolness);
                }
                    
            }
           
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i].ToString().All(char.IsDigit))
                    {
                        threshold *= int.Parse(input[i].ToString());
                    }
                    
                }
            
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{emojiCoolness.Count} emojis found in the text. The cool ones are:");
            foreach (var item in emojiCoolness)
            {
                if (item.Value>threshold)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
