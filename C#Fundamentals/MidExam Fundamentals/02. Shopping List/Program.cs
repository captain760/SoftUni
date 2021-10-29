using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split("!").ToList();
            string input = Console.ReadLine();
            while (input != "Go Shopping!")
            {
                string[] cmd = input.Split().ToArray();
                if (cmd[0] == "Urgent")
                {
                    if (!items.Contains(cmd[1]))
                    {
                       items.Insert(0, cmd[1]);
                    }
                    
                }
                else if (cmd[0] == "Unnecessary")
                {
                    if (items.Contains(cmd[1]))
                    {
                        items.Remove(cmd[1]);
                    }

                }
                else if (cmd[0] == "Correct")
                {
                    if (items.Contains(cmd[1]))
                    {
                      items[items.IndexOf(cmd[1])] = cmd[2];
                    }

                }
                else if (cmd[0] == "Rearrange")
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
