using System;

namespace _12_RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int currentNumber = 1; currentNumber <= num; currentNumber++)

            {
                int local = currentNumber;
                int sum = 0;
                while (local > 0)

                {

                    sum += local % 10;

                    local = local / 10;

                }

                bool isSpecial = (sum == 5) || (sum == 7) || (sum == 11);

                Console.WriteLine("{0} -> {1}", currentNumber, isSpecial);

                
            }
        }
    }
}
