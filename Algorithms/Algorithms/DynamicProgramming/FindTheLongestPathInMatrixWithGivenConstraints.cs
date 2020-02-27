using System;

namespace Algorithms.DynamicProgramming
{
    public class FindTheLongestPathInMatrixWithGivenConstraints
    {
        public FindTheLongestPathInMatrixWithGivenConstraints()
        {
            Console.WriteLine(4 == Solution(new []
            {
                new [] { 1, 2, 9 },
                new [] { 5, 3, 8 },
                new [] { 4, 6, 7 },
            }));
        }

        private int Solution(int[][] matrix)
        {
            var dp = new int[matrix.Length, matrix[0].Length];

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix.Length; j++)
                {
                    dp[i, j] = -1;
                }
            }

            var result = 1;

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix.Length; j++)
                {
                    if (dp[i, j] == -1)
                    {
                        FindLongestFromCell(i, j, matrix, dp);
                    }
                    
                    result = Math.Max(result, dp[i, j]);
                }
            }

            return result;
        }

        private int FindLongestFromCell(int i, int j, int[][] matrix, int[,] dp)
        {
            var n = matrix.Length;
            var m = matrix[0].Length;
            
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                return 0;
            }
            
            if (dp[i, j] != -1)
            {
                return dp[i, j];
            }

            var x = int.MinValue;
            var y = int.MinValue;
            var z = int.MinValue;
            var w = int.MinValue;

            if (j < m - 1 && ((matrix[i][j] + 1) == matrix[i][j + 1]))
            {
                x = dp[i, j] = 1 + FindLongestFromCell(i, j + 1, matrix, dp);
            }

            if (j > 0 && (matrix[i][j] + 1 == matrix[i][j - 1]))
            {
                y = dp[i, j] = 1 + FindLongestFromCell(i, j - 1, matrix, dp);
            }
            
           if (i > 0 && (matrix[i][j] + 1 == matrix[i - 1][j]))
           {
               z = dp[i, j] = 1 + FindLongestFromCell(i - 1, j, matrix, dp);
           }

           if (i < n - 1 && (matrix[i][j] + 1 == matrix[i + 1][j]))
           {
               w = dp[i, j] = 1 + FindLongestFromCell(i + 1, j, matrix, dp);
           }

           dp[i, j] = Math.Max(x, Math.Max(y, Math.Max(z, Math.Max(w, 1))));
           return dp[i, j];
        }
    }
}