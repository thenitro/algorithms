using System;

namespace Algorithms.RandomTests
{
    public class FindTheNumberOfIslands
    {
        public FindTheNumberOfIslands()
        {
            Console.WriteLine(5 == Solve(new int[][]
            {
                new int[] {1, 1, 0, 0, 0},
                new int[] {0, 1, 0, 0, 1},
                new int[] {1, 0, 0, 1, 1},
                new int[] {0, 0, 0, 0, 0},
                new int[] {1, 0, 1, 0, 1},
            }));
        }

        private int Solve(int[][] matrix)
        {
            var visited = new bool[matrix.Length, matrix[0].Length];

            var count = 0;

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 1 && !visited[i, j])
                    {
                        Dfs(matrix, i, j, visited);
                        count++;
                    }
                }
            }

            return count;
        }

        private void Dfs(int[][] matrix, int i, int j, bool[,] visited)
        {
            var rows = new int[] {-1, -1, -1, 0, 0, 1, 1, 1};
            var cols = new int[] {-1, 0, 1, -1, 1, -1, 0, 1};

            visited[i, j] = true;

            for (var k = 0; k < 8; k++)
            {
                var row = i + rows[k];
                var col = j + cols[k];
                
                if (IsSafe(matrix, row, col, visited))
                {
                    Dfs(matrix, row, col, visited);
                }
            }
        }

        private bool IsSafe(int[][] matrix, int i, int j, bool[,] visited)
        {
            return i >= 0 && i < matrix.Length &&
                   j >= 0 && j < matrix[i].Length &&
                   matrix[i][j] == 1 &&
                   !visited[i, j];
        }
    }
}