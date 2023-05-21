namespace ConsoleApp1.Graph;

public class Graph_ShortestPath
{
    public static void Main1(string[] args)
    {
        List<(int node1, int node2)> edges = new()
        {
            (1, 2),
            (2, 3),
            (3, 5),
            (1, 4),
            (4, 6),
            (6, 7),
            (5, 7),
            (4, 5)
        };

        //transform to adjecency Graph
        Dictionary<int, List<int>> adjecencyGraph = new();
        foreach (var edge in edges)
        {
            if (!adjecencyGraph.ContainsKey(edge.node1)) adjecencyGraph[edge.node1] = new List<int>();
            if (!adjecencyGraph.ContainsKey(edge.node2)) adjecencyGraph[edge.node2] = new List<int>();

            adjecencyGraph[edge.node1].Add(edge.node2);
            adjecencyGraph[edge.node2].Add(edge.node1);
        }

        HashSet<int> visited = new();
        int shortestNodPath = BFS(adjecencyGraph, 1, 7, visited);
        Console.WriteLine(shortestNodPath);
        Console.ReadKey();
    }

    private static int BFS(Dictionary<int, List<int>> graph, int source, int dest, HashSet<int> visited)
    {
        Queue<(int source, int index)> queue = new();
        queue.Enqueue((source, 0)); // push initial
        visited.Add(source);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();
            if (currentNode.source == dest) return currentNode.index;

            foreach (var node in graph[currentNode.source])
            {
                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    queue.Enqueue((node, currentNode.index + 1));
                }
            }
        }

        return -1;
    }
}