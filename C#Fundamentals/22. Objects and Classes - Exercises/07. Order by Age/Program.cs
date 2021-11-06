using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> persons = new List<Person>();
            while (input!= "End")
            {
                string[] token = input.Split();
                bool infoAmended = false;
                foreach (var item in persons)
                {
                    if (item.Id == token[1])
                    {
                        item.Name = token[0];
                        item.Age = int.Parse(token[2]);
                        infoAmended = true;
                        break;
                    }
                }
                if (!infoAmended)
                {
                    Person currentPerson = new Person();
                    currentPerson.Name = token[0];
                    currentPerson.Id = token[1];
                    currentPerson.Age = int.Parse(token[2]);
                    persons.Add(currentPerson);
                }
                
                input = Console.ReadLine();
            }
            List<Person> sortedByAge = persons.OrderBy(x => x.Age).ToList();
            foreach (var item in sortedByAge)
            {
                Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Age} years old.");
            }
        }
    }
}
