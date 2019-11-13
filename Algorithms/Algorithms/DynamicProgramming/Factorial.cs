using System;

namespace Algorithms.Other
{
    public class Factorial
    {
        public static int Calculate(int n)
        {
            var memo = new int[n + 1];
                memo[0] = 1;

            for (var i = 1; i <= n; i++)
            {
                memo[i] = i * memo[i - 1];
            }
            
            return memo[n];
        }

        public static int CalculateRecursive(int n)
        {
            if (n < 1)
            {
                return 1;
            }
            
            return n * CalculateRecursive(n - 1);
        }
    }
}