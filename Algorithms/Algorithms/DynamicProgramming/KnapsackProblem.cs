using System;

namespace Algorithms.RandomTests
{
    public class KnapsackProblem
    {
        public KnapsackProblem()
        {
            Console.WriteLine(220 == SolutionRecursive(new [] { 60, 100, 120 }, new [] { 10, 20, 30 }, 50));
            Console.WriteLine(220 == SolutionDp(new [] { 60, 100, 120 }, new [] { 10, 20, 30 }, 50));
        }

        private int SolutionDp(int[] values, int[] weights, int capacity)
        {
            var dp = new int[values.Length + 1, capacity + 1];

            for (var i = 1; i <= values.Length; i++)
            {
                for (var w = 1; w <= capacity; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        dp[i, w] = 0;
                    } 
                    else if (weights[i - 1] <= w)
                    {
                        dp[i, w] = Math.Max(values[i - 1] + dp[i - 1, w - weights[i - 1]], dp[i - 1, w]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            return dp[values.Length, capacity];
        }
        
        private int SolutionRecursive(int[] values, int[] weights, int capacity) 
        {
            return SolutionHelper(values, weights, capacity, values.Length);
        }

        private int SolutionHelper(int[] values, int[] weights, int capacity, int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (capacity == 0)
            {
                return 0;
            }

            if (weights[n - 1] > capacity)
            {
                return SolutionHelper(values, weights, capacity, n - 1);
            }
            
            return Math.Max(
                values[n - 1] + SolutionHelper(values, weights, capacity - weights[n - 1], n - 1), 
                SolutionHelper(values, weights, capacity, n - 1));
        }
    }
}