using System;

namespace _07._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            //initializing
            int n = int.Parse(Console.ReadLine());
            long[][] triangle = new long[n][];
            for (long i = 0; i < n; i++)
            {
                triangle[i] = new long[i + 1];
            }
            triangle[0][0] = 1;
            //calculating
            for (long row = 1; row < n; row++)
            {
                for (long col = 0; col <= row; col++)
                {
                    if (col>0 && row!=col)
                    {
                        triangle[row][col] = triangle[row - 1][col] + triangle[row - 1][col - 1];                        
                    }
                    else
                    {                        
                        triangle[row][col] = 1; 
                    }
                }
            }
            //printing
            for (long i = 0; i < n; i++)
            {
                for (long j = 0; j < i+1; j++)
                {
                    if (j<=i)
                    {
                        Console.Write(triangle[i][j]+" ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
