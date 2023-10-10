namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public List<List<int>> PathsWithGivenSum(int sum)
        {
            var neededPaths = new List<List<int>>();
            var currentPath = new LinkedList<int>();
            currentPath.AddFirst(this.Key);
            var currentSum = this.Key;
            this.Dfs(this, neededPaths, currentPath, ref currentSum, sum);

            return neededPaths;
        }

        private void Dfs(
            Tree<int> subtree,
            List<List<int>> neededPaths,
            LinkedList<int> currentPath,
            ref int currentSum,
            int neededSum)
        {
            foreach (var child in subtree.Children)
            {
                currentSum += child.Key;
                currentPath.AddLast(child.Key);
                this.Dfs(child, neededPaths, currentPath, ref currentSum, neededSum);
            }
            if (currentSum == neededSum)
            {
                neededPaths.Add(new List<int> (currentPath));
            }

            currentSum-=subtree.Key;
            currentPath.RemoveLast();
        }

        public List<Tree<int>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<int>> subtrees = new List<Tree<int>>();
            Queue<Tree<int>> queue = new Queue<Tree<int>>(new[] { this });

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                int currentSum = 0;
                Queue<Tree<int>> subQueue = new Queue<Tree<int>>(new[] {node});

                while (subQueue.Count > 0)
                {
                    var subElement = subQueue.Dequeue();
                    currentSum += subElement.Key;

                    foreach (var subChild in subElement.Children)
                    {
                        subQueue.Enqueue(subChild);
                    }
                }

                if (currentSum == sum)
                {
                    subtrees.Add(node);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return subtrees;
        }

    }
}
