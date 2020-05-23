using System;

namespace Algorithms.DynamicProgramming
{
    public class MatrixChainMultiplication
    {
        public MatrixChainMultiplication()
        {
            var array = new int[] { 1, 2, 3, 4, 3 };
            
            Console.WriteLine(30 == SolutionRecursive(array, 1, array.Length - 1));
            Console.WriteLine(30 == SolutionDp(array));
        }

        private int SolutionDp(int[] p)
        {
            var N = p.Length;
            var dp = new int[N, N];

            for (var L = 2; L < N; L++)
            {
                for (var i = 1; i < N - L + 1; i++)
                {
                    var j = i + L - 1;
                    dp[i, j] = int.MaxValue;
                    
                    for (var k = i; k <= j - 1; k++)
                    {
                        var q = dp[i, k] + dp[k + 1, j] +
                                p[i - 1] * p[k] * p[j];

                        if (q < dp[i, j])
                        {
                            dp[i, j] = q;
                        }
                    }
                }
            }

            return dp[1, N - 1];
        }

        private int SolutionRecursive(int[] p, int i, int j)
        {
            if (i == j)
            {
                return 0;
            }

            var min = int.MaxValue;

            for (var k = i; k < j; k++)
            {
                var count = SolutionRecursive(p, i, k) +
                            SolutionRecursive(p, k + 1, j) + 
                            p[i - 1] * p[k] * p[j];

                if (count < min)
                {
                    min = count;
                }
            }

            return min;
        }
    }
}