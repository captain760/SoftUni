using System;

namespace _09_SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int days = 0;
            int saved = 0;
            if (yield >= 100)
            {


                
                while (yield >= 100)
                {
                    days++;
                    saved += yield - 26;
                    yield -= 10;

                }
                saved -= 26;
            }
            Console.WriteLine(days);
            Console.WriteLine(saved);
        }
    }
}
