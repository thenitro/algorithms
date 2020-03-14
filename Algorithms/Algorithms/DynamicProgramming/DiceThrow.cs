using System;

namespace Algorithms.DynamicProgramming
{
    public class DiceThrow
    {
        public DiceThrow()
        {
            Console.WriteLine(0 == Solution(4, 2, 1));
            Console.WriteLine(2 == Solution(2, 2, 3));
            Console.WriteLine(21 == Solution(6, 3, 8));
            Console.WriteLine(4 == Solution(4, 2, 5));
        }

        private int Solution(int n, int m, int X)
        {
            var dp = new int[n + 1, X + 1];

            for (var j = 1; j <= m && j <= X; j++)
            {
                dp[1, j] = 1;
            }

            for (var i = 2; i <= n; i++)
            {
                for (var j = 1; j <= X; j++)
                {
                    for (var k = 1; k <= m && k < j; k++)
                    {
                        dp[i, j] += dp[i - 1, j - k];
                    }
                }
            }

            return dp[n, X];
        }
    }
}