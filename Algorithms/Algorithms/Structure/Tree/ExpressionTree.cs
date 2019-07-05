using System;
using System.Collections.Generic;

namespace Algorithms.Structure.Tree
{
    public class ExpressionTree
    {
        public ExpressionTreeNode Head { get; private set; }
        
        public ExpressionTree(string postfix)
        {
            var stack = new Stack<ExpressionTreeNode>();
            
            for (var i = 0; i < postfix.Length; i++)
            {
                var node = new ExpressionTreeNode() { Value = postfix[i] };
                
                if (IsOperator(postfix[i]))
                {
                    var leftNode = stack.Count > 0 ? stack.Pop() : null;
                    var rightNode = stack.Count > 0 ? stack.Pop() : null;

                    node.Right = leftNode;
                    node.Left = rightNode;
                    
                    stack.Push(node);
                }
                else
                {
                    stack.Push(node);
                }
            }

            Head = stack.Pop();
        }

        private bool IsOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
            {
                return true;
            }

            return false;
        }

        public void PrintInorder(ExpressionTreeNode node)
        {
            if (node == null)
            {
                return;
            } 
            
            PrintInorder(node.Left);
            Console.Write(node.Value + " ");
            PrintInorder(node.Right);
        }
    }
}