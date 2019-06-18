namespace Algorithms.Structure.Tree
{
    public class RedBlackTreeNode
    {
        public int Data { get; private set; }
        public bool Color { get; set; }
        public RedBlackTreeNode Left { get; set; }
        public RedBlackTreeNode Right { get; set; }
        public RedBlackTreeNode Parent { get; set; }
        
        public RedBlackTreeNode(int data)
        {
            Data = data;
        }
    }
}