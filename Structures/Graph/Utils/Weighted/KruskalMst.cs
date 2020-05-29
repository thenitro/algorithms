using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.algorithms.Structures.Graph.Weighted;
using Algorithms.Structure.UnionFind;

namespace Algorithms.algorithms.Structures.Graph.Utils.Weighted
{
    public class KruskalMst
    {
        private Queue<Edge> _mst;

        public KruskalMst(EdgeWeightedGraph graph)
        {
            _mst = new Queue<Edge>();

            var edges = graph.Edges();
            Array.Sort(edges, (edge, edge1) => edge.CompareTo(edge1));
            
            var vertices = graph.Vertices();
            var uf = new QuickFind(vertices.Length);

            var count = 0;
            
            while (count < edges.Length && _mst.Count < vertices.Length - 1)
            {
                var edge = edges[count];
                
                var v = edge.Either();
                var w = edge.Other(v);

                if (!uf.Connected(v, w))
                {
                    uf.Union(v, w);
                    _mst.Enqueue(edge);
                }

                count++;
            }
        }

        public Edge[] Edges()
        {
            return _mst.ToArray();
        }
    }
}