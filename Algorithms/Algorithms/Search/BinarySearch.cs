using System;
using System.Collections.Generic;

namespace Algorithms.Search
{
    public class BinarySearch
    {
        public static int Search(int[] array, int item)
        {
            var l = 0;
            var r = array.Length;
            
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