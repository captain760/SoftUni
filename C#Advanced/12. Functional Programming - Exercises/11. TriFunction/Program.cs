using System;

namespace _11._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int ln = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<string, int, bool> comparer = (n, ln) =>
              {
                  int sum = 0;
                  foreach (var letter in n)
                  {
                      sum += letter;
                  }
                  if (sum>=ln)
                  {
                      return true;
                  }
                  else
                  {
                      return false;
                  }
              };
            Func<string[], string> FirstGoodName = (x) =>
              {
                  foreach (var name in x)
                  {
                      if (comparer(name, ln))
                      {

                          return name;
                      }
                      
                  }
                  return null;
              };
            Console.WriteLine(FirstGoodName(names));
        }
    }
}
