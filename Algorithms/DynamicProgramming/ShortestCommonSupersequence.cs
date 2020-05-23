using System;

namespace Algorithms.DynamicProgramming
{
    public class ShortestCommonSupersequence
    {
        public ShortestCommonSupersequence()
        {
            Console.WriteLine(5 == Solution("geek", "eke"));
            Console.WriteLine(9 == Solution("AGGTAB", "GXTXAYB"));
        }

        public int Solution(string str1, string str2)
        {
            return str1.Length + str2.Length - Lcs(str1, str2);
        }

        private int Lcs(string str1, string str2)
        {
            var N = str1.Length + 1;
            var M = str2.Length + 1;

            var dp = new int[N, M];

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else
                    {
                        if (str1[i - 1] == str2[j - 1])
                        {
                            dp[i, j] = dp[i - 1, j - 1] + 1;
                        }
                        else
                        {
                            dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                        }
                    }
                }
            }

            return dp[N - 1, M - 1];
        }
    }
}