namespace TestGraph
{
    public class Edge
    {
        public Node Node1 { get; set; }
        public Node Node2 { get; set; }

        private Edge(Node node1, Node node2)
        {
            Node1 = node1;
            Node2 = node2;
        }

        public Edge Initialize(Node node1, Node node2)
        {
            return new Edge(node1, node2);
        }

        public static Edge Initialize(string node1, string node2)
        {
            return new Edge(Node.Initialize(node1), Node.Initialize(node2));
        }

        public override string ToString()
        {
            return $"{Node1.Name} {Node2.Name}";
        }
    }
}