﻿using System;
using Algorithms.Search;
using Algorithms.Sort;
using Algorithms.Structure.Tree;

namespace Algorithms
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TestBinarySearchTree();
            //TestBinarySort();
            //TestBinarySearch();
        }

        private static void TestBinarySearchTree()
        {
            var tree = new BinarySearchTree();
                tree.Insert(100);
            
            tree.Insert(99);
            tree.Insert(101);
            tree.Insert(80);
            tree.Insert(120);
            
            tree.Print();
            
            Console.WriteLine(tree.Has(80));
            Console.WriteLine(tree.Has(121));
        }
        
        private static void TestBinarySort()
        {
            var arr = new int[] {9, 8, 7, 6, 5, 4, 3, 2, 1};

            BinarySort.Sort(arr);
            
            for (var i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);                
            }
        }

        private static void TestBinarySearch()
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