using System;
using System.Collections.Generic;

namespace Algorithms.Structure.Graphs.Utils
{
    public class ConnectedComponents
    {
        private HashSet<int> _marked;
        private Dictionary<int, int> _id;
        
        public int Count { get; }
        
        public ConnectedComponents(Graph G)
        {
            Count = 0;
            
            _marked = new HashSet<int>();
            _id = new Dictionary<int, int>();

            foreach (var vertex in G.Vertices)
            {
                if (_marked.Contains(vertex))
                {
                    continue;
                }

                Dfs(G, vertex);
                Count++;
            }
        }

        public int GetId(int vertex)
        {
            if (!_id.ContainsKey(vertex))
            {
                return -1;
            }
            
            return _id[vertex];
        }

        private void Dfs(Graph G, int vertex)
        {
            _marked.Add(vertex);
            _id[vertex] = Count;

            foreach (var neighbor in G.GetNeighbors(vertex))
            {
                if (_marked.Contains(neighbor))
                {
                    continue;
                }
                
                Dfs(G, neighbor);
            }
        }
    }
}