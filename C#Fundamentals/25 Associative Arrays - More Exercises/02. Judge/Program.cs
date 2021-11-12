using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            //input of the three elements
            Dictionary<string, List<string>> contestUsers = new Dictionary<string, List<string>>();
           
            string input = Console.ReadLine();
            while (input != "no more time")
            {
                string[] token = input.Split(" -> ");
                string user = token[0];
                string contest = token[1];                
                string points = token[2];

                
                    if (contestUsers.ContainsKey(contest))
                    {
                        if (contestUsers[contest].Contains(user))
                        {
                            if (int.Parse(contestUsers[contest][contestUsers[contest].IndexOf(user) + 1]) < int.Parse(points))
                            {
                                contestUsers[contest][contestUsers[contest].IndexOf(user) + 1] = points;
                            }

                        }
                        else
                        {
                            contestUsers[contest].Add(user);
                            contestUsers[contest].Add(points);

                        }
                    }
                    else
                    {
                        List<string> userPointList = new List<string>();
                        userPointList.Add(user);
                        userPointList.Add(points);

                        contestUsers.Add(contest, userPointList);
                    }

                
                input = Console.ReadLine();
            }
            // total points summation
            Dictionary<string, int> userPoints = new Dictionary<string, int>();
            foreach (var cont in contestUsers)
            {
                for (int m = 0; m < cont.Value.Count - 1; m += 2)
                {
                    string user = cont.Value[m];
                    int pts = int.Parse(cont.Value[m + 1]);
                    if (userPoints.ContainsKey(user))
                    {
                        userPoints[user] += pts;
                    }
                    else
                    {
                        userPoints.Add(user, pts);
                    }
                }
            }
            // printings of contests with users and points
            foreach (var item in contestUsers)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count/2} participants");
                Dictionary<string, int> currentUserPoints = new Dictionary<string, int>();
                for (int k = 0; k < item.Value.Count; k+=2)
                {
                    currentUserPoints.Add(item.Value[k], int.Parse(item.Value[k + 1]));
                }
                currentUserPoints = currentUserPoints.OrderByDescending(x => x.Value).ThenBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);
                 int j = 1;
                foreach (var participant in currentUserPoints)
                {
                    
                    Console.WriteLine($"{j}. {participant.Key} <::> {participant.Value}");
                    j++;
                }
            }
            //printing individual statistics
            userPoints = userPoints.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Individual standings:");
            int i = 1;
            foreach (var item in userPoints)
            {
                
                Console.WriteLine($"{i}. {item.Key} -> {item.Value}");
                i++;
            }
        }
    }
}
