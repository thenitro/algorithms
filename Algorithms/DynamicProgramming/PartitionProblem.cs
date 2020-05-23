using System;

namespace Algorithms.DynamicProgramming
{
    public class PartitionProblem
    {
        public PartitionProblem()
        {
            Console.WriteLine(true == SolutionRecursive(new int[] {1, 5, 11, 5}));
            Console.WriteLine(false == SolutionRecursive(new int[] {1, 5, 3}));

            Console.WriteLine(true == SolutionDp(new int[] {1, 5, 11, 5}));
            Console.WriteLine(false == SolutionDp(new int[] {1, 5, 3}));
        }

        private bool SolutionDp(int[] array)
        {
            var N = array.Length;
            var sum = 0;
            
            for (var i = 0; i < N; i++) 
            {
                sum += array[i];
            }

            if (sum % 2 != 0)
            {
                return false;
            }

            var dp = new bool[sum / 2 + 1, N + 1];

            for (var i = 0; i <= N; i++)
            {
                dp[0, i] = true;
            }

            for (var i = 1; i <= sum / 2; i++)
            {
                for (var j = 1; j <= N; j++)
                {
                    dp[i, j] = dp[i, j - 1];

                    if (i >= array[j - 1])
                    {
                        dp[i, j] = dp[i, j - 1] || dp[i - array[j - 1], j - 1];
                    }
                }
            }

            return dp[sum / 2, N];
        }

        private bool SolutionRecursive(int[] array)
        {
            var N = array.Length;
            var sum = 0;

            for (var i = 0; i < N; i++)
            {
                sum += array[i];
            }

            if (sum % 2 != 0)
            {
                return false;
            }
            
            return SolutionRecursiveHelper(array, N, sum / 2);
        }

        private bool SolutionRecursiveHelper(int[] array, int element, int sum)
        {
            if (sum == 0)
            {
                return true;
            }

            if (element == 0)
            {
                return false;
            }

            if (array[element - 1] > sum)
            {
                return SolutionRecursiveHelper(array, element - 1, sum);
            }

            return SolutionRecursiveHelper(array, element - 1, sum) ||
                   SolutionRecursiveHelper(array, element - 1, sum - array[element - 1]);
        }
    }
}