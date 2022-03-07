using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue:IBaseHero
    {
        public Rogue(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public int Power()
        {
            return 80;
        }
        public string CastAbility()
        {
            return $"Rogue - {Name} hit for {Power()} damage";
        }
    }
}
