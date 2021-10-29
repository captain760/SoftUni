using System;

namespace _07_TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayType = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int price = 0;
            if (dayType == "Weekday")
            {
                if (age>=0 && age<=18)
                {
                    price = 12;
                }
                if (age >18 && age<=64)
                {
                    price = 18;
                }
                if (age>64 && age<=122)
                {
                    price = 12;
                }
            }
            else if (dayType=="Weekend")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 15;
                }
                if (age > 18 && age <= 64)
                {
                    price = 20;
                }
                if (age > 64 && age <= 122)
                {
                    price = 15;
                }
            }
            else if (dayType == "Holiday")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 5;
                }
                if (age > 18 && age <= 64)
                {
                    price = 12;
                }
                if (age > 64 && age <= 122)
                {
                    price = 10;
                }
            }
            if (price == 0)
            {
                Console.WriteLine("Error!");
            }
            else
                Console.WriteLine(price+"$");
        }
    }
}
