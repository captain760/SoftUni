using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regexKey = @"^%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>[0-9]*\.{0,1}[0-9]+)\$";
            decimal income = 0M;
            while (input !="end of shift")
            {
                MatchCollection line = Regex.Matches(input, regexKey);
                string user = "";
                string product = "";
                int quantity = 0;
                decimal price = 0M;
                
                foreach (Match item in line)
                {
                    user = item.Groups["name"].Value;
                    product = item.Groups["product"].Value;
                    quantity = int.Parse(item.Groups["quantity"].Value);
                    price = decimal.Parse(item.Groups["price"].Value);
                }
                income += price * quantity;
                if (user!="")
                {
                    Console.WriteLine($"{user}: {product} - {price * quantity:f2}");
                }
                
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
