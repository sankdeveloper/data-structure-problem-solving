namespace ConsoleApp1.LinkedList.shared;

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