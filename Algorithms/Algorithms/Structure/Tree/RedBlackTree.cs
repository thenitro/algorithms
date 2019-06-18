using System;
using System.Runtime.Remoting.Messaging;
using Algorithms.Other;
using Algorithms.Structure.Queue;

namespace Algorithms.Structure.Tree
{
    public class RedBlackTree
    {
        public RedBlackTreeNode Root;

        private const bool BLACK = false;
        private const bool RED = true;

        public void Print()
        {
            Console.WriteLine(PrintNode(Root));
        }

        private string PrintNode(RedBlackTreeNode node, int tabs = 0)
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

            return prefix + "V: " + node.Data + ", c " + node.Color + "" + PrintNode(node.Left, tabs) + "" + PrintNode(node.Right, tabs);
        }

        public void Insert(int data)
        {
            var pt = new RedBlackTreeNode(data);
            Root = BtInsert(Root, pt);
            FixViolation(Root, pt);
        }

        private RedBlackTreeNode BtInsert(RedBlackTreeNode root, RedBlackTreeNode pt)
        {
            if (root == null)
            {
                return pt;
            }

            if (pt.Data < root.Data)
            {
                root.Left = BtInsert(root.Left, pt);
                root.Left.Parent = root;
            }
            else if (pt.Data > root.Data)
            {
                root.Right = BtInsert(root.Right, pt);
                root.Right.Parent = root;
            }

            return root;
        }

        private void FixViolation(RedBlackTreeNode root, RedBlackTreeNode pt)
        {
            while (pt != root && pt.Color != BLACK && pt.Parent.Color == RED)
            {
                Console.WriteLine("FixViolation " + pt.Data);
                
                var parentPt = pt.Parent;
                var grandParentPt = pt.Parent.Parent;

                if (parentPt == grandParentPt.Left)
                {
                    var unclePt = grandParentPt.Right;

                    if (unclePt != null && unclePt.Color == RED)
                    {
                        grandParentPt.Color = RED;
                        parentPt.Color = BLACK;
                        unclePt.Color = BLACK;
                        pt = grandParentPt;
                    }
                    else
                    {
                        if (pt == parentPt.Right)
                        {
                            RotateLeft(root, parentPt);
                            pt = parentPt;
                            parentPt = pt.Parent;
                        }

                        RotateRight(root, grandParentPt);

                        var tmp = parentPt.Color;
                        parentPt.Color = grandParentPt.Color;
                        grandParentPt.Color = tmp;
                        
                        pt = parentPt;
                    }
                }
                else
                {
                    var unclePt = grandParentPt.Left;
                    if (unclePt != null && unclePt.Color == RED)
                    {
                        grandParentPt.Color = RED;
                        parentPt.Color = BLACK;
                        unclePt.Color = BLACK;
                        pt = grandParentPt;
                    }
                    else
                    {
                        if (pt == parentPt.Left)
                        {
                            RotateRight(root, parentPt);
                            pt = parentPt;
                            parentPt = pt.Parent;
                        }

                        RotateLeft(root, grandParentPt);
                        
                        var tmp = parentPt.Color;
                        parentPt.Color = grandParentPt.Color;
                        grandParentPt.Color = tmp;
                        
                        pt = parentPt;
                    }
                }
            }

            root.Color = BLACK;
        }

        private void RotateLeft(RedBlackTreeNode root, RedBlackTreeNode pt)
        {
            var ptRight = pt.Right;

            pt.Right = ptRight.Left;
            if (pt.Right != null)
            {
                pt.Right.Parent = pt;
            }

            ptRight.Parent = pt.Parent;

            if (pt.Parent == null)
            {
                root = ptRight;
            }
            else if (pt == pt.Parent.Left)
            {
                pt.Parent.Left = ptRight;
            }
            else
            {
                pt.Parent.Right = ptRight;
            }

            ptRight.Left = pt;
            pt.Parent = ptRight;
        }

        private void RotateRight(RedBlackTreeNode root, RedBlackTreeNode pt)
        {
            var ptLeft = pt.Left;
            
            pt.Left = ptLeft.Right;
            if (pt.Left != null)
            {
                pt.Left.Parent = pt.Parent;
            }

            ptLeft.Parent = pt.Parent;

            if (pt.Parent == null)
            {
                root = ptLeft;
            } 
            else if (pt == pt.Parent.Left)
            {
                pt.Parent.Left = ptLeft;
            }
            else
            {
                pt.Parent.Right = ptLeft;
            }

            ptLeft.Right = pt;
            pt.Parent = ptLeft;
        }
    }
}