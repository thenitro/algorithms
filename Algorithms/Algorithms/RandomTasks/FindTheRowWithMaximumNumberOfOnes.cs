using System;
using System.Runtime.Remoting.Messaging;

namespace Algorithms.RandomTests
{
    public class FindTheRowWithMaximumNumberOfOnes
    {
        public FindTheRowWithMaximumNumberOfOnes()
        {
            var matrix = new[]
            {
                new[] {0, 1, 1, 1},
                new[] {0, 0, 1, 1},
                new[] {1, 1, 1, 1},
                new[] {0, 0, 0, 0},
            };
            
            Console.WriteLine(2 == SolutionBruteForce(matrix));
            Console.WriteLine(2 == SolutionBinarySearch(matrix));
        }

        private int SolutionBinarySearch(int[][] arr)
        {
            var maxRowIndex = 0;
            var max = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                var length = arr[i].Length - 1;
                var index = BinarySearchHelper(arr[i], 0, length);
                
                if (index != -1 && length - index > max)
                {
                    max = length - index;
                    maxRowIndex = i;
                } 
            }

            return maxRowIndex;
        }

        private int BinarySearchHelper(int[] arr, int lo, int hi)
        {
            while (hi >= lo)
            {
                var mid = lo + (hi - lo) / 2;
                
                if ((mid == 0 || arr[mid - 1] == 0) && arr[mid] == 1)
                {
                    return mid;
                }
                else if (arr[mid] == 0)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }
            
            return -1;
        }

        private int SolutionBruteForce(int[][] arr)
        {
            var result = 0;
            var row = 0;
            
            for (var y = 0; y < arr.Length; y++)
            {
                var count = 0;
                
                for (var x = 0; x < arr[y].Length; x++)
                {
                    if (arr[y][x] == 1)
                    {
                        count++;
                    }
                }

                if (count > result)
                {
                    result = count;
                    row = y;
                }
            }
            
            return row;
        }
    }
}