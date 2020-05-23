using System;

namespace Algorithms.RandomTests
{
    public class BytelandianGoldCoins
    {
        public BytelandianGoldCoins()
        {
            Console.WriteLine(Solution(12));
            Console.WriteLine(Solution(2));
            
            Console.WriteLine(13 == Solution(12) && 13 == SolutionDp(12) && 13 == SolutionMemo(12));
            Console.WriteLine(2 == Solution(2) && 2 == SolutionDp(2) && 2 == SolutionMemo(2));
        }
        
        private int Solution(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            
            return Math.Max(n, Solution(n / 2) + Solution(n / 3) + Solution(n / 4));
        }
        
        private int SolutionMemo(int n)
        {
            var memo = new int[n + 1];

            return SolutionMemoHelper(memo, n);
        }

        private int SolutionMemoHelper(int[] memo, int n)
        {
            if (n == 0)
            {
                return 0;
            }
            
            if (memo[n] == 0)
            {
                memo[n] = Math.Max(n,
                    SolutionMemoHelper(memo, n / 2) + SolutionMemoHelper(memo, n / 3) +
                    SolutionMemoHelper(memo, n / 4));
            }
            
            return memo[n];
        }

        private int SolutionDp(int n)
        {
            var dp = new int[n + 1];

            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = i;
            }

            for (var i = 0; i <= n; i++)
            {
                dp[i] = Math.Max(dp[i], dp[i / 2] + dp[i / 3] + dp[i / 4]);
            }

            return dp[n];
        }
    }
}