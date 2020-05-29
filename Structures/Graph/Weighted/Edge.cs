using System;

namespace Algorithms.algorithms.Structures.Graph.Weighted
{
    public class Edge : IComparable<Edge>
    {
        private readonly int _v;
        private readonly int _w;
        private readonly double _weight;

        public Edge(int v, int w, double weight)
        {
            _v = v;
            _w = w;
            _weight = weight;
        }

        public int Either()
        {
            return _v;
        }

        public int Other(int vertex)
        {
            return _v == vertex ? _w : _v;
        }
        
        public int CompareTo(Edge other)
        {
            if (_weight < other._weight)
            {
                return -1;
            }

            if (_weight > other._weight)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            return $"[ Edge v={_v}, w={_w}, weight={_weight} ]";
        }
    }
}