using System;
using System.Collections.Generic;

namespace Algorithms.RandomTests.CrackingCodingInterview
{
    public class Task12
    {
        public Task12()
        {
            Console.WriteLine(true == Naive("abc", "cba"));
            Console.WriteLine(true == Naive("abca", "cbaa"));
            Console.WriteLine(false == Naive("abc", "cbd"));
            Console.WriteLine(false == Naive("abca", "cbd"));
            Console.WriteLine(false == Naive("abca", "cba"));
            Console.WriteLine(false == Naive("abc", "abca"));
        }

        private bool Naive(string s1, string s2)
        {
            var hash1 = new Dictionary<char, int>();
            var hash2 = new Dictionary<char, int>();

            foreach (var c in s1)
            {
                hash1[c] = hash1.ContainsKey(c) ? hash1[c] + 1 : 1;
            }
            
            foreach (var c in s2)
            {
                hash2[c] = hash2.ContainsKey(c) ? hash2[c] + 1 : 1;
            }

            foreach (var c in s1)
            {
                if (!hash2.ContainsKey(c))
                {
                    return false;
                }

                hash2[c] -= 1;

                if (hash2[c] <= 0)
                {
                    hash2.Remove(c);
                }
            }

            foreach (var c in s2)
            {
                if (!hash1.ContainsKey(c))
                {
                    return false;
                }

                hash1[c] -= 1;

                if (hash1[c] <= 0)
                {
                    hash1.Remove(c);
                }
            }
            
            return hash1.Count == 0 && hash2.Count == 0;
        }
    }
}