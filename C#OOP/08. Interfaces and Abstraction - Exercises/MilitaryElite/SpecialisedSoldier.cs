using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class SpecialisedSoldier:Private,ISoldier,IPrivate,ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,string corps) : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }
        public string Corps 
        {
            get {return this.corps; }
            set 
            {
                if (value == "Airforces" || value == "Marines")
                {
                    this.corps = value;
                }
                else
                {
                    this.corps = "Invalid";
                }
               
            }
        }
    }
}
