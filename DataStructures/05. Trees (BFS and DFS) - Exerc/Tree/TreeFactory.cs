﻿namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public TreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                var keys = line.Split(' ').Select(int.Parse).ToArray();
                var parent = keys[0];
                var child = keys[1];

                this.AddEdge(parent,child);
            }
            return this.GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!this.nodesByKey.ContainsKey(key))
            {
                this.nodesByKey.Add(key, new IntegerTree(key));
            }
            return this.nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = this.CreateNodeByKey(parent);
            var childNode = this.CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);

        }

        public IntegerTree GetRoot()
        {
            foreach(var kvp in nodesByKey)
            {
                if (kvp.Value.Parent == null)
                {
                    return kvp.Value;
                }
            }
            return null;
        }
    }
}
