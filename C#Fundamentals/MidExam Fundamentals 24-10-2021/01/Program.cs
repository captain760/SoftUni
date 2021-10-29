using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());
            int freePacksFlour = students / 5;
            double totalNeeded = 1.0*apronPrice*Math.Ceiling(1.2*students) + 1.0*eggPrice *students* 10 + 1.0*flourPrice *(students - freePacksFlour);
            if (totalNeeded<=budget)
            {
                Console.WriteLine($"Items purchased for {totalNeeded:f2}$.");
            }
            else
            {
                Console.WriteLine($"{(totalNeeded-budget):f2}$ more needed.");
            }
        }
    }
}
