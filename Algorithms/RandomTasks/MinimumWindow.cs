using System;
using System.Collections.Generic;

namespace Algorithms.RandomTests
{
    public class MinimumWindow
    {
        public MinimumWindow()
        {
            Console.WriteLine("ZONINTE" == Solution("AMAZONINTERVIEW", "OZONE"));
            Console.WriteLine("EZON" == Solution("ZAMAZONINTEZONERVIEW", "OZONE"));
            Console.WriteLine(string.Empty == Solution("ZAMAZONINTEZONERVIEW", "LOL"));
        }
        
        private string Solution(string s, string t)
        {
            var dict = ConvertToDict(t);
            
            var pairs = new List<Tuple<int, int>>();

            var left = -1;
            var right = -1;

            for (var i = 0 ; i < s.Length; i++) 
            {
                if (dict.Contains(s[i]))
                {
                    if (left == -1)
                    {
                        left = i;
                    }
                    
                    dict.Remove(s[i]);
                    
                    if (dict.Count == 0)
                    {
                        right = i + 1;
                        pairs.Add(new Tuple<int, int>(left, right));
                        
                        dict = ConvertToDict(t);

                        i = left + 1;
                        left = -1;
                        right = -1;
                    }
                }
            }

            if (pairs.Count == 0)
            {
                return string.Empty;
            }

            var min = int.MaxValue;
            
            foreach (var pair in pairs)
            {
                var current = pair.Item2 - pair.Item1;
                if (current < min)
                {
                    min = current;
                    left = pair.Item1;
                    right = pair.Item2;
                }
            }
            
            return s.Substring(left, right - left);
        }

        private HashSet<char> ConvertToDict(string t)
        {
            var dict = new HashSet<char>();
            
            foreach (var ct in t)
            {
                dict.Add(ct);
            }

            return dict;
        }
    }
}