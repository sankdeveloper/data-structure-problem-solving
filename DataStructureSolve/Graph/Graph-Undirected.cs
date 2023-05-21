namespace ConsoleApp1.Graph;

public class Graph_Undirected
{
    public static void Main1(string[] args)
    {
        Dictionary<int, int[]> graph = new()
        {
            { 1, new[] { 2, 3, 4 } },
            { 2, new[] { 1, 5 } },
            { 5, new[] { 6, 7, 8 } },
            { 8, new[] { 4 } },
        };

        var visitedNodes = new HashSet<int>();
        bool pathExists = HasPath(graph, 1, 8, visitedNodes);
        Console.WriteLine(pathExists);
        Console.ReadKey();
    }

    private static bool HasPath(Dictionary<int, int[]> graph, int src, int dest, HashSet<int> hashSet)
    {
        if (src == dest) return true;
        if (hashSet.Contains(src)) return true;
        hashSet.Add(src);
        
        if (!graph.ContainsKey(src)) return false;

        foreach (var node in graph[src])
        {
            if (HasPath(graph, node, dest, hashSet))
            {
                return true;
            }
        }

        return false;
    }
}