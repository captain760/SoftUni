using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> parkingLot = new HashSet<string>();
            while (input!="END")
            {
                string[] cmd = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string direction = cmd[0];
                string carNumber = cmd[1];
                if (direction == "IN")
                {
                    parkingLot.Add(carNumber);
                }
                else if(parkingLot.Contains(carNumber))
                {
                    parkingLot.Remove(carNumber);
                }
                input = Console.ReadLine();
            }

            if (parkingLot.Count>0)
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}
