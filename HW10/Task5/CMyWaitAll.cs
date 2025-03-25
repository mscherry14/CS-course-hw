namespace Task5;

public class CMyWaitAll : IDisposable
{
    private readonly ManualResetEvent[] _atoms;
    private readonly object _lock = new object();
    private int _signaledCount;

    public CMyWaitAll(int atomsNumber)
    {
        if (atomsNumber < 0)
            throw new ArgumentOutOfRangeException(nameof(atomsNumber), "The number of atoms cannot be negative.");

        _atoms = new ManualResetEvent[atomsNumber];
        for (int i = 0; i < atomsNumber; i++)
        {
            _atoms[i] = new ManualResetEvent(false);
        }

        _signaledCount = 0;
    }

    public void SetAtomSignaled(int atomId)
    {
        if (atomId < 0 || atomId >= _atoms.Length)
            throw new ArgumentOutOfRangeException(nameof(atomId), "Invalid atom ID.");

        lock (_lock)
        {
            if (!_atoms[atomId].WaitOne(0))
            {
                _atoms[atomId].Set();
                _signaledCount++;

                if (_signaledCount == _atoms.Length)
                {
                    foreach (var atom in _atoms)
                    {
                        atom.Set();
                    }
                }
            }
        }
    }

    public bool Wait(TimeSpan timeout)
    {
        var waitHandles = new WaitHandle[_atoms.Length];
        for (int i = 0; i < _atoms.Length; i++)
        {
            waitHandles[i] = _atoms[i];
        }

        return WaitHandle.WaitAll(waitHandles, timeout);
    }

    public void Dispose()
    {
        foreach (var atom in _atoms)
        {
            atom.Dispose();
        }
    }
}
