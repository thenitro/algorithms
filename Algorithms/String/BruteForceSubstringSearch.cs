namespace Algorithms.algorithms.Algorithms.String
{
    public class BruteForceSubstringSearch
    {
        public static int Search(string pat, string txt)
        {
            var i = txt.Length;
            var j = pat.Length;

            var N = txt.Length;
            var M = pat.Length;

            for (i = 0, j = 0; i < N && j < M; i++)
            {
                if (txt[i] == pat[j])
                {
                    j++;
                }
                else
                {
                    i -= j;
                    j = 0;
                }
            }

            if (j == M)
            {
                return i - M;
            }
            else
            {
                return N;
            }
        }
    }
}