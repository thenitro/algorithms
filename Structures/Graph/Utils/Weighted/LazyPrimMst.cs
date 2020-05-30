using System.Collections.Generic;
using Algorithms.algorithms.Structures.Graph.Weighted;
using Algorithms.Structure.Queue;

namespace Algorithms.algorithms.Structures.Graph.Utils.Weighted
{
    public class LazyPrimMst
    {
        private HashSet<int> _marked;
        private Queue<Edge> _mst;
        private PriorityQueue<Edge> _pq;

        public LazyPrimMst(EdgeWeightedGraph graph)
        {
            _marked = new HashSet<int>();
            _mst = new Queue<Edge>();
            _pq = new PriorityQueue<Edge>();

            Visit(graph, 0);

            while (!_pq.IsEmpty)
            {
                var edge = _pq.DelMin() as Edge;
                
                var v = edge.Either();
                var w = edge.Other(v);

                if (_marked.Contains(v) && _marked.Contains(w))
                {
                    continue;
                }
                
                _mst.Enqueue(edge);

                if (!_marked.Contains(v))
                {
                    Visit(graph, v);
                }
                
                if (!_marked.Contains(w))
                {
                    Visit(graph, w);
                }
            }
        }

        private void Visit(EdgeWeightedGraph graph, int vertex)
        {
            _marked.Add(vertex);

            foreach (var edge in graph.Adjacent(vertex))
            {
                if (_marked.Contains(edge.Other(vertex)))
                {
                    continue;
                }
                
                _pq.Enqueue(edge);
            }
        }

        public Edge[] Edges()
        {
            return _mst.ToArray();
        }
    }
}