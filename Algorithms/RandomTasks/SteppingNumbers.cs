using System;
using System.Collections.Generic;

namespace Algorithms.RandomTests
{
    public class SteppingNumbers
    {
        public SteppingNumbers()
        {
            var result = Solution(0, 21);
            Console.WriteLine(string.Join(",", result));
            
            var result2 = Solution(10, 15);
            Console.WriteLine(string.Join(",", result2));
        }

        private List<int> Solution(int n, int m)
        {
            var result = new List<int>();

            for (var i = n; i <= m; i++)
            {
                if (IsStepNumber(i))
                {
                    result.Add(i);
                }
            }
            
            return result;
        }

        private bool IsStepNumber(int n)
        {
            var prevDigit = -1;

            while (n > 0)
            {
                var currDigit = n % 10;

                if (prevDigit != -1)
                {
                    if (Math.Abs(currDigit - prevDigit) != 1)
                    {
                        return false;
                    }
                }

                n /= 10;
                prevDigit = currDigit;
            }

            return true;
        }
    }
}