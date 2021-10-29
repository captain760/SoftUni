using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ").ToList();
            string input = Console.ReadLine();
            while (input != "Craft!")
            {
                List<string> cmd = input.Split(" - ").ToList();
                if (cmd[0] == "Collect")
                {
                    if (!items.Contains(cmd[1]))
                    {
                        items.Add(cmd[1]);
                    }

                }
                else if (cmd[0] == "Drop")
                {
                    if (items.Contains(cmd[1]))
                    {
                        items.Remove(cmd[1]);
                    }
                }
                else if (cmd[0] == "Combine Items")
                {
                    string[] oldNew = cmd[1].Split(":").ToArray();
                    if (items.Contains(oldNew[0]))
                    {
                        items.Insert(items.IndexOf(oldNew[0]) + 1, oldNew[1]);
                    }
                }
                else if (cmd[0] == "Renew")
                {
                    if (items.Contains(cmd[1]))
                    {
                        items.Add(cmd[1]);
                        items.Remove(cmd[1]);
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", items));
        }
    }
}
