using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace Algorithms.Structure
{
    public class Graph
    {
        private readonly List<int> Empty = new List<int>();
        
        private Dictionary<int, List<int>> _graph;

        private bool _directional;
        private int _vertices;

        public Graph(bool directional)
        {
            _directional = directional;
            _vertices = 0;
            _graph = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int u, int v)
        {
            _vertices = Math.Max(_vertices, Math.Max(u, v) + 1);
            
            AddHelper(_graph, u, v);

            if (_directional == false)
            {
                AddHelper(_graph, v, u);
            }
        }

        private void AddHelper(Dictionary<int, List<int>> graph, int u, int v)
        {
            if (!graph.ContainsKey(u))
            {
                graph[u] = new List<int>();
            }
            
            graph[u].Add(v);
        }

        public List<int> GetNeighbors(int u)
        {
            if (_graph.ContainsKey(u))
            {
                return _graph[u];
            }
            
            return Empty;
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

        public Stack<int> TopologicalSort()
        {
            var stack = new Stack<int>();

            var list = _graph.Keys;
            var visited = new Dictionary<int, bool>();

            foreach (var i in list)
            {
                if (visited.ContainsKey(i))
                {
                    continue;
                }
                
                TopologicalSortTraverse(i, visited, stack);
            }

            return stack;
        }

        public int[,] TransitiveClosure()
        {
            var result = new int[_vertices, _vertices];

            for (var i = 0; i < _vertices; i++)
            {
                TransitiveClosureUtil(i, i, result);
            }

            return result;
        }

        private void TransitiveClosureUtil(int u, int v, int[,] result)
        {
            result[u, v] = 1;

            if (!_graph.ContainsKey(v))
            {
                return;
            }

            foreach (var i in _graph[v])
            {
                if (result[u, i] == 0)
                {
                    TransitiveClosureUtil(u, i, result);
                }
            }
        }
        
        private void TopologicalSortTraverse(int v, Dictionary<int, bool> visited, Stack<int> stack)
        {
            visited[v] = true;

            if (_graph.ContainsKey(v))
            {
                
                var list = _graph[v];
                
                foreach (var i in _graph[v])
                {
                    if (visited.ContainsKey(i))
                    {
                        continue;
                    }
                
                    TopologicalSortTraverse(i, visited, stack);
                }                
            }
            
            Console.WriteLine(v);
            stack.Push(v);
        }
    }
}