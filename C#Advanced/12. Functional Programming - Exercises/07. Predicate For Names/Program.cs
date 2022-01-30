using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int reqLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split().ToArray();
            Func<string,int,string> isShorterOrEqual = (n,x) => n.Length<=x?n:null;
            foreach (var name in names)
            {
                Console.WriteLine(String.Join(Environment.NewLine,isShorterOrEqual(name,reqLength)));
            }
        }
    }
}
