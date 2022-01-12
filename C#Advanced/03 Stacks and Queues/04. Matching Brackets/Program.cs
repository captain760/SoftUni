using System;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> openingBracketIndex = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openingBracketIndex.Push(i);
                }
                if (expression[i] == ')')
                {
                    int startIndex = openingBracketIndex.Pop();
                    int endIndex = i;
                    Console.WriteLine(expression.Substring(startIndex,endIndex-startIndex+1));
                }
            }
            
        }
    }
}
