using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Create a method that receives a string and a repetition number n(integer). The method should return a new string,
            //containing the initial one, repeated n times.
            string inputStr = Console.ReadLine();

            int count = int.Parse(Console.ReadLine());

            string result = RepeatString(inputStr, count);

            Console.WriteLine(result);
        }
        static string RepeatString(string str, int num)
        {
            string finalStr = "";

            for (int i = 1; i <= num; i++)
            {
                finalStr += str;
            }
            return finalStr;
        }
    }
}
