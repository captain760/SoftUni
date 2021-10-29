using System;

namespace _08_BeerKeggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int kegsNumbers = int.Parse(Console.ReadLine());
            string biggestKegName = "";
            double biggestKegVolume = 0;
            for (int i = 1; i <= kegsNumbers; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double volume = Math.PI * radius * radius * height;
                if (volume>biggestKegVolume)
                {
                    biggestKegVolume = volume;
                    biggestKegName = model;
                }
            }
            Console.WriteLine(biggestKegName);
        }
    }
}
