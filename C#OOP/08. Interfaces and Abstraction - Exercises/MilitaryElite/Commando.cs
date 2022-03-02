using System;
using System.Collections.Generic;
using System.Text;


namespace MilitaryElite
{
    public class Commando:SpecialisedSoldier,ISpecialisedSoldier,ISoldier,IPrivate
    {
     
        public Commando(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<Mission>();
        }
        public List<Mission> Missions { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine(mission.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
