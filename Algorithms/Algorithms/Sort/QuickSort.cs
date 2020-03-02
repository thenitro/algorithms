using System;
using Algorithms.Search;

namespace Algorithms.Sort
{
    public class QuickSort
    {
        public static void Sort(int[] arr)
        {
            QuickSortHelper(arr, 0, arr.Length - 1);
        }

        private static void QuickSortHelper(int[] arr, int lo, int hi)
        {
            if (hi <= lo) return;

            var j = QuckSortPartition(arr, lo, hi);
            
            QuickSortHelper(arr, lo, j - 1);
            QuickSortHelper(arr, j + 1, hi);
        }

        private static int QuckSortPartition(int[] arr, int lo, int hi)
        {
            var pivot = arr[hi];

            var i = lo - 1;

            for (var j = lo; j < hi; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    
                    Swap(arr, i, j);
                }
            }
            
            Swap(arr, i + 1, hi);
            
            return i + 1;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}