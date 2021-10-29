using System;

namespace _1._Encrypt_Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Write a program that reads a sequence of strings from the console. Encrypt every string by summing:
            //   The code of each vowel multiplied by the string length
            //   The code of each consonant divided by the string length
            //  Sort the number sequence in ascending order and print it on the console.
            //  On the first line, you will always receive the number of strings you have to read.
            int stringNums = int.Parse(Console.ReadLine());
            string[][] initString = new string[stringNums][];
            for (int i = 0; i < stringNums; i++)
            {
                string newWord = Console.ReadLine();
                int sum = 0;
                initString[i] = new string[newWord.Length + 1];
                for (int j = 1; j <= newWord.Length; j++)
                {
                    initString[i][j] = newWord[j - 1].ToString();
                    switch (initString[i][j])
                    {
                        case "a":
                        case "o":
                        case "i":
                        case "u":
                        case "e":
                        case "A":
                        case "O":
                        case "I":
                        case "U":
                        case "E":
                            //case "y":
                            {
                                sum += (int)newWord[j - 1] * newWord.Length;
                                break;
                            }
                        //case "b":
                        //case "c":
                        //case "d":
                        //case "f":
                        //case "g":
                        //case "h":
                        //case "j":
                        //case "k":
                        //case "l":
                        //case "m":
                        //case "n":
                        //case "p":
                        //case "q":
                        //case "r":
                        //case "s":
                        //case "t":
                        //case "v":
                        //case "w":
                        //case "x":
                        //case "y":
                        //case "z":
                        //case "B":
                        //case "C":
                        //case "D":
                        //case "F":
                        //case "G":
                        //case "H":
                        //case "J":
                        //case "K":
                        //case "L":
                        //case "M":
                        //case "N":
                        //case "P":
                        //case "Q":
                        //case "R":
                        //case "S":
                        //case "T":
                        //case "V":
                        //case "W":
                        //case "X":
                        //case "Y":
                        //case "Z":
                        default:
                            {
                                sum += (int)newWord[j - 1] / newWord.Length;
                                break;
                            }
                            //default:
                            //    break;
                    }
                }
                initString[i][0] = sum.ToString();
            }
            int[] sortedArray = new int[stringNums];
            for (int i = 0; i < stringNums; i++)
            {
                sortedArray[i] = int.Parse(initString[i][0]);
            }
            for (int i = 0; i < stringNums - 1; i++)
            {
                for (int j = i + 1; j < stringNums; j++)
                {
                    if (sortedArray[i] > sortedArray[j])
                    {
                        int temp = sortedArray[i];
                        sortedArray[i] = sortedArray[j];
                        sortedArray[j] = temp;
                    }
                }
            }
            for (int i = 0; i < stringNums; i++)
            {
                //Console.WriteLine(string.Join(' ', initString[i]));
                Console.WriteLine(sortedArray[i]);
            }

        }
    }
}
