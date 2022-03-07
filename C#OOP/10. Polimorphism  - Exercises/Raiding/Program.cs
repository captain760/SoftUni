using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    { 
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int i = 0;
            List<IBaseHero> raid = new List<IBaseHero>();
            while (i<n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                IBaseHero hero = null;
                switch (type)
                {
                    case "Druid":
                        {
                            hero = new DruidFactory().CreateHero(name);
                            break;
                        }
                    case "Paladin":
                        {
                            hero = new PaladinFactory().CreateHero(name);
                            break;
                        }
                    case "Rogue":
                        {
                            hero = new RogueFactory().CreateHero(name);
                            break;
                        }
                    case "Warrior":
                        {
                            hero = new WarriorFactory().CreateHero(name);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid hero!");
                            continue;
                        }
                }
                raid.Add(hero);
                i++;
            }
            int bossPower = int.Parse(Console.ReadLine());
            foreach (var raider in raid)
            {
                Console.WriteLine(raider.CastAbility());
            }
            if (bossPower<=raid.Sum(x=>x.Power()))
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
