using System.Collections.Generic;
using Algorithms.algorithms.Structures.Graph.Weighted;
using Algorithms.Structure.Queue;

namespace Algorithms.algorithms.Structures.Graph.Utils.Weighted
{
    public class DijkstraSp
    {
        private Dictionary<int, DirectedEdge> _edgeTo;
        private Dictionary<int, double> _distanceTo;
        private IndexMinPq<double> _queue;

        public DijkstraSp(EdgeWeightedDigraph graph, int source)
        {
            _edgeTo = new Dictionary<int, DirectedEdge>();
            _distanceTo = new Dictionary<int, double>();
            _queue = new IndexMinPq<double>(graph.Vertices().Length);

            foreach (var vertex in graph.Vertices())
            {
                _distanceTo.Add(vertex, double.PositiveInfinity);
            }
            
            _distanceTo.Add(source, 0.0);
            _queue.Insert(source, 0.0);

            while (!_queue.IsEmpty())
            {
                var vertex = _queue.DelMin();

                foreach (var edge in graph.Adjacent(vertex))
                {
                    Relax(edge);
                }
            }
        }

        private void Relax(DirectedEdge edge)
        {
            var v = edge.From;
            var w = edge.To;

            if (_distanceTo[w] > _distanceTo[v] + edge.Weight)
            {
                _distanceTo[w] = _distanceTo[v] + edge.Weight;
                _edgeTo[w] = edge;

                if (_queue.Contains(w))
                {
                    _queue.DescreaseKey(w, _distanceTo[w]);
                }
                else
                {
                    _queue.Insert(w, _distanceTo[w]);
                }
            }
        }
    }
}