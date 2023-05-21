namespace ConsoleApp1.Graph;

public class Graph_MaxComponentCount
{
    public static void Main1(string[] args)
    {
        Dictionary<int, int[]> graph = new()
        {
            { 1, new[] { 2, 3, 4 } },
            { 2, new[] { 5 } },
            { 30, new[] { 100 } },
            { 40, new[] { 200 } },
            { 5, new[] { 6, 7, 8 } }
        };
        Console.WriteLine(CountMaxNumberOfComponents(graph));
        Console.ReadKey();
    }

    private static int CountMaxNumberOfComponents(Dictionary<int, int[]> graph)
    {
        int max = 0;
        HashSet<int> visited = new();
        foreach (var node in graph.Select(_=>_.Key))
        {
            int count = CounComponentsEdges(graph, node, visited);
            if (count > max) max = count;
        }

        return max;
    }

    private static int CounComponentsEdges(Dictionary<int, int[]> graph, int node, HashSet<int> visited)
    {
        if (visited.Contains(node)) return 0;
        visited.Add(node);
        if (!graph.ContainsKey(node)) return 0;

        int count = 1;
        foreach (var subNode in graph[node])
        {
            count += CounComponentsEdges(graph, subNode, visited);
        }

        return count;
    }
}