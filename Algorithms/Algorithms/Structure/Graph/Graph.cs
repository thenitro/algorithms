using System;
using System.Collections.Generic;
using System.Net;

namespace Algorithms.Structure
{
    public class Graph
    {
        private Dictionary<int, List<int>> _graph;

        public Graph()
        {
            _graph = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int u, int v)
        {
            if (!_graph.ContainsKey(u))
            {
                _graph[u] = new List<int>();
            }
            
            _graph[u].Add(v);
        }

        public void DFS(int v)
        {
            var visited = new bool[_graph.Count];

            TraverseDFS(v, visited);
        }

        private void TraverseDFS(int v, bool[] visited)
        {
            visited[v] = true;
            Console.Write(v + " ");

            foreach (var i in _graph[v])
            {
                if (!visited[i])
                {
                    TraverseDFS(i, visited);
                }
            }
        }
    }
}