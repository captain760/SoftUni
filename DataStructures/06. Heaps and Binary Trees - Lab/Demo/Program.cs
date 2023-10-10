using System;
using System.Diagnostics.CodeAnalysis;
using _02.BinarySearchTree;
using _03.MaxHeap;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinarySearchTree<int>();
            binaryTree.Insert(10);
            binaryTree.Insert(12);
            binaryTree.Insert(8);
            binaryTree.EachInOrder(Console.WriteLine);
        }
    }
}