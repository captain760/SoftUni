using System;

namespace _00._Longest_Palindrome_Sub_List
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
           
            int maxLengthOdd = 1;
            int maxLengthPair = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int j = 1;
                int currLength = 1;
                while (i-j>=0 && i+j<input.Length)
                {
                    if (input[i-j] == input [i+j])
                    {
                        currLength += 2;
                        if (currLength>maxLengthOdd)
                        {
                            maxLengthOdd = currLength;
                        }
                        
                        j++;
                    }
                    else
                    {
                         break;
                    }
                }
            }
            for (int i = 0; i < input.Length-1; i++)
            {
                int j = 0;
                if (input[i] == input[i + 1])
                {
                    int currLength = 0;

                    while (i - j >= 0 && i + j + 1 < input.Length)
                    {
                        if (input[i - j] == input[i + 1 + j])
                        {
                            currLength += 2;
                            if (currLength > maxLengthPair)
                            {
                                maxLengthPair = currLength;
                            }
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(Math.Max(maxLengthOdd, maxLengthPair));
        }
    }
}
