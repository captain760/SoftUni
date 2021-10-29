using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            //            You On the first line, we will receive a list of wagons(integers).Each integer represents the number of passengers
            //that are currently in each wagon of a passenger train. On the next line, you will receive the max capacity of a wagon
            //represented as a single integer. Until you receive the &quot; end & quot; command, you will be receiving two types of input:
            // Add { passengers} – add a wagon to the end of the train with the given number of
            //passengers.
            // { passengers}
            //            -find a single wagon to fit all the incomming passengers(starting
            //from the first wagon).
            //In the end, print the final state of the train(all the wagons separated by a space).
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());
            string com = Console.ReadLine();
            while (com != "end")
            {
                string[] incoming = com.Split();
                if (incoming[0] == "Add")
                {
                    wagons.Add(int.Parse(incoming[1]));
                }
                else
                {
                    int passengers = int.Parse(incoming[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i]+passengers<=capacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
                          
                com = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",wagons));
        }
    }
}
