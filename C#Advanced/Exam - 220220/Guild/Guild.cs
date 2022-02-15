using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private readonly List<Player> roster;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get {return roster.Count; } }
        public void AddPlayer(Player player)
        {
            if (Capacity>roster.Count)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            if (roster.Any(x=>x.Name==name))
            {
                return roster.Remove(roster.Where(x => x.Name == name).FirstOrDefault());
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            roster.Where(x => x.Name == name).First().Rank = "Member";
        }
        public void DemotePlayer(string name)
        {
            roster.Where(x => x.Name == name).First().Rank = "Trial";
        }
        public Player[] KickPlayersByClass(string clas)
        {
            Player[] kicked = roster.Where(x => x.Class == clas).ToArray();
            roster.RemoveAll(x => x.Class == clas);
            return kicked;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
