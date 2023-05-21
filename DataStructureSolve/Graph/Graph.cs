namespace ConsoleApp1.Graph;

class Program
{
    static bool DFS(int[,] matrix, int matrixSize, int rowNum, int colNum, bool[,] visitedArr,
        List<Tuple<int, int>> answer)
    {
        // If out of bounds, return false
        if (rowNum < 0 || colNum < 0 || rowNum >= matrixSize || colNum >= matrixSize)
        {
            return false;
        }

        // If the current cell is blocked, return false
        if (matrix[rowNum, colNum] == -1)
            return false;

        // if visited, return false
        if (visitedArr[rowNum, colNum])
            return false;

        visitedArr[rowNum, colNum] = true;
        answer.Add(new Tuple<int, int>(rowNum, colNum));

        // If we've reached the bottom right cell, return true
        if (rowNum == matrixSize - 1 && colNum == matrixSize - 1)
        {
            return true;
        }

        bool canGoDown = DFS(matrix, matrixSize, rowNum + 1, colNum, visitedArr, answer);
        bool canGoUp = DFS(matrix, matrixSize, rowNum - 1, colNum, visitedArr, answer);
        bool canGoRight = DFS(matrix, matrixSize, rowNum, colNum + 1, visitedArr, answer);
        bool canGoLeft = DFS(matrix, matrixSize, rowNum, colNum - 1, visitedArr, answer);

        if (canGoDown || canGoUp || canGoRight || canGoLeft)
        {
            return true;
        }

        answer.RemoveAt(answer.Count - 1);
        return false;
    }

    static void Main1(string[] args)
    {
        int[,] graph =
        {
            { 0, 0, 0, -1, 0 },
            { -1, 0, 0, -1, -1 },
            { 0, 0, 0, -1, 0 },
            { -1, 0, 0, 0, 0 },
            { 0, 0, -1, 0, 0 }
        };

        int graphSize = graph.GetLength(0);
        bool[,] visitedArr = new bool[graphSize, graphSize];
        List<Tuple<int, int>> answer = new();

        bool foundPath = DFS(graph, graphSize, 0, 0, visitedArr, answer);

        if (foundPath)
        {
            Console.WriteLine("Path found:");
            foreach (var node in answer)
            {
                Console.WriteLine($"({node.Item1}, {node.Item2})");
            }
        }
        else
        {
            Console.WriteLine("No path found.");
        }

        Console.ReadKey();
    }
}