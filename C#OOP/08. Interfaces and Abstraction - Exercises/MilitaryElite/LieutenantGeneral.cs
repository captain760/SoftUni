using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral:Private,ISoldier,IPrivate,ILieutenantGeneral
    {
        
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary):base(id, firstName, lastName, salary)
        {
            Privates = new HashSet<Private>();
        }
        public HashSet<Private> Privates { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine("Privates:");
            foreach (var private1 in Privates)
            {
                sb.AppendLine(private1.ToString());
            }
            return sb.ToString().Trim();
        }


    }
}
