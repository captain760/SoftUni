using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Treasure_Hunt
{
    class Program
    {
        private static bool IndexValidity(List<string> treasure, int v)
        {

            if (v >= 0 && v < treasure.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split("|").ToList();
            string input = Console.ReadLine();
            while (input != "Yohoho!")
            {
                //•	"Loot {item1} {item2}…{itemn}":
                //o Pick up treasure loot along the way. Insert the items at the beginning of the chest.
                //o If an item is already contained,don't insert it.
                //•	"Drop {index}":
                //o Remove the loot at the given positionand add it at the end of the treasure chest.
                //o If the index is invalid, skip the command.
                //•	"Steal {count}":
                //o Someone steals the last count loot items. If there are fewer items than the given count,remove as much as there are.
                //o Print the stolen items separated by ", ":
                //"{item1}, {item2}, {item3} … {itemn}"
                string[] cmd = input.Split().ToArray();
                if (cmd[0] == "Loot")
                {
                    for (int i = 1; i < cmd.Length; i++)
                    {
                        if (!chest.Contains(cmd[i]))
                        {
                            chest.Insert(0, cmd[i]);
                        }
                    }
                }
                else if (cmd[0] == "Drop")
                {
                    if (IndexValidity(chest, int.Parse(cmd[1])))
                    {
                        chest.Add(chest[int.Parse(cmd[1])]);
                        chest.RemoveAt(int.Parse(cmd[1]));
                    }
                }
                else if (cmd[0] == "Steal")
                {
                    int count = int.Parse(cmd[1]);
                    if (count>chest.Count)
                    {
                        count = chest.Count;
                    }
                    List<string> stolen = new List<string>();
                    for (int i = 0; i < count; i++)
                    {
                        int br = chest.Count - 1 - i;
                            stolen.Add(chest[br]);
                    }
                    stolen.Reverse();
                    Console.WriteLine(string.Join(", ", stolen));
                    for (int i = 0; i < count; i++)
                    {
                        chest.RemoveAt(chest.Count-1);
                    }
                }


                    input = Console.ReadLine();
            }
            double averageGain = 0;
            int sum = 0;
            foreach (string item in chest)
            {
                sum += item.Length;
            }
            if (chest.Count != 0)
            {
                averageGain = 1.0 * sum / chest.Count;
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
                if (chest.Count == 0)
            {
                Console.WriteLine($"Failed treasure hunt.");
            }
        }
    }
}
