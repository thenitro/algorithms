using System;
using System.Collections.Generic;
using Algorithms.Structure;

namespace Algorithms.Other
{
    public class ConvexHull
    {
        public static Point[] Find(Point[] points)
        {
            Array.Sort(points, (point, point1) => point1.Y - point.Y);

            var pointY = points[0];

            for (var i = 0; i < points.Length; i++)
            {
                var point = points[i];
                
                var dx = point.X - pointY.X;
                var dy = point.Y - pointY.Y;

                var angle = Math.Atan2(dy, dx);

                point.Tmp = -(int)(angle * 180 / Math.PI);
            }
            
            Array.Sort(points, (point, point1) => point.Tmp - point1.Tmp);
            
            var hull = new Stack<Point>();
                hull.Push(points[0]);
                hull.Push(points[1]);

            for (var i = 2; i < points.Length; i++)
            {
                var top = hull.Pop();

                if (Point.CCW(hull.Peek(), top, points[i]) > 0)
                {
                    top = hull.Pop();
                }
                
                hull.Push(top);
                hull.Push(points[i]);
            }
                
            return hull.ToArray();
        }
    }
}