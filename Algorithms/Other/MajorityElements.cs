namespace Algorithms.Other
{
    public class MajorityElements
    {
        public static int BoyerMoore(int[] array)
        {
            var size = array.Length;
            if (size == 0)
            {
                return 0;
            }

            var majorityElement = array[0];
            var count = 1;

            for (var i = 1; i < size; i++)
            {
                if (majorityElement == array[i])
                {
                    count++;
                } 
                else if (count == 0)
                {
                    majorityElement = array[i];
                    count = 1;
                }
                else
                {
                    count--;
                }
            }

            return majorityElement;
        }
    }
}