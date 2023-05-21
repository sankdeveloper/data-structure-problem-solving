namespace ConsoleApp1;

public class TestRND
{
    public static void Main1(string[] args)
    {
        Dictionary<char, char[]> graph = new Dictionary<char, char[]>
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

// adjucency matrix convert
// int[][] data = new int[][] {
//     new int[] { 1, 3 },
//     new int[] { 2, 3 },
//     new int[] { 3, 1 }
// };
//
// Dictionary<int, HashSet<int>> adjacencyList = new();
// foreach(var point in data){
//     var from = point[0];
//     var to = point[1];
//     
//     if(!adjacencyList.ContainsKey(from))
//         adjacencyList.Add(from, new HashSet<int>());
//     
//     adjacencyList[from].Add(to);
// }
//
// Console.Write(adjacencyList);