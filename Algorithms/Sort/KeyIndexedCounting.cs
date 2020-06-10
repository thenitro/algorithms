namespace Algorithms.Sort
{
    public class KeyIndexedCounting
    {
        public static void Sort(char[] array, int R)
        {
            var N = array.Length;
            var count = new int[R + 1];
            var aux = new char[N];

            for (var i = 0; i < N; i++)
            {
                count[array[i] + 1]++;
            }

            for (var r = 0; r < R; r++)
            {
                count[r + 1] += count[r];
            }

            for (var i = 0; i < N; i++)
            {
                aux[count[array[i]]++] = array[i];
            }

            for (var i = 0; i < N; i++)
            {
                array[i] = aux[i];
            }
        }
    }
}