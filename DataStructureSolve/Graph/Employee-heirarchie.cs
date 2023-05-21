namespace ConsoleApp1.Graph;

// public class SpiralMatrixGraph
// {
//     public static void Main(string[] args)
//     {
//         int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
//     }
//
//     public IList<int> SpiralOrder(int[][] matrix)
//     {
//         throw new NotImplementedException();
//     }
// }


public class Program3
{
    public static void Main1(string[] args)
    {
        Dictionary<string, string> employeeManagerPairs = new Dictionary<string, string>()
        {
            { "A", "C" },
            { "B", "C" },
            { "D", "A" },
            { "E", "B" },
        };
        List<string> result = new();
        string manager = "C";

        CalculateRecursively(employeeManagerPairs, manager, result);
        List<string> employeesReportingToManager = GetEmployeesReportingToManager(employeeManagerPairs, manager);

        Console.WriteLine($"Employees reporting to {manager}:");
        foreach (string employee in employeesReportingToManager)
        {
            Console.WriteLine(employee);
        }
    }

    private static void CalculateRecursively(Dictionary<string, string> employeeManagerPairs, string manager, List<string> result)
    {
        var employees = employeeManagerPairs.Where(x => x.Value == manager).Select(_=>_.Key).ToList();
        result.AddRange(employees);
        foreach (var emp in employees)
        {
            CalculateRecursively(employeeManagerPairs, emp, result);
        }
    }

    public static List<string> GetEmployeesReportingToManager(Dictionary<string, string> employeeManagerPairs, string manager)
    {
        List<string> employeesReportingToManager = employeeManagerPairs
            .Where(pair => pair.Value == manager)
            .Select(pair => pair.Key)
            .ToList();

        return employeesReportingToManager;
    }
}
