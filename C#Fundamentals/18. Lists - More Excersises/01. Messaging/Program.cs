using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            //You will be given a list of numbers and a string.For each element of the list, you must calculate the sum of its digits
            //and take the element, corresponding to that index from the text. If the index is greater than the length of the text,
            //start counting from the beginning (so that you always have a valid index). After you get that element from the text,
            //you must remove the character you have taken from it(so for the next index, the text will be with one
            //characterless).
            List<int> keysList = Console.ReadLine().Split().Select(int.Parse).ToList();
            string msg = Console.ReadLine();
            List<char> result = new List<char>();
            for (int i = 0; i < keysList.Count; i++)
            {
                int sum = 0;
                int num = keysList[i];
                while (num>0)
                {
                    int digit = num % 10;
                    sum += digit;
                    num /= 10;
                }
                while (sum>msg.Length)
                {
                    sum -= msg.Length;
                }
                result.Add(msg[sum]);
                string newMsg = "";
                for (int j = 0; j < msg.Length; j++)
                {
                    if (j != sum)
                    {
                        newMsg += msg[j].ToString();
                    }
                }
                msg = newMsg;
            }
            Console.WriteLine(string.Join("", result));
        }
    }
}
