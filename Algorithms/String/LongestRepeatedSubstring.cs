using System;

namespace Algorithms.algorithms.Algorithms.String
{
    public class LongestRepeatedSubstring
    {
        public static string Find(string s)
        {
            var N = s.Length;

            var suffixes = new string[N];
            for (var i = 0; i < N; i++)
            {
                suffixes[i] = s.Substring(i, N - i);
            }
            
            Array.Sort(suffixes);

            var lrs = string.Empty;
            for (var i = 0; i < N - 1; i++)
            {
                var len = LongestCommonPrefix(suffixes[i], suffixes[i + 1]);
                if (len > lrs.Length)
                {
                    lrs = suffixes[i].Substring(0, len);
                }
            }

            return lrs;
        }

        private static int LongestCommonPrefix(string a, string b)
        {
            var index = 0;
            
            while (GetCharAt(a, index) == GetCharAt(b, index))
            {
                index++;
            }

            return index;
        }

        private static int GetCharAt(string s, int i)
        {
            if (i >= s.Length)
            {
                return -1;
            }

            return s[i];
        }
    }
}