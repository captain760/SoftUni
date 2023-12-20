using System;
using AVLTree;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var tree = new AVL<int>();
            tree.Insert(10);
            tree.Insert(30);
            tree.Insert(50);

            tree.Delete(30);

            Console.WriteLine(tree.Root);
            Console.WriteLine(tree.Root.Left);
            Console.WriteLine(tree.Root.Right);
        }
    }
}
