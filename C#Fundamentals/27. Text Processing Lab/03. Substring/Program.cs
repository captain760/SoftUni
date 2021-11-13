using System;
using System.Text;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string input = Console.ReadLine();
            
            
            while (input.IndexOf(key)>=0)
            {
                input = input.Remove(input.IndexOf(key), key.Length);
            }
            Console.WriteLine(input);
        }
    }
}
