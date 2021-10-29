using System;
using System.Numerics;

namespace _11_Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSnowballs = int.Parse(Console.ReadLine());
            BigInteger bestSnowballValue = 0;
            BigInteger snowballValue;
            int bestSnowballSnow = 0;
            int bestSnowballTime = 1;
            int bestSnowballQuality = 0;
            for (int i = 0; i < numSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                
               
                snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                
               
                if (snowballValue > bestSnowballValue)
                {
                    bestSnowballValue = snowballValue;
                    bestSnowballSnow = snowballSnow;
                    bestSnowballTime = snowballTime;
                    bestSnowballQuality = snowballQuality;
                }
                
            }
            
                Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowballValue} ({bestSnowballQuality})");
            
            
        }
    }
}
