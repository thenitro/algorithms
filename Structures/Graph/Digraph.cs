namespace Algorithms.Structure.Graphs
{
    public class Digraph : Graph
    {
        public Digraph()
        {
            _directional = true;
        }

        public Digraph Reverse()
        {
            var graph = new Digraph();

            foreach (var vertex in Vertices)
            {
                foreach (var neighbor in GetNeighbors(vertex))
                {
                    graph.AddEdge(neighbor, vertex);
                }
            }

            return graph;
        }
    }
}