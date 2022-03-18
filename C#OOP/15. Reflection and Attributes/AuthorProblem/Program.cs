using System;

namespace AuthorProblem
{
    [Author("Boris")]
    public class StartUp
    {
        [Author("Boris")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
        [Author("Boris")]
        [Author("Toto")]
        public static void Hello()
        {
            Console.WriteLine("Hello!!!");
        }
    }
}
