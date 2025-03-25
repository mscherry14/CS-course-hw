namespace Task2;

public class ShowerRoom
{
    private int maleCount = 0;
    private int femaleCount = 0; 
    private readonly object lockObj = new object(); 

    public void MaleEnters()
    {
        lock (lockObj)
        {
            while (femaleCount > 0)
            {
                Monitor.Wait(lockObj);
            }
            maleCount++; 
        }
    }

    public void MaleExits()
    {
        lock (lockObj)
        {
            maleCount--;
            if (maleCount == 0)
            {
                Monitor.PulseAll(lockObj);
            }
        }
    }

    public void FemaleEnters()
    {
        lock (lockObj)
        {
            while (maleCount > 0)
            {
                Monitor.Wait(lockObj);
            }
            femaleCount++;
        }
    }

    public void FemaleExits()
    {
        lock (lockObj)
        {
            femaleCount--; 
            if (femaleCount == 0)
            {
                Monitor.PulseAll(lockObj);
            }
        }
    }
}