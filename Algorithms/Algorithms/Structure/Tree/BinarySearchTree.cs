using System;

namespace Algorithms.Structure.Tree
{
    public class BinarySearchTree
    {
        public BinaryTreeNode Head { get; private set; }
        
        public void Print()
        {
            Console.WriteLine(PrintNode(Head));
        }

        private string PrintNode(BinaryTreeNode node, int tabs = 0)
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
            
            return prefix + "V: " + node.Value + "" + PrintNode(node.Left, tabs) + "" + PrintNode(node.Right, tabs);
        }
        
        public void Insert(int value)
        {
            if (Head == null)
            {
                Head = new BinaryTreeNode {Value = value};
                return;
            }

            var next = Head;
            
            while (next != null)
            {
                if (value > next.Value)
                {
                    if (next.Right == null)
                    {
                        next.Right = new BinaryTreeNode {Value = value};
                        next = null;
                    }
                    else
                    {
                        next = next.Right;
                    }
                } else if (value < next.Value)
                {
                    if (next.Left == null)
                    {
                        next.Left = new BinaryTreeNode {Value = value};
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
                if (value > next.Value)
                {
                    next = next.Right;
                }
                else if (value < next.Value)
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

        public void Delete(int value)
        {
            DeleteNode(Head, value);
        }

        private BinaryTreeNode DeleteNode(BinaryTreeNode node, int value)
        {
            if (node == null)
            {
                return node;
            }

            if (value > node.Value)
            {
                node.Left = DeleteNode(node.Left, value);
            }
            else if (value < node.Value)
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

        private int MinValue(BinaryTreeNode node)
        {
            var result = node.Value;

            while (node.Left != null)
            {
                result = node.Value;
                node = node.Left;
            }

            return result;
        }

        public void TraverseNode(BinaryTreeNode node, Action<BinaryTreeNode> action)
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