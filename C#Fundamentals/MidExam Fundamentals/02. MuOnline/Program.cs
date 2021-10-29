using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> rooms = Console.ReadLine().Split("|").ToList();
            int bitcoins = 0;
            int health = 100;
            bool isDead = false;
            for (int i = 0; i < rooms.Count; i++)
            {
                string[] cmd = rooms[i].Split().ToArray();
                if (cmd[0] == "potion")
                {
                    int givenHealth = int.Parse(cmd[1]);
                    
                    if (health+givenHealth>100)
                    {
                        Console.WriteLine($"You healed for {100-health} hp.");
                        health = 100;
                    }
                    else
                    {
                        health += givenHealth;
                        Console.WriteLine($"You healed for {givenHealth} hp.");
                    }
                    
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (cmd[0] == "chest")
                {
                    bitcoins += int.Parse(cmd[1]);
                    Console.WriteLine($"You found {int.Parse(cmd[1])} bitcoins.");
                }
                else
                {
                    health -= int.Parse(cmd[1]);
                    if (health<=0)
                    {
                        Console.WriteLine($"You died! Killed by {cmd[0]}.");
                        Console.WriteLine($"Best room: {i+1}");
                        isDead = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {cmd[0]}.");
                    }
                }
            }
            if (!isDead)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
                
            }
        }
    }
}
