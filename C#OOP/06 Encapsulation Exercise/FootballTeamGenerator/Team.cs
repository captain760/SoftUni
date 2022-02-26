using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private double rating;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public double Rating 
        {
            get 
            {
                if (players.Count!=0)
                {
                    rating = Math.Round(players.Average(x => x.Skil));
                }
                else
                {
                    rating = 0;
                }
                
                return rating;
            }
            
        }

        public string Name
        {
            get { return name; }
            set 
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("A name should not be empty.");
                    //Environment.Exit(01);
                }
                name = value;
            }
        }
        public void Add(Player player)
        {
            players.Add(player);
        }
        public bool Remove(string playerName)
        {
            if (players.Any(x => x.Name == playerName))
            {
                players.Remove(players.Where(x => x.Name == playerName).First());
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
