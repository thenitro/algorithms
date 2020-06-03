using System.Collections.Generic;
using System.Linq;

namespace Algorithms.algorithms.Structures.Graph.Weighted
{
    public class EdgeWeightedDigraph
    {
        private readonly Dictionary<int, List<DirectedEdge>> _adjacencency;
        private readonly HashSet<DirectedEdge> _edges;
        private readonly HashSet<int> _vertices;

        public EdgeWeightedDigraph()
        {
            _adjacencency = new Dictionary<int, List<DirectedEdge>>();
            _edges = new HashSet<DirectedEdge>();
            _vertices = new HashSet<int>();
        }

        public DirectedEdge[] Edges()
        {
            return _edges.ToArray();
        }

        public int[] Vertices()
        {
            return _vertices.ToArray();
        }

        public void AddEdge(DirectedEdge edge)
        {
            if (_edges.Contains(edge))
            {
                return;
            }

            _edges.Add(edge);

            var v = edge.From();
            AddHelper(v, edge);
        }

        private void AddHelper(int v, DirectedEdge edge)
        {
            if (!_vertices.Contains(v))
            {
                _vertices.Add(v);
            }
            
            if (!_adjacencency.ContainsKey(v))
            {
                _adjacencency.Add(v, new List<DirectedEdge>());
            }
            
            _adjacencency[v].Add(edge);
        }

        public DirectedEdge[] Adjacent(int vertex)
        {
            return _adjacencency[vertex].ToArray();
        }
    }
}