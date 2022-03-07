using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin:IBaseHero
    {
        public Paladin(string name)
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
            return $"Paladin - {Name} healed for {Power()}";
        }
    }
}
