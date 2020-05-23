using System;

namespace Algorithms.DynamicProgramming
{
    public class BoxStackingProblem
    {
        public BoxStackingProblem()
        {
            var boxes = new Box[4]; 
                boxes[0] = new Box(4, 6, 7); 
                boxes[1] = new Box(1, 2, 3); 
                boxes[2] = new Box(4, 5, 6); 
                boxes[3] = new Box(10, 12, 32);

            Console.WriteLine(60 == Solution(boxes));
        }

        private int Solution(Box[] boxes)
        {
            var rotated = new Box[boxes.Length * 3];

            for (var i = 0; i < boxes.Length; i++)
            {
                var box = boxes[i];
                var newIndex = i * 3;
                
                rotated[newIndex] = new Box(box.W, Math.Max(box.H, box.D), Math.Min(box.H, box.D));
                rotated[newIndex + 1] = new Box(box.H, Math.Max(box.W, box.D), Math.Min(box.W, box.D));
                rotated[newIndex + 2] = new Box(box.D, Math.Max(box.W, box.H), Math.Min(box.W, box.H));
            }

            for (var i = 0; i < rotated.Length; i++)
            {
                rotated[i].Area = rotated[i].W * rotated[i].D;
            }
            
            Array.Sort(rotated, (box, box1) => box1.Area.CompareTo(box.Area));

            var dp = new int[rotated.Length];
            
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = rotated[i].H;
            }

            var max = -1;

            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = 0;

                var box = rotated[i];
                var subResult = 0;

                for (var j = 0; j < i; j++)
                {
                    var prevBox = rotated[j];

                    if (box.W < prevBox.W && box.D < prevBox.D)
                    {
                        subResult = Math.Max(subResult, dp[j]);
                    }
                }

                dp[i] = subResult + box.H;
                
                max = Math.Max(max, dp[i]);
            }

            return max;
        }

        private class Box
        {
            public int W { get; }
            public int H { get; }
            public int D { get; }
            public int Area { get; set; }
            
            public Box(int h, int w, int d)
            {
                W = w;
                H = h;
                D = d;
            }
        }
    }
}