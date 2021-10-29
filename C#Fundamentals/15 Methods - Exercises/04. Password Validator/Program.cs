using System;
using System.Linq;
namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Create a program that checks if a given password is valid.
            //The password validation rules are:
            // It should contain 6 – 10 characters(inclusive)
            // It should contain only of letters and digits
            // It should contain at least 2 digits
            //If it is not valid, for any unfulfilled rule print the corresponding message:
            // "Password must be between 6 and 10 characters"
            // "Password must consist only of letters and digits"
            // "Password must have at least 2 digits"
            string input = Console.ReadLine();
            if (ValidLength(input) == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (ValidSymbols(input) == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (ValidDigits(input)== false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (ValidLength(input) && ValidSymbols(input) && ValidDigits(input))
            {
                Console.WriteLine("Password is valid");
            }
            
        }

        private static bool ValidDigits(string input)
        {
            int digit = 0;
            foreach (char symbol in input)
            {
                if ((int)symbol > 47 && (int)symbol <58)
                {
                    digit++;
                }
            }
            if (digit>=2)
            {
                return true;
            }
            return false;
        }

        private static bool ValidSymbols(string input)
        {
            foreach  (char symbol in input)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ValidLength(string input)
        {
            if (input.Length > 5 && input.Length < 11)
            {
                return true;
            }
            return false;
        }
    }
}
