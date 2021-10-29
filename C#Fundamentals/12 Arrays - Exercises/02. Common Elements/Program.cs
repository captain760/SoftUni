using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Create a program that prints out all common elements in two arrays. You have to compare the elements of the
            //  second array to the elements of the first.
            string[] firstArray = Console.ReadLine().Split().ToArray();
            string[] secondArray = Console.ReadLine().Split().ToArray();
            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int j = 0; j < firstArray.Length; j++)
                {
                    if (secondArray[i] == firstArray[j])
                    {
                        Console.Write(secondArray[i]+" ");
                    }
                }
            }
        }
    }
}
