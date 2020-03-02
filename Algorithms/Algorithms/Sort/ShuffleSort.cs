using System;

namespace Algorithms.Sort
{
    public class ShuffleSort
    {
        public static void Sort(int[] arr)
        {
            var N = arr.Length;
            
            for (var i = 0; i < N; i++)
            {
                var rnd = new Random();
                var random = rnd.Next(0, i + 1);

                var tmp = arr[i];
                arr[i] = arr[random];
                arr[random] = tmp;
            }
        }
    }
}