using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rList = new RandomList();
            rList.Add("11");
            rList.Add("12");
            rList.Add("13");
            rList.Add("14");
            rList.Add("15");
            Console.WriteLine(string.Join(", ",rList));
            Console.WriteLine(rList.RandomString());
            Console.WriteLine(string.Join(", ", rList));
        }
    }
}
