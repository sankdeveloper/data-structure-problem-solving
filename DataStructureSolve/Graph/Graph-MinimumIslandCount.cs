namespace ConsoleApp1.Graph;

public class Graph_MinimumIslandCount
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
        int landCount = CountLandThatHasMinCount(graph);
        Console.WriteLine(landCount);
        Console.ReadKey();
    }

    private static int CountLandThatHasMinCount(char[][] graph)
    {
        HashSet<string> visited = new();
        int minLandCount = Int32.MaxValue;
        for (var row = 0; row < graph.Length; row++)
        {
            for (int col = 0; col < graph[0].Length; col++)
            {
                int count = TraverseLand(graph, row, col, visited);
                if (minLandCount > count && count > 0) minLandCount = count;
            }
        }

        return minLandCount;
    }

    private static int TraverseLand(char[][] graph, int row, int col, HashSet<string> visited)
    {
        if(row < 0 || row >= graph.Length) return 0;
        if(col < 0 || col >= graph[0].Length) return 0;

        var node = $"{row}_{col}";
        if (visited.Contains(node)) return 0;
        visited.Add(node);
        
        if (graph[row][col] == 'W') return 0;

        int traverseUp = TraverseLand(graph, row-1, col, visited);
        int traverseDown = TraverseLand(graph, row+1, col, visited);
        int traverseLeft = TraverseLand(graph, row, col-1, visited);
        int traverseRight = TraverseLand(graph, row, col+1, visited);

        return 1 + traverseUp + traverseDown + traverseLeft + traverseRight;
    }
}