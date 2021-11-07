using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentGrade = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (studentGrade.ContainsKey(name))
                {
                    studentGrade[name].Add(grade);
                }
                else
                {
                    List<double> grades = new List<double>();
                    grades.Add(grade);
                    studentGrade.Add(name, grades);
                }
            }
            Dictionary<string, double> omittingWeakGrade = new Dictionary<string, double>();
            foreach (var item in studentGrade)
            {
                double sum = 0;
                foreach (var mark in item.Value)
                {
                    sum += mark;
                }
                double average = sum / item.Value.Count;
                if (average >= 4.5)
                {
                    omittingWeakGrade[item.Key] = average;
                }

            }
            Dictionary<string, double> sortedNameGrade = omittingWeakGrade.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in sortedNameGrade)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
}
