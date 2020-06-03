using System;

namespace Algorithms.algorithms.Structures.Graph.Weighted
{
    public class DirectedEdge : IComparable<DirectedEdge>
    {
        public int From { get; }
        public int To { get; }
        public int Weight { get; }

        public DirectedEdge(int @from, int to, double weight)
        {
            From = @from;
            To = to;
            Weight = weight;
        }
        
        public int CompareTo(DirectedEdge other)
        {
            if (Weight < other.Weight)
            {
                return -1;
            }

            if (Weight > other.Weight)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            return $"[ DirectedEdge v={_v}, w={To}, weight={Weight} ]";
        }
    }
}