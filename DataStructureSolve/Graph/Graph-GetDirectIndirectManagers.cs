namespace ConsoleApp1.Graph;

public class Graph_GetDirectIndirectManagers
{
    public static void Main1(string[] args)
    {
        Dictionary<char, char[]> graph = new()
        {
            { 'F', new char[] { 'C' } },
            { 'G', new char[] { 'C' } },
            { 'C', new char[] { 'A' } },
            { 'B', new char[] { 'A' } },
            { 'D', new char[] { 'B' } },
            { 'E', new char[] { 'B' } },
            { 'X', new char[] { 'D' } },
            { 'Y', new char[] { 'E' } }
        };

        var managers = GetAllDirectIndirectManagers(graph, 'X');
        var managers2 = GetAllDirectIndirectManagers(graph, 'Y');
        Console.WriteLine();

    }

    private static List<char> GetAllDirectIndirectManagers(Dictionary<char, char[]> graph, char emp)
    {
        List<char> managers = new();
        if (!graph.ContainsKey(emp)) return managers;
        managers.AddRange(graph[emp]);
        
        foreach (var manager in graph[emp])
        {
            var mngrs = GetAllDirectIndirectManagers(graph, manager);
            managers.AddRange(mngrs);
        }

        return managers;
    }
}