using System;
using System.Linq;
using System.Linq.Expressions;

namespace Algorithms.Median
{
    public class Median
    {
        public static int MedianSort(int[] array)
        {
            Array.Sort(array);

            var halfArray = array.Length / 2;

            if (array.Length % 2 == 1)
            {
                return array[halfArray];
            }
            else
            {
                return (array[halfArray - 1] + array[halfArray]) / 2;
            }
        }

        public static int QuickSelectMedian(int[] array)
        {
            if (array.Length % 2 == 1)
            {
                return QuickSelectMedianHelper(array, array.Length / 2);
            }

            return (int)(0.5 + (QuickSelectMedianHelper(array, array.Length / 2 - 1) +
                                QuickSelectMedianHelper(array, array.Length / 2)));
        }

        private static int QuickSelectMedianHelper(int[] array, int k)
        {
            if (array.Length == 1)
            {
                return array[0];
            }
            
            var rnd = new Random();
            var pivot = array[rnd.Next(0, array.Length)];

            var lows = array.Where(x => x < pivot);
            var highs = array.Where(x => x > pivot);
            var pivots = array.Where(x => x == pivot);

            if (k < lows.Count())
            {
                return QuickSelectMedianHelper(lows.ToArray(), k);
            }
            else if (k < lows.Count() + pivots.Count())
            {
                return pivots.First();
            }
            else
            {
                return QuickSelectMedianHelper(highs.ToArray(), k - lows.Count() - pivots.Count());
            }
        }
    }
}