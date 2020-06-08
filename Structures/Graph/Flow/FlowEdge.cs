using System;

namespace Algorithms.algorithms.Structures.Graph.Flow
{
    public class FlowEdge
    {
        public int From { get; }
        public int To { get; }
        
        public double Capacity { get; }
        public double Flow { get; private set; }

        public FlowEdge(int v, int w, double capacity)
        {
            From = v;
            To = w;
            Capacity = capacity;
        }

        public int Other(int vertex)
        {
            if (vertex == From)
            {
                return To;
            }

            if (vertex == To)
            {
                return From;
            }

            throw new ArgumentOutOfRangeException("vertex", "is not part of this edge");
            return 0;
        }

        public double ResidualCapacityTo(int vertex)
        {
            if (vertex == From)
            {
                return Flow;
            } 
            else if (vertex == To)
            {
                return Capacity - Flow;
            }
            else
            {
                throw new ArgumentOutOfRangeException("vertex", "is not part of this edge");
            }
        }
        
        public void AddResidualFlowTo(int vertex, double delta)
        {
            if (vertex == From)
            {
                Flow -= delta;
            }
            else if (vertex == To)
            {
                Flow += delta;
            }
            else
            {
                throw new ArgumentOutOfRangeException("vertex", "is not part of this edge");
            }
        }
    }
}