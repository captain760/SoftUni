using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> userPoints = new Dictionary<string, int>();
            Dictionary<string, int> langSubs = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] token = input.Split("-").ToArray();
                string username = token[0];
                string language = token[1];
                
                if (language == "banned")
                {
                    if (userPoints.ContainsKey(username))
                    {
                        userPoints.Remove(username);
                    }
                }
                else
                {
                    int points = int.Parse(token[2]);
                    if (userPoints.ContainsKey(username))
                    {
                        if (userPoints[username] < points)
                        {
                            userPoints[username] = points;
                        }
                    }
                    else
                    {
                        userPoints.Add(username, points);
                    }
                }
                if (langSubs.ContainsKey(language))
                {
                    langSubs[language]++;
                }
                else
                {
                    langSubs.Add(language, 1);
                }
                input = Console.ReadLine();
            }
            if (langSubs.ContainsKey("banned"))
            {
                langSubs.Remove("banned");
            }
            Console.WriteLine("Results:");
            userPoints = userPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in userPoints)
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            Console.WriteLine("Submissions:");
            langSubs = langSubs.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in langSubs)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
