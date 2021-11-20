using System;
using System.Text;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string initial = Console.ReadLine();
            string input = Console.ReadLine();
            StringBuilder schedule = new StringBuilder();
            schedule.Append(initial);
            while (input != "Travel")
            {
                string[] cmd = input.Split(":");
                if (cmd[0] == "Add Stop")
                {
                    int index = int.Parse(cmd[1]);
                    string stop = cmd[2];
                    if (IsValid(schedule,index))
                    {
                        schedule.Insert(index, stop);
                    }
                    Console.WriteLine(schedule);
                }
                else if (cmd[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(cmd[1]);
                    int endIndex = int.Parse(cmd[2]);
                    if (IsValid(schedule,startIndex) && IsValid(schedule,endIndex))
                    {
                        schedule.Remove(startIndex, (endIndex - startIndex+1));
                    }
                    Console.WriteLine(schedule);

                }
                else if (cmd[0] == "Switch")
                {
                    string oldString = cmd[1];
                    string newString = cmd[2];
                    if (schedule.ToString().Contains(oldString))
                    {
                        schedule.Replace(oldString, newString);
                    }
                    Console.WriteLine(schedule);
                }


                input = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {schedule}");
        }

        private static bool IsValid(StringBuilder schedule, int index)
        {
            if (index >= 0 && index < schedule.Length)
                return true;
            else return false;
        }
    }
}
