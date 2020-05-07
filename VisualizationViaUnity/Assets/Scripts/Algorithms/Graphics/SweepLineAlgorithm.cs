using System.Collections.Generic;
using Algorithms.Structure;
using Algorithms.Structure.Heap;
using Algorithms.Structure.Tree;
using UnityEngine;

namespace Algorithms.Graphics
{
    public class SweepLineAlgorithm
    {
        public static List<Line> CalculateIntersections(List<Line> lines)
        {
            var result = new List<Line>();

            var heap = new MinHeap<Line>();

            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                
                if (line.IsVertical())
                {
                    heap.Push(line.A.X, line);
                } 
                else if (line.IsHorizontal())
                {
                    heap.Push(line.A.X, line);
                    heap.Push(line.B.X, line);
                }
            }

            var tree = new BinarySearchTree<Line>();
            
            while (heap.Count > 0)
            {
                var node = heap.Pop();
                var sweep = node.Priority;
                var line = node.Data;

                if (line.IsVertical())
                {
                    var lineA = new Line(new Point(int.MinValue, line.A.Y), new Point(int.MinValue, line.A.Y));
                    var lineB = new Line(new Point(int.MaxValue, line.B.Y), new Point(int.MaxValue, line.B.Y));

                    var list = tree.Range(lineA, lineB);

                    foreach (var lineResult in list)
                    {
                        result.Add(lineResult as Line);
                    }
                } 
                else if (sweep == line.A.X)
                {
                    tree.Insert(line);
                }
                else if (sweep == line.B.X)
                {
                    tree.Delete(line);
                }
                
                Debug.Log(line + " " + tree.PrintNode(tree.Head));
            }
            
            return result;
        }
    }    
}

