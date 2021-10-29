using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads positive integers until you receive the " END " command. For each number, print
            //whether the number is a palindrome or not.A palindrome is a number which reads the same backward as forward,
            //such as 323 or 1001.
            string input = Console.ReadLine();
            while (input!="END")
            {
                if (IsPalindrome(input))
                {
                    Console.WriteLine(IsPalindrome(input));
                }
                else
                {
                    Console.WriteLine(IsPalindrome(input));
                }
                input = Console.ReadLine();
            }
        }

        private static bool IsPalindrome(string input)
        {
            for (int i = 0; i <= input.Length/2; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
