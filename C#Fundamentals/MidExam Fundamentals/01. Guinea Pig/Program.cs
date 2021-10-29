using System;

namespace _01._Guinea_Pig
{
    class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine());
            double hay = double.Parse(Console.ReadLine());
            double cover = double.Parse(Console.ReadLine());
            double weight = double.Parse(Console.ReadLine());
            int days = 0;
            bool notEnough = false;
            while (days<30)
            {
                days++;
                food -= 0.3;
                if (days%2 == 0)
                {
                    hay -= 0.05 * food;
                }
                if (days%3==0)
                {
                    cover -= weight / 3;
                }
                if (food<=0 || hay<=0 || cover<=0)
                {
                    notEnough = true;
                    break;
                }
            }
            if (notEnough)
            {
                Console.WriteLine($"Merry must go to the pet store!");
            }
            else
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
        }
    }
}
