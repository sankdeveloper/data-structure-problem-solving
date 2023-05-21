namespace ConsoleApp1.Graph;

public class Graph1
{
    public static void Main1(string[] args)
    {
        Dictionary<int, int[]> graph = new()
        {
            { 1, new[] { 2, 3, 4 } },
            { 2, new[] { 5 } },
            { 5, new[] { 6, 7, 8 } },
            { 8, new[] { 4 } },
        };
        
        List<int> result = new();
        BFS(graph, 1,result);
        
        result.ForEach(Console.WriteLine);
        Console.WriteLine();

        
        // Console.WriteLine(DFS(graph, 1, 8));
        Console.ReadKey();
    }

    private static List<int> BFS(Dictionary<int, int[]> graph, int start, List<int> result)
    {
        Queue<int> queue = new();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int last = queue.Dequeue();
            result.Add(last);
            if (!graph.ContainsKey(last)) continue;
            foreach (var node in graph[last])
            {
                queue.Enqueue(node);
            }
        }

        return result;
    }

    private static bool DFS(Dictionary<int, int[]> graph, int start, int search)
    {
        if (start == search) return true;
        if (!graph.ContainsKey(start)) return false;
        foreach (var node in graph[start])
        {
            if (DFS(graph, node, search))
            {
                return true;
            }
        }

        return false;
    }
}