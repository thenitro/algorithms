using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Principal;

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

            return (int)(0.5 * (QuickSelectMedianHelper(array, array.Length / 2 - 1) +
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

        public static int PickPivotMedian(int[] array)
        {
            if (array.Length < 5)
            {
                return MedianSort(array);
            }

            var chunks = PickPivotMedianHelper(array, 5);
            var fullChunks = chunks.Where(x => x.Count == 5).ToList();
                fullChunks.ForEach(x => x.Sort());
            
            var medians = new int[fullChunks.Count];
            var count = 0;
            
            fullChunks.ForEach(x =>
            {
                medians[count] = x[2];
                count++;
            });
            
            return QuickSelectMedian(medians);
        }

        private static List<List<int>> PickPivotMedianHelper(int[] array, int chunkSize)
        {
            var result = new List<List<int>>();
            var currentList = new List<int>();
            
            for (var i = 0; i < array.Length; i++)
            {
                currentList.Add(array[i]);
                
                if (currentList.Count == chunkSize)
                {
                    currentList = new List<int>();
                    result.Add(currentList);
                }
            }
            
            return result;
        }
    }
}