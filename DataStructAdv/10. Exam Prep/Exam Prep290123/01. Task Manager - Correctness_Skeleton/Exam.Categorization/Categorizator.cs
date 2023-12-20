using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Exam.Categorization
{
    public class Categorizator : ICategorizator
    {
        private class Node
        {
            public Category Value { get; set; }
            public Node Parent { get; set; }
            public List<Node> Children { get; set; }

            public Node(Category value)
            {
                this.Value = value;
                this.Children = new List<Node>();
            }
        }        
        private Dictionary<string, Node> nodesByCatId = new Dictionary<string, Node>();        

        public void AddCategory(Category category)
        {
            if (nodesByCatId.ContainsKey(category.Id))
            {
                throw new ArgumentException();
            }
            Node node = new Node(category);
            nodesByCatId[category.Id] = node;
        }

        public void AssignParent(string childCategoryId, string parentCategoryId)
        {
            if (!nodesByCatId.ContainsKey(childCategoryId) || !nodesByCatId.ContainsKey(parentCategoryId))
            {
                throw new ArgumentException();
            }
            var child = nodesByCatId[childCategoryId];
            var parent = nodesByCatId[parentCategoryId];

            if (parent.Children.Contains(child))
            {
                throw new ArgumentException();
            }
            
            child.Parent = parent;
            parent.Children.Add(child);
            //finding the root
            var ancestor = parent;

            while (ancestor.Parent!=null)
            {
                ancestor = ancestor.Parent;
            }
            UpdateParentDepth(ancestor);
        }
        //dind the depth recursevly
        private int UpdateParentDepth(Node node)
        {
            if (node==null)
            {
                return 0;
            }
            int depth = 0;
            foreach (var child in node.Children)
            {
               depth = Math.Max(depth, UpdateParentDepth(child)); 
            }
            node.Value.Depth = depth+1;

            return node.Value.Depth;
        }

        public bool Contains(Category category)
        {
            return nodesByCatId.ContainsKey(category.Id);
        }

        public IEnumerable<Category> GetChildren(string categoryId)
        {
            if (!nodesByCatId.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }
            
            var children = new HashSet<Category>();
            GetAllChildren(categoryId, children);
            return children;
        }

        private void GetAllChildren(string categoryId, HashSet<Category> children)
        {
            foreach (var child in nodesByCatId[categoryId].Children)
            {
                children.Add(child.Value);
                GetAllChildren(child.Value.Id, children);
            }
        }

        public IEnumerable<Category> GetHierarchy(string categoryId)
        {
            if (!nodesByCatId.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }
            var node = nodesByCatId[categoryId];
            var parents = new List<Category>();
            while (node != null)
            {
                parents.Add(node.Value);
                node = node.Parent;
            }
            parents.Reverse();
            return parents;
        }

        public IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName()
        {
            
            var sortedCats = nodesByCatId.Values.OrderByDescending(x => x.Value.Depth).ThenBy(x=>x.Value.Name).Select(x=>x.Value).Take(3);
            return sortedCats;
        }

        

        public void RemoveCategory(string categoryId)
        {
            if (!nodesByCatId.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }
            var node = nodesByCatId[categoryId];
            
            

            RemoveChildren(categoryId);
            
            if (node.Parent != null)
            {
                node.Parent.Children.Remove(node);
            }
            nodesByCatId.Remove(categoryId);
        }

        private void RemoveChildren(string categoryId)
        {
            foreach (var child in nodesByCatId[categoryId].Children)
            {                
                RemoveChildren(child.Value.Id);
                nodesByCatId.Remove(child.Value.Id);
            }

        }

        public int Size()=>nodesByCatId.Count;
    }
}
