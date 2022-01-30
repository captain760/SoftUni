using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int devisor = int.Parse(Console.ReadLine());
            Func<int[], int[]> reverse = n => n.Reverse().ToArray();
            List<int> reversedList = new List<int>(reverse(numbers));
            Func<List<int>, int, List<int>> excludedDevisor = (n, x) => n.Where(y => y%x !=0).ToList();
            List<int> exclusionList = new List<int>(excludedDevisor(reversedList, devisor));
            Console.WriteLine(string.Join(" ",exclusionList));
        }
    }
}
