using System.Collections.Generic;
using System.Linq;

namespace TestGraph
{
    public class Graph
    {
        public List<Edge> _edges;

        private Graph()
        {
            _edges = new List<Edge>();
        }

        private void Add(Edge edge)
        {
            _edges.Add(edge);
        }

        public List<Edge> GetEdgesForNode(Node node)
        {
            return _edges.Where(edge => edge.Node1.Equals(node) || edge.Node2.Equals(node)).ToList();
        }

        public static Graph Initialize(params Edge[] edges)
        {
            var graph = new Graph();
            foreach (var edge in edges)
            {
                graph.Add(edge);
            }
            return graph;
        }

        public List<Path> FindPaths(string nodeStart, string nodeFinish)
        {
            var start = Node.Initialize(nodeStart);
            var finish = Node.Initialize(nodeFinish);
            return Path.Build(this, start, finish);
        }

        public Path GetShortestPath(string nodeStart, string nodeFinish)
        {
            return FindPaths(nodeStart, nodeFinish).Min();
        }
    }
}