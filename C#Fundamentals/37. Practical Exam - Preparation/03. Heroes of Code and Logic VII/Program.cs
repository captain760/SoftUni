using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> heroHp = new Dictionary<string, int>();
            Dictionary<string, int> heroMp = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int hp = int.Parse(input[1]);
                int mp = int.Parse(input[2]);
                heroHp.Add(name, hp);
                heroMp.Add(name, mp);
            }
            string token = Console.ReadLine();
            while (token != "End")
            {
                string[] cmd = token.Split(" - ");
                if (cmd[0] == "CastSpell")
                {
                    string name = cmd[1];
                    int neededMp = int.Parse(cmd[2]);
                    string spellName = cmd[3];
                    if (heroMp[name]>=neededMp)
                    {
                        heroMp[name] -= neededMp;
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroMp[name]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (cmd[0] == "TakeDamage")
                {
                    string name = cmd[1];
                    int damage = int.Parse(cmd[2]);
                    string attacker = cmd[3];
                    heroHp[name] -= damage;
                    if (heroHp[name]>0)
                    {
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroHp[name]} HP left!");
                    }
                    else
                    {
                        heroHp.Remove(name);
                        heroMp.Remove(name);
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                    }
                }
                else if (cmd[0] == "Recharge")
                {
                    string name = cmd[1];
                    int ammountMp = int.Parse(cmd[2]);
                    int recharge = ammountMp;
                    if ((heroMp[name] + ammountMp) > 200)
                    {
                        
                        recharge = 200 - heroMp[name];
                        heroMp[name] = 200;
                    }
                    else
                    {
                        heroMp[name] += ammountMp;
                    }
                    Console.WriteLine($"{name} recharged for {recharge} MP!");
                }
                else if (cmd[0] == "Heal")
                {
                    string name = cmd[1];
                    int ammountHp = int.Parse(cmd[2]);
                    int recharge = ammountHp;
                    if ((heroHp[name] + ammountHp) > 100)
                    {
                      
                        recharge = 100 - heroHp[name];
                        heroHp[name] = 100;
                    }
                    else
                    {
                        heroHp[name] += ammountHp;
                    }
                    Console.WriteLine($"{name} healed for {recharge} HP!");

                }
                token = Console.ReadLine();
            }
            heroHp = heroHp.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in heroHp)
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine($"  HP: {item.Value}");
                Console.WriteLine($"  MP: {heroMp[item.Key]}");
            }
        }
    }
}
