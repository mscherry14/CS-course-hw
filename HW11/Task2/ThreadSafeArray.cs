namespace Task2;

public class ThreadSafeArray
{
    private int[] array;
    private ReaderWriterLockSlim lockSlim = new ReaderWriterLockSlim();

    public ThreadSafeArray(int[] initialArray)
    {
        array = initialArray.ToArray(); 
    }

    public int FindMin()
    {
        lockSlim.EnterReadLock();
        try
        {
            return array.Min();
        }
        finally
        {
            lockSlim.ExitReadLock();
        }
    }

    public double FindAverage()
    {
        lockSlim.EnterReadLock();
        try
        {
            return array.Average();
        }
        finally
        {
            lockSlim.ExitReadLock();
        }
    }

    public void Sort()
    {
        lockSlim.EnterWriteLock();
        try
        {
            Array.Sort(array);
        }
        finally
        {
            lockSlim.ExitWriteLock();
        }
    }

    public void SwapRandomElements()
    {
        lockSlim.EnterWriteLock();
        try
        {
            Random random = new Random();
            int index1 = random.Next(array.Length);
            int index2 = random.Next(array.Length);

            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
        finally
        {
            lockSlim.ExitWriteLock();
        }
    }
}