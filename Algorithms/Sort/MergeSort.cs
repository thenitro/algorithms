using System;

namespace Algorithms.Sort
{
    public class MergeSort
    {
        public static void Sort(int[] array)
        {
            var N = array.Length;
            var aux = new int[N];

            for (var sz = 1; sz < N; sz += sz)
            {
                for (var i = 0; i < N - sz; i += sz + sz)
                {
                    Merge(aux, array, i, Math.Min(i + sz + sz - 1, N - 1), i + sz - 1);
                }
            }
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