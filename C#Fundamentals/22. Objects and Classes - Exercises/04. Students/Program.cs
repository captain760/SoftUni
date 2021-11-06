using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());
            List<Student> studentsList = new List<Student>();
            for (int i = 0; i < numStudents; i++)
            {
                string[] input = Console.ReadLine().Split();

                Student current = new Student();
                current.FirstName = input[0];
                current.LastName = input[1];
                current.Grade = double.Parse(input[2]);
                studentsList.Add(current);
            }
            List<Student> sortedList = studentsList.OrderByDescending(x => x.Grade).ToList();
            foreach (var item in sortedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
