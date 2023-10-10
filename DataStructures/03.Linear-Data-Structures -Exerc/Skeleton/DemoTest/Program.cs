using Problem03.ReversedList;

namespace DemoTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var revList = new ReversedList<int>();
            revList.Add(1);
            revList.Add(2);
            revList.Add(3);
            revList.Add(4);
            revList.Add(5);
            revList.Insert(1,99);
            Console.WriteLine(String.Join(",", revList));
        }
    }
}