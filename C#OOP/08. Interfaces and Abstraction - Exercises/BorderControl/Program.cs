using System;
using System.Collections.Generic;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IDentifiable> inhabitors = new List<IDentifiable>();
            while (input!="End")
            {
                string[] stringElements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (stringElements.Length == 3)
                {
                    IDentifiable person = new Citizen(stringElements[0], int.Parse(stringElements[1]), stringElements[2]);
                    inhabitors.Add(person);
                }
                else if (stringElements.Length == 2)
                {
                    IDentifiable android = new Robot(stringElements[0], stringElements[1]);
                    inhabitors.Add(android);
                }
                input = Console.ReadLine();
            }
            string detain = Console.ReadLine();
            foreach (var inhabitor in inhabitors)
            {
                if (inhabitor.Id.EndsWith(detain))
                {
                    Console.WriteLine(inhabitor.ToString());
                }
            }
        }
    }
}
