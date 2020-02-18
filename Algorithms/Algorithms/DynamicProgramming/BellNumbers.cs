using System;

namespace Algorithms.DynamicProgramming
{
    public class BellNumbers
    {
        public BellNumbers()
        {
            Console.WriteLine(2 == Solution(2));
            Console.WriteLine(5 == Solution(3));
            Console.WriteLine(15 == Solution(4));
            Console.WriteLine(52 == Solution(5));
        }

        public int Solution(int n)
        {
            var dp = new int[n, n];
                dp[0, 0] = 1;

            for (var i = 1; i < n; i++)
            {
                dp[i, 0] = dp[i - 1, i - 1];
                
                for (var j = 1; j <= i; j++)
                {
                    dp[i, j] = dp[i - 1, j - 1] + dp[i, j - 1];
                }
            }

            return dp[n - 1, n - 1];
        }
    }
}