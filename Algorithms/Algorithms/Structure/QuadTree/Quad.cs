using System;

namespace Algorithms.Structure.QuadTree
{
    public class Quad
    {
        public Point TopLeft;
        public Point BottomRight;

        public Node Node;

        public Quad TopLeftTree;
        public Quad TopRightTree;
        public Quad BottomLeftTree;
        public Quad BottomRightTree;

        public Quad()
        {
            TopLeft = new Point();
            BottomRight = new Point();
        }
        
        public Quad(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public void Insert(Node node)
        {
            if (node == null)
            {
                return;
            }

            if (!InBoundary(node.Position))
            {
                return;
            }

            if (Math.Abs(TopLeft.X - BottomRight.X) <= 1 &&
                Math.Abs(TopLeft.Y - BottomRight.Y) <= 1)
            {
                if (Node == null)
                {
                    Node = node;
                }

                return;
            }

            if ((TopLeft.X + BottomRight.X) / 2 >= node.Position.X)
            {
                if ((TopLeft.Y + BottomRight.Y) / 2 >= node.Position.Y)
                {
                    if (TopLeftTree == null)
                    {
                        TopLeftTree = new Quad(
                            new Point(TopLeft.X, TopLeft.Y),
                            new Point((TopLeft.X + BottomRight.X) / 2, (TopLeft.Y + BottomRight.Y) / 2));
                    }

                    TopLeftTree.Insert(node);
                }
                else
                {
                    if (BottomLeftTree == null)
                    {
                        BottomLeftTree = new Quad(
                            new Point(TopLeft.X, (TopLeft.Y + BottomRight.Y) / 2), 
                            new Point((TopLeft.X + BottomRight.X) / 2, BottomRight.Y));
                    }
                    BottomLeftTree.Insert(node);
                }
            }
            else
            {
                if ((TopLeft.Y + BottomRight.Y) / 2 >= node.Position.Y)
                {
                    if (TopRightTree == null)
                    {
                        TopRightTree = new Quad(
                            new Point((TopLeft.X + BottomRight.X) / 2, TopLeft.Y),
                            new Point(BottomRight.X, (TopLeft.Y + BottomRight.Y) / 2));
                    }

                    TopRightTree.Insert(node);
                }
                else
                {
                    if (BottomRightTree == null)
                    {
                        BottomRightTree = new Quad(
                            new Point((TopLeft.X + BottomRight.X) / 2, (TopLeft.Y + BottomRight.Y) / 2),
                            new Point(BottomRight.X, BottomRight.Y));
                    }
                    
                    BottomRightTree.Insert(node);
                }
            }
        }

        public Node Search(Point point)
        {
            if (!InBoundary(point))
            {
                return null;
            }

            if (Node != null)
            {
                return Node;
            }

            if ((TopLeft.X + BottomRight.X) / 2 >= point.X)
            {
                if ((TopLeft.Y + BottomRight.Y) / 2 >= point.Y)
                {
                    return TopLeftTree?.Search(point);
                }
                else
                {
                    return BottomLeftTree?.Search(point);
                }
            }
            else
            {
                if ((TopLeft.Y + BottomRight.Y) / 2 >= point.Y)
                {
                    return TopRightTree?.Search(point);
                }
                else
                {
                    return BottomRightTree?.Search(point);
                }
            }

            return null;
        }

        private bool InBoundary(Point point)
        {
            return (point.X >= TopLeft.X &&
                    point.X <= BottomRight.X &&
                    point.Y >= TopLeft.Y &&
                    point.Y <= BottomRight.Y);
        }
    }
}