using System;

namespace _02_FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            for (int i = 0; i < rows; i++)
            {
                string inputString = Console.ReadLine();
                int length = inputString.Length;
                int spacePosition = 0;
                string leftString = "";
                string rightString = "";
                int leftSum = 0;
                int rightSum = 0;
                for (int j = 0; j < length; j++)
                {
                    if (inputString[j] == ' ')
                    {
                        spacePosition = j;
                    }
                }
                for (int l = 0; l < spacePosition; l++)
                {
                    leftString += inputString[l];
                    if (inputString[l] != '-')
                    {


                        leftSum += int.Parse(inputString[l].ToString());
                    }
                }
                for (int k = spacePosition+1; k < length; k++)
                {
                    rightString += inputString[k];
                    if (inputString[k] !='-')
                    {


                        rightSum += int.Parse(inputString[k].ToString());
                    }
                }
                long leftNum = long.Parse(leftString);
                long rightNum = long.Parse(rightString);
                if (leftNum>=rightNum)
                {
                    Console.WriteLine(leftSum);
                }
                else
                {
                    Console.WriteLine(rightSum);
                }
            }
        }
    }
}
