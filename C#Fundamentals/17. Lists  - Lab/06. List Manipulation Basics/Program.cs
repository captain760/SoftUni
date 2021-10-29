using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads a list of integers.Then until you receive &quot; end & quot;, you will receive different commands:
            // Add { number}: add a number to the end of the list.
            // Remove { number}: remove a number from the list.
            // RemoveAt { index}: remove a number at a given index.
            // Insert { number}{ index}: insert a number at a given index.
            //Note: All the indices will be valid!
            //When you receive the & quot; end & quot; command, print the final state of the list(separated by spaces).
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] order = command.Split();
                if (order[0] == "Add")
                {
                    addProcedure(nums, int.Parse(order[1]));
                }
                else if (order[0] == "Remove")
                {
                    removeProcedure(nums, int.Parse(order[1]));
                }
                else if (order[0] == "RemoveAt")
                {
                    removeAtProcedure(nums, int.Parse(order[1]));
                }
                else if (order[0] == "Insert")
                {
                    insertProcedure(nums, int.Parse(order[1]), int.Parse(order[2]));
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",nums));
        }

        private static void insertProcedure(List<int> nums, int v1, int v2)
        {
            nums.Insert(v2, v1);
        }

        private static void removeAtProcedure(List<int> nums, int v)
        {
            nums.RemoveAt(v);
        }

        private static void removeProcedure(List<int> nums, int v)
        {
            nums.Remove(v);
        }

        private static void addProcedure(List<int> nums, int v)
        {
            nums.Add(v);
        }
    }
}
