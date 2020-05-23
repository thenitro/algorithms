using System;

namespace Algorithms.Sort
{
    public class HeapSort
    {
        public static void Sort(int[] array)
        {
            var N = array.Length;

            for (var k = N / 2; k >= 1; k--)
            {
                Sink(array, k, N);
            }

            while (N > 1)
            {
                var tmp = array[1];
                array[1] = array[N];
                array[N] = tmp;

                Sink(array, 1, --N);
            }
        }

        private static void Sink(int[] array, int k, int N)
        {
            while (2 * k <= N)
            {
                var j = 2 * k;

                Console.WriteLine(array.Length + " " + j);
                
                if (j < N && array[j] < array[j + 1])
                {
                    j++;
                }

                if (array[k] > array[j])
                {
                    break;
                }

                var tmp = array[k];
                array[k] = array[j];
                array[j] = tmp;

                k = j;
            }
        }
    }
}