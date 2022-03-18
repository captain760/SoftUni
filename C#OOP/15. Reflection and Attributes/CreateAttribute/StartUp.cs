using System;

namespace AuthorProblem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Hello();
        }
        [Author("Boris")]
        public static void Hello()
        {
            Console.WriteLine("Hello!!!");
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple =true)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
