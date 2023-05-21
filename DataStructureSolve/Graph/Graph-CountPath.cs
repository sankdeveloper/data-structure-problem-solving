namespace ConsoleApp1.Graph;

public class Graph_CountPath
{
    public static void Main1(string[] args)
    {
        int[,] graph = new int[2, 4];
        int count = CountPossiblePaths(graph, 0, 0);
        Console.WriteLine(count);
        Console.ReadKey();
    }

    private static int CountPossiblePaths(int[,] graph, int startRow, int startCol)
    {
        if (startRow < 0 || startRow > graph.GetLength(0) - 1) return 0;
        if (startCol < 0 || startCol > graph.GetLength(1) - 1) return 0;

        (int Row, int Col) lastCell = (graph.GetLength(0) - 1, graph.GetLength(1) - 1);
        if (startRow == lastCell.Row && startCol == lastCell.Col) return 1;

        int countRight = CountPossiblePaths(graph, startRow, startCol + 1);
        int countBtm = CountPossiblePaths(graph, startRow + 1, startCol);

        return countBtm + countRight;
    }
}