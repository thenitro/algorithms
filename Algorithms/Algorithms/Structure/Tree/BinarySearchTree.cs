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
    }
}