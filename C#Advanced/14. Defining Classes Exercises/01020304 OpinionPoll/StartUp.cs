using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] token = Console.ReadLine().Split();
                string name = token[0];
                int age = int.Parse(token[1]);
                Person person = new Person();
                person.Name = name;
                person.Age = age;
                family.AddMember(person);
            }
            List<Person> elders = family.OldPeople(30);
            foreach (var old in elders)
            {
                Console.WriteLine($"{old.Name} - {old.Age}");
            }
        }
    }
}
