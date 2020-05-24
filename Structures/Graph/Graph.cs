using System;
using System.Collections.Generic;

namespace Algorithms.Structure
{
    public class Graph
    {
        private readonly List<int> Empty = new List<int>();
        
        private readonly Dictionary<int, List<int>> _graph;
        public HashSet<int> Vertices { get; }

        private readonly bool _directional;

        public Graph(bool directional)
        {
            _directional = directional;
            
            Vertices = new HashSet<int>();
            _graph = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int u, int v)
        {
            AddVertex(u);
            AddVertex(v);
            
            AddHelper(_graph, u, v);

            if (_directional == false)
            {
                AddHelper(_graph, v, u);
            }
        }

        private void AddVertex(int v)
        {
            if (Vertices.Contains(v))
            {
                return;
            }
            
            Vertices.Add(v);
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

        public List<int> DFS(int v)
        {
            var result = new List<int>();
            
            var visited = new HashSet<int>();
            
            var stack = new Stack<int>();    
                stack.Push(v);

            while (stack.Count > 0)
            {
                v = stack.Pop();
                visited.Add(v);
                
                result.Add(v);

                if (!_graph.ContainsKey(v))
                {
                    continue;
                }

                foreach (var u in _graph[v])
                {
                    if (visited.Contains(u))
                    {
                        continue;
                    }
                    
                    stack.Push(u);
                }
            }

            return result;
        }

        public bool IsCyclic()
        {
            var visited = new bool[_graph.Count];
            var recStack = new bool[_graph.Count];

            for (var i = 0; i < _graph.Count; i++)
            {
                if (IsCyclicUtil(i, visited, recStack))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsCyclicUtil(int i, bool[] visited, bool[] recursionStack)
        {
            if (recursionStack[i])
            {
                return true;
            }

            if (visited[i])
            {
                return false;
            }

            visited[i] = true;
            recursionStack[i] = true;

            var children = _graph[i];

            foreach (var child in children)
            {
                if (IsCyclicUtil(child, visited, recursionStack))
                {
                    return true;
                }
            }

            recursionStack[i] = false;

            return true;
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
            var result = new int[Vertices.Count, Vertices.Count];

            foreach (var vertex in Vertices)
            {
                TransitiveClosureUtil(vertex, vertex, result);
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

        public int FindMother()
        {
            if (!_directional)
            {
                return -1;
            }
            
            var visited = new HashSet<int>();
            var v = 0;

            foreach (var vertex in Vertices)
            {
                if (!visited.Contains(vertex))
                {
                    FindMotherHelper(vertex, visited);
                    v = vertex;
                }
            }

            foreach (var vertex in Vertices)
            {
                if (Vertices.Contains(vertex))
                {
                    Vertices.Remove(vertex);
                }
            }
            
            FindMotherHelper(v, visited);

            foreach (var vertex in Vertices)
            {
                if (!visited.Contains(vertex))
                {
                    return -1;
                }
            }

            return v;
        }

        private void FindMotherHelper(int v, HashSet<int> visited)
        {
            visited.Add(v);

            if (!_graph.ContainsKey(v))
            {
                return;
            }

            foreach (var i in _graph[v])
            {
                if (visited.Contains(i))
                {
                    continue;
                }
                
                FindMotherHelper(i, visited);
            }
        }

        public List<List<int>> FindAllPaths(int source, int destination)
        {
            if (!_directional)
            {
                return null;
            }

            var result = new List<List<int>>();
            
            var visited = new HashSet<int>();

            FindAllPathsHelper(source, destination, visited, new List<int>(), result);

            return result;
        }

        private void FindAllPathsHelper(
            int u, int destination, 
            HashSet<int> visited, List<int> path, 
            List<List<int>> result)
        {
            visited.Add(u);
            path.Add(u);

            if (u == destination)
            {
                result.Add(new List<int>(path));
            }
            else
            {
                foreach (var i in _graph[u])
                {
                    if (visited.Contains(i))
                    {
                        continue;
                    }
                    
                    FindAllPathsHelper(i, destination, visited, path, result);
                }
            }

            path.RemoveAt(path.Count - 1);
            visited.Remove(u);
        }
    }
}