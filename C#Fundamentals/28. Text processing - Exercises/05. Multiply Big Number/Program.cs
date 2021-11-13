using System;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //            You are given two lines – the first one can be a really big number(0 to 10^50).The second one will be a single digit number(0 to 9). Your task is to display the product of these numbers.
            //Note: do not use the BigInteger class.
            string bigNumber = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            int transfer = 0;
            int toWrite = 0;
            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int currentFigure = int.Parse(bigNumber[i].ToString());
                int res = currentFigure * num;
                
                toWrite = (res + transfer) % 10;
                transfer = (res + transfer) / 10;
                result.Insert(0, toWrite.ToString());
                if (i==0 && transfer != 0)
                {
                    result.Insert(0, transfer.ToString());
                }
            }
            if (num !=0)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("0");
            }
            
        }
    }
}
