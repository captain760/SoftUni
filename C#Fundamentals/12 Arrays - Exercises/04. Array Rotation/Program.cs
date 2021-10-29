using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that receives an array and a number of rotations that you have to perform.The rotations are
            //done by moving the first element of the array from the front to the back. Print the resulting array.
            int[] initialArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotator = int.Parse(Console.ReadLine());
            int temp;
            for (int i = 0; i < rotator; i++)
            {
                temp = initialArray[0];
                for (int j = 0; j < initialArray.Length-1; j++)
                {
                    initialArray[j] = initialArray[j + 1];
                }
                initialArray[initialArray.Length - 1] = temp;
            }
            Console.WriteLine(string.Join(" ", initialArray));
        }
    }
}
