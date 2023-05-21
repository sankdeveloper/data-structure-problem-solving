namespace ConsoleApp1.Graph;

public class NumberOfPaths
{
    static void Main2(string[] args)
    {
        Console.WriteLine(NumberOfPathsFunction(3,3));
        Console.ReadKey();
    }

    private static int NumberOfPathsFunction(int m, int n)
    {
        if (m == 1 || n == 1)
            return 1;

        int numWays1 = NumberOfPathsFunction(m-1, n);
        int numWays2 = NumberOfPathsFunction(m, n-1);

        return numWays1 + numWays2;
    }
}