using System;

namespace Algorithms.DynamicProgramming
{
    public class CuttingRod
    {
        public CuttingRod()
        {
            Console.WriteLine(22 == Solution(new int[] { 1, 5, 8, 9, 10, 17, 17, 20 }));
            Console.WriteLine(24 == Solution(new int[] { 3, 5, 8, 9, 10, 17, 17, 20 }));
        }

        private int Solution(int[] arr)
        {
            var N = arr.Length;
            var dp = new int[N + 1, N + 1];

            for (var i = 1; i <= N; i++)
            {
                for (var j = 1; j <= N; j++)
                {
                    if (j >= i)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], arr[i - 1] + dp[i, j - i]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp[N - 1, N];
        }
    }
}