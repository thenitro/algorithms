using System;

namespace Algorithms.RandomTests.CrackingCodingInterview
{
    public class Task13
    {
        public Task13()
        {
            Console.WriteLine("Mr%20John%20Smith" == Naive("Mr John Smith      "));
            Console.WriteLine("%20Mr%20John%20Smith" == Naive("     Mr   John   Smith      "));
        }

        private string Naive(string str)
        {
            var startIndex = 0;

            while (str.Length > startIndex)
            {
                if (str[startIndex] == ' ')
                {
                    var endIndex = startIndex;

                    while (str.Length > endIndex && str[endIndex] == ' ')
                    {
                        endIndex++;
                    }
                    
                    if (endIndex == str.Length)
                    {
                        str = str.Substring(0, startIndex);
                    }
                    else
                    {
                        str = str.Substring(0, startIndex) + "%20" + str.Substring(endIndex, str.Length - endIndex);
                    }
                    
                    startIndex = 0;
                }
                else
                {
                    startIndex++;
                }
            }

            return str;
        }
    }
}