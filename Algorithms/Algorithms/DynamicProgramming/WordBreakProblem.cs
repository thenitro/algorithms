using System;
using System.Linq;

namespace Algorithms.DynamicProgramming
{
    public class WordBreakProblem
    {
        public WordBreakProblem()
        {
            var dictionary = new string[]
            {
                "i",
                "like",
                "sam",
                "sung",
                "samsung",
                "mobile",
                "ice",
                "cream",
                "icecream",
                "man",
                "go",
                "mango",
            };
            
            Console.WriteLine(true == Solution(dictionary, "ilike"));
            Console.WriteLine(true == Solution(dictionary, "ilikesamsung"));
        }

        private bool Solution(string[] dictionary, string word)
        {
            var size = word.Length;
            if (size == 0)
            {
                return true;
            }
            
            var dp = new bool[size + 1];

            for (var i = 1; i <= size; i++)
            {
                if (dp[i] == false && dictionary.Contains(word.Substring(0, i)))
                {
                    dp[i] = true;
                }

                if (dp[i] == true)
                {
                    if (i == size)
                    {
                        return true;
                    }

                    for (var j = i + 1; j <= size; j++)
                    {
                        if (dp[j] == false && dictionary.Contains(word.Substring(i, j - i)))
                        {
                            dp[j] = true;
                        }

                        if (j == size && dp[j] == true)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}