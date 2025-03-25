namespace Task1FrogAndLake;

using System.Collections;

public class Lake : IEnumerable<int>
{
    private readonly List<int> _stones;

    public Lake(IEnumerable<int> stones)
    {
        _stones = new List<int>(stones);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < _stones.Count; i++)
        {
            if (_stones[i] % 2 != 0)
            {
                yield return _stones[i];
            }
        }

        for (int i = _stones.Count - 1; i >= 0; i--)
        {
            if (_stones[i] % 2 == 0)
            {
                yield return _stones[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}