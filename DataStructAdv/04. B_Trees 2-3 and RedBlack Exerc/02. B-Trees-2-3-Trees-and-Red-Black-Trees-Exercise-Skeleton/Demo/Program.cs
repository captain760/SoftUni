using System;
using _01.RedBlackTree;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            RedBlackTree<int> rbt = new RedBlackTree<int>();

            rbt.Insert(10);
            rbt.Insert(5);
            rbt.Insert(3);
            rbt.Insert(1);
            rbt.Insert(4);
            rbt.Insert(8);
            rbt.Insert(9);
            rbt.Insert(37);
            rbt.Insert(39);
            rbt.Insert(45);

            // Act
            int actualCount = rbt.Count();
            Console.WriteLine(actualCount);
        }
    }
}
