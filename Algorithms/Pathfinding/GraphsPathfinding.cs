using System.Collections.Generic;
using Algorithms.Structure.Graphs;

namespace Algorithms.Pathfinding
{
    public class GraphsPathfinding
    {
        public List<int> FindPath(Graph graph, int source, int destination)
        {
            var path = new List<int>();
            
            var previous = TraverseViaBfs(graph, source, destination);
            if (previous != null)
            {
                var crawl = destination;
                path.Add(crawl);
                while (previous.ContainsKey(crawl))
                {
                    path.Add(previous[crawl]);
                    crawl = previous[crawl];
                }
            }
            
            path.Reverse();
            
            return path;
        }

        private Dictionary<int, int> TraverseViaBfs(Graph graph, int source, int destination)
        {
            var queue = new Queue<int>();
            
            var visited = new HashSet<int>();
            
            var previous = new Dictionary<int, int>();
            var distance = new Dictionary<int, int>();
            
            queue.Enqueue(source);
            visited.Add(source);
            distance[source] = 0;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                
                foreach (var neighbor in graph.GetNeighbors(node))
                {
                    if (visited.Contains(neighbor))
                    {
                        continue;
                    }

                    visited.Add(neighbor);
                    distance[neighbor] = distance[node] + 1;
                    previous[neighbor] = node;

                    queue.Enqueue(neighbor);

                    if (neighbor == destination)
                    {
                        return previous;
                    }
                }
            }

            return null;
        }
    }
}