using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            //  The first input line will hold a list of integers. Until we receive the &quot; End & quot; command, we will be given operations we
            //have to apply to the list.
            //The possible commands are:
            // Add { number} – add the given number to the end of the list
            // Insert { number} { index} – insert the number at the given index
            // Remove { index} – remove the number at the given index
            // Shift left { count} – first number becomes last. This has to be repeated the
            //specified number of times
            // Shift right { count} – last number becomes first. To be repeated the specified
            //number of times
            //Note: the index given may be outside of the bounds of the array. In that case print: &quot; Invalid index&quot;.
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string com = Console.ReadLine();
            while (com != "End")
            {
                string[] incoming = com.Split();
                if (incoming[0] == "Add")
                {
                    int number = int.Parse(incoming[1]);
                    nums.Add(number);

                }
                else if (incoming[0] == "Insert")
                {
                    int index = int.Parse(incoming[2]);
                    if (index>=0 && index < nums.Count)
                    {
                        
                        int number = int.Parse(incoming[1]);
                        nums.Insert(index, number);
                    }
                    else Console.WriteLine("Invalid index");
                    
                }
                else if (incoming[0] == "Remove")
                {
                    int index = int.Parse(incoming[1]);
                    if (index >= 0 && index < nums.Count)
                        nums.RemoveAt(index);
                    else Console.WriteLine("Invalid index");
                }
                else if (incoming[0] == "Shift")
                {
                    int count = int.Parse(incoming[2]);
                    if (incoming[1] == "left")
                    {
                        
                        for (int i = 1; i <= count; i++)
                        {
                            nums.Add(nums[0]);
                            nums.RemoveAt(0);
                        }
                                                
                    }
                    else if (incoming[1] == "right")
                    {
                        for (int i = 1; i <= count; i++)
                        {
                            nums.Insert(0, nums[nums.Count - 1]);
                            nums.RemoveAt(nums.Count - 1);
                            
                        }
                    }
                    
                }
                com = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
