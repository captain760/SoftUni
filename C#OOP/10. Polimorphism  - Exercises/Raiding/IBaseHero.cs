using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public interface IBaseHero
    {
        
        public string Name { get; set; }
        int Power();
        string CastAbility();
    }
}
