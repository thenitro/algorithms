using System;

namespace Algorithms.Structure
{
    public class FloydWarshallAlgorithm
    {
        private const int INF = 99999;
        
        public FloydWarshallAlgorithm()
        {
            var graph = new int[,]
            {
                {
                    0, 5, INF, 10
                },
                {
                    INF, 0, 3, INF
                },
                {
                    INF, INF, 0, 1
                },
                {
                    INF, INF, INF, 0
                },
            };

            var result = Solve(graph, 4);

            for (var i = 0; i < result.GetLength(0); i++)
            {
                for (var j = 0; j < result.GetLength(1); j++)
                {
                    if (result[i, j] == INF)
                    {
                        Console.Write("I ");
                    }
                    else
                    {
                        Console.Write(result[i, j] + " ");
                    }
                }

                Console.WriteLine();
            }
        }

        public int[,] Solve(int[,] graph, int vertices)
        {
            var distance = new int[vertices, vertices];

            for (var i = 0; i < vertices; i++)
            {
                for (var j = 0; j < vertices; j++)
                {
                    distance[i, j] = graph[i, j];
                }
            }

            for (var k = 0; k < vertices; k++)
            {
                for (var i = 0; i < vertices; i++)
                {
                    for (var j = 0; j < vertices; j++)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                        {
                            distance[i, j] = distance[i, k] + distance[k, j];
                        }
                    }
                }
            }

            return distance;
        }
    }
}