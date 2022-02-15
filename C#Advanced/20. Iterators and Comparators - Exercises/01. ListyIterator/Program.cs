using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().Skip(1).ToList();
            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);
            string cmd = Console.ReadLine();
            while (cmd!="END")
            {
                if (cmd == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (cmd =="Print")
                {
                    listyIterator.Print();
                }
                else if (cmd == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                cmd = Console.ReadLine();
            }
        }
    }
}
