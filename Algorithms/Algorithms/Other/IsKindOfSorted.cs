using System;

namespace Algorithms.Other
{
    public class IsKindOfSorted
    {
        public IsKindOfSorted()
        {
            Console.WriteLine(false == Solution(new []{ 1, 2, 3, 5, 6, 7, 8, 9, 4 }));
            Console.WriteLine(false == Solution(new []{ 1, 2, 3, 5, 6, 8, 9, 7, 4 }));
            Console.WriteLine(true == Solution(new []{ 1, 2, 3, 9, 5, 6, 7, 8, 4 }));
            Console.WriteLine(false == Solution(new []{ 1, 7, 3, 9, 5, 6, 2, 8, 4 }));
            Console.WriteLine(true == Solution(new []{ 1, 9, 4 }));
        }
        
        private bool Solution(int[] arr)
        {
            var min = int.MaxValue;
            var max = int.MinValue;

            for (var i = 0; i < arr.Length; i++)
            {
                min = Math.Min(min, arr[i]);
                max = Math.Max(max, arr[i]);
            }

            var count = 0;

            for (int i = min, j = 0; i <= max; i++, j++)
            {
                if (arr[j] != i)
                {
                    count++;
                }
            }

            return count == 2;
        }
    }
}