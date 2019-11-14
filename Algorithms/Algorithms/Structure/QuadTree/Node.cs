namespace Algorithms.Structure.QuadTree
{
    public class Node
    {
        public Point Position;
        public int Data;

        public Node(Point position, int data)
        {
            Position = position;
            Data = data;
        }

        public Node()
        {
            Data = 0;
        }
    }
}