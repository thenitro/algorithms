using System;

namespace Algorithms.DynamicProgramming
{
    public class CountNumberOfWaysToCoverDistance
    {
        public CountNumberOfWaysToCoverDistance()
        {
            Console.WriteLine(4 == Solution(3));
            Console.WriteLine(7 == Solution(4));
        }

        private int Solution(int N)
        {
            var dp = new int[Math.Max(N + 1, 3)];
                dp[0] = 1;
                dp[1] = 1;
                dp[2] = 2;

            for (var i = 3; i <= N; i++)
            {
                dp[i] = dp[i - 3] + dp[i - 2] + dp[i - 1];
            }
            
            return dp[N];
        }
    }
}