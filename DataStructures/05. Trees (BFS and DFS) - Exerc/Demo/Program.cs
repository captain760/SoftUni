namespace Demo
{
    using System;
    using System.Linq;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[]
               {
                "7 19", "7 21", "7 14", "19 1", "19 12", "19 31", "14 23", "14 6"
               };

            var tree = new TreeFactory().CreateTreeFromStrings(input);

            //Console.WriteLine($"Internals: {String.Join(' ',tree.GetMiddleKeys())}");
            //Console.WriteLine(tree.GetDeepestLeftomostNode().Key);
            //Console.WriteLine($"Longest Path: {String.Join(" > ", tree.GetLongestPath())}");
            //Console.WriteLine($"Paths with Sum 27: {String.Join(" > ", tree.PathsWithGivenSum(27).Select(path=>String.Join(", ",path)))}");
            Console.WriteLine($"Subtreess with Sum 43: {String.Join(", ", tree.SubTreesWithGivenSum(43).Select(x=>x.GetAsString()))}");

        }
    }
}
