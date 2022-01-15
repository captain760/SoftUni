using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenTime = int.Parse(Console.ReadLine());
            int freeTime = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int passedCars = 0;
            Queue<string> queue = new Queue<string>();
            while (input != "END")
            {
                if (input == "green")
                {
                    int currentGreen = greenTime;
                    while (queue.Count > 0 )
                    {

                        if (queue.Peek().Length <= currentGreen)
                        {
                            currentGreen -= queue.Dequeue().Length;
                            passedCars++;
                        }
                        else if (queue.Peek().Length <= currentGreen + freeTime && currentGreen>0)
                        {
                            queue.Dequeue();
                            passedCars++;
                            break;
                        }
                        else
                        {
                            if (currentGreen<=0)
                            {
                                break;
                            }
                            int hitAtIndex = currentGreen + freeTime;
                            char hitAtSymbol = queue.Peek()[hitAtIndex];
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{queue.Peek()} was hit at {hitAtSymbol}.");
                            return;
                        }


                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
