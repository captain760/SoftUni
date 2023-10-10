using System;
using _02.BinarySearchTree;
using _03.MinHeap;
using _04.CookiesProblem;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(10);
            bst.Delete(10);
            bst.EachInOrder(Console.WriteLine);
        }
    }
}
