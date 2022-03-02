using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer: SpecialisedSoldier,ISoldier,ISpecialisedSoldier,IPrivate
    {
        
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary,corps)
        {
            Repairs = new List<Repair>();
        }
        public List<Repair> Repairs { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");
            foreach (var repair in Repairs)
            {
                sb.AppendLine(repair.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
