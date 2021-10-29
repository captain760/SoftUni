using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> house = Console.ReadLine().Split("@").Select(int.Parse).ToList();
            string input = Console.ReadLine();
            int pos = 0;
            while (input !="Love!")
            {
                string[] cmd = input.Split().ToArray();
                pos += int.Parse(cmd[1]);
                if (pos>=house.Count)
                {
                    pos = 0;
                }
                
                if (house[pos] == 0)
                {
                    Console.WriteLine($"Place {pos} already had Valentine's day.");
                    
                }
                else if(house[pos] == 2)
                {
                    Console.WriteLine($"Place {pos} has Valentine's day.");
                    house[pos] -= 2;
                }
                else
                {
                    house[pos] -= 2;
                }
                


                input = Console.ReadLine();
            }
            Console.WriteLine($"Cupid's last position was {pos}.");
            int houseCount = 0;
            for (int i = 0; i < house.Count; i++)
            {
                if (house[i] != 0)
                {
                    houseCount++;   
                }
            }
            if (houseCount==0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {houseCount} places.");
            }
            
        }
    }
}
