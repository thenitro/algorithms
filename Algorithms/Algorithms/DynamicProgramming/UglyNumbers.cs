using System;

namespace Algorithms.Other
{
    public class UglyNumbers
    {
        public UglyNumbers()
        {
            Console.WriteLine(5832 == SolveStraightforward(150));
            Console.WriteLine(5832 == SolveTabulate(150));
        }

        private int SolveStraightforward(int n)
        {
            var i = 1;
            var count = 1;

            while (n > count)
            {
                i++;
                
                if (IsUgly(i))
                {
                    count++;
                }
            }

            return i;
        }

        private bool IsUgly(int n)
        {
            n = MaxDivide(n, 2);
            n = MaxDivide(n, 3);
            n = MaxDivide(n, 5);

            return n == 1;
        }

        private int MaxDivide(int a, int b)
        {
            while (a % b == 0)
            {
                a = a / b;
            }

            return a;
        }

        private int SolveTabulate(int n)
        {
            var memo = new int[n];

            var i2 = 0;
            var i3 = 0;
            var i5 = 0;

            var nextMultipleOf2 = 2;
            var nextMultipleOf3 = 3;
            var nextMultipleOf5 = 5;

            var nextUglyN = 1;

            memo[0] = 1;

            for (var i = 1; i < n; i++)
            {
                nextUglyN = Math.Min(nextMultipleOf2, Math.Min(nextMultipleOf3, nextMultipleOf5));
                memo[i] = nextUglyN;

                if (nextUglyN == nextMultipleOf2)
                {
                    i2 = i2 + 1;
                    nextMultipleOf2 = memo[i2] * 2;
                }

                if (nextUglyN == nextMultipleOf3)
                {
                    i3 = i3 + 1;
                    nextMultipleOf3 = memo[i3] * 3;
                }

                if (nextUglyN == nextMultipleOf5)
                {
                    i5 = i5 + 1;
                    nextMultipleOf5 = memo[i5] * 5;
                }
            }

            return nextUglyN;
        }
    }
}