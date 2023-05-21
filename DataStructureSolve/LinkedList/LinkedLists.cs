namespace ConsoleApp1.LinkedList;

public class ListNode
{
    public readonly int Value;
    public ListNode? Next;

    public ListNode(int value = 0, ListNode? next = null)
    {
        this.Value = value;
        this.Next = next;
    }
}

public class Program
{
    public static void Main0(string[] args)
    {
        // Example linked lists
        ListNode? list1 = new(1);
        list1.Next = new(3);
        list1.Next.Next = new(5);

        ListNode? list2 = new(2);
        list2.Next = new(4);
        list2.Next.Next = new(6);

        // Merge the lists
        ListNode? mergedList = MergeTwoLists(list1, list2);

        // Print the merged list
        PrintList(mergedList);
    }

    public static ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        if (list1 == null)
            return list2;
        if (list2 == null)
            return list1;

        if (list1.Value < list2.Value)
        {
            list1.Next = MergeTwoLists(list1.Next, list2);
            return list1;
        }
        else
        {
            list2.Next = MergeTwoLists(list1, list2.Next);
            return list2;
        }
    }

    public static void PrintList(ListNode? head)
    {
        ListNode? current = head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
        Console.ReadKey();
    }
}
