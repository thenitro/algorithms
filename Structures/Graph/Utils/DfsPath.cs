using System.Collections.Generic;
using Algorithms.Structure.Graphs;

namespace Algorithms.Structure
{
    public class DfsPath
    {
        private int _s;
        private HashSet<int> _marked;
        private Dictionary<int, int> _edgeTo;

        public DfsPath(Graph G, int s)
        {
            _s = s;
            _marked = new HashSet<int>();
            _edgeTo = new Dictionary<int, int>();

            Dfs(G, s);
        }

        private void Dfs(Graph G, int v)
        {
            _marked.Add(v);

            foreach (var w in G.GetNeighbors(v))
            {
                if (_marked.Contains(w))
                {
                    continue;
                }
                
                Dfs(G, w);
                _edgeTo[w] = v;
            }
        }
    }
}