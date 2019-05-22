using System;
using Algorithms.Search;

namespace Algorithms
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TestBinarySearch();
        }

        public static void TestBinarySearch()
        {
            Console.WriteLine(2 == BinarySearch.Search(new int[] { 1,2,3,4,5 }, 3));
            Console.WriteLine(1 == BinarySearch.Search(new int[] { 1,3,4,5,6,7 }, 3));
            Console.WriteLine(2 == BinarySearch.Search(new int[] { 1,2,3,4,5,6 }, 3));
            Console.WriteLine(1 == BinarySearch.Search(new int[] { 1,2,3,4,5 }, 2));
            Console.WriteLine(1 == BinarySearch.Search(new int[] { 1,2,3,4,5,6 }, 2));
            Console.WriteLine(4 == BinarySearch.Search(new int[] { 1,2,3,4,5 }, 5));
            Console.WriteLine(4 == BinarySearch.Search(new int[] { 1,2,3,4,5,6 }, 5));
            Console.WriteLine(0 == BinarySearch.Search(new int[] { 1,2,3,4,5,6 }, 1));
            Console.WriteLine(-1 == BinarySearch.Search(new int[] { }, 3));
            Console.WriteLine(-1 == BinarySearch.Search(new int[] { 1 }, 3));
            Console.WriteLine(0 == BinarySearch.Search(new int[] { 1 }, 1));
        }
    }
}