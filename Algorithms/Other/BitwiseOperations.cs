namespace Algorithms.Other
{
    public class BitwiseOperations
    {
        public static bool IsPowerOfTwo(int x)
        {
            return (x && !(x & (x - 1) == 0));
        }
    }
}