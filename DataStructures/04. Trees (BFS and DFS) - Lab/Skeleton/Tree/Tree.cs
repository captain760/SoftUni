namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private List<Tree<T>> children;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindNodeWithBFS(parentKey);
            if (parentNode == null)
            {
                throw new ArgumentNullException();
            }
            parentNode.children.Add(child);
            child.parent = parentNode;   

        }

        private Tree<T> FindNodeWithBFS(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                if (subtree.value.Equals(parentKey))
                {
                    return subtree;
                }

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
        }

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();

            queue.Enqueue(this);
            while (queue.Count>0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.value);

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var list = new List<T>();
            this.Dfs(this, list);
            return list;
        }

        private void Dfs(Tree<T> node, List<T> result)
        {
            foreach(var child in node.children)
            {
               this.Dfs(child, result);
            }
            result.Add(node.value);
        }

        public void RemoveNode(T nodeKey)
        {
            var toDeleteNode = this.FindNodeWithBFS(nodeKey);
            if (toDeleteNode == null)
            {
                throw new ArgumentNullException();
            }
            var parentNode = toDeleteNode.parent;
            if (toDeleteNode.parent==null)
            {
                throw new ArgumentException();
            }
            parentNode.children.Remove(toDeleteNode);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindNodeWithBFS(firstKey);
            var secondNode = this.FindNodeWithBFS(secondKey);
            if (firstNode == null || secondNode==null)
            {
                throw new ArgumentNullException();
            }
            var firstParent = firstNode.parent;
            var secondParent = secondNode.parent;

            if (firstNode.parent==null || secondNode.parent==null)
            {
                throw new ArgumentException();
            }
            var indexOfFirstNode = firstParent.children.IndexOf(firstNode);
            var indexOfSecondNode = secondParent.children.IndexOf(secondNode);

            firstParent.children[indexOfFirstNode] = secondNode;
            secondParent.children[indexOfSecondNode] = firstNode;
        }
    }
}
