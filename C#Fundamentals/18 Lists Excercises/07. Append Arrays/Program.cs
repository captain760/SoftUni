using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Create a program to append several arrays of numbers one after another.
            // Arrays are separated by &#39;|&#39;
            // Their Values are separated by spaces(&#39; &#39;, one or several)
            // Take all arrays starting from the rightmost and going to the left and place them in a new array in that order
            string input = Console.ReadLine();
            
            input = input.Replace(" ", String.Empty);
            
            List<string> firstList = input.Split("|",StringSplitOptions.RemoveEmptyEntries).ToList();
            //Console.WriteLine(string.Join(" ", firstList));
            firstList.Reverse();
            for (int i = 0; i < firstList.Count; i++)
            {
                
                for (int j = 1; j < firstList[i].Length; j++)
                {
                    firstList[i] = firstList[i].Insert(j, " ");
                    j++;
                }
                
            }
            
            Console.WriteLine(string.Join(" ",firstList));
        }
    }
}
