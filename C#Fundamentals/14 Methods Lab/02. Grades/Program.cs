using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a method that receives a grade between 2.00 and 6.00 and prints the corresponding grade definition:
            // 2.00 – 2.99 - &quot; Fail & quot;
            // 3.00 – 3.49 - &quot; Poor & quot;
            // 3.50 – 4.49 - &quot; Good & quot;
            // 4.50 – 5.49 - &quot; Very good&quot;
            // 5.50 – 6.00 - &quot; Excellent & quot;
            double mark = double.Parse(Console.ReadLine());
            Console.WriteLine(MarkInWords(mark));
        }
        static string MarkInWords(double mark)
        {
            string word ="";
            if (mark>=2 && mark<=2.99)
            {
                word = "Fail";
            }
            else if (mark >= 3 && mark <= 3.49)
            {
                word = "Poor";
            }
            else if (mark >= 3.5 && mark <= 4.49)
            {
                word = "Good";
            }
            else if (mark >= 4.50 && mark <= 5.49)
            {
                word = "Very good";
            }
            else if (mark >= 5.5 && mark <= 6)
            {
                word = "Excellent";
            }
            return word;
        }
    }
}
