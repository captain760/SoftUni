using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings ss = new CustomStack.StackOfStrings();
            List<string> someStrings = new List<string>();
            someStrings.Add("hello");
            someStrings.Add("how");
            someStrings.Add("are");
            someStrings.Add("you?");
            ss.AddRange(someStrings);
            while (ss.Count>0)
            {
                Console.WriteLine(ss.Pop());
            }
        }
    }
}
