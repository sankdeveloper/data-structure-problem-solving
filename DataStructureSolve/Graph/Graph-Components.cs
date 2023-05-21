namespace ConsoleApp1.Graph;

public class GraphComponents
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
        Console.WriteLine(PrintNumberOfComponents(graph));
        Console.ReadKey();
    }

    private static int PrintNumberOfComponents(Dictionary<int,int[]> graph)
    {
        int count = 0;
        HashSet<int> visited = new();
        foreach (int node in graph.Select(_=>_.Key))
        {
            if(VisitAllNodes(graph, node, visited)) count++;
        }

        return count;
    }

    private static bool VisitAllNodes(Dictionary<int, int[]> graph, int node, HashSet<int> visited)
    {
        if(visited.Contains(node)) return false;
        visited.Add(node);
        if(!graph.ContainsKey(node)) return false;
        foreach (var subNodes in graph[node])
        {
            VisitAllNodes(graph, subNodes, visited);
        }
        return true;
    }
}