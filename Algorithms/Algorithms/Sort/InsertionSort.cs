namespace Algorithms.Sort
{
    public class InsertionSort
    {
        public static void Sort(int[] arr)
        {
            var N = arr.Length;

            for (var i = 0; i < N; i++)
            {
                for (var j = i; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        var tmp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = tmp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}