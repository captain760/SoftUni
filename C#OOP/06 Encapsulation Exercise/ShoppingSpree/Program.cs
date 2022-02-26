using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] stringElements = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> persons = new List<Person>();
            List<Product> bag = new List<Product>();
            for (int i = 0; i < stringElements.Length; i++)
            {
                string[] stringElements2 = stringElements[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);
                decimal money = decimal.Parse(stringElements2[1]);
                Person person = new Person(bag, money, stringElements2[0]);
                persons.Add(person);
            }
            string[] stringElements3 = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();
            for (int i = 0; i < stringElements3.Length; i++)
            {
                string[] stringElements4 = stringElements3[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);
                decimal cost = decimal.Parse(stringElements4[1]);
                Product product = new Product(cost, stringElements4[0]);
                products.Add(product);
            }
            string cmd = Console.ReadLine();
            while (cmd!="END")
            {
                string[] personProduct = cmd
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = personProduct[0];
                string productName = personProduct[1];
                if (persons.Where(x=>x.Name == personName).First().Money >= products.Where(x=>x.Name==productName).First().Price)
                {
                    persons.Where(x => x.Name == personName).First().Money -= products.Where(x => x.Name == productName).First().Price;
                    persons.Where(x => x.Name == personName).First().Bag.Add(products.Where(x => x.Name == productName).First());
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
                cmd = Console.ReadLine();
            }
            foreach (var person in persons)
            {
                if (person.Bag.Count==0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ",person.Bag.Select(x=>x.Name))}");
                }
            }
        }
    }
}
 