using System;
using System.Collections.Generic;
using Algorithms.algorithms.Structures.Graph.Flow;

namespace Algorithms.algorithms.Structures.Graph.Utils.Flow
{
    public class FordFulkerson
    {
        private HashSet<int> _marked;
        private Dictionary<int, FlowEdge> _edgeTo;
        public double Value { get; private set; }

        public FordFulkerson(FlowNetwork graph, int s, int t)
        {
            Value = 0;

            while (HasAugmentingPath(graph, s, t))
            {
                var bottle = double.PositiveInfinity;

                for (var v = t; v != s; v = _edgeTo[v].Other(v))
                {
                    bottle = Math.Min(bottle, _edgeTo[v].ResidualCapacityTo(v));
                }

                for (var v = t; v != s; v = _edgeTo[v].Other(v))
                {
                    _edgeTo[v].AddResidualFlowTo(v, bottle);
                }

                Value += bottle;
            }
        }

        public bool InCut(int vertex)
        {
            return _marked.Contains(vertex);
        }

        private bool HasAugmentingPath(FlowNetwork graph, int s, int t)
        {
            _edgeTo = new Dictionary<int, FlowEdge>();
            _marked = new HashSet<int>();
            
            var queue = new Queue<int>();
                queue.Enqueue(s);

            _marked.Add(s);

            while (queue.Count > 0)
            {
                var v = queue.Dequeue();

                foreach (var edge in graph.Adjacent(v))
                {
                    var w = edge.Other(v);

                    if (edge.ResidualCapacityTo(w) > 0 && !_marked.Contains(w))
                    {
                        _edgeTo.Add(w, edge);
                        _marked.Add(w);
                        
                        queue.Enqueue(w);
                    }
                }
            }

            return _marked.Contains(t);
        }
    }
}