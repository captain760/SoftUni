namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.Value = element;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            var sb = new StringBuilder();

            this.DfsPreOrder(this, sb, indent);

            return sb.ToString().Trim();
        }

        private void DfsPreOrder(IAbstractBinaryTree<T> tree, StringBuilder sb, int indent)
        {
            sb.Append(new string(' ', indent)).AppendLine(tree.Value.ToString());
            if (tree.LeftChild!=null)
            {
                this.DfsPreOrder(tree.LeftChild, sb, indent + 2);
            };
            if (tree.RightChild!=null)
            {
                this.DfsPreOrder(tree.RightChild, sb, indent + 2);
            }
        }

        public void ForEachInOrder(Action<T> action)
        {
            InOrderDfs(this, action);
            
        }

        private void InOrderDfs(IAbstractBinaryTree<T> binTree, Action<T> action)
        {
            if (binTree.LeftChild!=null)
            {
                InOrderDfs(binTree.LeftChild, action);
            }

            action.Invoke(binTree.Value);

            if (binTree.RightChild!=null)
            {
                InOrderDfs(binTree.RightChild, action);
            }
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();
            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.InOrder());
            }
            result.Add(this);

            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.InOrder());
            }

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();
            if (this.LeftChild != null)
            {
                result.AddRange(this.LeftChild.PostOrder());
            }
            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.PostOrder());
            }
            result.Add(this);

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();
            result.Add(this);
            if (this.LeftChild!=null)
            {
                result.AddRange(this.LeftChild.PreOrder());
            }
            if (this.RightChild != null)
            {
                result.AddRange(this.RightChild.PreOrder());
            }

            return result;
        }
    }
}
