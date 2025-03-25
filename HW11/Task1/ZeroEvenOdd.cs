namespace Task1;

public class ZeroEvenOdd
{
    private int n;
    private ManualResetEventSlim zeroEvent = new ManualResetEventSlim(true);
    private ManualResetEventSlim evenEvent = new ManualResetEventSlim(false);
    private ManualResetEventSlim oddEvent = new ManualResetEventSlim(false);

    public ZeroEvenOdd(int n)
    {
        this.n = n;
    }

    public void Zero(Action<int> printNumber)
    {
        for (int i = 1; i <= n; i++)
        {
            zeroEvent.Wait();
            printNumber(0);
            zeroEvent.Reset();

            if (i % 2 == 1)
                oddEvent.Set();
            else
                evenEvent.Set();
        }
    }

    public void Even(Action<int> printNumber)
    {
        for (int i = 2; i <= n; i += 2)
        {
            evenEvent.Wait();
            printNumber(i);
            evenEvent.Reset();
            zeroEvent.Set();
        }
    }

    public void Odd(Action<int> printNumber)
    {
        for (int i = 1; i <= n; i += 2)
        {
            oddEvent.Wait();
            printNumber(i);
            oddEvent.Reset();
            zeroEvent.Set();
        }
    }
}

