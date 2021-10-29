using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //The array may be manipulated by one of the following commands
            // exchange { index} – splits the array after the given index, and exchanges the places of the two resulting
            //sub - arrays.E.g. [1, 2, 3, 4, 5] -> exchange 2 -> result:[4, 5, 1, 2, 3]
            //o If the index is outside the boundaries of the array, print " Invalid index"
            // max even/ odd – returns the INDEX of the max even / odd element ->[1, 4, 8, 2, 3] -> max odd -> print 4
            // min even/ odd – returns the INDEX of the min even / odd element ->[1, 4, 8, 2, 3] -> min even -> print 3
            //o If there are two or more equal min / max elements, return the index of the rightmost one
            //  o If a min / max even / odd element cannot be found, print " No matches"
            // first { count}
            //            even / odd – returns the first { count}
            //            elements ->[1, 8, 2, 3] -> first 2 even -> print[8, 2]
            // last { count}
            //            even / odd – returns the last { count}
            //            elements ->[1, 8, 2, 3] -> last 2 odd -> print[1, 3]
            //o If the count is greater than the array length, print " Invalid count"
            //            o If there are not enough elements to satisfy the count, print as many as you can.If there are zero
            //even / odd elements, print an empty array “[]”
            // end – stop taking input and print the final state of the array
            //Input
            // The input data should be read from the console.
            // On the first line, the initial array is received as a line of integers, separated by a single space
            // On the next lines, until the command " end " is received, you will receive the array manipulation commands
            // The input data will always be valid and in the format described.There is no need to check it explicitly.
            //Output
            // The output should be printed on the console.
            // On a separate line, print the output of the corresponding command
            // On the last line, print the final array in square brackets with its elements separated by a comma and a space
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    if ((int.Parse(command[1]) > array.Length-1) || (int.Parse(command[1])<0))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        Exchange(array,int.Parse(command[1]));
                    }
                    
                }
                else if (command[0] == "max")
                {
                    MaxOddEven(array,command[1]);
                }
                else if (command[0] == "min")
                {
                    MinOddEven(array,command[1]);
                }
                else if (command[0] == "first")
                {
                    FirstOddEven(array, command[1], command[2]);
                }
                else if (command[0] == "last")
                {
                    LastOddEven(array, command[1], command[2]);
                }

                command = Console.ReadLine().Split();
            }
            Console.Write("[");
            Console.Write(string.Join(", ",array));
            Console.Write("]");
        }

        private static void LastOddEven(int[] array, string v1, string v2)
        {
            int oddEven = 0;
            if (v2 == "odd")
            {
                oddEven = 1;
            }
            int count = int.Parse(v1);
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int[] output = new int[count];
            int initialCount = count;
            int index = 0;
            int i = array.Length-1;
            while (count >= 0 && i>=0 && index<=initialCount-1)
            {
                if (array[i] % 2 == 1 && oddEven == 1)
                {
                    output[initialCount - index-1] = array[i];
                    index++;
                    count--;
                }
                if (array[i] % 2 == 0 && oddEven == 0)
                {
                    output[initialCount - index -1] = array[i];
                    index++;
                    count--;
                }
                i--;

            }
            int cut = 0;
            for (int k = 0; k < output.Length; k++)
            {
                if (output[k] != 0)
                {
                    cut++;
                }
            }
            int[] toPrint = new int[cut];
            for (int k = cut-1; k >=0; k--)
            {
                toPrint[k] = output[output.Length - k -1];
            }
            Console.Write("[");

            Console.Write(string.Join(", ", toPrint));

            Console.WriteLine("]");

        }

        private static void FirstOddEven(int[] array, string v1, string v2)
        {
            int oddEven = 0;
            if (v2 == "odd")
            {
                oddEven = 1;
            }
            int count = int.Parse(v1);
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int[] output = new int[count];
            int index = 0;
            count--;
            int i = 0;
            while (count >= 0 && i<array.Length)
            {
                if (array[i] % 2 == 1 && oddEven == 1)
                {
                    output[index] = array[i];
                    index++;
                    count--;
                }
                if (array[i] % 2 == 0 && oddEven == 0)
                {
                    output[index] = array[i];
                    index++;
                    count--;
                }
                i++;

            }
            int cut = 0;
            for (int k = 0; k < output.Length; k++)
            {
                if (output[k] != 0)
                {
                    cut++;
                }
            }
            int[] toPrint = new int[cut];
            for (int k = 0; k < cut; k++)
            {
                toPrint[k] = output[k];
            }
            Console.Write("[");
            
                Console.Write(string.Join(", ", toPrint));
                       
            Console.WriteLine("]");

        }

        private static void MinOddEven(int[] array, string v)
        {
            int oddEven = 0;
            int minOdd = int.MaxValue;
            int minEven = int.MaxValue;
            int indexMinOdd = 0;
            int indexMinEven = 0;
            bool foundElement = false;
            if (v == "odd")
            {
                oddEven = 1;

            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 ==1 && oddEven==1)
                {
                    if (array[i] <= minOdd)
                    {
                        minOdd = array[i];
                        indexMinOdd = i;
                        foundElement = true;
                    }
                }
                else if(array[i] % 2 == 0 && oddEven == 0)
                {
                    if (array[i] <= minEven)
                    {
                        minEven = array[i];
                        indexMinEven = i;
                        foundElement = true;
                    }
                }
            }
            if (oddEven == 1 && foundElement)
            {
                Console.WriteLine(indexMinOdd);
            }
            else if (oddEven == 0 && foundElement)
            {
                Console.WriteLine(indexMinEven);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void MaxOddEven(int[] array, string v)
        {
            int oddEven = 0;
            int maxOdd = int.MinValue;
            int maxEven = int.MinValue;
            int indexMaxOdd = 0;
            int indexMaxEven = 0;
            bool foundElement = false;
            if (v == "odd")
            {
                oddEven = 1;
               
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]%2 == 1 && oddEven==1)
                {
                    if (array[i]>= maxOdd)
                    {
                        maxOdd = array[i];
                        indexMaxOdd =i;
                        foundElement = true;
                    }
                }
                else if (array[i] % 2 == 0 && oddEven == 0)
                {
                    if (array[i] >= maxEven)
                    {
                        maxEven = array[i];
                        indexMaxEven = i;
                        foundElement = true;
                    }
                }
            }
            if (oddEven ==1 && foundElement)
            {
                Console.WriteLine(indexMaxOdd);
            }
            else if(oddEven == 0 && foundElement)
            {
                Console.WriteLine(indexMaxEven);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void Exchange(int[] array, int index)
        {
            int[] exchangedArray = new int[array.Length];
            int newIndex = 0;
            for (int i = index+1; i < array.Length; i++)
            {
                exchangedArray[newIndex] = array[i];
                newIndex++;
            }
            for (int i = 0; i <= index; i++)
            {
                exchangedArray[newIndex] = array[i];
                newIndex++;
            }
            for (int i = 0; i < newIndex; i++)
            {
                array[i] = exchangedArray[i];
            }
            
         //   Console.WriteLine(string.Join(",",array));
          //  Console.WriteLine(string.Join(",",exchangedArray));
        }
    }
}
