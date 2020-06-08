using System.Collections.Generic;

namespace Algorithms.algorithms.Structures.Graph.Flow
{
    public class FlowNetwork
    {
        private Dictionary<int, List<FlowEdge>> _adjacency;
        private HashSet<int> _vertices;
        private HashSet<FlowEdge> _edges;

        public FlowNetwork()
        {
            _adjacency = new Dictionary<int, List<FlowEdge>>();
            _vertices = new HashSet<int>();
            _edges = new HashSet<FlowEdge>();
        }

        public void AddEdge(FlowEdge e)
        {
            AddEdgeHelper(e.From, e);
            AddEdgeHelper(e.To, e);
        }

        public FlowEdge[] Adjacent(int vertex)
        {
            return _adjacency[vertex].ToArray();
        }

        private void AddEdgeHelper(int vertex, FlowEdge edge)
        {
            _vertices.Add(vertex);
            _edges.Add(edge);

            if (!_adjacency.ContainsKey(vertex))
            {
                _adjacency.Add(vertex, new List<FlowEdge>());
            }
            
            _adjacency[vertex].Add(edge);
        }
    }
}