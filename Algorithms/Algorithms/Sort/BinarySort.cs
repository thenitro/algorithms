using System;
using Algorithms.Search;

namespace Algorithms.Sort
{
    public class BinarySort
    {
        public static void Sort(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                var current = arr[i];
                var location = BinarySearch.Search(arr, current, 0, i) + 1;

                Array.Copy(arr, location, arr, location + 1, i - location);

                arr[location] = current;
            }
        }
    }
}