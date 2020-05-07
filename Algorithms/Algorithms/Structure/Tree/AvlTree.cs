using System;
using System.Dynamic;

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

        public AvlNode DeleteNode(AvlNode root, int key)
        {
            if (root == null)
            {
                return root;
            }

            if (key < root.Value)
            {
                root.Left = DeleteNode(root.Left, key);
            } else if (key > root.Value)
            {
                root.Right = DeleteNode(root.Right, key);
            }
            else
            {
                if (root.Left == null || root.Right == null)
                {
                    AvlNode temp = null;

                    if (temp == root.Left)
                    {
                        temp = root.Right;
                    }
                    else
                    {
                        temp = root.Left;
                    }

                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else
                    {
                        root = temp;
                    }
                }
                else
                {
                    var temp = MinValueNode(root.Right);
                    root.Value = temp.Value;
                    root.Right = DeleteNode(root.Right, temp.Value);
                }
            }

            if (root == null)
            {
                return root;
            }

            root.Height = Math.Max(Height(root.Left), Height(root.Right)) + 1;

            var balance = GetBalance(root);

            if (balance > 1 && GetBalance(root.Left) >= 0)
            {
                return RightRotate(root);
            }

            if (balance > 1 && GetBalance(root.Left) < 0)
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }

            if (balance < -1 && GetBalance(root.Right) <= 0)
            {
                return LeftRotate(root);
            }

            if (balance < -1 && GetBalance(root.Right) > 0)
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }

            return root;
        }

        private AvlNode MinValueNode(AvlNode node)
        {
            var current = node;
            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
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