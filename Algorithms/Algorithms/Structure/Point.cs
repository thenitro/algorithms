namespace Algorithms.Structure
{
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Id { get; private set; }
        
        public int Tmp { get; set; } 
        
        public Point(int x, int y, string id = null)
        {
            X = x;
            Y = y;
            Id = id;
        }
        
        public Point()
        {
            X = 0;
            Y = 0;
        }

        public static int CCW(Point a, Point b, Point c)
        {
            var determinent = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
            
            if (determinent < 0)
            {
                return -1;
            } 
            
            if (determinent > 0)
            {
                return 1;
            }
            
            return 0;
        }

        public override string ToString()
        {
            return string.Format("Point id={0}, x={1}, y={2}", Id, X, Y);
        }
    }
}