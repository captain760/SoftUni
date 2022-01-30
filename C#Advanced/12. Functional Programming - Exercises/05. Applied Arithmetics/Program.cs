using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string cmd = Console.ReadLine();
            Func<int[], int[]> add1 = num => num.Select(n => n + 1).ToArray();
            Func<int[], int[]> multiplyBy2 = num => num.Select(n => n*2).ToArray();
            Func<int[], int[]> subtract1 = num => num.Select(n => n - 1).ToArray();
            Action<int[]> print = num => Console.WriteLine(string.Join(" ",num));
            while (cmd!="end")
            {
                switch (cmd)
                {
                    case "add":
                        numbers = add1(numbers);
                        break;
                    case "multiply":
                        numbers = multiplyBy2(numbers);
                        break;
                    case "subtract":
                        numbers = subtract1(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
                cmd = Console.ReadLine();
            }
            
        }
    }
}
