using System;
using System.Collections.Generic;

namespace Algorithms.Structure.Tree.Abstract
{
    public interface IBinaryTree
    {
        string PrintNode(BinaryTreeNode<IComparable> node, int tabs = 0, char lrh = 'H');
        void PrintInorder();
        
        bool Has(IComparable value);
        void Insert(IComparable value);
        void Delete(IComparable value);
        
        List<IComparable> Range(IComparable a, IComparable b);
    }
}