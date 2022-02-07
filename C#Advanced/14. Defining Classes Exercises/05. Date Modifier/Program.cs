using System;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();
            DateModifier date = new DateModifier(firstString, secondString);
            Console.WriteLine(Math.Abs(date.DaysCalc(firstString, secondString).Days));
        }
    }
}
