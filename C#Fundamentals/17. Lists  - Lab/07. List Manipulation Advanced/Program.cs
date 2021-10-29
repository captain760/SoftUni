using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            //Next, we are going to implement more complicated list commands, extending the previous task. Again, read a list
            //and keep reading commands until you receive &quot; end & quot;:
            // Contains { number} – check if the list contains the number and if so - print
            //& quot; Yes & quot;, otherwise print &quot; No such number & quot;.
            // PrintEven – print all the even numbers, separated by a space.
            // PrintOdd – print all the odd numbers, separated by a space.
            // GetSum – print the sum of all the numbers.
            // Filter { condition} { number} – print all the numbers that fulfill the given
            //condition.The condition will be either &#39;&lt;&#39;, &#39;&gt;&#39;, &quot;&gt;=&quot;, &quot;&lt;=&quot;.
            //After the end command, print the list only if you have made some changes to the original list. Changes are made
            //only from the commands from the previous task.
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            bool isChanged = false;
            while (command != "end")
            {
                string[] order = command.Split();
                if (order[0] == "Contains")
                {
                    contProcedure(nums, int.Parse(order[1]));
                   
                }
                else if (order[0] == "PrintEven")
                {
                    prEvenProcedure(nums);
                }
                else if (order[0] == "PrintOdd")
                {
                    prOddProcedure(nums);
                }
                else if (order[0] == "GetSum")
                {
                    getSumProcedure(nums);
                }
                else if (order[0] == "Filter")
                {
                    filterProcedure(nums, order[1], int.Parse(order[2]));
                }
                else if (order[0] == "Add")
                {
                    addProcedure(nums, int.Parse(order[1]));
                    isChanged = true;
                }
                else if (order[0] == "Remove")
                {
                    removeProcedure(nums, int.Parse(order[1]));
                    isChanged = true;
                }
                else if (order[0] == "RemoveAt")
                {
                    removeAtProcedure(nums, int.Parse(order[1]));
                    isChanged = true;

                }
                else if (order[0] == "Insert")
                {
                    insertProcedure(nums, int.Parse(order[1]), int.Parse(order[2]));
                    isChanged = true;
                }
                command = Console.ReadLine();
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }
        private static void filterProcedure(List<int> nums, string v1, int v2)
        {
            List<int> forPrint = new List<int>();
            if (v1 == "<")
            {
                foreach (var item in nums)
                {
                    if (item < v2 )
                    {
                        forPrint.Add(item);
                    }
                }
            }
            else if(v1 == ">")
            {
                foreach (var item in nums)
                {
                    if (item > v2)
                    {
                        forPrint.Add(item);
                    }
                }
            }
            else if (v1 == "<=")
            {
                foreach (var item in nums)
                {
                    if (item <= v2)
                    {
                        forPrint.Add(item);
                    }
                }
            }
            else if (v1 == ">=")
            {
                foreach (var item in nums)
                {
                    if (item >= v2)
                    {
                        forPrint.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", forPrint));
        }
        private static void getSumProcedure(List<int> nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                sum += nums[i];  
        
            }
            Console.WriteLine(sum);
        }

        private static void prOddProcedure(List<int> nums)
        {
            List<int> forPrint = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 == 1)
                {
                    forPrint.Add(nums[i]);
                }
            }
            Console.WriteLine(string.Join(" ", forPrint));
        }

        private static void prEvenProcedure(List<int> nums)
        {
            List<int> forPrint = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i]%2 == 0)
                {
                    forPrint.Add(nums[i]);
                }
            }
            Console.WriteLine(string.Join(" ",forPrint));
        }

        private static void contProcedure(List<int> nums, int v)
        {
            if (nums.Contains(v))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
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
