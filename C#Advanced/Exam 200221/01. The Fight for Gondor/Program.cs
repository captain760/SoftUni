using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            int[] platesElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            var plates = new Queue<int>(platesElements);
            var orcs = new Stack<int>();
            int currWave = 0;            
            while (currWave < waves && plates.Count>0)
            {
                
                int[] orcsElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < orcsElements.Length; j++)
                {
                    orcs.Push(orcsElements[j]);
                }
                if ((currWave + 1) % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }                
                while (orcs.Count>0 && plates.Count>0)
                {
                    while (orcs.Peek()>plates.Peek())
                    {
                        orcs.Push(orcs.Pop() - plates.Dequeue());
                        if (plates.Count==0)
                        {
                            break;
                        }
                    }
                    if (plates.Count == 0)
                    {
                        break;
                    }
                    if (orcs.Peek()<plates.Peek())
                    {
                        plates.Enqueue(plates.Peek() - orcs.Pop());
                        Queue<int> tempQueue = new Queue<int>();
                        tempQueue.Enqueue(plates.ElementAt(plates.Count - 1
                            ));
                        for (int s = 1; s < plates.Count-1; s++)
                        {
                            tempQueue.Enqueue(plates.ElementAt(s));
                        }
                        plates =new Queue<int>(tempQueue);
                        if (orcs.Count==0)
                        {
                            break;
                        }
                    }
                    if (orcs.Peek()==plates.Peek())
                    {
                        orcs.Pop();
                        plates.Dequeue();
                        if (orcs.Count == 0 || plates.Count == 0)
                        {
                            break;
                        }
                    }
                }                               
                currWave++;
            }

            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            }
            if (orcs.Count > 0)
            {
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }

        }
    }
}
