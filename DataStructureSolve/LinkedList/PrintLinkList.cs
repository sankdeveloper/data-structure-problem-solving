using ConsoleApp1.LinkedList.shared;

namespace ConsoleApp1.LinkedList;

public class PrintLinkList
{
    public static void Main1(string[] args)
    {
        ListNode list1 = new(1);
        list1.Next = new(3);
        list1.Next.Next = new(5);

        Print(list1);

        List<int> values = new();
        FillValuesIntoList(list1, values);

        Console.WriteLine("Reverse: ");
        list1 = Reverse(list1);
        Print(list1);

        Console.WriteLine("Total Sum: " + Sum(list1));

        Console.WriteLine("Found 3: " + Find(list1, 3));
        Console.WriteLine("Found 30: " + Find(list1, 30));

        Console.WriteLine(string.Join("\n", values));
        Console.ReadKey();
    }

    private static ListNode? Reverse(ListNode? head)
    {
        ListNode previous = null;
        var current = head;
        while (current != null)
        {
            var next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        return previous;
    }

    private static bool Find(ListNode? head, int search)
    {
        if (head == null) return false;
        if (head.Value == search) return true;
        return Find(head.Next, search);
    }

    private static int Sum(ListNode? head)
    {
        if (head == null) return 0;
        return head.Value + Sum(head.Next);
    }

    private static void FillValuesIntoList(ListNode? head, List<int> values)
    {
        if (head == null) return;

        values.Add(head.Value);
        FillValuesIntoList(head.Next, values);
    }

    private static void Print(ListNode? head)
    {
        if (head == null) return;

        Console.WriteLine(head.Value);
        Print(head.Next);
    }
}