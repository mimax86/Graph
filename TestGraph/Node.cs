using System;

namespace TestGraph
{
    public class Node : IEquatable<Node>
    {
        public string Name { get; set; }

        private Node(string name)
        {
            Name = name;
        }

        public bool Equals(Node other)
        {
            return other != null && Name.Equals(other.Name);
        }

        public static Node Initialize(string name)
        {
            return new Node(name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}