namespace Task3PseudoStack;

public class PseudoStack<T>
{
    private readonly List<Stack<T>> _stacks;
    private readonly int _maxStackSize; 

    public PseudoStack(int maxStackSize)
    {
        if (maxStackSize <= 0)
        {
            throw new ArgumentException("Максимальный размер стека должен быть больше 0.");
        }

        _stacks = new List<Stack<T>>();
        _maxStackSize = maxStackSize;

        _stacks.Add(new Stack<T>());
    }

    public void Push(T value)
    {
        Stack<T> currentStack = _stacks[_stacks.Count - 1];

        if (currentStack.Count >= _maxStackSize)
        {
            currentStack = new Stack<T>();
            _stacks.Add(currentStack);
        }

        currentStack.Push(value);
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Стек пуст.");
        }

        var currentStack = _stacks[_stacks.Count - 1];

        var value = currentStack.Pop();

        if (currentStack.Count == 0 && _stacks.Count > 1)
        {
            _stacks.RemoveAt(_stacks.Count - 1);
        }

        return value;
    }

    public bool IsEmpty()
    {
        return _stacks.Count == 1 && _stacks[0].Count == 0;
    }

    public int Count
    {
        get
        {
            int totalCount = 0;
            foreach (var stack in _stacks)
            {
                totalCount += stack.Count;
            }
            return totalCount;
        }
    }
}