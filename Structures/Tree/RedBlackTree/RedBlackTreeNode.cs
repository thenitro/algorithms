namespace Algorithms.Structure.Tree
{
    public class RedBlackTreeNode<IComparable> : BinaryTreeNode<IComparable>
    {
        public bool Color { get; set; }        
        
        public RedBlackTreeNode(IComparable data)
        {
            Value = data;
            Color = false;
        }
    }
}