using System.Collections;

namespace Task5Matrix;

public class SparseMatrix2D<T> : IEnumerable<T>
{
    private readonly Dictionary<(int, int), T> _data = new();

    public T this[int i, int j]
    {
        get => _data.TryGetValue((i, j), out var value) ? value : default;
        set
        {
            if (value == null)
            {
                _data.Remove((i, j));
            }
            else
            {
                _data[(i, j)] = value;
            }
        }
    }

    public int Count => _data.Count;

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var value in _data.Values)
        {
            yield return value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<((int, int), T)> EnumerateWithIndices()
    {
        foreach (var kvp in _data)
        {
            yield return (kvp.Key, kvp.Value);
        }
    }
}