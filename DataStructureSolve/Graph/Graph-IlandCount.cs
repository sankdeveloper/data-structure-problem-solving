namespace ConsoleApp1.Graph;

// https://structy.net/problems/island-count
public class Graph_IlandCount
{
    public static void Main1(string[] args)
    {
        char[][] graph =
        {
            new[] { 'W', 'L', 'W', 'W', 'W' },
            new[] { 'W', 'L', 'W', 'W', 'W' },
            new[] { 'W', 'W', 'W', 'L', 'W' },
            new[] { 'W', 'W', 'L', 'L', 'W' },
            new[] { 'L', 'W', 'W', 'L', 'L' },
            new[] { 'L', 'L', 'W', 'W', 'W' },
        };
        int landCount = CountLands(graph);
        Console.WriteLine(landCount);
    }

    private static int CountLands(char[][] graph)
    {
        int count = 0;
        HashSet<string> visited = new();
        for (int row = 0; row < graph.Length; row++)
        {
            for (int col = 0; col < graph[0].Length; col++)
            {
                if (TraverseLand(graph, row, col, visited))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static bool TraverseLand(char[][] graph, int row, int col, HashSet<string> visited)
    {
        if (row < 0 || row >= graph.Length) return false;
        if (col < 0 || col >= graph[0].Length) return false;
        if (graph[row][col] == 'W') return false;

        var node = $"{row}_{col}";
        if (visited.Contains(node)) return false;
        visited.Add(node);

        TraverseLand(graph, row - 1, col, visited);
        TraverseLand(graph, row + 1, col, visited);
        TraverseLand(graph, row, col - 1, visited);
        TraverseLand(graph, row, col + 1, visited);

        return true;
    }
}