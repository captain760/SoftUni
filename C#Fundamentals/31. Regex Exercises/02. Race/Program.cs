using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> runnerDist
                = new Dictionary<string, int>();
            string[] names = Console.ReadLine().Split(", ").ToArray();
           
            foreach (var item in names)
            {
                runnerDist.Add(item,0);
            }
            string input = Console.ReadLine();
            string regexKey = @"[A-Za-z]";
            while (input!="end of race")
            {
                MatchCollection name = Regex.Matches(input, regexKey);
                StringBuilder nameOfRunner = new StringBuilder();
                foreach (Match match in name)
                {
                    nameOfRunner.Append(match);
                }
                
                if (runnerDist.ContainsKey(nameOfRunner.ToString()))
                {
                    int sum = 0;
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (Char.IsDigit(input[j]))
                        {
                            sum += int.Parse(input[j].ToString());
                        }
                    }
                    runnerDist[nameOfRunner.ToString()] += sum;
                }
                

                
                input = Console.ReadLine();
            }
            runnerDist = runnerDist.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int i = 1;
            foreach (var item in runnerDist)
            {
                    switch (i)
                    {
                        case 1:
                            {
                                Console.WriteLine($"1st place: {item.Key}");
                                break;
                            };
                        case 2:
                            {
                                Console.WriteLine($"2nd place: {item.Key}");
                                break;
                            };
                        case 3:
                            {
                                Console.WriteLine($"3rd place: {item.Key}");
                                break;
                            };
                        default:
                            break;
                    }

                i++;
            }
        }
    }
}
