using System;
using System.Collections.Generic;

namespace Comparing_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string input = Console.ReadLine();
            while (input!="END")
            {
                string[] token = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person current = new Person();
                current.Name = token[0];
                current.Age = int.Parse(token[1]);
                current.Town = token[2];
                persons.Add(current);
                input = Console.ReadLine();
            }
            int n = int.Parse(Console.ReadLine());
            int equals = 0;
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[n - 1].CompareTo(persons[i])==0)
                {
                    equals++;
                }
            }
            if (equals == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equals} {persons.Count-equals} {persons.Count}");
            }
        }
    }
}
