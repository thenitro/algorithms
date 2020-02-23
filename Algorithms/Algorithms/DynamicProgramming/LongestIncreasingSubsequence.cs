using System;

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

            for (int i = 1; i < N; i++)
            {
                if (array[i - 1] < array[i])
                {
                    dp[i] = dp[i - 1] + 1;
                }
                else
                {
                    dp[i] = dp[i - 1];
                }
            }

            return dp[N - 1];
        }
    }
}