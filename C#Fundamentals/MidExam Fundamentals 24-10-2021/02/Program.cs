using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friends = Console.ReadLine().Split(", ").ToList();
            string input = Console.ReadLine();
            while (input != "Report")
            {
                string[] cmd = input.Split().ToArray();
                if (cmd[0] == "Blacklist")
                {
                    if (friends.Contains(cmd[1]))
                    {
                        string name = cmd[1];
                        int index = friends.IndexOf(cmd[1]);
                        friends[index] = "Blacklisted";
                        Console.WriteLine($"{name} was blacklisted.");
                    }
                    else
                    {
                        Console.WriteLine($"{cmd[1]} was not found.");
                    }
                }
                else if (cmd[0] == "Error")
                {
                    int index = int.Parse(cmd[1]);
                    
                    if (index>=0 && index<friends.Count)
                    {
                        if (friends[index] !="Blacklisted" && friends[index]!="Lost")
                        {

                            string name = friends[index]; 
                            friends[index] = "Lost";
                            Console.WriteLine($"{name} was lost due to an error.");
                        }
                        
                    }
                }
                else if (cmd[0] == "Change")
                {
                    int index = int.Parse(cmd[1]);
                    
                    string newName = cmd[2];
                    if (index >= 0 && index < friends.Count)
                    {
                        string currentName = friends[index];
                        friends[index] = newName;
                        Console.WriteLine($"{currentName} changed his username to {newName}.");
                    }
                }
                
                
                
                
                input = Console.ReadLine();
            }
            int blacklisted = 0;
            int lost = 0;
            for (int i = 0; i < friends.Count; i++)
            {
                if (friends[i] == "Blacklisted")
                {
                    blacklisted++;
                }
                if (friends[i] == "Lost")
                {
                    lost++;
                }
            }
            Console.WriteLine($"Blacklisted names: {blacklisted}");
            Console.WriteLine($"Lost names: {lost}");
            Console.WriteLine(string.Join(" ",friends));
        }
    }
}
