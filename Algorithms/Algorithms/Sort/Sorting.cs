using System;
using Algorithms.Search;

namespace Algorithms.Sort
{
    public class Sorting
    {
        public static void BinarySort(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                var current = arr[i];
                var location = BinarySearch.Search(arr, current, 0, i) + 1;

                Array.Copy(arr, location, arr, location + 1, i - location);

                arr[location] = current;
            }
        }

        public static void QuickSort(int[] arr)
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