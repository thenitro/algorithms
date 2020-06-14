namespace Algorithms.Sort
{      
    public class Msd
    {
        private const int R = 256;
        
        public static void Sort(string[] array)
        {
            var aux = new string[array.Length];
            Sort(array, aux, 0, array.Length, 0);
        }

        private static void Sort(string[] a, string[] aux, int lo, int hi, int d)
        {
            if (hi <= lo)
            {
                return;
            }

            var count = new int[R + 2];

            for (var i = lo; i < hi; i++)
            {
                count[CharAt(a[i], d) + 2]++;
            }

            for (var r = 0; r < R + 1; r++)
            {
                count[r + 1] += count[r];
            }

            for (var i = lo; i < hi; i++)
            {
                aux[count[CharAt(a[i], d) + 1]++] = a[i];
            }

            for (var i = lo; i < hi; i++)
            {
                a[i] = aux[i - lo];
            }

            for (var r = 0; r < R; r++)
            {
                Sort(a, aux, lo + count[r], lo + count[r + 1], d + 1);
            }
        }

        private static int CharAt(string s, int d)
        {
            if (d < s.Length)
            {
                return s[d];
            }

            return -1;
        }
    }
}