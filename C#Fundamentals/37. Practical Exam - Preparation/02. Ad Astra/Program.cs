using System;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexFood = @"(?<sep>[#|])(?<name>[A-Za-z ]+)(\k<sep>)(?<date>\d{2}\/\d{2}\/\d{2})(\k<sep>)(?<cal>\d{1,5})(\k<sep>)";
            string input = Console.ReadLine();
            MatchCollection supplies = Regex.Matches(input, regexFood);
            int totalCal = 0;
            foreach (Match food in supplies)
            {
                totalCal += int.Parse(food.Groups["cal"].Value);
            }
            int days = totalCal / 2000;
            if (true)
            {

            }
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match food in supplies)
            {
                Console.WriteLine($"Item: {food.Groups["name"].Value}, Best before: {food.Groups["date"].Value}, Nutrition: {food.Groups["cal"].Value}");
            }
        }
    }
}
