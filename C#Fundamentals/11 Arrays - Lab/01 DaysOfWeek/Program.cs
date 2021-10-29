using System;

namespace _01_DaysOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Enter a number in range 1 - 7 and print out the word representing it or 'Invalid Day'. Use an array of strings.
            string[] weekDays = new string[] { "Monday","Tuesday","Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int n = int.Parse(Console.ReadLine());
            if (n>0 && n<8)
            {
                Console.WriteLine(weekDays[n - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
