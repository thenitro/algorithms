namespace Algorithms.Sort
{
    public class SelectionSort
    {
        public static void Sort(int[] arr)
        {
            var N = arr.Length;
            
            for (var i = 0; i < N; i++)
            {
                var min = i;

                for (var j = i + 1; j < N; j++)
                {
                    if (arr[min] > arr[j])
                    {
                        min = j;
                    }
                }

                var tmp = arr[i];
                arr[i] = arr[min];
                arr[min] = tmp;
            }
        }
    }
}