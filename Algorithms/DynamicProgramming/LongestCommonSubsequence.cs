using System;

namespace Algorithms.DynamicProgramming
{
    public class LongestCommonSubsequence
    {
        public LongestCommonSubsequence()
        {
            Console.WriteLine(3 == Solution("ABCDGH", "AEDFHR"));
            Console.WriteLine(4 == Solution("AGGTAB", "GXTXAYB"));
        }

        private int Solution(string s1, string s2)
        {
            var dp = new int[s1.Length + 1, s2.Length + 1];

            for (var i = 1; i <= s1.Length; i++)
            {
                for (var j = 1; j <= i; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[s1.Length, s2.Length];
        }
    }
}