namespace Task3;

public class NarrowBridge
{
    private int northboundCount = 0;
    private int southboundCount = 0;
    private readonly object lockObj = new object();
    private readonly SemaphoreSlim bridgeSemaphore = new SemaphoreSlim(1, 1);

    public void EnterFromNorth()
    {
        lock (lockObj)
        {
            while (southboundCount > 0 || northboundCount > 0)
            {
                Monitor.Wait(lockObj);
            }
            northboundCount++;
        }
        bridgeSemaphore.Wait();
    }

    public void ExitToNorth()
    {
        lock (lockObj)
        {
            northboundCount--;
            if (northboundCount == 0)
            {
                Monitor.PulseAll(lockObj);
            }
        }
        bridgeSemaphore.Release();
    }

    public void EnterFromSouth()
    {
        lock (lockObj)
        {
            while (northboundCount > 0 || southboundCount > 0)
            {
                Monitor.Wait(lockObj);
            }
            southboundCount++;
        }
        bridgeSemaphore.Wait();
    }

    public void ExitToSouth()
    {
        lock (lockObj)
        {
            southboundCount--;
            if (southboundCount == 0)
            {
                Monitor.PulseAll(lockObj);
            }
        }
        bridgeSemaphore.Release();
    }
}