using System;
using Algorithms.Structure.Tree.Abstract;

namespace Algorithms.Structure.Tree
{
    public class RedBlackTree<T> : AbstractBinaryTree, IBinaryTree
    {
        public const bool BLACK = false;
        public const bool RED = true;
        
        public void Insert(IComparable data)
        {
            var pt = new RedBlackTreeNode<IComparable>(data);
                pt.Color = RED;
                
            Root = BtInsert(Root, pt);
            FixViolation(pt);
        }
        
        public void Delete(IComparable data)
        {
            throw new NotImplementedException();
        }

        private BinaryTreeNode<IComparable> BtInsert(BinaryTreeNode<IComparable> root, BinaryTreeNode<IComparable> pt)
        {
            if (root == null)
            {
                return pt;
            }

            if (Less(pt.Value, root.Value))
            {
                root.Left = BtInsert(root.Left, pt);
                root.Left.Parent = root;
            }
            else if (Less(root.Value, pt.Value))
            {
                root.Right = BtInsert(root.Right, pt);
                root.Right.Parent = root;
            }

            return root;
        }

        private void FixViolation(RedBlackTreeNode<IComparable> pt)
        {
            var parent = pt.Parent as RedBlackTreeNode<IComparable>;
            
            while (pt != Root && pt.Color != BLACK && parent.Color == RED)
            {
                var parentPt = pt.Parent as RedBlackTreeNode<IComparable>;
                var grandParentPt = pt.Parent.Parent as RedBlackTreeNode<IComparable>;

                if (parentPt == grandParentPt.Left)
                {
                    var unclePt = grandParentPt.Right as RedBlackTreeNode<IComparable>;
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
                            RotateLeft(parentPt);
                            pt = parentPt;
                            parentPt = pt.Parent as RedBlackTreeNode<IComparable>;
                        }

                        RotateRight(grandParentPt);

                        var tmp = parentPt.Color;
                        parentPt.Color = grandParentPt.Color;
                        grandParentPt.Color = tmp;
                        
                        pt = parentPt;
                    }
                }
                else
                {
                    var unclePt = grandParentPt.Left as RedBlackTreeNode<IComparable>;
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
                            RotateRight(parentPt);
                            pt = parentPt;
                            parentPt = pt.Parent as RedBlackTreeNode<IComparable>;
                        }

                        RotateLeft(grandParentPt);
                        
                        var tmp = parentPt.Color;
                        parentPt.Color = grandParentPt.Color;
                        grandParentPt.Color = tmp;
                        
                        pt = parentPt;
                    }
                }
            }

            (Root as RedBlackTreeNode<IComparable>).Color = BLACK;
        }

        private void RotateLeft(BinaryTreeNode<IComparable> pt)
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
                Root = ptRight;
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

        private void RotateRight(BinaryTreeNode<IComparable> pt)
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
                Root = ptLeft;
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