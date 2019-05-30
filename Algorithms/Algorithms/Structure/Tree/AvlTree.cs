using System;

namespace Algorithms.Structure.Tree
{
    public class AvlTree
    {
        public AvlNode Head { get; private set; }
        
        public void Print()
        {
            Console.WriteLine(PrintNode(Head));
        }

        private string PrintNode(AvlNode node, int tabs = 0)
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
                Head = new AvlNode() { Value = value };
                return;
            }

            Head = InsertNode(Head, value);
        }

        private AvlNode InsertNode(AvlNode node, int value)
        {
            if (node == null)
            {
                return new AvlNode() { Value = value };
            }
            
            if (value < node.Value)
            {
                node.Left = InsertNode(node.Left, value);
            } else if (value > node.Value)
            {
                node.Right = InsertNode(node.Right, value);
            }
            else
            {
                return node;
            }

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

            var balance = GetBalance(node);

            if (balance > 1 && value < node.Left.Value)
            {
                return RightRotate(node);
            }

            if (balance < -1 && value > node.Right.Value)
            {
                return LeftRotate(node);
            }

            if (balance > 1 && value > node.Left.Value)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            if (balance < -1 && value < node.Right.Value)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        private AvlNode RightRotate(AvlNode node)
        {
            var left = node.Left;
            var leftRight = left.Right;

            left.Right = node;
            node.Left = leftRight;

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            left.Height = Math.Max(Height(left.Left), Height(left.Right)) + 1;

            return left;
        }

        private AvlNode LeftRotate(AvlNode node)
        {
            var right = node.Right;
            var rightLeft = right.Left;

            right.Left = node;
            node.Right = rightLeft;

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            right.Height = Math.Max(Height(right.Left), Height(right.Right)) + 1;

            return right;
        }

        private int Height(AvlNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private int GetBalance(AvlNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return Height(node.Left) - Height(node.Right);
        }
    }
}