using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseNames = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] token = input.Split(" : ").ToArray();
                string name = token[1];
                string course = token[0];
                if (courseNames.ContainsKey(course))
                {
                    courseNames[course].Add(name);
                }
                else
                {
                    List<string> students = new List<string>();
                    students.Add(name);
                    courseNames.Add(course, students);
                }

                input = Console.ReadLine();
            }
            Dictionary<string, List<string>> sortedCourses = new Dictionary<string, List<string>>();
            sortedCourses = courseNames.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in sortedCourses)
            {
                int numStudents = item.Value.Count;
                Console.WriteLine($"{item.Key}: {numStudents}");
                List<string> sortedStudents = item.Value;
                sortedStudents.Sort();
                foreach (var student in sortedStudents)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
