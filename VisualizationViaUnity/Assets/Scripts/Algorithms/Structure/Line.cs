using System;

namespace Algorithms.Structure
{
    public class Line : IComparable
    {
        public Point A { get; }
        public Point B { get; }

        public Line(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public bool IsVertical()
        {
            return A.X == B.X;
        }
        
        public bool IsHorizontal()
        {
            return A.Y == B.Y;
        }

        public override string ToString()
        {
            return $"[ Line A={A} to B={B} ]";
        }

        public int CompareTo(object other)
        {
            var otherLine = other as Line;
            if (otherLine == null) return +1;
            if (otherLine == this) return 0;
            
            if (A.Y < otherLine.A.Y) return -1;
            if (A.Y > otherLine.A.Y) return +1;
            if (B.Y < otherLine.B.Y) return -1;
            if (B.Y > otherLine.B.Y) return +1;
            if (A.X < otherLine.A.X) return -1;
            if (A.X > otherLine.A.X) return +1;
            if (B.X < otherLine.B.X) return -1;
            if (B.X > otherLine.B.X) return +1;

            return 0;
        }
    }
}