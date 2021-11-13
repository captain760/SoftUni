using System;
using System.Text;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input!="end")
            {
                StringBuilder reversed = new StringBuilder(input.Length);
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversed.Append(input[i]);
                }
                Console.WriteLine($"{input} = {reversed}");
                input = Console.ReadLine();
            }
        }
    }
}
