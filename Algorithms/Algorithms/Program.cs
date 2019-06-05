using System;
using System.Linq;
using Algorithms.Concurency.Examples;
using Algorithms.Other;
using Algorithms.Search;
using Algorithms.Sort;
using Algorithms.Structure.Queue;
using Algorithms.Structure.Tree;

namespace Algorithms
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TestSemaphore();
            //TestMutex();
            //TestPriorityQueue();
            //TestLock();
            //TestAvlTree();
            //TestFibonacci();
            //TestBinarySearchTree();
            //TestBinarySort();
            //TestBinarySearch();
        }

        private static void TestSemaphore()
        {
            new SemaphoreExample();
        }

        private static void TestMutex()
        {
            //new LocalMutexExample();
            new TimeoutMutexExample();
        }

        private static void TestPriorityQueue()
        {
            var queue = new PriorityQueue<int>();
            
            queue.Enqueue(5);
            queue.Enqueue(1);
            queue.Enqueue(0);
            queue.Enqueue(2);
            queue.Enqueue(7);
            
            Console.WriteLine(queue.ToString());
            
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            
            Console.WriteLine(queue.ToString());
            
            queue.Enqueue(5);
            queue.Enqueue(1);
            queue.Enqueue(0);
            queue.Enqueue(2);
            queue.Enqueue(7);
            
            Console.WriteLine(queue.ToString());
        }

        private static void TestLock()
        {
            new LockExample();
        }

        private static void TestAvlTree()
        {
            var tree = new AvlTree();
                
                tree.Insert(100);
                tree.Insert(99);
                tree.Insert(101);
                tree.Insert(80);
                tree.Insert(120);
                tree.Insert(140);
                tree.Insert(150);
                tree.Insert(160);
                tree.Insert(170);
                
                tree.Print();
                
            var binarySearchTree = new BinarySearchTree();
               
                binarySearchTree.Insert(100);
                binarySearchTree.Insert(99);
                binarySearchTree.Insert(101);
                binarySearchTree.Insert(80);
                binarySearchTree.Insert(120);
                binarySearchTree.Insert(140);
                binarySearchTree.Insert(150);
                binarySearchTree.Insert(160);
                binarySearchTree.Insert(170);
                
                binarySearchTree.Print();
        }

        private static void TestFibonacci()
        {
            Fibonacci.Create(0).ToList().ForEach(x => Console.Write(x + " ")); Console.WriteLine();
            Fibonacci.Create(1).ToList().ForEach(x => Console.Write(x + " ")); Console.WriteLine();
            Fibonacci.Create(2).ToList().ForEach(x => Console.Write(x + " ")); Console.WriteLine();
            Fibonacci.Create(10).ToList().ForEach(x => Console.Write(x + " ")); Console.WriteLine();
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
            
            Console.WriteLine(tree.Has(100));
            tree.Delete(100);
            Console.WriteLine(tree.Has(100));
            
            tree.Print();
            
            tree.TraverseNode(tree.Head, node => { Console.Write(node.Value + ", ");});
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