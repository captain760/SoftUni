namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length%2 == 1)
            {
                return false;
            }  
            var bufer = new Stack<char>(parentheses.Length/2);
            for (int i = 0; i < parentheses.Length; i++)
            {
                char currentChar = parentheses[i];
                char expectedChar = default;
                switch (currentChar)

                {
                    case ')':
                        expectedChar = '(';
                        break;
                    case '}':
                        expectedChar = '{';
                        break;
                    case ']':
                        expectedChar = '[';
                        break;
                    default:
                        bufer.Push(currentChar);
                        break;
                }
                if (expectedChar == default) 
                {
                    continue;
                }
                if (bufer.Pop()!=expectedChar)
                {
                    return false;
                }
                
            }

            return bufer.Count == 0;
        }
    }
}
