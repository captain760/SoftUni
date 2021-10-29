using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are going to receive two lists of numbers.Create a list that contains the numbers from both of the lists. The
            //first element should be from the first list, the second from the second list, and so on.If the length of the two lists is
            //not equal, just add the remaining elements at the end of the list.
            List<int> nums1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            int smalestCount = nums1.Count;
            int highestCount = nums2.Count;
            if (nums1.Count>=nums2.Count)
            {
                smalestCount = nums2.Count;
                highestCount = nums1.Count;
            }
            List<int> merged = new List<int>();
            for (int i = 0; i < smalestCount; i++)
            {
                
                    merged.Add(nums1[i]);
                
                    merged.Add(nums2[i]);
               
            }
            for (int i = smalestCount; i < highestCount; i++)
            {
                if (nums1.Count>=nums2.Count)
                {
                    merged.Add(nums1[i]);
                }
                else
                {
                    merged.Add(nums2[i]);
                }
                
            }
            Console.WriteLine(string.Join(" ", merged));
        }
    }
}
