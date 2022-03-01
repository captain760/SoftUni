using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IBirthable> inhabitors = new List<IBirthable>();
            while (input != "End")
            {
                string[] stringElements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (stringElements[0] == "Citizen")
                {
                    IBirthable person = new Citizen(stringElements[1], int.Parse(stringElements[2]), stringElements[3],stringElements[4]);
                    inhabitors.Add(person);
                }
                else if (stringElements[0] == "Robot")
                {
                    //IDentifiable android = new Robot(stringElements[1], stringElements[2]);
                    //inhabitors.Add(android);
                }
                else if (stringElements[0] == "Pet")
                {
                    IBirthable pet = new Pet(stringElements[1],stringElements[2]);
                    inhabitors.Add(pet);
                }
                input = Console.ReadLine();
            }
            string year = Console.ReadLine();
            foreach (var inhabitor in inhabitors)
            {
                if (inhabitor.Birthday.EndsWith(year))
                {
                    Console.WriteLine(inhabitor.ToString());
                }
            }
        }
    }
}
