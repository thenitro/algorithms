using System;

namespace Algorithms.RandomTests
{
    public class SubsetSumProblem
    {
        public SubsetSumProblem()
        {
            Console.WriteLine(true == SolutionRecursive(new[] {3, 34, 4, 12, 5, 2}, 9));
            Console.WriteLine(true == SolutionRecursive(new[] {3, 34, 4, 12}, 9));
            
            Console.WriteLine(true == SolutionDp(new[] {3, 34, 4, 12, 5, 2}, 9));
            Console.WriteLine(true == SolutionDp(new[] {3, 34, 4, 12}, 9));
        }

        private bool SolutionDp(int[] set, int sum)
        {
            var dp = new bool[set.Length + 1, sum + 1];

            for (var i = 0; i <= set.Length; i++)
            {
                dp[i, 0] = true;
            }

            for (var i = 1; i <= set.Length; i++)
            {
                for (var j = 1; j <= sum; j++)
                {
                    if (j < set[i - 1])
                    {
                        dp[i, j] = dp[i - 1, j];
                    }

                    if (j >= set[i - 1])
                    {
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - set[i - 1]];
                    }
                }
            }

            return dp[set.Length, sum];
        }

        private void Print(bool[,] dp)
        {
            Console.WriteLine();
            
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    Console.Write(dp[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private bool SolutionRecursive(int[] set, int sum)
        {
            return SolutionRecursiveHelper(set, sum, 0);
        }

        private bool SolutionRecursiveHelper(int[] set, int sum, int currentElement)
        {
            if (sum == 0)
            {
                return true;
            }
            
            if (sum != 0 && currentElement >= set.Length)
            {
                return false;
            }

            return SolutionRecursiveHelper(set, sum - set[currentElement], currentElement + 1) || SolutionRecursiveHelper(set, sum, currentElement + 1);
        }
    }
}