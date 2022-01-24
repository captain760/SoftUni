using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> data = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = Console.ReadLine();
            while (input!="Statistics")
            {
                string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmd[1] == "joined")
                {
                    if (!data.ContainsKey(cmd[0]))
                    {
                        data.Add(cmd[0], new Dictionary<string,SortedSet<string>>());
                    }
                    
                }
                else if (cmd[1] == "followed")
                {
                    string follower = cmd[0];
                    string vlogger = cmd[2];
                    if (follower!=vlogger)
                    {
                        if (data.ContainsKey(following))
                        {
                            if (data[following].Contains(follower)|| !data.ContainsKey(follower))
                            {
                                input = Console.ReadLine();
                                continue;
                            }
                            data[following].Add(follower);
                            
                        }
                       
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var followers in vloggerFolowers)
            {
                foreach (var follower in followers.Value)
                {
                    
                        if (!vloggerFolowings.ContainsKey(follower))
                        {
                            vloggerFolowings.Add(follower, new List<string>());
                        }
                    vloggerFolowings[follower].Add(followers.Key);
                    
                }
            }
            Console.WriteLine($"The V - Logger has a total of {vloggerFolowers.Count} vloggers in its logs.");
            Dictionary<string, List<string>> sorted = vloggerFolowers.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Value.Contains(x.Key)).ToDictionary(x => x.Key, x => x.Value);
            Dictionary<string, List<string>> firstSorted = vloggerFolowers.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Value.Contains(x.Key)).ToDictionary(x => x.Key, x => x.Value);
            Dictionary<string, List<string>> secondSorted = vloggerFolowings.OrderBy(x => x.Value.Count).ToDictionary(x => x.Key, y => y.Value);
            foreach (var item in sorted)
            {
                if (item.Value.Count>0)
                {
                    Console.WriteLine($"{item.Key} : {item.Value.Count} followers, ");
                }
                break;
            }
            {

            }
        }
    }
}
