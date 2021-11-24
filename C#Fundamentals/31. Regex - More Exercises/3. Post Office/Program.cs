using System;
using System.Text.RegularExpressions;

namespace _3._Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|");
            string first = input[0];
            string second = input[1];
            string third = input[2];
            string regexFirst = @"((?<sep>[#|$|%|*|&])(?<capts>[A-Z]+)(\k<sep>)).*";
            string regexSecond = @"(?<ascii>[0-9]{2}):(?<length>[0-9]{2})";
            string regexThird = @"(?<words>\b[A-Z][^ ]*)";
            Match caps = Regex.Match(first, regexFirst);
            string capitals = caps.Groups["capts"].Value.ToString();
            MatchCollection asciiLength = Regex.Matches(second, regexSecond);
            MatchCollection words = Regex.Matches(third, regexThird);
            int wordsCounter = 0;

            foreach (Match item in asciiLength)
            {
                int asciiCode = int.Parse(item.Groups["ascii"].Value);
                int wordLength = int.Parse(item.Groups["length"].Value);
                if (capitals.Length > wordsCounter)
                {
                    string currentWord = "";
                    foreach (Match word in words)
                    {
                        if ((wordLength == word.Groups["words"].Value.Length - 1) && asciiCode == word.Groups["words"].Value[0] && word.Groups["words"].Value[0] == capitals[wordsCounter])
                        {
                            currentWord = word.Groups["words"].Value;
                            wordsCounter++;
                            Console.WriteLine(currentWord);
                        }
                    }
                    

                }
            }

        }
    }
}
