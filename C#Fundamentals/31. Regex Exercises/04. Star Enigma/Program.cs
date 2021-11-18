using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            for (int i = 0; i < linesCount; i++)
            {
                string input = Console.ReadLine();
                string regexKey = @"[starSTAR]";
                MatchCollection star = Regex.Matches(input, regexKey);
                int kod = star.Count;
                StringBuilder msg = new StringBuilder();
                for (int j = 0; j < input.Length; j++)
                {
                    msg.Append((char)(input[j] - kod));
                }
                string message = msg.ToString();
                string regexMsg = @"@(?<planet>[A-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attack>[AD])![^@\-!:>]*->(?<soldiers>\d+)";
                Match instructions = Regex.Match(message, regexMsg);
                if (!instructions.Success)
                {
                    continue;
                }
                string planet = instructions.Groups["planet"].Value;
                string attack = instructions.Groups["attack"].Value;
                
                if (attack == "A")
                {
                    if (!attackedPlanets.Contains(planet))
                    {
                        attackedPlanets.Add(planet);
                    }
                    
                }
                else
                {

                    if (!destroyedPlanets.Contains(planet))
                    {
                        destroyedPlanets.Add(planet);
                    }
                        
                }

            }
            attackedPlanets.Sort();
            destroyedPlanets.Sort();
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            for (int i = 0; i < attackedPlanets.Count; i++)
            {
                Console.WriteLine($"-> {attackedPlanets[i]}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            for (int i = 0; i < destroyedPlanets.Count; i++)
            {
                Console.WriteLine($"-> {destroyedPlanets[i]}");
            }
        }
    }
}
