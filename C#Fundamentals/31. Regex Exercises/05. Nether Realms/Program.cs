using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexHealth = @"[^0-9+\-\*\/\.]";
            string regexBaseDamage = @"[+-]{0,1}[0-9]+\.{0,1}[0-9]*";
            string[] input = Console.ReadLine().Split(",");
            List<string> names = new List<string>();
            foreach (var item in input)
            {
                names.Add(item.Trim());
            }
            names.Sort();
            foreach (var name in names)
            {
                MatchCollection healts = Regex.Matches(name, regexHealth);
                StringBuilder health = new StringBuilder();
                foreach (Match symbol in healts)
                {
                    health.Append(symbol.Value);
                }
                int totalHealth = 0;
                for (int i = 0; i < health.Length; i++)
                {
                    totalHealth += health[i];
                }
                MatchCollection damages = Regex.Matches(name, regexBaseDamage);
                double baseDamage = 0;
                foreach (Match number in damages)
                {
                    baseDamage+=double.Parse(number.Value.ToString());
                }
                double totalDamage = baseDamage;
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i].ToString() == "*")
                    {
                        totalDamage *= 2;
                    }
                    if (name[i].ToString() == "/")
                    {
                        totalDamage /= 2;
                    }
                }
                Console.WriteLine($"{name} - {totalHealth} health, {totalDamage:f2} damage");
            }
            
        }
    }
}
