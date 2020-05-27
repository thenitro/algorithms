using System.Collections.Generic;
using Algorithms.Structure.Graphs;

namespace Algorithms.algorithms.Structures.Graph.Utils
{
    public class DepthFirstOrder
    {
        private HashSet<int> _marked;
        private Stack<int> _reversePost;
        
        public int[] ReversePost => _reversePost.ToArray();

        public DepthFirstOrder(Digraph G)
        {
            _marked = new HashSet<int>();
            _reversePost = new Stack<int>();

            foreach (var vertex in G.Vertices)
            {
                if (_marked.Contains(vertex))
                {
                    continue;
                }

                Dfs(G, vertex);
            }
        }

        private void Dfs(Digraph G, int vertex)
        {
            _marked.Add(vertex);

            foreach (var neighborVertex in G.GetNeighbors(vertex))
            {
                if (_marked.Contains(neighborVertex))
                {
                    continue;
                }
                
                Dfs(G, neighborVertex);
            }
            
            _reversePost.Push(vertex);
        }
    }
}