using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> ravni = new EqualityScale<int>(4,4);
            Console.WriteLine(ravni.AreEqual());
        }
    }
}
