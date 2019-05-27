using System;
using System.Collections.Generic;

namespace Algorithms.Search
{
    public class BinarySearch
    {
        public static int Search(int[] array, int item, int left = -1, int right = -2)
        {
            var l = left == -1 ? 0 : left;
            var r = right == -1 ? array.Length : right;
            
            while (l < r)
            {
                var middle = (l + r) / 2;
                
                if (item > array[middle])
                {
                    l = middle + 1;
                    continue;
                } else if (item < array[middle])
                {
                    r = middle;
                    continue;
                }
                
                return middle;
            }
            
            return -1;
        } 
    }
}