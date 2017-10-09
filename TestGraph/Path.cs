using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGraph
{
    public class Path : IComparable<Path>
    {
        private List<Node> _path;

        public Node Tail
        {
            get { return _path.Last(); }
        }

        public int Length
        {
            get { return _path.Count; }
        }

        private Path(Node root)
        {
            _path = new List<Node>();
            _path.Add(root);
        }

        private Path(List<Node> path)
        {
            _path = new List<Node>(path);
        }

        public Path Add(Edge edge)
        {
            var node = edge.Node1.Equals(Tail) ? edge.Node2 : edge.Node1;
            if (_path.Contains(node))
                return null;
            var newPath = new Path(_path);
            newPath.Add(node);
            return newPath;
        }

        public void Add(Node node)
        {
            _path.Add(node);
        }

        public int CompareTo(Path other)
        {
            return Length.CompareTo(other.Length);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("Path: ");
            foreach (var node in _path)
            {
                builder.Append($" {node.Name} ");
            }
            return builder.ToString();
        }

        public static List<Path> Build(Graph graph, Node start, Node finish)
        {
            var path = new Path(start);
            return Enrich(path, finish, graph);
        }

        private static List<Path> Enrich(Path path, Node finish, Graph graph)
        {
            var edges = graph.GetEdgesForNode(path.Tail);
            var paths = new List<Path>();
            foreach (var edge in edges)
            {
                var newPath = path.Add(edge);
                if (newPath != null)
                {
                    if (newPath.Tail.Equals(finish))
                        paths.Add(newPath);
                    else
                        paths.AddRange(Enrich(newPath, finish, graph));
                    
                }
            }
            return paths;
        }
    }
}