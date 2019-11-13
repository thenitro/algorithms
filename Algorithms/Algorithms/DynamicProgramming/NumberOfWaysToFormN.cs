using System;

namespace Algorithms.Other
{
    public class NumberOfWaysToFormN
    {
        public NumberOfWaysToFormN()
        {
            Console.WriteLine(1 == SolveRecursive(1));
            Console.WriteLine(1 == SolveMemo(1));
            
            Console.WriteLine(1 == SolveRecursive(2));
            Console.WriteLine(1 == SolveMemo(2));
            
            Console.WriteLine(2 == SolveRecursive(3));
            Console.WriteLine(2 == SolveMemo(3));
            
            Console.WriteLine(3 == SolveRecursive(4));
            Console.WriteLine(3 == SolveMemo(4));
            
            Console.WriteLine(8 == SolveRecursive(6));
            Console.WriteLine(8 == SolveMemo(6));
        }

        private int SolveRecursive(int n)
        {
            if (n < 0)
            {
                return 0;
            }

            if (n == 0)
            {
                return 1;
            }
            
            return SolveRecursive(n - 1) + SolveRecursive(n - 3) + SolveRecursive(n - 5);
        }

        private int SolveMemo(int n)
        {
            var memo = new int[n + 1];

            return SolveMemoHelper(memo, n);
        }

        private int SolveMemoHelper(int[] memo, int n)
        {
            if (n < 0)
            {
                return 0;
            }

            if (n == 0)
            {
                return 1;
            }
            
            if (memo[n] == 0)
            {
                memo[n] = SolveMemoHelper(memo, n - 1) + SolveMemoHelper(memo, n - 3) + SolveMemoHelper(memo, n - 5);
            }

            return memo[n];
        }
    }
}