namespace Task5;

using System;
using System.Threading;

public class CMyCountdownEvent : IDisposable
{
    private int _count; 
    private readonly ManualResetEvent _event;
    private readonly object _lock = new object();

    public CMyCountdownEvent(int initialCount)
    {
        if (initialCount < 0)
            throw new ArgumentOutOfRangeException(nameof(initialCount), "Initial count cannot be negative.");

        _count = initialCount;
        _event = new ManualResetEvent(_count == 0);
    }

    public void Signal()
    {
        Signal(1);
    }

    public void Signal(int signalCount)
    {
        if (signalCount < 1)
            throw new ArgumentOutOfRangeException(nameof(signalCount), "Signal count must be positive.");

        lock (_lock)
        {
            if (_count == 0)
                throw new InvalidOperationException("CountdownEvent has already reached zero.");

            if (signalCount > _count)
                throw new InvalidOperationException("Signal count exceeds the remaining count.");

            _count -= signalCount;

            if (_count == 0)
                _event.Set();
        }
    }

    public bool Wait(TimeSpan timeout)
    {
        return _event.WaitOne(timeout);
    }

    public void Dispose()
    {
        _event.Dispose();
    }
}