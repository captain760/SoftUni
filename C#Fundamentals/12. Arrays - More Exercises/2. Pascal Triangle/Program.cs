using System;

namespace _2._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            // The triangle may be constructed in the following manner: In row 0(the topmost row), there is a unique nonzero
            //entry 1.Each entry of each subsequent row is constructed by adding the number above and to the left with the
            //number above and to the right, treating blank entries as 0.For example, the initial number in the first(or any other)
            //row is 1(the sum of 0 and 1), whereas the numbers 1 and 3 in the third row are added to produce the number 4 in
            //the fourth row.Print each row element separated with whitespace.
            int height = int.Parse(Console.ReadLine());
            int[,] array = new int[height, height];
            array[0, 0] = 1;
            Console.WriteLine("1");
            for (int i = 1; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    if (j == 0)
                    {
                        array[i, j] = array[i - 1, j];
                    }
                    else
                    {
                        array[i, j] = array[i - 1, j] + array[i - 1, j - 1];
                    }
                    if (array[i, j] != 0)
                    {
                        Console.Write(array[i, j] + " ");
                    }

                }
                Console.WriteLine();
            }

        }
    }
}
