using System;

namespace _06_BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            bool isBalanced = true;
            bool cicleClosed = false;
            int leftP = 0;
            int rightP = 0;
            for (int i = 1; i <= rows; i++)
            {
                string currentRowString = Console.ReadLine();
                
               
                if (currentRowString == "(")
                {
                    leftP += 1;
                    cicleClosed = false;
                }
                if (currentRowString == ")")
                {
                    rightP -= 1;
                    cicleClosed = true;

                }
                if ((rightP+leftP) < 0 || (Math.Abs(leftP+rightP)>1 || leftP>1 || rightP<-1)||(leftP!=(-rightP) && i==rows))
                {
                    isBalanced = false;
                    
                }
                if (cicleClosed && leftP == 1)
                {
                    leftP = 0;
                    rightP = 0;
                }
                
            }
            if (isBalanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
