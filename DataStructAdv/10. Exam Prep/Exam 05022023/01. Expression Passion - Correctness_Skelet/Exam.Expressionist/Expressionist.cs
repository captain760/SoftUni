using System;
using System.Collections.Generic;

namespace Exam.Expressionist
{
    public class Expressionist : IExpressionist
    {
        private Dictionary<string,Expression> entities = new Dictionary<string,Expression>();
        private Expression root;
        public void AddExpression(Expression expression)
        {
            if (root==null)
            {
                entities[expression.Id]=expression;
                root = expression;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddExpression(Expression expression, string parentId)
        {
            if (!entities.ContainsKey(parentId))
            {
                throw new ArgumentException();
            }
            Expression parent = entities[parentId];
            if (parent.RightChild!=null) 
            {
                throw new ArgumentException();
            }
            if (parent.LeftChild==null)
            {
                parent.LeftChild = expression;
                parent.LeftChild.Parent = parent;
            }
            else 
            {
                parent.RightChild = expression;
                parent.RightChild.Parent = parent;
            }
            expression.Parent = parent;
            entities.Add(expression.Id, expression);
        }

        public bool Contains(Expression expression)
        {
            return entities.ContainsKey(expression.Id);
        }

        public int Count()=>entities.Count;

        public string Evaluate()
        {
            return InOrderEvaluate(root, "");
        }

        private string InOrderEvaluate(Expression expression, string result)
        {
            if (expression==null)
            {
                return result;
            }
            if (expression.Type == ExpressionType.Value)
            {
                result += expression.Value;
            }
            else
            {
                result += $"({InOrderEvaluate(expression.LeftChild, "")} {expression.Value} {InOrderEvaluate(expression.RightChild, "")})";
            }
            return result;
        }

        public Expression GetExpression(string expressionId)
        {
            if (!entities.ContainsKey(expressionId))
            {
                throw new ArgumentException();
            }
            return entities[expressionId];
        }

        public void RemoveExpression(string expressionId)
        {
            if (!entities.ContainsKey(expressionId))
            {
                throw new ArgumentException();
            }
            var node = entities[expressionId];
            if (node.Parent == null)
            {
                root = null;
                entities.Remove(expressionId);
            }
            if (node.Parent.LeftChild == node ) 
            {
                RemoveNodeAndChildren(node);
                
                node.Parent.LeftChild = node.Parent.RightChild;
            }
            else if(node.Parent.RightChild == node )
            {
                RemoveNodeAndChildren(node);
                
            }
            node.Parent.RightChild = null;
            
        }

        private void RemoveNodeAndChildren(Expression node)
        {
            var queue = new Queue<Expression>();
            queue.Enqueue(node);
            while (queue.Count>0) 
            {
                var currNode = queue.Dequeue();
                entities.Remove(currNode.Id);
                if (currNode.LeftChild != null)
                {
                    queue.Enqueue(currNode.LeftChild);                                       
                }
                if (currNode.RightChild != null)
                {
                    queue.Enqueue(currNode.RightChild);
                }
            }
        }
    }
}
