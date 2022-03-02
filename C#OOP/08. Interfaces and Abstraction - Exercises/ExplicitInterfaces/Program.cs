using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input !="End")
            {
                string[] el = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                IPerson citizen1 = new Citizen(el[0], el[1], int.Parse(el[2]));
                IResident citizen2 = new Citizen(el[0], el[1], int.Parse(el[2]));
                Console.WriteLine(citizen1.GetName());
                Console.WriteLine(citizen2.GetName());
                input = Console.ReadLine();
            }
        }
    }
}
