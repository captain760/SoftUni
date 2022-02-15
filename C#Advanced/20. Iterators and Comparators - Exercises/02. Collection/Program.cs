using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().Skip(1).ToList();
            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);
            string cmd = Console.ReadLine();
            try
            {
                while (cmd != "END")
                {
                    if (cmd == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }
                    else if (cmd == "Print")
                    {
                        listyIterator.Print();
                    }
                    else if (cmd == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }
                    else if (cmd == "PrintAll")
                    {
                        listyIterator.PrintAll();
                    }
                    cmd = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
