using System;
using System.Collections.Generic;

namespace Algorithms.Structure.Tree.Abstract
{
    public class AbstractBinaryTree
    {
        public BinaryTreeNode<IComparable> Root;
        
        public string PrintNode(BinaryTreeNode<IComparable> node, int tabs = 0, char lrh = 'H')
        {
            var prefix = "\n|";

            for (int i = 0; i < tabs; i++)
            {
                prefix += "--";
            }
            
            if (node == null)
            {
                return prefix + "None";
            }

            tabs++;
            
            return prefix + lrh + ": " + node.Value + "" + PrintNode(node.Left, tabs, 'L') + "" + PrintNode(node.Right, tabs, 'R');
        }
        
        public void PrintInorder()
        {
            var result = string.Empty;
            var stack = new Stack<BinaryTreeNode<IComparable>>();
            var current = Root;
                
            while (current != null || stack.Count != 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                
                result += " " + current.Value;
                current = current.Right;
            }

            Console.WriteLine("Inorder: " + result);
        }

        public List<BinaryTreeNode<IComparable>> GetLevelOrderTraversal()
        {
            var result = new List<BinaryTreeNode<IComparable>>();
            var height = CalculateHeight();
            for (var i = 1; i <= height; i++)
            {
                GetCurrentLevel(Root, i, result);
            }

            return result;
        }

        private void GetCurrentLevel(BinaryTreeNode<IComparable> node, int level, List<BinaryTreeNode<IComparable>> result)
        {
            if (node == null)
            {
                return;
            }

            if (level == 1)
            {
                result.Add(node);
                return;
            }

            if (level > 1)
            {
                GetCurrentLevel(node.Left, level - 1, result);
                GetCurrentLevel(node.Right, level - 1, result);
            }
        }

        public int CalculateHeight()
        {
            return CalculateHeight(Root);
        }

        private int CalculateHeight(BinaryTreeNode<IComparable> node)
        {
            if (node == null)
            {
                return 0;
            }

            var lHeight = CalculateHeight(node.Left);
            var rHeight = CalculateHeight(node.Right);

            return Math.Max(lHeight, rHeight) + 1;
        }
        
        public bool Has(IComparable value)
        {
            if (Root == null)
            {
                return false;
            }

            var next = Root;

            while (next != null)
            {
                if (Less(next.Value, value))
                {
                    next = next.Right;
                }
                else if (Less(value, next.Value))
                {
                    next = next.Left;
                }
                else
                {
                    return true;
                }             
            }
            
            return false;
        }
        
        public List<IComparable> Range(IComparable a, IComparable b)
        {
            var list = new List<IComparable>();
            
            if (Less(b, a))
            {
                return list;
            }

            Range(Root, a, b, list);

            return list;
        }

        private void Range(BinaryTreeNode<IComparable> node, IComparable a, IComparable b, List<IComparable> list)
        {
            if (node == null)
            {
                return;
            }

            if (LessOrEquals(a, node.Value)) Range(node.Left, a, b, list);
            if (LessOrEquals(a, node.Value) && LessOrEquals(node.Value, b)) list.Add(node.Value);
            if (LessOrEquals(node.Value, b)) Range(node.Right, a, b, list);
        }
        
        protected bool Less(IComparable a, IComparable b)
        {
            return a.CompareTo(b) < 0;
        }
        
        protected bool LessOrEquals(IComparable a, IComparable b)
        {
            return a.CompareTo(b) <= 0;
        }
    }
}