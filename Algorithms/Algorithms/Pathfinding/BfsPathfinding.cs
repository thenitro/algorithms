using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Pathfinding
{
    internal class Node
    {
        public int X;
        public int Y;
        public int Distance;
    }
    
    public class BfsPathfinding
    {
        private const char Start = 's';
        private const char Destination = 'd';
        private const char Walkable = '*';
        private const char NoNWalkable = '0';
        
        public int FindPath(char[][] grid)
        {
            var queue = new Queue<Node>();
            var visited = new bool[grid.Length,grid.Length];

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid.Length; j++)
                {
                    if (grid[i][j] == Start)
                    {
                        queue.Enqueue(new Node() { X = i, Y = j, Distance = 0 });
                    }
                }
            }

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                
                if (currentNode.X < 0 || currentNode.Y < 0 ||
                    currentNode.X >= grid.Length || currentNode.Y >= grid.Length)
                {
                    continue;
                }
                
                if (visited[currentNode.X,currentNode.Y] == true)
                {
                    continue;
                }
                
                visited[currentNode.X,currentNode.Y] = true;

                var nodeValue = grid[currentNode.X][currentNode.Y]; 
                
                if (nodeValue == Destination)
                {
                    return currentNode.Distance;
                }

                if (nodeValue == NoNWalkable)
                {
                    continue;
                }

                if (nodeValue == Walkable || nodeValue == Start)
                {
                    var distance = currentNode.Distance + 1;
                    
                    queue.Enqueue(new Node()
                    {
                        X = currentNode.X + 1, 
                        Y = currentNode.Y,
                        Distance =  distance,
                    });
                    
                    queue.Enqueue(new Node()
                    {
                        X = currentNode.X - 1, 
                        Y = currentNode.Y,
                        Distance =  distance,
                    });
                    
                    queue.Enqueue(new Node()
                    {
                        X = currentNode.X, 
                        Y = currentNode.Y + 1,
                        Distance =  distance,
                    });
                    
                    queue.Enqueue(new Node()
                    {
                        X = currentNode.X, 
                        Y = currentNode.Y - 1,
                        Distance =  distance,
                    });
                }
            }

            return -1;
        }
    }
}