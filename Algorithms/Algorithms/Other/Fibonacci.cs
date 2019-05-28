using System.Collections.Generic;

namespace Algorithms.Other
{
    public class Fibonacci
    {
        public static int[] Create(int size)
        {
            var result = new int[size];
            
            if (size == 0)
            {
                return result;
            }

            result[0] = 0;

            if (size == 1)
            {
                return result;
            }
            
            result[1] = 1;

            for (var i = 2; i < size; i++)
            {
                result[i] = result[i - 2] + result[i - 1];
            }

            return result;
        }
    }
}