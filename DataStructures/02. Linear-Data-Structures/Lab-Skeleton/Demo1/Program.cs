namespace Demo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            list.Insert(0, 345);
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}