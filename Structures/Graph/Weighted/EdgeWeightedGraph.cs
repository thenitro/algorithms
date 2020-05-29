using System.Collections.Generic;
using System.Linq;

namespace Algorithms.algorithms.Structures.Graph.Weighted
{
    public class EdgeWeightedGraph
    {
        private readonly Dictionary<int, List<Edge>> _adjacencency;
        private readonly HashSet<Edge> _edges;
        private readonly HashSet<int> _vertices;

        public EdgeWeightedGraph()
        {
            _adjacencency = new Dictionary<int, List<Edge>>();
            _edges = new HashSet<Edge>();
            _vertices = new HashSet<int>();
        }

        public Edge[] Edges()
        {
            return _edges.ToArray();
        }

        public int[] Vertices()
        {
            return _vertices.ToArray();
        }

        public void AddEdge(Edge edge)
        {
            if (_edges.Contains(edge))
            {
                return;
            }

            _edges.Add(edge);
            
            var v = edge.Either();
            var w = edge.Other(v);
            
            AddHelper(v, edge);
            AddHelper(w, edge);
        }

        private void AddHelper(int v, Edge edge)
        {
            if (!_vertices.Contains(v))
            {
                _vertices.Add(v);
            }
            
            if (!_adjacencency.ContainsKey(v))
            {
                _adjacencency.Add(v, new List<Edge>());
            }
            
            _adjacencency[v].Add(edge);
        }

        public Edge[] Adjacent(int vertex)
        {
            return _adjacencency[vertex].ToArray();
        }
    }
}