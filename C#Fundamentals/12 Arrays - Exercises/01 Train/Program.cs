using System;

namespace _01_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            //A train has an **n * *number of wagons(integer, received as input). On the next n lines, you will receive the amount
            //of people that are going to get on each wagon.Print out the number of passengers in each wagon followed by the
            //total number of passengers on the train.
            int numVagons = int.Parse(Console.ReadLine());
            int[] passengers = new int[numVagons];
            int sum = 0;
            for (int i = 0; i < numVagons; i++)
            {
                passengers[i] = int.Parse(Console.ReadLine());
                sum += passengers[i];
            }
            Console.WriteLine(string.Join(" ",passengers));
            Console.WriteLine(sum);
        }
    }
}
