using System;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            IBuyer[] buyers = new IBuyer[n];
            for (int i = 0; i < n; i++)
            {
                string[] stringElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (stringElements.Length == 4)
                {
                    IBuyer citizen = new Citizen(stringElements[0], int.Parse(stringElements[1]), stringElements[2], stringElements[3]);
                    buyers[i] = citizen;
                }
                else if (stringElements.Length == 3)
                {
                    IBuyer rebel = new Rebel(stringElements[0], int.Parse(stringElements[1]), stringElements[2]);
                    buyers[i] = rebel;
                }
            }
            string input = Console.ReadLine();
            int totalFood = 0;
            while (input !="End")
            {
                if (buyers.Any(x=>x.Name ==input))
                {
                    buyers.Where(x => x.Name == input).First().BuyFood();
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(buyers.Sum(x=>x.Food));
        }
    }
}
