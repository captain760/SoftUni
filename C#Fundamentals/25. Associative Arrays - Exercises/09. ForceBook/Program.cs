using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sideUser = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                string[] token = input.Split(" | ").ToArray();
                bool siUs = true;
                if (token.Length == 1)
                {
                    token = input.Split(" -> ").ToArray();
                    siUs = false;
                }
                string side = "";
                string user = "";
                if (siUs)
                {
                    side = token[0];
                    user = token[1];
                    if (sideUser.ContainsKey(side))
                    {
                        if (!sideUser[side].Contains(user))
                        {
                            sideUser[side].Add(user);
                        }
                    }
                    else
                    {
                        List<string> users = new List<string>();
                        users.Add(user);
                        sideUser.Add(side, users);
                    }
                }
                else
                {
                    side = token[1];
                    user = token[0];
                    foreach (var item in sideUser)
                    {
                        if (item.Value.Contains(user))
                        {
                            item.Value.Remove(user);
                        }
                    }
                    if (!sideUser.ContainsKey(side))
                    {
                        List<string> users = new List<string>();
                        sideUser.Add(side, users);
                    }
                    sideUser[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }
                input = Console.ReadLine();
            }
            Dictionary<string, List<string>> sorted = sideUser.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in sorted)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                    foreach (var user in item.Value.OrderBy(x =>x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
