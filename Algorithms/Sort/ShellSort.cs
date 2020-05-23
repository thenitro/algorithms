namespace Algorithms.Sort
{
    public class ShellSort
    {
        public static void Sort(int[] arr)
        {
            var N = arr.Length;
            
            var h = 1;
            while (h < N / 3)
            {
                h = 3 * h + 1;
            }

            while (h >= 1)
            {
                for (var i = h; i < N; i++)
                {
                    for (var j = i; j >= h && arr[j] < arr[j - h]; j -= h)
                    {
                        var tmp = arr[j];
                        arr[j] = arr[j - h];
                        arr[j - h] = tmp;
                    }
                }
                
                h = h / 3;
            }
        }
    }
}