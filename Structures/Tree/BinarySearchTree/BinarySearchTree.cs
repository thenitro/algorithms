using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Structure.QuadTree;
using Algorithms.Structure.Tree.Abstract;
using UnityEngine;

namespace Algorithms.Structure.Tree
{
    public class BinarySearchTree<T> : AbstractBinaryTree, IBinaryTree
    {   
        public void Insert(IComparable value)
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode<IComparable> { Value = value };
                return;
            }

            var next = Root;
            
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

        public void Delete(IComparable value)
        {
            DeleteNode(Root, value);
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