using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyEmployees = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] token = input.Split(" -> ").ToArray();
                string company = token[0];
                string employee = token[1];
                if (companyEmployees.ContainsKey(company))
                {
                    if (!companyEmployees[company].Contains(employee))
                    {
                        companyEmployees[company].Add(employee);
                    }

                }
                else
                {
                    List<string> employees = new List<string>();
                    employees.Add(employee);
                    companyEmployees.Add(company, employees);
                }

                input = Console.ReadLine();
            }
            companyEmployees = companyEmployees.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in companyEmployees)
            {
                Console.WriteLine(item.Key);
                foreach (var item1 in item.Value)
                {
                    Console.WriteLine($"-- {item1}");
                }
            }
        }
    }
}
