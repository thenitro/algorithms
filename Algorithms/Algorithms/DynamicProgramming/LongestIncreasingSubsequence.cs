using System;
using System.Security.Principal;

namespace Algorithms.DynamicProgramming
{
    public class LongestIncreasingSubsequence
    {
        public LongestIncreasingSubsequence()
        {
            Console.WriteLine(6 == Solution(new[] {10, 22, 9, 33, 21, 50, 41, 60, 80}));
            Console.WriteLine(1 == Solution(new[] {3, 2}));
            Console.WriteLine(4 == Solution(new[] {50, 3, 10, 7, 40, 80}));
        }

        private int Solution(int[] array)
        {
            var N = array.Length;
            var dp = new int[N];

            for (var i = 0; i < N; i++)
            {
                dp[i] = 1;
            }

            var max = 1;

            for (int i = 0; i < N; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (array[i] > array[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }

                max = Math.Max(max, dp[i]);
            }

            return dp[N - 1];
        }
    }
}