using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPass = new Dictionary<string, string>();
            Dictionary<string, List<string>> contestUsers = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input!="end of contests")
            {
                string[] token = input.Split(":");
                contestPass.Add(token[0], token[1]);                
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] token = input.Split("=>");
                string contest = token[0];
                string pass = token[1];
                string user = token[2];
                string points = token[3];

                if (contestPass.ContainsKey(contest) && contestPass[contest] == pass)
                {
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
                    
                }
                input = Console.ReadLine();
            }
            Dictionary<string, int> userPoints = new Dictionary<string, int>();
            foreach (var cont in contestUsers)
            {
                for (int i = 0; i < cont.Value.Count-1; i+=2)
                {
                    string user = cont.Value[i];
                    int pts = int.Parse(cont.Value[i + 1]);
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
            int maxPoints = 0;
            string userMaxPoints = "";
            foreach (var item in userPoints)
            {
                if (item.Value>maxPoints)
                {
                    maxPoints = item.Value;
                    userMaxPoints = item.Key;

                }
            }

            Console.WriteLine($"Best candidate is { userMaxPoints } with total {maxPoints} points.");
            Console.WriteLine("Ranking: ");
            userPoints = userPoints.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in userPoints)
            {
                Console.WriteLine(item.Key);
                Dictionary<string, int> coursePoints = new Dictionary<string, int>();
                foreach (var contest in contestUsers)
                {
                    if (contest.Value.Contains(item.Key))
                    {
                        coursePoints.Add(contest.Key, int.Parse(contest.Value[contest.Value.IndexOf(item.Key) + 1])); 
                    }
                }
                coursePoints = coursePoints.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                foreach (var course in coursePoints)
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
            
        }
    }
}
