using System;
using System.Collections.Generic;

namespace Algorithms.RandomTests.CrackingCodingInterview
{
    public class Task11
    {
        public Task11()
        {
            Console.WriteLine(true == Naive("abcd"));
            Console.WriteLine(false == Naive("abcda"));
            
            Console.WriteLine(true == Naive2("abcd"));
            Console.WriteLine(false == Naive2("abcda"));
            
            Console.WriteLine(true == NoDataStruct("abcd"));
            Console.WriteLine(false == NoDataStruct("abcda"));
        }

        public bool Naive(string s)
        {
            var set = new HashSet<char>();

            foreach (var c in s)
            {
                if (set.Contains(c))
                {
                    return false;
                }
                
                set.Add(c);
            }
            
            return true;
        }
        
        public bool Naive2(string s)
        {
            var array = new int[26];

            foreach (var c in s)
            {
                var index = c - 'a';

                if (array[index] != 0)
                {
                    return false;
                }
                
                array[index] = 1;
            }

            return true;
        }

        public bool NoDataStruct(string s)
        {
            for (var i = 0; i < s.Length; i++)
            {
                for (var j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}