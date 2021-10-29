using System;

namespace Momchi_thing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"the squire is: IDK");
            Console.WriteLine($"HOW DID YOU ECPECT ME TO TELL YOU???!!");
            string str = Console.ReadLine();
            if (str == "idk" || str == "IDK" || str == "IDK!")
            {
                Console.WriteLine("UMMM!! UMM!!");

            }
            
            else if (str == "ok" || str == "OK" || str == "OK!")
            {
                Console.WriteLine("What \"ok\" means?");
            }
            else if (int.Parse(str) > 0 && int.Parse(str) < 1000)
            {
                Console.WriteLine("What is that answer?");
                Console.WriteLine("WHAT DID THAT MEAN?! I AM A COMPUTER!");
            }
        }
    }
}
