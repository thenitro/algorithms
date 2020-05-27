using System.Collections.Generic;
using Algorithms.Structure.Graphs;

namespace Algorithms.algorithms.Structures.Graph.Utils
{
    public class KosarajuSharirScc
    {
        private HashSet<int> _marked;
        private Dictionary<int, int> _id;
        private int _count;

        public KosarajuSharirScc(Digraph G)
        {
            _marked = new HashSet<int>();
            _id = new Dictionary<int, int>();
            _count = 0;
            
            var dfs = new DepthFirstOrder(G.Reverse());

            foreach (var vertex in dfs.ReversePost)
            {
                if (_marked.Contains(vertex))
                {
                    continue;
                }
                
                Dfs(G, vertex);
                _count++;
            }
        }

        private void Dfs(Digraph G, int vertex)
        {
            _marked.Add(vertex);
            _id.Add(vertex, _count);

            foreach (var neighbor in G.GetNeighbors(vertex))
            {
                if (_marked.Contains(neighbor))
                {
                    continue;
                }
                
                Dfs(G, neighbor);
            }
        }

        public bool IsStronglyConnected(int v, int w)
        {
            return _id[v] == _id[w];
        }
    }
}