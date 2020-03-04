using System;

namespace Algorithms.Sort
{
    public class MergeSort
    {
        public static void Sort(int[] array)
        {
            var aux = new int[array.Length];
            SortHelper(aux, array, 0, array.Length - 1);
        }

        private static void SortHelper(int[] aux, int[] array, int lo, int hi)
        {
            if (hi <= lo)
            {
                return;
            }

            var middle = lo + (hi - lo) / 2;
            
            SortHelper(aux, array, lo, middle);
            SortHelper(aux, array, middle + 1, hi);
            
            Merge(aux, array, lo, hi, middle);
        }

        private static void Merge(int[] aux, int[] array, int lo, int hi, int mid)
        {
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = array[k];
            }

            var i = lo;
            var j = mid + 1;

            for (var k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    array[k] = aux[j++];
                } else if (j > hi)
                {
                    array[k] = aux[i++];
                }
                else if (aux[j] < aux[i])
                {
                    array[k] = aux[j++];
                }
                else
                {
                    array[k] = aux[i++];
                }
            }
        }
    }
}