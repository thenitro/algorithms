using System;
using System.Collections.Generic;

namespace Algorithms.Search
{
    public class BinarySearch
    {
        public static int Search(int[] array, int item, int left = -1, int right = -2)
        {
            var l = left == -1 ? 0 : left;
            var r = right == -2 ? array.Length : right;
            
            while (l <= r)
            {
                var middle = l + (r - l) / 2;
                
                if (item > array[middle])
                {
                    l = middle + 1;
                } 
                else if (item < array[middle])
                {
                    r = middle - 1;
                }
                else
                {
                    return middle;
                }
            }
            
            return -1;
        } 
    }
}