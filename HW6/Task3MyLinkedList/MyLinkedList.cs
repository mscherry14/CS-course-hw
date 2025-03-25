using System.Collections;

namespace Task3MyLinkedList;


public class MyLinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node? Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node? _head; 
    private Node? _tail;
    private int _count; 

    public int Count => _count; 

    public MyLinkedList()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public void Add(T value)
    {
        var newNode = new Node(value);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            _tail = newNode;
        }

        _count++;
    }

    public bool Remove(T value)
    {
        if (_head == null)
        {
            return false; 
        }

        if (_head.Value.Equals(value))
        {
            _head = _head.Next;
            if (_head == null)
            {
                _tail = null; 
            }
            _count--;
            return true;
        }

        var current = _head;
        while (current.Next != null)
        {
            if (current.Next.Value.Equals(value))
            {
                current.Next = current.Next.Next;
                if (current.Next == null)
                {
                    _tail = current;
                }
                _count--;
                return true;
            }
            current = current.Next;
        }

        return false; 
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}