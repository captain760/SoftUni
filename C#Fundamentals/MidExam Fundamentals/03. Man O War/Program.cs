using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList(); ;
            List<int> warShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input !="Retire")
            {
                string[] cmd = input.Split().ToArray();
                if (cmd[0] == "Fire")
                {
                    int index = int.Parse(cmd[1]);
                    if (IndexValidity(warShip, index))
                    {
                        warShip[index] -= int.Parse(cmd[2]);
                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (cmd[0] == "Defend")
                {
                    int index1 = int.Parse(cmd[1]);
                    int index2 = int.Parse(cmd[2]);
                    if (IndexValidity(pirateShip, index1) && IndexValidity(pirateShip, index2))
                    {
                        for (int i = index1; i <= index2; i++)
                        {
                            pirateShip[i] -= int.Parse(cmd[3]);
                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }


                    }
                }
                else if (cmd[0] == "Repair")
                {
                    int index = int.Parse(cmd[1]);
                    if (IndexValidity(pirateShip, index))
                    {
                        pirateShip[index] += int.Parse(cmd[2]);
                        if (pirateShip[index] > maxCapacity)
                        {
                            pirateShip[index] = maxCapacity;
                        }
                    }
                }
                else if (cmd[0] == "Status")
                {
                    double criticalHealth = maxCapacity / 5 * 1.0;
                    int count = 0;
                    foreach (int section in pirateShip)
                    {
                        if (section<criticalHealth)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine($"{count} sections need repair.");
                }




                input = Console.ReadLine();
            }
            int pirateShipSum = 0;
            int warShipSum = 0;
            foreach (int section in pirateShip)
            {
                pirateShipSum += section;
            }
            foreach (int section in warShip)
            {
                warShipSum += section;
            }
            Console.WriteLine($"Pirate ship status: {pirateShipSum}");
            Console.WriteLine($"Warship status: {warShipSum}");
        }

        private static bool IndexValidity(List<int> ship, int v)
        {
            
            if (v>=0 && v<ship.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
