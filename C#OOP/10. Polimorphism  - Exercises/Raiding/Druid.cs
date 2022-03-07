using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : IBaseHero
    {
        public Druid(string name)
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
            return $"Druid - {Name} healed for {Power()}";
        }
    }
}
