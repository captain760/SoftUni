using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>();
            Stack<int> plates = new Stack<int>();
            int[] guestsArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            foreach (var item in guestsArray)
            {
                guests.Enqueue(item);
            }
            int[] platesArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            foreach (var item in platesArray)
            {
                plates.Push(item);
            }
            int wastedFood = 0;

            while (guests.Count != 0 && plates.Count != 0)
            {
                if (plates.Peek() >= guests.Peek())
                {
                    wastedFood += plates.Pop() - guests.Dequeue();
                    continue;
                }
                else
                {
                    int updatedGuest = guests.Peek();
                    while (updatedGuest >= plates.Peek())
                    {
                        updatedGuest -= plates.Pop();
                        if (plates.Peek() >= updatedGuest)
                        {
                            wastedFood += plates.Pop() - updatedGuest;
                            guests.Dequeue();
                            break;
                        }
                    }
                }
            }
            if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else if (plates.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
