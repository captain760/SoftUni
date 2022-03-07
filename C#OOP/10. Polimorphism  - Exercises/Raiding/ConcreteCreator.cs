using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class DruidFactory : HeroFactory
    {
        protected override IBaseHero MakeHero(string name)
        {
            IBaseHero hero = new Druid(name);
            return hero;
        }
    }
    public class PaladinFactory : HeroFactory
    {
        protected override IBaseHero MakeHero(string name)
        {
            IBaseHero hero = new Paladin(name);
            return hero;
        }
    }
    public class RogueFactory : HeroFactory
    {
        protected override IBaseHero MakeHero(string name)
        {
            IBaseHero hero = new Rogue(name);
            return hero;
        }
    }
    public class WarriorFactory : HeroFactory
    {
        protected override IBaseHero MakeHero(string name)
        {
            IBaseHero hero = new Warrior(name);
            return hero;
        }
    }
}
