using System;

namespace TestGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = Graph.Initialize(
                Edge.Initialize("A", "B"),
                Edge.Initialize("B", "E"),
                Edge.Initialize("A", "C"),
                Edge.Initialize("C", "B"),
                Edge.Initialize("C", "F"),
                Edge.Initialize("B", "F"),
                Edge.Initialize("E", "G"),
                Edge.Initialize("F", "G"),
                Edge.Initialize("A", "D"),
                Edge.Initialize("D", "G"),
                Edge.Initialize("G", "H"));


            string start = "A";
            string finish = "H";

            //Task 1
            Console.WriteLine($"All paths: from {start} to {finish}");
            var paths = graph.FindPaths(start, finish);
            foreach (var path in paths)
            {
                Console.WriteLine(path);
            }

            //Task 2
            Console.WriteLine($"The shortest path from {start} to {finish}");
            var shortest = graph.GetShortestPath(start, finish);
            Console.WriteLine(shortest);

            Console.ReadLine();
        }
    }
}