using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //A top number is an integer that holds the following properties:
            // Its sum of digits is divisible by 8, e.g. 8, 17, 88
            // Holds at least one odd digit, e.g. 232, 707, 87578
            // Some examples of top numbers are: 17, 161, 251, 4310, 123200
            //Create a program to print all top numbers in range[1…n].
            //You will receive a single integer from the console, representing the end value. 
            int limit = int.Parse(Console.ReadLine());
            for (int i = 1; i <= limit; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool IsTopNumber(int i)
        {
            string num = i.ToString();
            int sum = 0;
            bool odd = false;
            for (int j= 0; j < num.Length; j++)
            {
                sum += int.Parse(num[j].ToString());
            }
            if (sum%8!=0)
            {
                return false;
            }
            for (int j = 0; j < num.Length; j++)
            {
                if ((int.Parse(num[j].ToString())%2==1))
                {
                    odd = true;
                }
                
            }
            if (odd)
            {
                return true;
            }
            return false;
        }
    }
}
