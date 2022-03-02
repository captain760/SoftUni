using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ILieutenantGeneral
    {
        public HashSet<Private> Privates { get; set; }
    }
}
