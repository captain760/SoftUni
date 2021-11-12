using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Dragon_Army
{
    public class Dragon
    {
        public Dragon(string name, double damage, double health, double armor)
        {
            Name = name;

            Damage = damage;
            Health = health;
            Armor = armor;
        }
        public string Name { get; set; }

        public double Damage { get; set; }
        public double Health { get; set; }
        public double Armor { get; set; }

     //   public override string ToString() => $"-{Name} -> damage: {Damage}, health: {Health}, armor: {Armor}";
    }
    class Program
    { 
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, List<Dragon>> dragons = new Dictionary<string, List<Dragon>>();
            for (int i = 0; i < count; i++)
            {
                string[] currDragon = Console.ReadLine().Split();
                _ = currDragon[2] == "null" ? currDragon[2] = "45" : currDragon[2] = currDragon[2];
                _ = currDragon[3] == "null" ? currDragon[3] = "250" : currDragon[3] = currDragon[3];
                _ = currDragon[4] == "null" ? currDragon[4] = "10" : currDragon[4] = currDragon[4];
                Dragon dragon = new Dragon(currDragon[1], double.Parse(currDragon[2]), double.Parse(currDragon[3]),
                    double.Parse(currDragon[4]));

                if (!dragons.ContainsKey(currDragon[0]))
                {
                    var tempList = new List<Dragon>();
                    tempList.Add(dragon);
                    dragons.Add(currDragon[0], tempList);

                }

                if (dragons[currDragon[0]].Any(x => x.Name == dragon.Name))
                {
                    dragons[currDragon[0]].RemoveAll(x => x.Name == dragon.Name);
                    dragons[currDragon[0]].Add(dragon);
                }
                else
                {
                    dragons[currDragon[0]].Add(dragon);
                }
            }
            foreach (var type in dragons)
            {
                Console.WriteLine($"{type.Key}::({type.Value.Select(x => x.Damage).Average():f2}/{type.Value.Select(x => x.Health).Average():f2}/{type.Value.Select(x => x.Armor).Average():f2})");
                foreach (var individualDragon in type.Value.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{individualDragon.Name} -> damage: {individualDragon.Damage}, health: {individualDragon.Health}, armor: {individualDragon.Armor}");
                }
            }
        }
    }
    
}
