using System;

namespace _01._Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double targetPlunder = double.Parse(Console.ReadLine());
            double currentPlunder = 0;
            for (int i = 1; i <= days; i++)
            {
                currentPlunder += dailyPlunder;
                if (i%3 == 0)
                {
                    currentPlunder += 0.5*dailyPlunder;
                }
                if (i % 5 == 0)
                {
                    currentPlunder = 0.7*currentPlunder;
                }

            }
            if (currentPlunder>=targetPlunder)
            {
                Console.WriteLine($"Ahoy! {currentPlunder:f2} plunder gained.");
            }
            else
            {

                double perc = currentPlunder / targetPlunder * 100;
                Console.WriteLine($"Collected only {perc:f2}% of the plunder.");
            }
        }
    }
}
