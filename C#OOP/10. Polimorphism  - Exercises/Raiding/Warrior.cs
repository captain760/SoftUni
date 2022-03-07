using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior:IBaseHero
    {
        public Warrior(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public int Power()
        {
            return 100;
        }
        public string CastAbility()
        {
            return $"Warrior - {Name} hit for {Power()} damage";
        }
    }
}
