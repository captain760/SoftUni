using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> ssp = new SortedSet<Person>();
            HashSet<Person> hsp = new HashSet<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                
                string[] token = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries); 
                Person person = new Person(token[0], int.Parse(token[1]));
                
                ssp.Add(person);
                hsp.Add(person);
            }
            Console.WriteLine(ssp.Count);
            Console.WriteLine(hsp.Count);
        }
    }
}
