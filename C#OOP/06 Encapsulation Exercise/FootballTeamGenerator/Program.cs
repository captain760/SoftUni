using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string input = Console.ReadLine();            
            while (input!="END")
            {
                string[] elements = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
                string teamName = elements[1];
                if (string.IsNullOrWhiteSpace(teamName))
                {
                    Console.WriteLine("A name should not be empty.");
                    input = Console.ReadLine();
                    continue;
                }

                if (elements[0] == "Team")
                {                   
                    Team team = new Team(teamName);
                    teams.Add(team);
                }
                else if (elements[0] == "Add")
                {
                    string playerName = elements[2];
                    int endurance = int.Parse(elements[3]);
                    int sprint = int.Parse(elements[4]);
                    int dribble = int.Parse(elements[5]);
                    int passing = int.Parse(elements[6]);
                    int shooting = int.Parse(elements[7]);
                    if (teams.Any(x => x.Name == teamName) == false)
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        input = Console.ReadLine();
                        continue;
                    }
                    Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                    if (!string.IsNullOrWhiteSpace(playerName) && endurance >= 0 && endurance <= 100 && sprint >= 0 && sprint <= 100 && dribble >= 0 && dribble <= 100 && passing >= 0 && passing <= 100 && shooting >= 0 && shooting <= 100)
                    {

                        if (teams.Any(x => x.Name == teamName))
                        {
                            teams.Where(x => x.Name == teamName).First().Add(player);
                        }
                    }   
                                        
                }
                else if (elements[0]=="Remove")
                {
                    string playerName = elements[2];
                    if (teams.Any(x => x.Name == teamName) == false)
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        input = Console.ReadLine();
                        continue;
                    }
                    if (teams.Any(x=>x.Name == teamName))
                    {
                        if (teams.Where(x => x.Name == teamName).First().Remove(playerName)==false)
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                        }
                        else
                        {
                            teams.Where(x => x.Name == teamName).First().Remove(playerName);
                        }

                    }
                    
                }
                else if (elements[0] == "Rating")
                {
                    if (teams.Any(x => x.Name == teamName) == false)
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        input = Console.ReadLine();
                        continue;
                    }
                    if (teams.Any(x=>x.Name == teamName))
                    {
                        
                        Console.WriteLine($"{teamName} - {teams.Where(x=>x.Name==teamName).First().Rating}");
                    }
                    
                    
                }
                input = Console.ReadLine();
            }

        }
    }
}
