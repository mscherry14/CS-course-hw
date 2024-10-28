namespace Task5LinkedListsIntersection;

public class SingleLinkedListsIntersection<T>
{
    public static ListNode<T>? FindIntersection(ListNode<T>? list1, ListNode<T>? list2)
    {
        if (list1 is null || list2 is null) { return null; }
        
        var lengthA = GetListNodeLength(list1);
        var lengthB = GetListNodeLength(list2);
        var list1P = list1;
        var list2P = list2;
        
        while (lengthA > lengthB)
        {
            list1P = list1P!.Next;
            lengthA--;
        }

        while (lengthB > lengthA)
        {
            list2P = list2P!.Next;
            lengthB--;
        }
        
        while (list1P != list2P)
        {
            list1P = list1P!.Next;
            list2P = list2P!.Next;
        }

        return list1P;
    }
    
    private static int GetListNodeLength(ListNode<T>? node)
    {
        var length = 0;

        while (node != null)
        {
            node = node.Next;
            length++;
        }

        return length;
    }
}