using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that receives a singlestring and on the firstline prints all the digits, on the second – all the letters, and on the third – all the other characters. There will always be at least one digit, one letter and one other characters.
            string input = Console.ReadLine();
            StringBuilder resultDigits = new StringBuilder();
            StringBuilder resultLetters = new StringBuilder();
            StringBuilder resultOther = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                
                if (Char.IsDigit(input[i]))
                {
                    resultDigits.Append(input[i]);
                }
                else if (Char.IsLetter(input[i]))
                {
                    resultLetters.Append(input[i]);
                }
                else
                {
                    resultOther.Append(input[i]);
                }
            }
            Console.WriteLine(resultDigits);
            Console.WriteLine(resultLetters);
            Console.WriteLine(resultOther);


        }
    }
}
