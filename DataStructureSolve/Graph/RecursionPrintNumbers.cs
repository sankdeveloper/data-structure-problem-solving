namespace ConsoleApp1.Graph;

public class RecursionPrintNumbers
{
    static void Main0(string[] args)
    {
        PrintNumbers(5);
        Console.ReadKey();
    }

    private static void PrintNumbers(int number, bool ascending = true)
    {
        if (number == 0)
            return;

        if(!ascending) 
            Console.WriteLine(number);

        PrintNumbers(number-1, ascending);
        
        if(ascending) 
            Console.WriteLine(number);
    }
}