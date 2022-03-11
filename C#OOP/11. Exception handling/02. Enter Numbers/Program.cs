using System;

namespace _02._Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[10];
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    nums[i] = ReadNumber(1, 100);
                    if (i > 0 && nums[i] <= nums[i - 1])
                    {
                        
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    if (i==0)
                    {
                        Console.WriteLine($"Your number is not in range 1 - 100!");
                        i--;
                        continue;
                    }
                    else
                    {
                        i--;
                        Console.WriteLine($"Your number is not in range {nums[i]} - 100!");
                        
                        continue;
                    }
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                    i--;
                    continue;
                }
            }
            Console.WriteLine(string.Join(", ", nums));
        }

        private static int ReadNumber(int start, int end)
        {
            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                throw new FormatException();
            }
            else if (num <= start || num >= end)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return num;
            };
        }
    }
}
