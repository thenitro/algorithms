using System;

namespace Algorithms.RandomTests
{
    public class FindNumberWithoutDuplicate
    {
        public FindNumberWithoutDuplicate()
        {
            Console.WriteLine(1 == Solution(new []{ 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 }));
            Console.WriteLine(2 == Solution(new []{ 1, 1, 2, 3, 3, 4, 4, 5, 5, 6, 6 }));
            Console.WriteLine(3 == Solution(new []{ 1, 1, 2, 2, 3, 4, 4, 5, 5, 6, 6 }));
            Console.WriteLine(6 == Solution(new []{ 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6 }));
            Console.WriteLine(5 == Solution(new []{ 1, 1, 2, 2, 3, 3, 4, 4, 5, 6, 6 }));
        }

        private int Solution(int[] array)
        {
            var left = 0;
            var right = array.Length;

            var flip = false;
            
            while (left < right)
            {
                var middle = left + (right - left) / 2;
                
                var middleLeft = middle - 1;
                var middleRight = middle + 1;

                var middleValue = array[middle];
                var middleLeftValue = middleLeft < 0 ? -1 : array[middleLeft];
                var middleRightValue = middleRight >= array.Length ? -1 : array[middleRight];
                
                if (middleValue == middleLeftValue)
                {
                    if (flip)
                    {
                        right = middle;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                    
                    
                    flip = !flip;
                } 
                else if (middleValue == middleRightValue)
                {
                    if (flip)
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle;
                    }
                    
                    flip = !flip;
                }
                else
                {
                    return middleValue;
                }
            }
            
            return 0;
        }
    }
}