namespace Algorithms.Sort
{
    public class RadixQuicksort
    {
        public static void Sort(string[] array)
        {
            Sort(array, 0, array.Length - 1, 0);
        }

        private static void Sort(string[] a, int lo, int hi, int d)
        {
            if (hi <= lo)
            {
                return;
            }

            var lt = lo;
            var gt = hi;

            var v = CharAt(a[lo], d);
            var i = lo + 1;

            while (i <= gt)
            {
                var t = CharAt(a[i], d);
                if (t < v)
                {
                    Swap(a, lt++, i++);
                } else if (t > v)
                {
                    Swap(a, i, gt--);
                }
                else
                {
                    i++;
                }
            }

            Sort(a, lo, lt - 1, d);
            if (v >= 0)
            {
                Sort(a, lt, gt, d + 1);
            }
            Sort(a, gt + 1, hi, d);
        }
        
        private static int CharAt(string s, int d)
        {
            if (d < s.Length)
            {
                return s[d];
            }

            return -1;
        }
        
        private static void Swap(string[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}