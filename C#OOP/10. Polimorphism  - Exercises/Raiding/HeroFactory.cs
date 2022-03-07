using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class HeroFactory
    {
        protected abstract IBaseHero MakeHero(string name);
        public IBaseHero CreateHero(string name)
        {
            return this.MakeHero(name);
        }
    }
}
