namespace Algorithms.Sort
{
    public class Lsd
    {
        public static void Sort(string[] array)
        {
            var W = array[0].Length;
            var R = 256;
            var N = array.Length;

            var aux = new string[N];

            for (var d = W - 1; d >= 0; d--)
            {
                var count = new int[R + 1];

                for (var i = 0; i < N; i++)
                {
                    count[array[i][d] + 1]++;
                }

                for (var r = 0; r < R; r++)
                {
                    count[r + 1] += count[r];
                }

                for (var i = 0; i < N; i++)
                {
                    aux[count[array[i][d]]++] = array[i];
                }

                for (var i = 0; i < N; i++)
                {
                    array[i] = aux[i];
                }
            }
        }
    }
}