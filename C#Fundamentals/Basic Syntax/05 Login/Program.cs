using System;

namespace _05_Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string pass = Console.ReadLine();
            string ssap="";
            int count = 1;
            int l = 0;
            l = user.Length;
            for (int i = l-1; i >= 0; i--)
            {
                ssap += user[i];
            }
             // Console.WriteLine(ssap);
            while (pass != ssap && count < 4)
            {
                Console.WriteLine("Incorrect password. Try again.");
                count++;
                pass = Console.ReadLine();
            }
            if (count == 4)
            {
                Console.WriteLine($"User {user} blocked!");
            }
            if (pass == ssap)
            {
                Console.WriteLine($"User {user} logged in.");
            }
        }
    }
}
