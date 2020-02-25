using System;

namespace Algorithms.DynamicProgramming
{
    public class PartitionSetIntoTwoSubsets
    {
        public PartitionSetIntoTwoSubsets()
        {
            Console.WriteLine(1 == Solution(new []{ 1, 6, 11, 5 }));
            Console.WriteLine(1 == Solution(new []{ 3, 1, 4, 2, 2, 1 }));
        }

        private int Solution(int[] array)
        {
            var N = array.Length;
            
            var sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += array[i];
            }

            var dp = new bool[N + 1, sum + 1];
            for (int i = 0; i <= N; i++)
            {
                dp[i, 0] = true;
            }
            for (int i = 0; i <= N; i++)
            {
                dp[0, i] = false;
            }

            for (var i = 1; i <= N; i++)
            {
                for (var j = 1; j <= sum; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    
                    if (array[i - 1] <= j)
                    {
                        dp[i,j] |= dp[i - 1, j - array[i - 1]];
                    }
                }
            }

            var diff = int.MaxValue;

            for (var j = sum / 2; j>= 0; j--)
            {
                if (dp[N, j] == true)
                {
                    diff = sum - 2 * j;
                    break;
                }
            }

            return diff;
        }
    }
}