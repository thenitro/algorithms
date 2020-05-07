using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Structure.QuadTree;
using UnityEngine;

namespace Algorithms.Structure.Tree
{
    public class BinarySearchTree<T>
    {
        public BinaryTreeNode<IComparable> Head { get; private set; }
        
        public void Print()
        {
            Console.WriteLine(PrintNode(Head));
        }

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
            var current = Head;
                
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
        
        public void Insert(IComparable value)
        {
            if (Head == null)
            {
                Head = new BinaryTreeNode<IComparable> { Value = value };
                return;
            }

            var next = Head;
            
            while (next != null)
            {
                if (Less(next.Value, value))
                {
                    if (next.Right == null)
                    {
                        next.Right = new BinaryTreeNode<IComparable> {Value = value};
                        next = null;
                    }
                    else
                    {
                        next = next.Right;
                    }
                } 
                else
                {
                    if (next.Left == null)
                    {
                        next.Left = new BinaryTreeNode<IComparable> {Value = value};
                        next = null;
                    }
                    else
                    {
                        next = next.Left;
                    }
                }
            }
        }

        public bool Has(int value)
        {
            if (Head == null)
            {
                return false;
            }

            var next = Head;

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

        public void Delete(IComparable value)
        {
            DeleteNode(Head, value);
        }

        private BinaryTreeNode<IComparable> DeleteNode(BinaryTreeNode<IComparable> node, IComparable value)
        {
            if (node == null)
            {
                return node;
            }

            if (Less(node.Value, value))
            {
                node.Left = DeleteNode(node.Left, value);
            }
            else if (Less(value, node.Value))
            {
                node.Right = DeleteNode(node.Right, value);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                } else if (node.Right == null)
                {
                    return node.Left;
                }

                node.Value = MinValue(node.Right);
                node.Right = DeleteNode(node.Right, node.Value);
            }

            return node;
        }

        private IComparable MinValue(BinaryTreeNode<IComparable> node)
        {
            var result = node.Value;

            while (node.Left != null)
            {
                result = node.Value;
                node = node.Left;
            }

            return result;
        }

        public List<IComparable> Range(IComparable a, IComparable b)
        {
            var list = new List<IComparable>();
            
            if (Less(b, a))
            {
                return list;
            }

            Range(Head, a, b, list);

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

        private bool Less(IComparable a, IComparable b)
        {
            return a.CompareTo(b) < 0;
        }
        
        private bool LessOrEquals(IComparable a, IComparable b)
        {
            return a.CompareTo(b) <= 0;
        }

        public void TraverseNode(BinaryTreeNode<IComparable> node, Action<BinaryTreeNode<IComparable>> action)
        {
            if (node == null)
            {
                return;
            }
            
            action(node);
            TraverseNode(node.Left, action);
            TraverseNode(node.Right, action);
        }
    }
}