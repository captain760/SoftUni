using System;
using System.Linq;

namespace Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < array.Length - 1; i++)
            {
                int currentMinIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        currentMinIndex = j;
                    }
                }
                int buffer = array[i];
                array[i] = array[currentMinIndex];
                array[currentMinIndex] = buffer;
            }
            Console.WriteLine(string.Join(' ', array));
        }
    }
}
