using System;
using System.Linq;
using System.Xml.Serialization;
using Algorithms.Concurency.Examples;
using Algorithms.Median;
using Algorithms.Other;
using Algorithms.Pathfinding;
using Algorithms.RandomTests;
using Algorithms.Search;
using Algorithms.Sort;
using Algorithms.Structure;
using Algorithms.Structure.Queue;
using Algorithms.Structure.Tree;

namespace Algorithms
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TestGraph();
            //new FindTheNumberOfIslands();
            //TestTrie();
            //TestExpressionTree();
            //TestGraphsPathfinding();
            //new MinimumSwapsToMakeToArraysIdentical();
            //new MinimumSwapsRequiredToSortAnArray();
            //TestPathfinding();
            //TestFindMedian();
            //TestSort();
            //TestRbTree();
            //TestAvlTree();
            //TestMonitor();
            //TestSemaphore();
            //TestMutex();
            //TestPriorityQueue();
            //TestLock();
            //TestFibonacci();
            //TestBinarySearchTree();
            //TestBinarySearch();
        }

        private static void TestTrie()
        {
            var trie = new Trie();
                trie.Insert("lol");
                
            Console.WriteLine(trie.Search("lol"));
            Console.WriteLine(trie.Search("lo"));
            Console.WriteLine(trie.Search("notlol"));
            
            trie.Insert("todelete");
            
            Console.WriteLine(trie.Search("todelete"));
            
            trie.Remove("todelete");
            
            Console.WriteLine(trie.Search("todelete"));
            Console.WriteLine(trie.Search("lol"));
            
            trie.Insert("h");
            trie.Insert("he");
            trie.Insert("hel");
            trie.Insert("hell");
            trie.Insert("hello");

            var suggestions = trie.GetSuggestions("h");

            foreach (var suggestion in suggestions)
            {
                Console.Write(suggestion + " ");
            }
            Console.WriteLine();}

        private static void TestExpressionTree()
        {
            var tree = new ExpressionTree("ab+ef*g*-");
                tree.PrintInorder(tree.Head);
        }

        private static void TestGraphsPathfinding()
        {
            var graph = new Graph(false);
                graph.AddEdge(0, 1);
                graph.AddEdge(0, 3);
                graph.AddEdge(1, 2);
                graph.AddEdge(3, 4);
                graph.AddEdge(3, 7);
                graph.AddEdge(4, 5);
                graph.AddEdge(4, 6);
                graph.AddEdge(4, 7);
                graph.AddEdge(5, 6);
                graph.AddEdge(6, 7);

            foreach (var i in new GraphsPathfinding().FindPath(graph, 0, 7))
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            foreach (var i in new GraphsPathfinding().FindPath(graph, 2, 6))
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        private static void TestPathfinding()
        {
            var pathfinding = new BfsPathfinding();

            var grid = new char[][]
            {
                new char[] {'0', '*', '0', 's'},
                new char[] {'*', '0', '*', '*'},
                new char[] {'0', '*', '*', '*'},
                new char[] {'d', '*', '*', '*'},
            };
            
            Console.WriteLine(pathfinding.FindPath(grid));
            
            var grid2 = new char[][]
            {
                new char[] {'0', '*', '0', 's'},
                new char[] {'*', '0', '*', '*'},
                new char[] {'0', '*', '*', '*'},
                new char[] {'d', '0', '0', '0'},
            };
            
            Console.WriteLine(pathfinding.FindPath(grid2));
        }

        private static void TestFindMedian()
        {
            var array = new int[] {4, 5, 6, 7, 1, 2, 3, 10, 11, 12, 20, 30, 40};
            
            Console.WriteLine(Median.Median.MedianSort(array));
            
            var array2 = new int[] {4, 5, 6, 7, 1, 2, 3, 10, 11, 12, 20, 30, 40};
            
            Console.WriteLine(Median.Median.QuickSelectMedian(array2));
            
            var array3 = new int[] {4, 5, 6, 7, 1, 2, 3, 10, 11, 12, 20, 30, 40};
            
            Console.WriteLine(Median.Median.PickPivotMedian(array3));
        }

        private static void TestRbTree()
        {
            var tree = new RedBlackTree();

            tree.Insert(7);
            tree.Insert(6);
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);
            
            tree.Print();
        }

        private static void TestMonitor()
        {
            //new MonitorsSyncExample();
            new MonitorCombinedExample();
        }

        private static void TestGraph()
        {
            var graph = new Graph(true);
            
            /*graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);
            
            graph.DFS(2);*/
            
            /*graph.AddEdge(5, 2);
            graph.AddEdge(5, 0);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1);

            var stack = graph.TopologicalSort();

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }*/
            
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            var result = graph.TransitiveClosure();

            for (var i = 0; i < result.GetLength(0); i++)
            {
                for (var j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
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

                tree.DeleteNode(tree.Head, 120);
                
                tree.Print();
                
            /*var binarySearchTree = new BinarySearchTree();
               
                binarySearchTree.Insert(100);
                binarySearchTree.Insert(99);
                binarySearchTree.Insert(101);
                binarySearchTree.Insert(80);
                binarySearchTree.Insert(120);
                binarySearchTree.Insert(140);
                binarySearchTree.Insert(150);
                binarySearchTree.Insert(160);
                binarySearchTree.Insert(170);
                
                binarySearchTree.Print();*/
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
        
        private static void TestSort()
        {
            var arr = new int[] {9, 8, 7, 6, 5, 4, 3, 2, 1};

            Sorting.BinarySort(arr);
            
            for (var i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);                
            }
            Console.WriteLine();
            
            arr = new int[] {3, 2, 1, 9, 8, 7, 6, 5, 4 };

            Sorting.QuickSort(arr);
            
            for (var i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);                
            }
            Console.WriteLine();
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