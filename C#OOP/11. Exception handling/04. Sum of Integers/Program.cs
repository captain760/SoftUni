using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Sum_of_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                    .Split();
            List<int> intList = new List<int>();
            for (int i = 0; i < elements.Length; i++)
            {
                try
                {
                    if (!long.TryParse(elements[i], out long num))
                    {
                        throw new FormatException();
                    }                    
                    if (num < int.MinValue || num > int.MaxValue)
                    {
                        throw new OverflowException();
                    }
                    intList.Add((int)num);
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{elements[i]}' is out of range!"); 
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{elements[i]}' is in wrong format!");                    
                }
                Console.WriteLine($"Element '{elements[i]}' processed - current sum: {intList.Sum()}");
            }            
                Console.WriteLine($"The total sum of all integers is: {intList.Sum()}");
        }
    }
}
