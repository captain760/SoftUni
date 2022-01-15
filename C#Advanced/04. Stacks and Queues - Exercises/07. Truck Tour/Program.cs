using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int fuelPumps = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();


            for (int i = 0; i < fuelPumps; i++)
            {
                int[] fuelDist = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(fuelDist);

            }
            int index = 0;
            bool isSuccess = false;
            while (index < fuelPumps)
            {

                int j = 0;
                int accumFuel = queue.Peek()[0];
                foreach (var item in queue)
                {



                    if (accumFuel < item[0])
                    {
                        int[] temp = queue.Dequeue();
                        queue.Enqueue(temp);
                        break;
                    }
                    else
                    {
                        j++;
                        accumFuel += item[0];
                        accumFuel -= item[1];
                    }
                    if (j == fuelPumps - 1)
                    {
                        Console.WriteLine(index);
                        isSuccess = true;
                        break;
                    }
                }
                if (isSuccess)
                {
                    break;
                }
                index++;

            }
        }
    }
}
