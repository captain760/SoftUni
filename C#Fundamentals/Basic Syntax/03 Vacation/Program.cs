using System;

namespace _03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;
            double discount = 0;
            double total = 0;

            if (type == "Students")
            {
                if (day == "Friday")
                {
                    price = 8.45;
                }
                if (day == "Saturday")
                {
                    price = 9.8;
                }
                if (day == "Sunday")
                {
                    price = 10.46;
                }
                if (count >=30)
                {
                    discount = 0.15 * price * count;
                }
                total = (price * count) - discount;
            }
            if (type == "Business")
            {
                if (day == "Friday")
                {
                    price = 10.9;
                }
                if (day == "Saturday")
                {
                    price = 15.6;
                }
                if (day == "Sunday")
                {
                    price = 16;
                }
                if (count >= 100)
                {
                    count = count - 10;
                }
                total = price * count;
            }
            if (type == "Regular")
                {
                    if (day == "Friday")
                    {
                        price = 15;
                    }
                    if (day == "Saturday")
                    {
                        price = 20;
                    }
                    if (day == "Sunday")
                    {
                        price = 22.5;
                    }
                    if (count>=10 && count<=20)
                    {
                        discount = 0.05 * count * price;
                    }
                    total = count * price - discount;
                }
                Console.WriteLine($"Total price: {total:F2}");
            //Friday Saturday Sunday
            //Students  8.45  9.80   10.46
            //Business 10.90 15.60   16
            //Regular  15    20      22.50
            //There are also discounts based on some conditions:
            // Students – if the group is bigger than or equal to 30 people you should reduce the total price by 15 %
            // Business – if the group is bigger than or equal to 100 people 10 of them can stay for free.
            // Regular – if the group is bigger than or equal to 10 and less than or equal to 20 reduce the total price by 5 %


        }
    }
}
