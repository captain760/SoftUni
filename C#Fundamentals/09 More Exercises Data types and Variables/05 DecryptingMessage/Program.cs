using System;

namespace _05_DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string msg = "";
            for (int i = 1; i <= n; i++)
            {
                char currentSymbol = char.Parse(Console.ReadLine());
                msg += (char)((int)currentSymbol + key);
            }
            Console.WriteLine(msg);
        }
    }
}
