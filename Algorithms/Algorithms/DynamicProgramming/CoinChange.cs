using System;
using System.Globalization;

namespace Algorithms.RandomTests
{
    public class CoinChange
    {
        public CoinChange()
        {
            Console.WriteLine(4 == SolutionRecursive(4, new [] { 1, 2, 3 }));
            Console.WriteLine(5 == SolutionRecursive(10, new [] { 2, 5, 3, 6 }));
            
            Console.WriteLine(4 == SolutionDp(4, new [] { 1, 2, 3 }));
            Console.WriteLine(5 == SolutionDp(10, new [] { 2, 5, 3, 6 }));
        }

        private int SolutionRecursive(int N, int[] coins)
        {
            var result = new int[1];
            SolutionRecursiveHelper(N, coins, result, 0);
            
            return result[0];
        }

        private void SolutionRecursiveHelper(int n, int[] coins, int[] result, int startFrom)
        {
            if (n == 0)
            {
                result[0]++;
                return;
            }

            if (n < 0)
            {
                return;
            }

            for (var i = startFrom; i < coins.Length; i++)
            {
                SolutionRecursiveHelper(n - coins[i], coins, result, i);
            }
        }

        private int SolutionDp(int N, int[] coins)
        {
            var memo = new int[N + 1];
                memo[0] = 1;

            for (var i = 0; i < coins.Length; i++)
            {
                Console.WriteLine("C " + coins[i]);
                var coin = coins[i];
                
                for (var j = coin; j < memo.Length; j++)
                {
                    if (j >= coin)
                    {
                        memo[j] += memo[j - coin];
                    }
                }
            }
            
            return memo[N];
        }
    }
}