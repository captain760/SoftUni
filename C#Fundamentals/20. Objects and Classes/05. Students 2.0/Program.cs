using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students_2._0
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();
            while (input != "end")
            {
                string[] data = input.Split().ToArray();
                string firstName = data[0];
                string lastName = data[1];
                int age = int.Parse(data[2]);
                string town = data[3];
                Student record = new Student();
                record.FirstName = firstName;
                record.LastName = lastName;
                record.Age = age;
                record.HomeTown = town;
                if (StudentExist(students, firstName, lastName))
                {
                    record = GetStudent(students, firstName, lastName);
                    record.Age = age;
                    record.HomeTown = town;
                }
                else
                {
                    students.Add(record);
                }
                
                input = Console.ReadLine();
            }
            string reqCity = Console.ReadLine();
            foreach (var item in students)
            {
                if (item.HomeTown == reqCity)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
                }
            }
        }

        private static Student GetStudent(List<Student> students, string firstName, string lastName)
        {

            Student existingStudent = null;
            foreach (var item in students)
            {
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                    existingStudent = item;
                }
            }
            return existingStudent;
        }

        private static bool StudentExist(List<Student> students, string firstName, string lastName)
        {
            foreach (var item in students)
            {
                if (item.FirstName == firstName && item.LastName == lastName)
                {
                    return true;
                }
                
            }
            return false;
        }
    }
}
