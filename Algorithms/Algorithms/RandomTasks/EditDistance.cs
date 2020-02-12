using System;

namespace Algorithms.RandomTests
{
    public class EditDistance
    {
        public EditDistance()
        {
            Console.WriteLine(1 == SolveRecursive("geek", "gesek"));
            Console.WriteLine(1 == SolveRecursive("cat", "cut"));
            Console.WriteLine(3 == SolveRecursive("sunday", "saturday"));
            
            Console.WriteLine(1 == SolveDp("geek", "gesek"));
            Console.WriteLine(1 == SolveDp("cat", "cut"));
            Console.WriteLine(3 == SolveDp("sunday", "saturday"));
        }
        
        private int SolveDp(string str1, string str2)
        {
            var memo = new int[str1.Length + 1, str2.Length + 1];

            for (var i = 1; i <= str1.Length; i++)
            {
                memo[i, 0] = i;
            }
            
            for (var i = 1; i <= str2.Length; i++)
            {
                memo[0, i] = i;
            }

            for (var i = 1; i <= str1.Length; i++)
            {
                for (var j = 1; j <= str2.Length; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                    {
                        memo[i, j] = memo[i - 1, j - 1];
                    }
                    else
                    {
                        memo[i, j] = 1 + MinThree(
                                         memo[i - 1, j],
                                         memo[i, j - 1],
                                         memo[i - 1, j - 1]);                        
                    }
                }
            }

            return memo[str1.Length, str2.Length];
        }

        private int SolveRecursive(string str1, string str2)
        {
            return SolveRecursiveHelper(str1, str2, str1.Length, str2.Length);
        }

        private int SolveRecursiveHelper(string str1, string str2, int m, int n)
        {
            if (m == 0)
            {
                return n;
            }

            if (n == 0)
            {
                return m;
            }
            
            if (str1[m - 1] == str2[n - 1])
            {
                return SolveRecursiveHelper(str1, str2, m - 1, n - 1);
            }

            return 1 + MinThree(
                       SolveRecursiveHelper(str1, str2, m, n - 1),
                       SolveRecursiveHelper(str1, str2, m - 1, n),
                       SolveRecursiveHelper(str1, str2, m - 1, n - 1));
        }

        private int MinThree(int x, int y, int z)
        {
            return Math.Min(x, Math.Min(y, z));
        }
    }
}