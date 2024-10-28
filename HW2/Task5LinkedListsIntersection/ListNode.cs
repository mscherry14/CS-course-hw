namespace Task5LinkedListsIntersection;

public class ListNode<T>
{
    public ListNode()
    {
        Next = null;
        Data = default(T);
    }

    public ListNode(T? dataItem)
    {
        Next = null;
        Data = dataItem;
    }

    public ListNode(ListNode<T>? next, T dataItem)
    {
        Next = next;
        Data = dataItem;
    }
    
    public T? Data { get; set; }
    public ListNode<T>? Next { get; set; }
}