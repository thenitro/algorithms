using System;

namespace Algorithms.DynamicProgramming
{
    public class OptimalStrategyForAGame
    {
        public OptimalStrategyForAGame()
        {
            Console.WriteLine(15 == Solution(new [] { 5, 3, 7, 10 }));
            Console.WriteLine(22 == Solution(new [] { 8, 15, 3, 7 }));
        }

        private int Solution(int[] array)
        {
            var n = array.Length;
            var dp = new int[n, n];

            for (var gap = 0; gap < n; gap++)
            {
                var i = 0;
                
                for (var j = gap; j < n; i++, j++)
                {
                    var x = ((i + 2) <= j) ? dp[i + 2, j] : 0;
                    var y = ((i + 1) <= j - 1) ? dp[i + 1, j - 1] : 0;
                    var z = (i <= j - 2) ? dp[i, j - 2] : 0;

                    dp[i, j] = Math.Max(array[i] + Math.Min(x, y), array[j] + Math.Min(y, z));
                }
            }

            return dp[0, n - 1];
        }
    }
    
    
}