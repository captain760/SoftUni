using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Santa_s_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> houses = Console.ReadLine().Split().Select(int.Parse).ToList();
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] token = input.Split();
                if (token[0] == "Forward")
                {
                    int steps = int.Parse(token[1]);
                    index += steps;
                    if ( IsIndexValid(houses, index))
                    {
                        houses.RemoveAt(index);
                    }
                    else
                    {
                        index -= steps;
                    }
                    
                    
                }
                else if (token[0] == "Back")
                {
                    int steps = int.Parse(token[1]);
                    index -= steps;
                    if (IsIndexValid(houses, index))
                    {
                        houses.RemoveAt(index);
                    }
                    else
                    {
                        index += steps;
                    }
                    
                }
                else if (token[0] == "Gift")
                {
                    int givenIndex = int.Parse(token[1]);
                    int houseNumber = int.Parse(token[2]);
                    if (IsIndexValid(houses, givenIndex))
                    {
                        houses.Insert(givenIndex, houseNumber);
                        index = givenIndex;
                    }
                    
                    
                }
                else if (token[0] == "Swap")
                {
                    int indexFirst = houses.IndexOf(int.Parse(token[1]));
                    int indexSecond = houses.IndexOf(int.Parse(token[2]));
                    if (IsIndexValid(houses,indexFirst) && IsIndexValid(houses,indexSecond))
                    {
                        int temp = houses[indexFirst];
                        houses[indexFirst] = houses[indexSecond];
                        houses[indexSecond] = temp;
                    }
                    
                }
            }
            Console.WriteLine($"Position: {index}");
            Console.WriteLine(string.Join(", ",houses));
        }

        private static bool IsIndexValid(List<int> houses, int index)
        {
            if (index>=0 && index< houses.Count)
            {
                return true;
            }
            return false;
        }
    }
}
