using System;

namespace _10_Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int powerN = int.Parse(Console.ReadLine());
            double halfInitialPower = powerN/2.0;
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionY = int.Parse(Console.ReadLine());
            int targets = 0;
            while (powerN>=distanceM)
            {
                powerN -= distanceM;
                if (powerN == halfInitialPower && exhaustionY!=0)
                {
                    powerN = powerN / exhaustionY;
                }
                targets++;
                

            }
            Console.WriteLine(powerN);
            Console.WriteLine(targets);
        }
    }
}
