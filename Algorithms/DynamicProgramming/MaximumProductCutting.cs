using System;

namespace Algorithms.DynamicProgramming
{
    public class MaximumProductCutting
    {
        public MaximumProductCutting()
        {
            Console.WriteLine(1 == Solution(2));
            Console.WriteLine(2 == Solution(3));
            Console.WriteLine(4 == Solution(4));
            Console.WriteLine(6 == Solution(5));
            Console.WriteLine(36 == Solution(10));
        }

        private int Solution(int N)
        {
            var dp = new int[N + 1];
                dp[0] = 0;
                dp[1] = 0;

            for (var i = 1; i <= N; i++)
            {
                var maxValue = 0;

                for (var j = 1; j <= i / 2; j++)
                {
                    maxValue = Math.Max(maxValue, Math.Max((i - j) * j, j * dp[i - j]));
                }

                dp[i] = maxValue;
            }

            return dp[N];
        }
    }
}