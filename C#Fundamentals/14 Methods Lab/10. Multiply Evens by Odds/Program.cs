using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a program that multiplies the sum of all even digits of a number by the sum of all odd digits of the same number:
            // Create a method called GetMultipleOfEvenAndOdds()
            // Create a method GetSumOfEvenDigits()
            // Create GetSumOfOddDigits()
            // You may need to use Math.Abs() for negative numbers
            string num = Console.ReadLine();
            int oddSum = GetSumOfOddDigits(GetMultipleOfEvenAndOdds(num));
            int evenSum = GetSumOfEvenDigits(GetMultipleOfEvenAndOdds(num));
            Console.WriteLine(oddSum*evenSum);
        }
        static string GetMultipleOfEvenAndOdds(string num)
        {
            string separatedNum = "";
            if (num[0].ToString() == "-")
            {
                for (int i = 1; i < num.Length; i++)
                {
                    separatedNum += num[i];
                }
            }
            else
            {
                for (int i = 0; i < num.Length; i++)
                {
                    separatedNum += num[i];
                }
            }
            return separatedNum;
        }
        static int GetSumOfEvenDigits(string num)
        {
            int sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (int.Parse(num[i].ToString())%2==0)
                {
                    sum += int.Parse(num[i].ToString());
                }
            }
            return sum;
        }
        static int GetSumOfOddDigits(string n)
        {
            int oddSum = 0;
            for (int i = 0; i < n.Length; i++)
            {
                if (int.Parse(n[i].ToString()) % 2 != 0)
                {
                    oddSum += int.Parse(n[i].ToString());
                }
            }
            return oddSum;
        }
    }
}
