using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    class Program
    {
        public struct NameHat
        {
            public String Name;
            public String Hat;
        }
        static void Main(string[] args)
        {
            Dictionary<NameHat, int> dwarfHatPhysics = new Dictionary<NameHat, int>();
            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                string[] token = input.Split(" <:> ");
                string name = token[0];
                string hat = token[1];
                int physics = int.Parse(token[2]);
                NameHat nameHat = new NameHat();
                nameHat.Name = name;
                nameHat.Hat = hat;
                bool isExisting = false;
                foreach (var item in dwarfHatPhysics)
                {
                    if (item.Key.Name == name && item.Key.Hat == hat && item.Value < physics)
                    {
                        isExisting = true;
                        break;
                    }
                    
                }
                if (isExisting)
                {
                    dwarfHatPhysics[nameHat] = physics;
                }
                else if (!dwarfHatPhysics.ContainsKey(nameHat))
                {
                    dwarfHatPhysics.Add(nameHat, physics);
                }
                


                input = Console.ReadLine();
            }
            dwarfHatPhysics = dwarfHatPhysics
                .OrderByDescending(x=>x.Value)
                .ThenByDescending(x => dwarfHatPhysics.Where(y => y.Key.Hat == x.Key.Hat).Count())
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in dwarfHatPhysics)
            {
                Console.WriteLine($"({item.Key.Hat}) {item.Key.Name} <-> {item.Value}");
            }
        }
    }
}
