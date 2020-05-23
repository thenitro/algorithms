namespace Algorithms.Structure.Tree
{
    public class BinaryTreeNode<IComparable>
    {
        public BinaryTreeNode<IComparable> Left;
        public BinaryTreeNode<IComparable> Right;
        public BinaryTreeNode<IComparable> Parent { get; set; }
        
        public IComparable Value;
    }
}