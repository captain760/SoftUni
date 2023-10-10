﻿namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            BinaryTree<T> firstNode = this.FindBFS(this, first);
            BinaryTree<T> secondNode = this.FindBFS(this, second);
            if (firstNode==null || secondNode==null)
            {
                throw new InvalidOperationException();
            }
            var firstAncestors = this.FindAncestorst(firstNode);
            var secondAncestors = this.FindAncestorst(secondNode);

            return firstAncestors.Intersect(secondAncestors).First();
        }

        private List<T> FindAncestorst(BinaryTree<T> root)
        {
            var result = new List<T>();

            var current = root;
            while (current != null)
            {
                result.Add(current.Value);
                current = current.Parent;
            }

            return result;
        }

        private BinaryTree<T> FindBFS(BinaryTree<T> root, T element)
        {
            var queue = new Queue<BinaryTree<T>>();
            queue.Enqueue(root);
            while (queue.Count>0)
            {
                var currentNode = queue.Dequeue();

                if (element.Equals(currentNode.Value))
                {
                    return currentNode;
                }
                if (currentNode.LeftChild!=null)
                {
                    queue.Enqueue(currentNode.LeftChild);
                }
                if (currentNode.RightChild != null)
                {
                    queue.Enqueue(currentNode.RightChild);
                }
            }
            return null;
        }
    }
}
