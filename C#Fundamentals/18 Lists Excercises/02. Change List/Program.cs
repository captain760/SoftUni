using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Create a program, that reads a list of integers from the console and receives commands to manipulate the list.
            //Your program may receive the following commands:
            // Delete { element} – delete all elements in the array, which are equal to the given
            //element.
            // Insert { element}
            //            { position} – insert the element at the given position.
            //You should exit the program when you receive the & quot; end & quot; command.Print all numbers in the array separated by a
            //   single whitespace.
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            string com = Console.ReadLine();
            while (com != "end")
            {
                string[] incoming = com.Split();
                if (incoming[0] == "Delete")
                {
                    int toRemove = int.Parse(incoming[1]);
                        nums.RemoveAll(el => el == toRemove);
                    
                }
                else
                {
                    int index = int.Parse(incoming[2]);
                    int element = int.Parse(incoming[1]);
                    nums.Insert(index, element);
                }

                com = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
