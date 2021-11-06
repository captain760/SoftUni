using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    class Team
    {
        public Team()
        {
            Users = new List<string>();
        }
        public string Creator { get; set; }
        public string TeamName { get; set; }
        public List<string> Users { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams= new List<Team>();
            
            
            
            for (int i = 0; i < teamsCount; i++)
            {
                string[] input = Console.ReadLine().Split("-");
                
                
                bool isTeamAndUserValid = true;
                foreach (var team in teams)
                {
                    if (team.TeamName == input[1])
                    {
                        Console.WriteLine($"Team {input[1]} was already created!");
                        isTeamAndUserValid = false;
                        break;
                    }
                }
                if (isTeamAndUserValid)
                {
                    foreach (var team in teams)
                    {
                        if (team.Creator == input[0])
                        {
                            Console.WriteLine($"{input[0]} cannot create another team!");
                            isTeamAndUserValid = false;
                            break;
                        }

                    }
                }
                
                if (isTeamAndUserValid)
                {
                    Team currentTeam1 = new Team();
                    currentTeam1.Creator = input[0];
                    currentTeam1.TeamName = input[1];
                    teams.Add(currentTeam1);
                    Console.WriteLine($"Team {input[1]} has been created by {input[0]}!");
                }
                
                
            }
            string token = Console.ReadLine();
            Team currentTeam = new Team();
            
            while (token !="end of assignment")
            {
                string[] cmd = token.Split("->",StringSplitOptions.RemoveEmptyEntries);
                string user = cmd[0];
                string team = cmd[1];
                bool isTeamExisting = false;
                bool isUserExisting = false;
                bool isUserCreator = false;
                foreach (var item in teams)
                {
                    
                    if (item.TeamName == team )
                    {
                        isTeamExisting = true;
                        if (item.Creator == user)
                        {
                            isUserCreator = true;
                            break;
                        }
                        break;
                    }
                    else 
                    {
                        if (item.Users.Contains(user) )
                        {
                            isUserExisting = true;
                            break;
                        }
                      
                    }
                    if (isUserExisting)
                    {
                        break;
                    }
                }

                if (!isTeamExisting)
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (isUserExisting || isUserCreator)
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                }
                else
                {
                    foreach (var item2 in teams)
                    {
                        if (item2.TeamName == team)
                        {
                            //Team currentTeam2 = new Team();

                            //currentTeam2.Users.Add(user);
                            item2.Users.Add(user);
                            break;
                        }
                    }
                    
                }
                isTeamExisting = false;
                isUserExisting = false;
                
                token = Console.ReadLine();
            }
            List<string> disbanded = new List<string>();
            foreach (var item3 in teams)
            {
                if (item3.Users.Count == 0)
                {
                    disbanded.Add(item3.TeamName);
                }
            }
            disbanded.Sort();
            
            
            List<Team> sortedTeams = new List<Team>();
            sortedTeams = teams.OrderByDescending(x => x.Users.Count).ThenBy(x=>x.TeamName).ToList();
            foreach (var item4 in sortedTeams)
            {
                if (item4.Users.Count !=0)
                {
                    Console.WriteLine(item4.TeamName);
                    Console.WriteLine($"- {item4.Creator}");
                    item4.Users.Sort();
                    foreach (var item5 in item4.Users)
                    {
                        Console.WriteLine($"-- {item5}");
                    }
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var item6 in disbanded)
            {
                Console.WriteLine(item6);
            }
        }
    }
}
