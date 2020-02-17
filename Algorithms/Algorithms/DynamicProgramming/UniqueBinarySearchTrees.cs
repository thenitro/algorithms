using System;

namespace Algorithms.DynamicProgramming
{
    public class UniqueBinarySearchTrees
    {
        public UniqueBinarySearchTrees()
        {
            Console.WriteLine(5 == Solution(3));
        }

        private int Solution(int n)
        {
            var G = new int[n + 1];
                G[0] = 1;
                G[1] = 1;

            for (var i = 2; i <=n; i++)
            {
                for (var j = 1; j <= i; j++)
                {
                    G[i] += G[j - 1] * G[i - j];
                }
            }

            return G[n];
        }
    }
}