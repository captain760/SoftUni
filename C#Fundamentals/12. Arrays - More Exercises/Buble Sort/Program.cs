using System;
using System.Linq;

namespace Buble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < array.Length - 2; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int buffer = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = buffer;
                        swapped = true;
                    }
                }
            } while (swapped);
            Console.WriteLine(string.Join(' ', array));
        }
    }
}
