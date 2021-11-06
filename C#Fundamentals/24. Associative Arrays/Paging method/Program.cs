using System;
using System.Linq;

namespace Paging_method
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[100];
            for (int i = 0; i < 100; i++)
            {
                int num = i;
                numbers[i] = num;
            }
            int page = int.Parse(Console.ReadLine());
            int countsPerPage = 10;
            Console.WriteLine(string.Join(" ",numbers.Where(x=>x>(page-1)*countsPerPage).Take(countsPerPage)));
        }
    }
}
