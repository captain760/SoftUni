using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> courses = Console.ReadLine().Split(", ").ToList();
            string input = Console.ReadLine();
            while (input !="course start")
            {
                string[] cmd = input.Split(":").ToArray();
                if (cmd[0] == "Add")
                {
                    if (!courses.Contains(cmd[1]))
                    {
                        courses.Add(cmd[1]);
                    }
                }
                else if (cmd[0] == "Insert")
                {
                    int index = int.Parse(cmd[2]);
                    if (!courses.Contains(cmd[1])&& index>=0 && index<courses.Count)
                    {
                        courses.Insert(index,cmd[1]);
                    }
                }
                else if (cmd[0] == "Remove")
                {
                        if (courses.Contains(cmd[1]))
                        {
                            courses.Remove(cmd[1]);
                            if (courses.Contains(cmd[1]+"-Exercise"))
                            {
                            courses.Remove(cmd[1] + "-Exercise");
                            }
                        }
                }
                else if (cmd[0] == "Swap")
                {
                    if (courses.Contains(cmd[1]) && courses.Contains(cmd[2]))
                    {
                        int index1 = courses.IndexOf(cmd[1]);
                        int index2 = courses.IndexOf(cmd[2]);
                        string temp = courses[index1];
                        courses[index1] = courses[index2];
                        courses[index2] = temp;
                        if (courses.Contains(cmd[1] + "-Exercise"))
                        {
                            courses.Remove(cmd[1] + "-Exercise");
                            if (index2 == courses.Count)
                            {
                                courses.Add(cmd[1] + "-Exercise");
                            }
                            else
                            courses.Insert(index2+1,cmd[1] + "-Exercise");
                        }
                        if (courses.Contains(cmd[2] + "-Exercise"))
                        {
                            courses.Remove(cmd[2] + "-Exercise");
                            if (index1 == courses.Count)
                            {
                                courses.Add(cmd[2] + "-Exercise");
                            }
                            else
                                courses.Insert(index1+1, cmd[2] + "-Exercise");
                        }
                    }
                }
                else if (cmd[0] == "Exercise")
                {
                    if (courses.Contains(cmd[1]) && !courses.Contains(cmd[1]+"-Exercise"))
                    {
                        int nextIndex = courses.IndexOf(cmd[1])+1;
                        courses.Insert(nextIndex,cmd[1]+"-Exercise");
                    }
                    else if (!courses.Contains(cmd[1]))
                    {
                        courses.Add(cmd[1]);
                        courses.Add(cmd[1] + "-Exercise");
                    }
                }





               // Console.WriteLine(string.Join(" ", courses));
                input = Console.ReadLine();
            }
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i+1}.{courses[i]}");
            }
            
        }
    }
}
