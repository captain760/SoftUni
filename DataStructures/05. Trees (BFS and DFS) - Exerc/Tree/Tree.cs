namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        
        private List<Tree<T>> children;
        
        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();
            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);            
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;            
        }


        public string GetAsString()
        {
            var sb = new StringBuilder();
            this.DfsAsString(sb, this, 0);
            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ',indent)
              .AppendLine(tree.Key.ToString());

            foreach (var child in tree.Children)
            {
                this.DfsAsString(sb, child, indent + 2);
            }

        }

        public List<T> GetMiddleKeys()
        {            
            return this.BfsWithKeys(tree=> tree.children.Count > 0 && tree.Parent != null)
                    .Select(tree=>tree.Key).ToList();
        }

        //BFS check for a condition(predicate)  - see GetMiddleKeys() and BfsWithKeys(Predicate<Tree<T>> predicate)

        private List<Tree<T>> BfsWithKeys(Predicate<Tree<T>> predicate)
        {
            var internals = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var currentSubtree = queue.Dequeue();
                if (predicate.Invoke(currentSubtree))
                {
                    internals.Add(currentSubtree);
                }
                foreach (var child in currentSubtree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return internals;
        }

        public IEnumerable<T> GetLeafKeys()
        {
            var leafs = new List<T>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count>0)
            {
                var currentSubtree = queue.Dequeue();
                if (currentSubtree.children.Count==0)
                {
                    leafs.Add(currentSubtree.Key);
                }
                foreach (var child in currentSubtree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return leafs;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            return this.GetDeepestNode();
        }

        private Tree<T> GetDeepestNode()
        {
            var leafs = this.BfsWithKeys(t=>t.children.Count==0);
            Tree<T> deepestLeaf = null;
            int maxDepth = 0;
            foreach (var leaf in leafs)
            {
                var depth = GetDepth(leaf);

                if (depth>maxDepth) //if most right one needed: depth>=maxDepth !!!
                {
                    maxDepth = depth;
                    deepestLeaf = leaf;
                }
            }

            return deepestLeaf;
        }

        private int GetDepth(Tree<T> leaf)
        {
            int depth = 0;
            var tree = leaf;
            while (tree.Parent!=null)
            {
                depth++;
                tree = tree.Parent;
            }
            return depth;
        }

        //private List<Tree<T>> DfsWithKeys(Predicate<Tree<T>> predicate)
        //{
        //    var node = this;
        //    var result = new List<Tree<T>>();
        //    foreach (var child in node.children)
        //    {
        //        node.DfsWithKeys(predicate.Invoke());
        //        result.Add(child);
        //    }
        //    return result;
        //}

        public List<T> GetLongestPath()
        {
            var longestPath = new List<T>();
            var deepestNode = this.GetDeepestLeftomostNode();
            while (deepestNode!=null)
            {
                longestPath.Add(deepestNode.Key);
                deepestNode = deepestNode.Parent;
            }
            longestPath.Reverse();
            return longestPath;
        }

    }
}
