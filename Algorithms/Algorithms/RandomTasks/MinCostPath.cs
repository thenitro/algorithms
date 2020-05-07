using System;

namespace Algorithms.RandomTests
{
    public class MinCostPath
    {
        public MinCostPath()
        {
            var matrix = new int[,]
            {
                {1, 2, 3},
                {4, 8, 2},
                {1, 5, 3},
            };

            Console.WriteLine(8 == Solution(matrix, 2, 2));
        }

        private int Solution(int[,] matrix, int m, int n)
        {
            m++;
            n++;
            
            var map = new int[m, n];

            for (var i = 0; i < m; i++)
            {
                if (i == 0)
                {
                    map[i, 0] = matrix[i, 0];
                }
                else
                {
                    map[i, 0] = map[i - 1, 0] + matrix[i, 0];
                }
            }
            
            for (var i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    map[0, i] = matrix[0, i];
                }
                else
                {
                    map[0, i] = map[0, i - 1] + matrix[0, i];
                }
            }

            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    var right = matrix[i, j] + map[i - 1, j];
                    var down = matrix[i, j] + map[i, j - 1];
                    var diagonal = matrix[i, j] + map[i - 1, j - 1];

                    map[i, j] = Math.Min(right, Math.Min(down, diagonal));
                }
            }

            /*for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Console.Write(map[i, j] + " ");
                }

                Console.WriteLine();
            }*/
            
            return map[m - 1, n - 1];
        }
    }
}